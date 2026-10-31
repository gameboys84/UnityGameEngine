using System;
using System.Linq;
using GameCore;
using GameRuntime.LogicTests;
using NUnit.Framework;
using UnityEngine;

public sealed class SettlementLogicTests
{
    private long elapsed;
    private ServerClock clock;
    private OperationRule[] rules;
    private SettlementSimulation model;
    [SetUp] public void Setup()
    {
        elapsed = 0; clock = new ServerClock(() => elapsed); clock.Synchronize(1000);
        var asset = Resources.Load<TextAsset>("LogicTests/Rules"); Assert.IsNotNull(asset);
        rules = JsonUtility.FromJson<RuleCatalog>(asset.text).Rules;
        model = new SettlementSimulation(rules, clock);
        model.Grant("seedFood", "Food", 10000); model.Grant("seedWood", "Wood", 10000); model.Grant("seedSpeedup", "Speedup", 100);
    }
    private void Finish(string id, int rule)
    {
        Assert.AreEqual(RequestResult.Accepted, model.Start(id, rule)); elapsed += 100000; model.ConfirmElapsed();
    }
    [Test] public void BuildingPrerequisitesQueueLimitsAndAcknowledgementAreEnforced()
    {
        Assert.AreEqual(RequestResult.PrerequisiteMissing, model.Start("lab", 2));
        Assert.AreEqual(RequestResult.Accepted, model.Start("hq", 1));
        Assert.AreEqual(RequestResult.QueueFull, model.Start("hqOther", 1)); Assert.AreEqual(9900, model.GetBalance("Food"));
        elapsed += 100000; Assert.AreEqual(0, model.GetLevel(1)); Assert.AreEqual(1, model.Timeline.Count);
        Assert.AreEqual(1, model.ConfirmElapsed()); Assert.AreEqual(1, model.GetLevel(1)); Assert.AreEqual(0, model.ConfirmElapsed());
        Assert.AreEqual(RequestResult.Duplicate, model.Start("hq", 1)); Assert.AreEqual(9900, model.GetBalance("Food"));
        Finish("labAfter", 2); Assert.AreEqual(1, model.GetLevel(2));
    }
    [Test] public void ResearchUsesAllPrerequisitesAndTrainingCreditsOnlyOnce()
    {
        Finish("hq", 1); Finish("lab", 2);
        Assert.AreEqual(RequestResult.PrerequisiteMissing, model.Start("advanced", 102));
        Finish("production", 101); Finish("labUpgrade", 2); Finish("advancedAfter", 102);
        Finish("barracks", 3);
        Assert.AreEqual(RequestResult.Accepted, model.Start("troops", 201, 5));
        elapsed += 100000; Assert.AreEqual(0, model.GetBalance("Unit201")); model.ConfirmElapsed();
        Assert.AreEqual(5, model.GetBalance("Unit201")); model.ConfirmElapsed(); Assert.AreEqual(5, model.GetBalance("Unit201"));
    }
    [Test] public void InvalidQuantityAndInsufficientCostsLeaveNoQueueOrReceipt()
    {
        Assert.AreEqual(RequestResult.InvalidQuantity, model.Start("badQuantity", 1, 2));
        var empty = new SettlementSimulation(rules, clock);
        Assert.AreEqual(RequestResult.InsufficientBalance, empty.Start("hq", 1)); Assert.AreEqual(0, empty.Timeline.Count);
        empty.Grant("food", "Food", 100); Assert.AreEqual(RequestResult.InsufficientBalance, empty.Start("hq", 1)); Assert.AreEqual(100, empty.GetBalance("Food"));
        empty.Grant("wood", "Wood", 100); Assert.AreEqual(RequestResult.Accepted, empty.Start("hq", 1));
    }
    [Test] public void CancellationRefundsOnceAndDoesNotAllowRequestReplay()
    {
        model.Start("hq", 1); Assert.IsTrue(model.Cancel("hq")); Assert.AreEqual(9950, model.GetBalance("Food"));
        Assert.IsFalse(model.Cancel("hq")); Assert.AreEqual(RequestResult.Duplicate, model.Start("hq", 1)); Assert.AreEqual(0, model.GetLevel(1));
    }
    [Test] public void AccelerationCapsCostAtRemainingTimeAndIsIdempotent()
    {
        model.Start("hq", 1); elapsed += 1000;
        Assert.IsTrue(model.SpeedUp("speed", "hq", long.MaxValue)); Assert.AreEqual(98, model.GetBalance("Speedup"));
        Assert.IsFalse(model.SpeedUp("speed", "hq", 1000)); Assert.AreEqual(98, model.GetBalance("Speedup"));
        Assert.AreEqual(0, model.GetLevel(1)); model.ConfirmElapsed(); Assert.AreEqual(1, model.GetLevel(1));
    }
    [Test] public void SnapshotRoundTripAndOfflineAdvanceKeepReplayProtection()
    {
        model.Start("hq", 1);
        string json = JsonUtility.ToJson(model.Export());
        elapsed += 60000;
        var restored = new SettlementSimulation(rules, clock); restored.Restore(JsonUtility.FromJson<SettlementSnapshot>(json));
        Assert.AreEqual(0, restored.GetLevel(1)); Assert.AreEqual(1, restored.ConfirmElapsed()); Assert.AreEqual(1, restored.GetLevel(1));
        Assert.AreEqual(RequestResult.Duplicate, restored.Start("hq", 1)); Assert.AreEqual(9900, restored.GetBalance("Food"));
    }
    [Test] public void InvalidSnapshotDoesNotDestroyLiveState()
    {
        model.Start("hq", 1); var snapshot = model.Export(); snapshot.Actions[0].Operation.EntityId = 9999;
        Assert.Throws<ArgumentException>(() => model.Restore(snapshot)); Assert.AreEqual(1, model.Timeline.Count); Assert.AreEqual(9900, model.GetBalance("Food"));
    }
    [Test] public void AlteredRefundCostsAndExpiredCancellationAreRejected()
    {
        model.Start("hq", 1); var snapshot = model.Export(); snapshot.Actions[0].PaidCosts[0].Amount += 1000;
        Assert.Throws<ArgumentException>(() => model.Restore(snapshot)); Assert.AreEqual(9900, model.GetBalance("Food"));
        elapsed += 100000; Assert.IsFalse(model.Cancel("hq")); Assert.AreEqual(1, model.ConfirmElapsed()); Assert.AreEqual(1, model.GetLevel(1));
    }
    [Test] public void RulesAndExportedStateDoNotExposeInternalMutableObjects()
    {
        rules[0].Costs[0].Amount = 90000; model.GetRules()[0].Costs[0].Amount = 90000;
        Assert.AreEqual(RequestResult.Accepted, model.Start("hq", 1)); Assert.AreEqual(9900, model.GetBalance("Food"));
        model.GetActions()[0].Operation.EndMilliseconds = 0; Assert.Greater(model.GetActions()[0].Operation.EndMilliseconds, 0);
        var snapshot = model.Export(); snapshot.Balances.Entries.First(e => e.Key == "Food").Value = 0; Assert.AreEqual(9900, model.GetBalance("Food"));
    }
}
