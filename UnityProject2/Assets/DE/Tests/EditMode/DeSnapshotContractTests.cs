using System;
using DE.Domain;
using NUnit.Framework;

namespace DE.Tests
{
    [Category("UnitTests")]
    public sealed class DeSnapshotContractTests
    {
        [Test]
        public void SnapshotCopiesBothInputAndExposedCollections()
        {
            var resources = new[] { new ResourceSnapshot("food", 120) };
            var snapshot = new DeSnapshot("account-a", 1, 3, 1000, resources: resources);
            resources[0] = new ResourceSnapshot("food", 999);
            Assert.That(snapshot.GetResource("food"), Is.EqualTo(120));
            var exposed = snapshot.Resources;
            exposed[0] = new ResourceSnapshot("food", 777);
            Assert.That(snapshot.GetResource("food"), Is.EqualTo(120));
        }

        [Test]
        public void DuplicateAndNullEntriesCannotCreateAnAmbiguousSnapshot()
        {
            Assert.Throws<ArgumentException>(() => new DeSnapshot("a", 1, 1, 0,
                resources: new[] { new ResourceSnapshot("food", 1), new ResourceSnapshot("food", 2) }));
            Assert.Throws<ArgumentException>(() => new DeSnapshot("a", 1, 1, 0,
                buildings: new BuildingSnapshot[] { null }));
        }

        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void NegativeHeaderValuesAreRejected(long generation, long revision, long time)
        {
            Assert.Throws<ArgumentException>(() => new DeSnapshot("a", generation, revision, time));
        }

        [Test]
        public void QueueExpiryMeansAwaitingAuthorityAndDoesNotGrantBuildingLevels()
        {
            var queue = new QueueSnapshot("queue-1", "building", "hq", "HQ", 1, 2, 100, 1000, 2000);
            var snapshot = new DeSnapshot("a", 1, 1, 2000,
                buildings: new[] { new BuildingSnapshot("hq", "HQ", 1, 10) },
                queues: new[] { queue });
            Assert.That(queue.RemainingMs, Is.Zero);
            Assert.That(queue.AwaitingConfirmation, Is.True);
            Assert.That(snapshot.GetBuildingLevel("hq"), Is.EqualTo(1));
            Assert.That(snapshot.Queues.Length, Is.EqualTo(1));
        }

        [Test]
        public void MarchPresentationClampsBeforeAndAfterItsTimeline()
        {
            Assert.That(new MarchSnapshot("m", "n", "Node", "infantry", 5, 100, 200, 0, "marching").Progress, Is.Zero);
            Assert.That(new MarchSnapshot("m", "n", "Node", "infantry", 5, 100, 200, 150, "marching").Progress, Is.EqualTo(0.5));
            Assert.That(new MarchSnapshot("m", "n", "Node", "infantry", 5, 100, 200, 999, "marching").Progress, Is.EqualTo(1));
        }

        [Test]
        public void InvalidEconomyAndWorldValuesAreRejected()
        {
            Assert.Throws<ArgumentException>(() => new ResourceSnapshot("food", -1));
            Assert.Throws<ArgumentException>(() => new TroopSnapshot("infantry", "Infantry", -1));
            Assert.Throws<ArgumentException>(() => new WorldNodeSnapshot("node", "Node", double.NaN, 1, "resource"));
            Assert.Throws<ArgumentException>(() => new BuildingSnapshot("hq", "HQ", 11, 10));
        }

        [Test]
        public void RequestPayloadIdentityIncludesAllGameplayFields()
        {
            var command = new DeCommand(DeCommandKind.CreateMarch, "node-a", 10, "request-a", "text", "infantry");
            Assert.That(command.HasSamePayload(new DeCommand(DeCommandKind.CreateMarch, "node-a", 10, "request-b", "text", "infantry")), Is.True);
            Assert.That(command.HasSamePayload(new DeCommand(DeCommandKind.CreateMarch, "node-a", 11, "request-a", "text", "infantry")), Is.False);
            Assert.That(command.HasSamePayload(new DeCommand(DeCommandKind.CreateMarch, "node-b", 10, "request-a", "text", "infantry")), Is.False);
            Assert.That(command.HasSamePayload(new DeCommand(DeCommandKind.CreateMarch, "node-a", 10, "request-a", "text", "tank")), Is.False);
        }
    }
}
