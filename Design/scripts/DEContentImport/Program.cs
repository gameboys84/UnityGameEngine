using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using DE.Infrastructure;

internal static class Program
{
    private static readonly UTF8Encoding Utf8 = new UTF8Encoding(false, true);
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { WriteIndented = false };
    private static string Hash(byte[] bytes) => Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
    private static void Save(string path, object value) => File.WriteAllText(path, JsonSerializer.Serialize(value, JsonOptions), Utf8);

    public static void Main(string[] args)
    {
        if (args.Length != 2) throw new ArgumentException("Usage: DEContentImport <read-only DE source root> <new project's Assets/AssetBundle/DE/Data>");
        var source = Path.GetFullPath(args[0]); var output = Path.GetFullPath(args[1]);
        if (output.StartsWith(source + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("The source project must remain read-only.");
        Directory.CreateDirectory(Path.Combine(output, "Tables"));
        Directory.CreateDirectory(Path.Combine(output, "Languages"));
        var aesSource = File.ReadAllText(Path.Combine(source, "Assets/T4F-BJ-Lib/Common/File/AES.cs"));
        var key = Utf8.GetBytes(Regex.Match(aesSource, "return\\s+\"([^\"]+)\"").Groups[1].Value);
        var ivText = Regex.Match(aesSource, @"_key1\s*=\s*\{([^}]+)\}").Groups[1].Value;
        var iv = Regex.Matches(ivText, @"0x([0-9A-Fa-f]{2})").Cast<Match>().Select(m => byte.Parse(m.Groups[1].Value, NumberStyles.HexNumber)).ToArray();
        if (key.Length != 16 || iv.Length != 16) throw new InvalidDataException("Source encryption parameters could not be identified.");
        var gamePack = Path.Combine(source, "Assets/StreamingAssets/GameData/gameData.pack");
        var locPack = Path.Combine(source, "Assets/StreamingAssets/GameData/loc.pack");
        var tables = new List<object>(); var languages = new List<object>();
        using (var reader = new LegacyPackReader(File.OpenRead(gamePack)))
        {
            foreach (var entry in reader.Entries.OrderBy(e => e.Name, StringComparer.Ordinal))
            {
                var name = Path.GetFileNameWithoutExtension(entry.Name);
                if (!Regex.IsMatch(name, @"^[A-Za-z0-9_]+$")) throw new InvalidDataException("Unsafe table name: " + name);
                var json = reader.ReadEncryptedJson(entry.Name, key, iv);
                using (var document = JsonDocument.Parse(json, new JsonDocumentOptions { AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip }))
                {
                    var normalized = JsonSerializer.Serialize(document.RootElement, JsonOptions);
                    File.WriteAllText(Path.Combine(output, "Tables", name + ".json"), normalized, Utf8);
                    int count = document.RootElement.ValueKind == JsonValueKind.Object ? document.RootElement.EnumerateObject().Count() : document.RootElement.GetArrayLength();
                    int uniqueKeyCount = document.RootElement.ValueKind == JsonValueKind.Object ? document.RootElement.EnumerateObject().Select(p => p.Name).Distinct(StringComparer.Ordinal).Count() : count;
                    tables.Add(new { name, count, rawEntryCount = count, uniqueKeyCount, duplicatePolicy = "last-value-wins", sha256 = Hash(Utf8.GetBytes(normalized)) });
                }
            }
        }
        using (var reader = new LegacyPackReader(File.OpenRead(locPack)))
        {
            var keys = Strings(reader.Read("T_C.bin"));
            foreach (var entry in reader.Entries.OrderBy(e => e.Name, StringComparer.Ordinal))
            {
                var language = Path.GetFileNameWithoutExtension(entry.Name);
                if (language == "T_C") continue;
                if (!Regex.IsMatch(language, @"^[A-Za-z0-9_]+$")) throw new InvalidDataException("Unsafe language name.");
                var values = Strings(reader.Read(entry.Name));
                if (values.Length != keys.Length) throw new InvalidDataException("Language and key counts differ: " + language);
                var words = new Dictionary<string, string>(StringComparer.Ordinal);
                for (int i = 0; i < keys.Length; i++) words[keys[i]] = values[i];
                var json = JsonSerializer.Serialize(words, JsonOptions);
                File.WriteAllText(Path.Combine(output, "Languages", language + ".json"), json, Utf8);
                languages.Add(new { name = language, count = words.Count, sha256 = Hash(Utf8.GetBytes(json)) });
            }
        }
        Save(Path.Combine(output, "catalog.json"), new { format = 1, source = "DeadEmpire-DEV", gameDataSha256 = Hash(File.ReadAllBytes(gamePack)), localizationSha256 = Hash(File.ReadAllBytes(locPack)), tables, languages });
        Console.WriteLine(JsonSerializer.Serialize(new { tables = tables.Count, languages = languages.Count, output }));
    }

    private static string[] Strings(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes, false))
        using (var reader = new BinaryReader(stream, Utf8))
        {
            int count = reader.ReadInt32();
            if (count < 0 || count > 2000000) throw new InvalidDataException("Language entry count is invalid.");
            var result = new string[count];
            for (int i = 0; i < count; i++) result[i] = reader.ReadString();
            if (stream.Position != stream.Length) throw new InvalidDataException("Unexpected trailing language data.");
            return result;
        }
    }
}
