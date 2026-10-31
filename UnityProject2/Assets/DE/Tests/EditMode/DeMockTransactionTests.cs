using System;
using DE.Application;
using DE.Domain;
using DE.Infrastructure;
using NUnit.Framework;

namespace DE.Tests
{
    // These verify explicit local fixture transactions, not compatibility with DE production services.
    [Category("HistoricalPrototype")]
    [Explicit("Historical local Mock prototype only; excluded from real DE acceptance.")]
    public sealed class DeMockTransactionTests
    {
        private IDeClient client;
        [SetUp] public void SetUp() { client = DeClientFactory.CreateMock("acceptance-account-a"); }
        [TearDown] public void TearDown() { client?.Dispose(); }

        private void Accept(DeCommandKind kind, string target, string request, int quantity = 1, string secondary = "")
        {
            var result = client.Execute(new DeCommand(kind, target, quantity, request, secondaryId: secondary));
            Assert.That(result.Success, Is.True, result.Code + ": " + result.Message);
        }

        [Test]
        public void MailRewardCannotBeGrantedTwiceByRetryOrANewRequest()
        {
            Assert.That(client.TransportLabel.ToUpperInvariant(), Does.Contain("MOCK"));
            var command = new DeCommand(DeCommandKind.ClaimMail, "mail-1", requestId: "claim-1");
            Assert.That(client.Execute(command).Success, Is.True);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5300));
            var revision = client.Snapshot.Revision;
            var retry = client.Execute(command);
            Assert.That(retry.Success, Is.True);
            Assert.That(retry.IsDuplicate, Is.True);
            Assert.That(client.Snapshot.Revision, Is.EqualTo(revision));
            Assert.That(client.Execute(new DeCommand(DeCommandKind.ClaimMail, "mail-1", requestId: "claim-2")).Success, Is.False);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5300));
        }

        [Test]
        public void ReusingARequestIdForAnotherPayloadCannotApplyTheSecondOperation()
        {
            Accept(DeCommandKind.ClaimMail, "mail-1", "shared-id");
            var before = client.Snapshot;
            var result = client.Execute(new DeCommand(DeCommandKind.ClaimMail, "mail-2", requestId: "shared-id"));
            Assert.That(result.Success, Is.False);
            Assert.That(result.Code, Is.EqualTo("request_conflict"));
            Assert.That(client.Snapshot, Is.SameAs(before));
            Assert.That(Array.Find(client.Snapshot.Mails, value => value.Id == "mail-2").IsClaimed, Is.False);
        }

        [Test]
        public void PrerequisiteFailureDoesNotSpendOrCreateQueues()
        {
            var before = client.Snapshot;
            var result = client.Execute(new DeCommand(DeCommandKind.StartResearch, "industry", requestId: "research-before-lab"));
            Assert.That(result.Success, Is.False);
            Assert.That(result.Code, Is.EqualTo("prerequisite_missing"));
            Assert.That(client.Snapshot, Is.SameAs(before));
            Assert.That(client.Snapshot.Queues, Is.Empty);
        }

        [Test]
        public void BuildingQueueAndCancellationAreAtomicAndRefundOnlyOnce()
        {
            Accept(DeCommandKind.StartBuildingUpgrade, "hq", "build-hq");
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(4760));
            Assert.That(client.Snapshot.GetBuildingLevel("hq"), Is.EqualTo(1));
            var beforeRejected = client.Snapshot;
            Assert.That(client.Execute(new DeCommand(DeCommandKind.StartBuildingUpgrade, "hq", requestId: "build-hq-again")).Success, Is.False);
            Assert.That(client.Snapshot, Is.SameAs(beforeRejected));
            var cancel = new DeCommand(DeCommandKind.CancelQueue, "build-hq", requestId: "cancel-hq");
            Assert.That(client.Execute(cancel).Success, Is.True);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(4880));
            Assert.That(client.Snapshot.GetResource("energy"), Is.EqualTo(4920));
            Assert.That(client.Snapshot.Queues, Is.Empty);
            Assert.That(client.Execute(cancel).IsDuplicate, Is.True);
            Assert.That(client.Execute(new DeCommand(DeCommandKind.CancelQueue, "build-hq", requestId: "cancel-hq-again")).Success, Is.False);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(4880));
        }

        [Test]
        public void InsufficientTrainingResourcesDoNotPartiallyDebitAnyResource()
        {
            Accept(DeCommandKind.StartBuildingUpgrade, "hq", "hq"); client.Tick(20);
            Accept(DeCommandKind.StartBuildingUpgrade, "barracks", "barracks"); client.Tick(10);
            var before = client.Snapshot;
            var result = client.Execute(new DeCommand(DeCommandKind.TrainTroops, "jeep", 1000, "too-expensive"));
            Assert.That(result.Success, Is.False);
            Assert.That(result.Code, Is.EqualTo("insufficient_resources"));
            Assert.That(client.Snapshot, Is.SameAs(before));
            Assert.That(client.Snapshot.Queues, Is.Empty);
        }

        [Test]
        public void RepeatedTrainingRequestCreatesAndSettlesOnlyOneBatch()
        {
            Accept(DeCommandKind.StartBuildingUpgrade, "hq", "hq"); client.Tick(20);
            Accept(DeCommandKind.StartBuildingUpgrade, "barracks", "barracks"); client.Tick(10);
            var command = new DeCommand(DeCommandKind.TrainTroops, "jeep", 5, "train-five");
            Assert.That(client.Execute(command).Success, Is.True);
            Assert.That(client.Execute(command).IsDuplicate, Is.True);
            Assert.That(client.Snapshot.Queues.Length, Is.EqualTo(1));
            client.Tick(15);
            Assert.That(Array.Find(client.Snapshot.Troops, value => value.Id == "jeep").Count, Is.EqualTo(45));
            client.Tick(15);
            Assert.That(Array.Find(client.Snapshot.Troops, value => value.Id == "jeep").Count, Is.EqualTo(45));
        }

        [Test]
        public void SpeedupChargesOnlyRemainingTimeAndRequiresAuthoritySettlement()
        {
            Accept(DeCommandKind.StartBuildingUpgrade, "hq", "hq");
            Accept(DeCommandKind.SpeedUpQueue, "hq", "speed-up", 10000);
            Assert.That(client.Snapshot.GetResource("diamond"), Is.EqualTo(198));
            Assert.That(client.Snapshot.GetBuildingLevel("hq"), Is.EqualTo(1));
            Assert.That(client.Snapshot.Queues[0].AwaitingConfirmation, Is.True);
            client.Tick(0.001);
            Assert.That(client.Snapshot.GetBuildingLevel("hq"), Is.EqualTo(2));
            Assert.That(client.Snapshot.Queues, Is.Empty);
        }

        [Test]
        public void LargeAuthorityTimeStepReturnsReservedTroopsAndAwardsOnce()
        {
            Accept(DeCommandKind.CreateMarch, "node-1", "march-ten", 10, "jeep");
            Assert.That(Array.Find(client.Snapshot.Troops, value => value.Id == "jeep").Count, Is.EqualTo(30));
            client.Tick(27);
            Assert.That(client.Snapshot.Marches, Is.Empty);
            Assert.That(Array.Find(client.Snapshot.Troops, value => value.Id == "jeep").Count, Is.EqualTo(40));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5100));
            client.Tick(27);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5100));
        }

        [Test]
        public void RecallReturnsTroopsWithoutCreatingAGatheringReward()
        {
            Accept(DeCommandKind.CreateMarch, "node-1", "march-ten", 10, "jeep");
            client.Tick(2);
            Accept(DeCommandKind.RecallMarch, "march-ten", "recall-ten");
            client.Tick(2);
            Assert.That(client.Snapshot.Marches, Is.Empty);
            Assert.That(Array.Find(client.Snapshot.Troops, value => value.Id == "jeep").Count, Is.EqualTo(40));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5000));
        }

        [Test]
        public void SwitchingAccountsSeparatesRewardsAndRestoresOnlyTheCorrectAccount()
        {
            Accept(DeCommandKind.ClaimMail, "mail-1", "same-request");
            client.SwitchAccount("acceptance-account-b");
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5000));
            Accept(DeCommandKind.ClaimMail, "mail-1", "same-request");
            client.SwitchAccount("acceptance-account-a");
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5300));
            Assert.That(client.Execute(new DeCommand(DeCommandKind.ClaimMail, "mail-1", requestId: "same-request")).IsDuplicate, Is.True);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5300));
        }
    }
}
