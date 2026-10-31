using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameCore;
using NUnit.Framework;

public sealed class CoreLogicTests
{
    [Test] public void PacketPrimitivesUseNetworkByteOrderAndCheckBounds()
    {
        var writer = new PacketWriter(); writer.WriteUInt16(0x1234); writer.WriteInt32(-3); writer.WriteInt64(long.MinValue); writer.WriteBoolean(true); writer.WriteString("sample");
        byte[] bytes = writer.ToArray(); Assert.AreEqual(0x12, bytes[0]); Assert.AreEqual(0x34, bytes[1]);
        var reader = new PacketReader(bytes);
        Assert.AreEqual(0x1234, reader.ReadUInt16()); Assert.AreEqual(-3, reader.ReadInt32()); Assert.AreEqual(long.MinValue, reader.ReadInt64());
        Assert.IsTrue(reader.ReadBoolean()); Assert.AreEqual("sample", reader.ReadString()); reader.RequireEnd();
        Assert.Throws<InvalidDataException>(() => reader.ReadByte());
        Assert.Throws<InvalidDataException>(() => new PacketReader(new byte[] { 2 }).ReadBoolean());
        Assert.Throws<InvalidDataException>(() => new PacketReader(new byte[] { 0, 10, 1 }).ReadString());
        Assert.Throws<ArgumentException>(() => writer.WriteString(new string('a', 65536)));
    }
    [Test] public void FramingHandlesEveryByteBoundaryAndCombinedFrames()
    {
        byte[] frame = new NetworkPacket(42, new byte[] { 8, 9 }, 7).Encode();
        CollectionAssert.AreEqual(new byte[] { 0, 6, 0, 7, 0, 42, 8, 9 }, frame);
        for (int split = 0; split <= frame.Length; split++)
        {
            var decoder = new PacketFramer(); var packets = new List<NetworkPacket>();
            packets.AddRange(decoder.Feed(frame, 0, split)); packets.AddRange(decoder.Feed(frame, split, frame.Length - split)); decoder.Complete();
            Assert.AreEqual(1, packets.Count); Assert.AreEqual(7, packets[0].NodeId); Assert.AreEqual(42, packets[0].MessageId);
            CollectionAssert.AreEqual(new byte[] { 8, 9 }, packets[0].GetPayload());
        }
        var merged = frame.Concat(frame).ToArray(); Assert.AreEqual(2, new PacketFramer().Feed(merged, 0, merged.Length).Length);
    }
    [Test] public void ExtendedFramesDoNotConfuseTheSentinelWithALength()
    {
        byte[] body = Enumerable.Range(0, 70000).Select(i => (byte)i).ToArray();
        byte[] bytes = new NetworkPacket(99, body).Encode();
        Assert.AreEqual(255, bytes[0]); Assert.AreEqual(255, bytes[1]);
        var decoder = new PacketFramer(); var packets = new List<NetworkPacket>();
        for (int i = 0; i < bytes.Length; i += 13) packets.AddRange(decoder.Feed(bytes, i, Math.Min(13, bytes.Length - i)));
        decoder.Complete(); Assert.AreEqual(1, packets.Count); CollectionAssert.AreEqual(body, packets[0].GetPayload());
    }
    [Test] public void MalformedAndTruncatedFramesFailBeforeUnboundedAllocation()
    {
        var decoder = new PacketFramer(1024);
        Assert.Throws<InvalidDataException>(() => decoder.Feed(new byte[] {255,255,127,255,255,255}, 0, 6));
        Assert.Throws<InvalidOperationException>(() => decoder.Feed(new byte[] {0,4}, 0, 2)); decoder.Reset();
        Assert.Throws<InvalidDataException>(() => decoder.Feed(new byte[] {0,3}, 0, 2)); decoder.Reset();
        decoder.Feed(new byte[] {0}, 0, 1); Assert.Throws<InvalidDataException>(() => decoder.Complete());
    }
    [Test] public void RouterSupportsSubscriptionRemovalDuringDispatch()
    {
        var router = new PacketRouter(); int calls = 0; IDisposable second = null;
        using (router.Subscribe(1, _ => { calls++; second.Dispose(); }))
        {
            second = router.Subscribe(1, _ => calls++);
            Assert.AreEqual(2, router.Dispatch(new NetworkPacket(1, Array.Empty<byte>())));
            Assert.AreEqual(1, router.Dispatch(new NetworkPacket(1, Array.Empty<byte>())));
        }
        Assert.AreEqual(3, calls); Assert.AreEqual(0, router.Dispatch(new NetworkPacket(1, Array.Empty<byte>())));
    }
    [Test] public void ServerClockUsesElapsedTimeAndDoesNotMoveBackwards()
    {
        long elapsed = 100; var clock = new ServerClock(() => elapsed);
        Assert.Throws<InvalidOperationException>(() => { var unused = clock.NowMilliseconds; });
        clock.Synchronize(1000, 100); Assert.AreEqual(1050, clock.NowMilliseconds);
        elapsed += 500; Assert.AreEqual(1550, clock.NowMilliseconds);
        elapsed -= 200; Assert.AreEqual(1550, clock.NowMilliseconds);
        clock.Synchronize(1200); Assert.AreEqual(1550, clock.NowMilliseconds);
        clock.Reset(); Assert.IsFalse(clock.IsSynchronized);
    }
    private static TimedOperation Job(string id, string group = "build") => new TimedOperation { Id = id, Group = group, EntityId = 1, StartMilliseconds = 100, EndMilliseconds = 200 };
    [Test] public void TimelineIsAuthoritativeVersionedAndDoesNotCompleteOnExpiry()
    {
        var timeline = new OperationTimeline(); var job = Job("one");
        Assert.IsTrue(timeline.ApplySnapshot("build", 5, new[] { job })); job.EndMilliseconds = 9999;
        Assert.AreEqual(0, timeline.Get("one").Remaining(300)); Assert.AreEqual(1, timeline.Count);
        Assert.IsFalse(timeline.ApplySnapshot("build", 4, Array.Empty<TimedOperation>()));
        Assert.Throws<ArgumentException>(() => timeline.ApplySnapshot("build", 6, new[] { Job("two"), Job("two") })); Assert.AreEqual(1, timeline.Count);
        Assert.IsTrue(timeline.ApplySnapshot("build", 6, Array.Empty<TimedOperation>())); Assert.AreEqual(0, timeline.Count);
    }
    [Test] public void TimelineRejectsCrossGroupIdentityAndClampsFutureProgress()
    {
        var timeline = new OperationTimeline(); timeline.ApplySnapshot("build", 0, new[] { Job("same") });
        Assert.Throws<ArgumentException>(() => timeline.ApplySnapshot("research", 0, new[] { Job("same", "research") }));
        Assert.AreEqual(0, timeline.Get("same").Fraction(50)); Assert.AreEqual(0.5, timeline.Get("same").Fraction(150)); Assert.AreEqual(1, timeline.Get("same").Fraction(500));
    }
    [Test] public void BalancesApplyAtomicallyAndRememberReceiptsAcrossRestore()
    {
        var ledger = new BalanceLedger(); ledger.TryApply("seed", new Dictionary<string,long> { ["Food"] = 20, ["Wood"] = 4 });
        Assert.AreEqual(LedgerResult.InsufficientBalance, ledger.TryApply("cost", new Dictionary<string,long> { ["Food"] = -10, ["Wood"] = -5 }));
        Assert.AreEqual(20, ledger.Get("Food")); Assert.IsFalse(ledger.ContainsReceipt("cost"));
        Assert.AreEqual(LedgerResult.Applied, ledger.TryApply("cost", new Dictionary<string,long> { ["Food"] = -10 }));
        var restored = new BalanceLedger(); restored.Restore(ledger.Export());
        Assert.AreEqual(LedgerResult.Duplicate, restored.TryApply("cost", new Dictionary<string,long> { ["Food"] = -10 })); Assert.AreEqual(10, restored.Get("Food"));
    }
    [Test] public void BalanceOverflowAndInvalidRestoreDoNotPartiallyCommit()
    {
        var ledger = new BalanceLedger(); ledger.TryApply("seed", new Dictionary<string,long> { ["Food"] = long.MaxValue });
        Assert.Throws<OverflowException>(() => ledger.TryApply("bad", new Dictionary<string,long> { ["Wood"] = 3, ["Food"] = 1 }));
        Assert.AreEqual(0, ledger.Get("Wood")); Assert.IsFalse(ledger.ContainsReceipt("bad"));
        Assert.Throws<ArgumentException>(() => ledger.Restore(new BalanceSnapshot { Entries = new[] { new BalanceEntry { Key = "Food", Value = -1 } } }));
        Assert.AreEqual(long.MaxValue, ledger.Get("Food"));
    }
    [Test] public void IndexedTableRejectsDuplicateReplacementAtomically()
    {
        var table = new IndexedTable<string>(s => int.Parse(s)); table.Replace(new[] { "1", "2" });
        Assert.Throws<ArgumentException>(() => table.Replace(new[] { "3", "3" })); Assert.AreEqual("1", table.Get(1)); Assert.AreEqual(2, table.Count);
    }
}
