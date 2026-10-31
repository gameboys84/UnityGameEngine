using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DE.Infrastructure
{
    public sealed class LegacyPackEntry
    {
        public string Name { get; } public int Offset { get; } public int Length { get; }
        internal LegacyPackEntry(string name, int offset, int length) { Name = name; Offset = offset; Length = length; }
    }
    // Read-only implementation of the original PackUtility index, with bounded independent entry streams.
    // Source encryption parameters must be supplied by the importer; they are not embedded into product code.
    public sealed class LegacyPackReader : IDisposable
    {
        private readonly Stream source;
        private readonly bool leaveOpen;
        private readonly Dictionary<string, LegacyPackEntry> entries = new Dictionary<string, LegacyPackEntry>(StringComparer.Ordinal);
        public LegacyPackEntry[] Entries { get { var result = new LegacyPackEntry[entries.Count]; entries.Values.CopyTo(result, 0); return result; } }
        public LegacyPackReader(Stream source, bool leaveOpen = false)
        {
            if (source == null || !source.CanRead || !source.CanSeek) throw new ArgumentException("A readable seekable pack stream is required.");
            this.source = source; this.leaveOpen = leaveOpen;
            source.Position = 0;
            using (var reader = new BinaryReader(source, new UTF8Encoding(false, true), true))
            {
                int count = reader.ReadInt32();
                if (count < 0 || count > 100000) throw new InvalidDataException("Pack entry count is out of bounds.");
                for (int i = 0; i < count; i++)
                {
                    reader.ReadInt32(); int offset = reader.ReadInt32(), length = reader.ReadInt32(), nameLength = reader.ReadInt32();
                    if (nameLength < 1 || nameLength > 4096 || nameLength > source.Length - source.Position) throw new InvalidDataException("Invalid pack name length.");
                    string path = new UTF8Encoding(false, true).GetString(reader.ReadBytes(nameLength));
                    string name = Path.GetFileName(path.Replace('\\', '/'));
                    if (string.IsNullOrEmpty(name) || offset < 0 || length < 0 || length > 64 * 1024 * 1024 || offset > source.Length - length)
                        throw new InvalidDataException("Invalid pack entry bounds.");
                    if (entries.ContainsKey(name)) throw new InvalidDataException("Ambiguous pack entry name: " + name);
                    entries.Add(name, new LegacyPackEntry(name, offset, length));
                }
                long indexEnd = source.Position;
                var sorted = Entries; Array.Sort(sorted, (a, b) => a.Offset.CompareTo(b.Offset));
                long previousEnd = indexEnd;
                foreach (var entry in sorted)
                {
                    if (entry.Offset < previousEnd) throw new InvalidDataException("Pack data overlaps index or another entry.");
                    previousEnd = (long)entry.Offset + entry.Length;
                }
            }
        }
        public byte[] Read(string name)
        {
            if (!entries.TryGetValue(name, out var entry)) throw new FileNotFoundException("Pack entry not found.", name);
            var data = new byte[entry.Length]; source.Position = entry.Offset;
            int done = 0;
            while (done < data.Length) { int count = source.Read(data, done, data.Length - done); if (count == 0) throw new EndOfStreamException(); done += count; }
            return data;
        }
        public string ReadEncryptedJson(string name, byte[] key, byte[] iv)
        {
            var data = Read(name);
            using (var aes = Aes.Create())
            {
                aes.Key = key; aes.IV = iv; aes.Mode = CipherMode.CBC; aes.Padding = PaddingMode.PKCS7;
                using (var decryptor = aes.CreateDecryptor())
                {
                    var plain = decryptor.TransformFinalBlock(data, 0, data.Length);
                    return new UTF8Encoding(false, true).GetString(plain).TrimEnd('\0');
                }
            }
        }
        public void Dispose() { if (!leaveOpen) source.Dispose(); }
    }
}
