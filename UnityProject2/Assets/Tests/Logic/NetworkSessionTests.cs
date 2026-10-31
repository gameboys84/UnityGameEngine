using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using GameCore;
using NUnit.Framework;
using UnityEngine.TestTools;

public sealed class NetworkSessionTests
{
    private static IEnumerator Await(Task task)
    {
        var watch = Stopwatch.StartNew();
        while (!task.IsCompleted) { Assert.Less(watch.Elapsed.TotalSeconds, 10, "Network operation timed out."); yield return null; }
        task.GetAwaiter().GetResult();
    }
    private static IEnumerator PumpUntil(TcpPacketSession session, Func<bool> complete)
    {
        var watch = Stopwatch.StartNew();
        while (!complete()) { Assert.Less(watch.Elapsed.TotalSeconds, 10, "Session callback timed out."); session.Pump(); yield return null; }
    }
    private static async Task<NetworkPacket> ReadPacket(TcpClient peer)
    {
        var decoder = new PacketFramer(); var bytes = new byte[1024];
        while (true)
        {
            int count = await peer.GetStream().ReadAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            if (count == 0) throw new InvalidOperationException("Peer closed before receiving a packet.");
            var packets = decoder.Feed(bytes, 0, count);
            if (packets.Length > 0) return packets[0];
        }
    }
    [UnityTest] public IEnumerator LoopbackTransportSendsReceivesAndDispatchesOnThePumpThread()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        using (var session = new TcpPacketSession())
        {
            TcpClient peer = null;
            try
            {
                Task<TcpClient> accepted = listener.AcceptTcpClientAsync();
                yield return Await(session.ConnectAsync("127.0.0.1", ((IPEndPoint)listener.LocalEndpoint).Port));
                yield return Await(accepted); peer = accepted.Result;
                var received = ReadPacket(peer);
                yield return Await(session.SendAsync(new NetworkPacket(11, new byte[] {1,2,3}, 6)));
                yield return Await(received); Assert.AreEqual(11, received.Result.MessageId); Assert.AreEqual(6, received.Result.NodeId);
                int expectedThread = Thread.CurrentThread.ManagedThreadId, actualThread = -1;
                NetworkPacket reply = null;
                session.PacketReceived += packet => { actualThread = Thread.CurrentThread.ManagedThreadId; reply = packet; };
                byte[] bytes = new NetworkPacket(12, new byte[] {4,5}).Encode();
                yield return Await(peer.GetStream().WriteAsync(bytes, 0, 1));
                yield return Await(peer.GetStream().WriteAsync(bytes, 1, bytes.Length - 1));
                yield return PumpUntil(session, () => reply != null);
                Assert.AreEqual(expectedThread, actualThread); Assert.AreEqual(12, reply.MessageId); CollectionAssert.AreEqual(new byte[] {4,5}, reply.GetPayload());
                bool closed = false; session.Disconnected += error => { Assert.IsNull(error); closed = true; };
                peer.Close(); yield return PumpUntil(session, () => closed); Assert.IsFalse(session.IsConnected);
            }
            finally { peer?.Close(); listener.Stop(); }
        }
    }
    [UnityTest] public IEnumerator MalformedRemoteFrameDisconnectsWithAnError()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        using (var session = new TcpPacketSession(1024))
        {
            TcpClient peer = null;
            try
            {
                var accepted = listener.AcceptTcpClientAsync();
                yield return Await(session.ConnectAsync("127.0.0.1", ((IPEndPoint)listener.LocalEndpoint).Port)); yield return Await(accepted); peer = accepted.Result;
                Exception failure = null; session.Disconnected += error => failure = error;
                yield return Await(peer.GetStream().WriteAsync(new byte[] {0,1}, 0, 2));
                yield return PumpUntil(session, () => failure != null); Assert.IsInstanceOf<System.IO.InvalidDataException>(failure); Assert.IsFalse(session.IsConnected);
            }
            finally { peer?.Close(); listener.Stop(); }
        }
    }
    [Test] public void CancelledConnectAndDisposedSessionDoNotOpenAConnection()
    {
        var session = new TcpPacketSession(); var cancellation = new CancellationTokenSource(); cancellation.Cancel();
        Assert.Throws<OperationCanceledException>(() => session.ConnectAsync("127.0.0.1", 1, cancellation.Token).GetAwaiter().GetResult());
        session.Dispose(); Assert.Throws<ObjectDisposedException>(() => session.ConnectAsync("127.0.0.1", 1).GetAwaiter().GetResult());
        Assert.IsFalse(session.IsConnected); cancellation.Dispose();
    }
    [UnityTest] public IEnumerator IncomingByteBudgetClosesTheConnectionWithoutGrowingTheQueue()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        using (var session = new TcpPacketSession(1024, 100, 8))
        {
            TcpClient peer = null;
            try
            {
                var accepted = listener.AcceptTcpClientAsync();
                yield return Await(session.ConnectAsync("127.0.0.1", ((IPEndPoint)listener.LocalEndpoint).Port)); yield return Await(accepted); peer = accepted.Result;
                byte[] frame = new NetworkPacket(1, new byte[] {1,2,3,4}).Encode();
                var pair = new byte[frame.Length * 2]; Buffer.BlockCopy(frame,0,pair,0,frame.Length); Buffer.BlockCopy(frame,0,pair,frame.Length,frame.Length);
                yield return Await(peer.GetStream().WriteAsync(pair, 0, pair.Length));
                var watch = Stopwatch.StartNew();
                while (session.IsConnected) { Assert.Less(watch.Elapsed.TotalSeconds,10); yield return null; }
                Assert.AreEqual(1, session.PendingPackets);
                Exception failure = null; session.Disconnected += error => failure = error;
                yield return PumpUntil(session, () => failure != null); Assert.IsInstanceOf<System.IO.IOException>(failure); Assert.AreEqual(0, session.PendingPackets);
            }
            finally { peer?.Close(); listener.Stop(); }
        }
    }
}
