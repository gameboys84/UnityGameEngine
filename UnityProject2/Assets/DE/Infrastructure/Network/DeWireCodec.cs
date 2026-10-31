using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Scpp;

namespace DE.Infrastructure.Network
{
    public static class DeWireCodec
    {
        private static readonly object initializationLock = new object();
        private static bool initialized;
        public const int MaximumBodyLength = 8 * 1024 * 1024;
        public static void Initialize()
        {
            lock (initializationLock)
            {
                if (initialized) return;
                CPool.Reset(); CPool.Init(Protocol.MVC); Protocol.BindVc(); initialized = true;
            }
        }
        public static uint DerivePikeKey(uint key1, uint key2)
        {
            // Exact NetSession.InitPike derivation; signed Int64 shifts matter for the source contract.
            long token = ((long)key1 << 32) | key2;
            uint u1 = (uint)(token >> 3) & 0xff, u2 = (uint)(token >> 23) & 0xff;
            uint u3 = (uint)(token >> 37) & 0xff, u4 = (uint)(token >> 47) & 0xff;
            return (u1 << 24) | (u3 << 16) | (u2 << 8) | u4;
        }
        public static byte[] EncodeBody(Protocol.MsgType type, NetworkMessage message, short nodeId = 0)
        {
            Initialize();
            var pack = new SPack { buf = new byte[256], offset = 0 };
            pack.Write((ushort)nodeId); pack.Write((ushort)type);
            if (message != null) { InitializeNullFields(message, new HashSet<object>(), 0); message.Encode(pack); }
            if (pack.offset < 4 || pack.offset > MaximumBodyLength) throw new InvalidDataException("DE packet body length is invalid.");
            Array.Resize(ref pack.buf, pack.offset); return pack.buf;
        }
        public static byte[] FrameBody(byte[] body)
        {
            if (body == null || body.Length < 4 || body.Length > MaximumBodyLength) throw new InvalidDataException("DE packet body length is invalid.");
            int header = body.Length < ushort.MaxValue ? 2 : 6;
            var frame = new byte[header + body.Length]; int position = 0;
            NetworkSerialization.Write(ref frame, ref position, (ushort)(header == 2 ? body.Length : ushort.MaxValue));
            if (header == 6) NetworkSerialization.Write(ref frame, ref position, body.Length);
            Buffer.BlockCopy(body, 0, frame, header, body.Length); return frame;
        }
        public static NetworkMessage DecodeBody(byte[] body, out Protocol.MsgType type)
        {
            Initialize();
            if (body == null || body.Length < 4 || body.Length > MaximumBodyLength) throw new InvalidDataException("DE packet body length is invalid.");
            int offset = 0; int node = NetworkSerialization.ReadUInt16(body, ref offset);
            if (node > 10000) node -= 10000;
            type = (Protocol.MsgType)NetworkSerialization.ReadUInt16(body, ref offset);
            var message = Protocol.CreateMessage(type);
            if (message == null) message = new UnknownProtocolMessage(body);
            message.SetMessageType(type); message.m_nodId = node;
            var pack = new SPack { buf = body, offset = offset };
            if (!(message is UnknownProtocolMessage))
            {
                // Known payloads must decode even when the body is header-only; never manufacture default UserInfo/Time.
                // The original Int16 reader logs and returns zero on truncation. Convert that codec-local error to failure.
                bool previousStrict = DLog.StrictCodecRead; DLog.StrictCodecRead = true;
                try { message.Decode(pack); }
                finally { DLog.StrictCodecRead = previousStrict; }
            }
            if (pack.offset > body.Length) throw new InvalidDataException("DE payload decoder exceeded packet bounds.");
            return message;
        }
        internal static byte[] Decompress(byte[] body, bool fourByteLength)
        {
            int offset = 4;
            if (body.Length < offset + (fourByteLength ? 8 : 6)) throw new InvalidDataException("Compressed DE header is incomplete.");
            int originalLength = NetworkSerialization.ReadInt32(body, ref offset);
            int compressedLength = fourByteLength ? NetworkSerialization.ReadInt32(body, ref offset) : NetworkSerialization.ReadUInt16(body, ref offset);
            if (originalLength < 4 || originalLength > MaximumBodyLength || compressedLength < 1 || compressedLength != body.Length - offset)
                throw new InvalidDataException("Compressed DE length is invalid.");
            var decoded = LZ4ps.LZ4Codec.Decode64(body, offset, compressedLength, originalLength);
            if (decoded == null || decoded.Length != originalLength) throw new InvalidDataException("DE LZ4 length mismatch.");
            return decoded;
        }
        private static void InitializeNullFields(object value, HashSet<object> visited, int depth)
        {
            if (value == null || value is string || value.GetType().IsValueType || depth > 64 || !visited.Add(value)) return;
            if (value is IList list) { foreach (var item in list) InitializeNullFields(item, visited, depth + 1); return; }
            foreach (var field in value.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                var child = field.GetValue(value);
                if (child == null)
                {
                    if (field.FieldType == typeof(string)) field.SetValue(value, "");
                    else if (field.FieldType == typeof(byte[])) field.SetValue(value, new byte[0]);
                    else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>)) field.SetValue(value, Activator.CreateInstance(field.FieldType));
                    else if (typeof(NetworkMessage).IsAssignableFrom(field.FieldType) && field.Name != "m_IStubNetworkMessage")
                    { child = Activator.CreateInstance(field.FieldType); field.SetValue(value, child); }
                }
                InitializeNullFields(child, visited, depth + 1);
            }
        }
    }
    public sealed class UnknownProtocolMessage : NetworkMessage
    {
        private readonly byte[] body;
        internal UnknownProtocolMessage(byte[] body) { this.body = (byte[])body.Clone(); }
        public byte[] RawBody => (byte[])body.Clone();
    }
}
