using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace DE.Infrastructure.Network
{
    // Transport owns one ordered Pike state per direction. It never drops or reorders protocol packets.
    public sealed class DeTcpSession : IDisposable
    {
        private readonly SemaphoreSlim sendLock = new SemaphoreSlim(1, 1);
        private readonly CancellationTokenSource lifetime = new CancellationTokenSource();
        private TcpClient socket;
        private NetworkStream stream;
        private Pike encrypt, decrypt;
        private bool disposed;
        private int started;
        private long receivedPackets, sentPackets, receivedBytes, sentBytes;
        public bool EncryptionActive => encrypt != null;
        public bool IsConnected => !disposed && socket != null && socket.Connected;
        public long ReceivedPackets => Interlocked.Read(ref receivedPackets);
        public long SentPackets => Interlocked.Read(ref sentPackets);
        public long ReceivedBytes => Interlocked.Read(ref receivedBytes);
        public long SentBytes => Interlocked.Read(ref sentBytes);
        // Raised on the transport's receive task. The owning connection marshals public notifications to Pump.
        public event Action<NetworkMessage, int> MessageReceived;
        public event Action<string> Disconnected;
        public async Task ConnectAsync(string host, int port, CancellationToken cancellationToken)
        {
            if (disposed) throw new ObjectDisposedException(nameof(DeTcpSession));
            if (Interlocked.Exchange(ref started, 1) != 0) throw new InvalidOperationException("Create a fresh transport for each connection attempt.");
            if (string.IsNullOrWhiteSpace(host) || port < 1 || port > 65535) throw new ArgumentException("Invalid gateway endpoint.");
            DeWireCodec.Initialize();
            socket = new TcpClient { NoDelay = true };
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(lifetime.Token, cancellationToken))
            {
                timeout.CancelAfter(TimeSpan.FromSeconds(5));
                using (timeout.Token.Register(() => socket.Close()))
                {
                    try { await socket.ConnectAsync(host, port).ConfigureAwait(false); }
                    catch { timeout.Token.ThrowIfCancellationRequested(); throw; }
                }
            }
            stream = socket.GetStream();
            _ = ReceiveLoopAsync();
        }
        public async Task SendAsync(Protocol.MsgType type, NetworkMessage message, short nodeId, CancellationToken cancellationToken)
        {
            if (disposed || stream == null) throw new InvalidOperationException("DE gateway is not connected.");
            byte[] body = DeWireCodec.EncodeBody(type, message, nodeId);
            using (var linked = CancellationTokenSource.CreateLinkedTokenSource(lifetime.Token, cancellationToken))
            {
                await sendLock.WaitAsync(linked.Token).ConfigureAwait(false);
                try
                {
                    // Length prefixes stay clear; node, protocol id and SPack body use the continuous Pike stream.
                    encrypt?.Codec(body, 0, body.Length);
                    byte[] frame = DeWireCodec.FrameBody(body);
                    await stream.WriteAsync(frame, 0, frame.Length, linked.Token).ConfigureAwait(false);
                    Interlocked.Increment(ref sentPackets); Interlocked.Add(ref sentBytes, frame.Length);
                }
                catch { Dispose(); throw; }
                finally { sendLock.Release(); }
            }
        }
        private async Task ReceiveLoopAsync()
        {
            try
            {
                while (!lifetime.IsCancellationRequested)
                {
                    byte[] header = await ReadExactAsync(2, lifetime.Token).ConfigureAwait(false);
                    int offset = 0, size = NetworkSerialization.ReadUInt16(header, ref offset);
                    int headerSize = 2;
                    if (size == ushort.MaxValue)
                    {
                        header = await ReadExactAsync(4, lifetime.Token).ConfigureAwait(false); offset = 0;
                        size = NetworkSerialization.ReadInt32(header, ref offset); headerSize += 4;
                    }
                    if (size < 4 || size > DeWireCodec.MaximumBodyLength) throw new InvalidDataException("Invalid gateway frame length.");
                    byte[] body = await ReadExactAsync(size, lifetime.Token).ConfigureAwait(false);
                    decrypt?.Codec(body, 0, body.Length);
                    Interlocked.Add(ref receivedBytes, size + headerSize);
                    ProcessBody(body, 0);
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception error)
            {
                if (!disposed) Disconnected?.Invoke("Gateway receive failed (" + error.GetType().Name + ").");
            }
            finally { Dispose(); }
        }
        private void ProcessBody(byte[] body, int depth)
        {
            if (depth > 4) throw new InvalidDataException("Excessive nested DE compression.");
            int offset = 2;
            Protocol.MsgType type = (Protocol.MsgType)NetworkSerialization.ReadUInt16(body, ref offset);
            if (type == Protocol.MsgType.COMPRESSED_NTF || type == Protocol.MsgType.COMPRESSED4B_NTF)
            { ProcessBody(DeWireCodec.Decompress(body, type == Protocol.MsgType.COMPRESSED4B_NTF), depth + 1); return; }
            NetworkMessage message = DeWireCodec.DecodeBody(body, out type);
            if (message is Protocol.SessionTokenInfo token)
            {
                // Must happen inside receive order before reading the next encrypted packet.
                if (token.m_key1 != 0 || token.m_key2 != 0)
                {
                    uint key = DeWireCodec.DerivePikeKey(token.m_key1, token.m_key2);
                    decrypt = new Pike(key); encrypt = new Pike(key);
                }
            }
            else if (message is Protocol.PvcInfo patch)
            { Scpp.CPool.Supply(patch.m_content); Protocol.BindVc(); }
            Interlocked.Increment(ref receivedPackets);
            MessageReceived?.Invoke(message, body.Length);
        }
        private async Task<byte[]> ReadExactAsync(int length, CancellationToken cancellationToken)
        {
            byte[] data = new byte[length]; int read = 0;
            while (read < length)
            {
                int count = await stream.ReadAsync(data, read, length - read, cancellationToken).ConfigureAwait(false);
                if (count == 0) throw new EndOfStreamException("Gateway closed the connection.");
                read += count;
            }
            return data;
        }
        public void Dispose()
        {
            if (disposed) return; disposed = true;
            lifetime.Cancel(); stream?.Dispose(); socket?.Close();
            MessageReceived = null; Disconnected = null;
            // Keep the semaphore alive until any in-flight send has released it.
        }
    }
}
