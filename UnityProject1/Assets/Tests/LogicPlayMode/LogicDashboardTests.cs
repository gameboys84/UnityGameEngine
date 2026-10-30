using System.Collections;
using GameRuntime;
using GameRuntime.LogicTests;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public sealed class LogicDashboardTests
{
    [UnityTest] public IEnumerator RuntimeDashboardLoadsRulesAndExercisesTheBusinessModel()
    {
        var owner = new GameObject("LogicDashboardTest");
        try
        {
            LogicTestDashboard.Attach(owner); LogicTestDashboard.Attach(owner);
            Assert.AreEqual(1, owner.GetComponents<LogicTestDashboard>().Length);
            var model = owner.GetComponent<LogicTestDashboard>().Model;
            Assert.IsNotNull(model); Assert.AreEqual(6, model.GetRules().Length);
            Assert.AreEqual(RequestResult.PrerequisiteMissing, model.Start("research", 101));
            Assert.AreEqual(RequestResult.Accepted, model.Start("headquarters", 1));
            Assert.IsTrue(model.SpeedUp("finish", "headquarters", long.MaxValue));
            Assert.AreEqual(1, model.ConfirmElapsed()); Assert.AreEqual(1, model.GetLevel(1));
            yield return null;
        }
        finally { Object.DestroyImmediate(owner); }
    }
}
