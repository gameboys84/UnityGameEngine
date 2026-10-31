using System;
using DE.Application;
using DE.Domain;
using NUnit.Framework;

namespace DE.Tests
{
    [Category("UnitTests")]
    public sealed class DeClientAuthorityTests
    {
        private sealed class ControlledSession : IDeSession
        {
            public string Label => "Controlled test transport; no simulated authority";
            public event Action<DeSnapshot> SnapshotReceived;
            public string Account;
            public long Generation;
            public int CloseCount;
            public int SendCount;
            public DeResult NextResult = DeResult.Accepted();
            public void Open(string accountId, long generation) { Account = accountId; Generation = generation; }
            public DeResult Send(DeCommand command) { SendCount++; return NextResult; }
            public void Tick(double deltaSeconds) { }
            public void Close() { CloseCount++; }
            public void Dispose() { }
            public void Emit(DeSnapshot snapshot) { SnapshotReceived?.Invoke(snapshot); }
            public DeSnapshot State(long revision, long amount = 100)
            {
                return new DeSnapshot(Account, Generation, revision, 1000,
                    resources: new[] { new ResourceSnapshot("food", amount) },
                    buildings: new[] { new BuildingSnapshot("hq", "HQ", 1, 10) });
            }
        }

        [Test]
        public void DuplicateAndStaleRevisionsCannotOverwriteAcceptedStateOrRaiseChanges()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            var changes = 0;
            client.Changed += _ => changes++;
            Assert.That(client.ApplySnapshot(session.State(10, 100)), Is.True);
            Assert.That(client.ApplySnapshot(session.State(10, 999)), Is.False);
            Assert.That(client.ApplySnapshot(session.State(9, 999)), Is.False);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(100));
            Assert.That(changes, Is.EqualTo(1));
            Assert.That(client.ApplySnapshot(session.State(11, 150)), Is.True);
            Assert.That(changes, Is.EqualTo(2));
        }

        [Test]
        public void WrongAccountOrSessionCannotOverwriteTheCurrentAccount()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            client.ApplySnapshot(session.State(10));
            Assert.That(client.ApplySnapshot(new DeSnapshot("account-b", session.Generation, 100, 1000)), Is.False);
            Assert.That(client.ApplySnapshot(new DeSnapshot("account-a", session.Generation + 1, 100, 1000)), Is.False);
            Assert.That(client.Snapshot.Revision, Is.EqualTo(10));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(100));
        }

        [Test]
        public void HigherRevisionWithOlderServerTimeIsRejectedAtomically()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            client.ApplySnapshot(session.State(10, 100));
            var before = client.Snapshot;
            Assert.That(client.ApplySnapshot(new DeSnapshot("account-a", session.Generation, 11, 999,
                resources: new[] { new ResourceSnapshot("food", 9999) })), Is.False);
            Assert.That(client.Snapshot, Is.SameAs(before));
        }

        [Test]
        public void AcceptedCommandDoesNotPredictAuthoritativeResourcesOrBuildingCompletion()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            client.ApplySnapshot(session.State(10));
            Assert.That(client.Execute(new DeCommand(DeCommandKind.StartBuildingUpgrade, "hq")).Success, Is.True);
            client.Tick(86400);
            Assert.That(session.SendCount, Is.EqualTo(1));
            Assert.That(client.Snapshot.Revision, Is.EqualTo(10));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(100));
            Assert.That(client.Snapshot.GetBuildingLevel("hq"), Is.EqualTo(1));
        }

        [Test]
        public void ServerRejectionLeavesTheEntireSnapshotUnchanged()
        {
            var session = new ControlledSession { NextResult = DeResult.Rejected("insufficient_resources", "Not enough food") };
            var client = new DeClient(session, "account-a");
            client.ApplySnapshot(session.State(10));
            var before = client.Snapshot;
            var result = client.Execute(new DeCommand(DeCommandKind.StartResearch, "economy"));
            Assert.That(result.Success, Is.False);
            Assert.That(result.Code, Is.EqualTo("insufficient_resources"));
            Assert.That(client.Snapshot, Is.SameAs(before));
        }

        [Test]
        public void AccountSwitchClearsVisibleStateAndRejectsDelayedOldSessionEvents()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            var old = session.State(10, 500);
            session.Emit(old);
            var oldGeneration = session.Generation;
            client.SwitchAccount("account-b");
            Assert.That(session.CloseCount, Is.GreaterThanOrEqualTo(1));
            Assert.That(session.Generation, Is.GreaterThan(oldGeneration));
            Assert.That(client.Snapshot.AccountId, Is.EqualTo("account-b"));
            Assert.That(client.Snapshot.GetResource("food"), Is.Zero);
            session.Emit(new DeSnapshot("account-a", oldGeneration, 999, 1000,
                resources: new[] { new ResourceSnapshot("food", 999999) }));
            Assert.That(client.Snapshot.AccountId, Is.EqualTo("account-b"));
            Assert.That(client.Snapshot.GetResource("food"), Is.Zero);
            session.Emit(session.State(1, 70));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(70));
        }

        [Test]
        public void ReopeningTheSameAccountStillRejectsItsPreviousGeneration()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            var oldGeneration = session.Generation;
            session.Emit(session.State(10, 500));
            client.SwitchAccount("account-a");
            Assert.That(client.ApplySnapshot(new DeSnapshot("account-a", oldGeneration, 999, 2000,
                resources: new[] { new ResourceSnapshot("food", 999999) })), Is.False);
            Assert.That(client.Snapshot.GetResource("food"), Is.Zero);
        }

        [Test]
        public void DisposalIsRepeatableAndLateTransportEventsCannotNotifyTheUi()
        {
            var session = new ControlledSession();
            var client = new DeClient(session, "account-a");
            session.Emit(session.State(10));
            var before = client.Snapshot;
            var changes = 0;
            client.Changed += _ => changes++;
            client.Dispose();
            client.Dispose();
            session.Emit(session.State(20, 999));
            Assert.That(client.Snapshot, Is.SameAs(before));
            Assert.That(changes, Is.Zero);
            Assert.Throws<ObjectDisposedException>(() => client.Execute(new DeCommand(DeCommandKind.ClaimMail, "mail-1")));
        }
    }
}
