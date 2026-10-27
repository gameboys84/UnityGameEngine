using System;
using System.Collections.Generic;
using System.IO;
using GameCore;
using NUnit.Framework;
using UnityEngine;

public class FoundationTests
{
    [Test]
    public void HeapMatchesSortedReferenceThroughGrowthAndDuplicates()
    {
        var queue = new GameCore.PriorityQueue<int>(0);
        var values = new List<int>();
        var random = new System.Random(91);
        for (int i = 0; i < 1000; i++) { int value = random.Next(-50, 51); values.Add(value); queue.Push(value); }
        values.Sort((a, b) => b.CompareTo(a));
        foreach (int value in values) Assert.AreEqual(value, queue.Pop());
        Assert.AreEqual(0, queue.Count);
        Assert.Throws<InvalidOperationException>(() => queue.Pop());
    }
    [Test]
    public void RingHistoryWrapsChronologicallyAndDoesNotExposeStorage()
    {
        var ring = new CircleList<int>(3);
        for (int i = 1; i <= 5; i++) ring.Push(i);
        CollectionAssert.AreEqual(new[] { 3, 4, 5 }, ring.GetData());
        ring.GetData()[0] = 99;
        Assert.AreEqual(3, ring.GetData()[0]);
        ring.Clear();
        Assert.AreEqual(0, ring.Count);
    }
    [Serializable]
    public class SaveData : LocalSaveDataBase { public int Number; }
    [Test]
    public void SaveRoundTripAndPathValidation()
    {
        var module = new LocalSaveModule();
        module.OnInit();
        module.RootPath = Path.GetFullPath(Path.Combine("Temp", "FoundationTests", Guid.NewGuid().ToString("N")));
        try
        {
            module.Save("save.json", new SaveData { Number = 47 });
            Assert.AreEqual(47, module.Load<SaveData>("save.json").Number);
            Assert.Throws<ArgumentException>(() => module.Save("../escape.json", new SaveData()));
            Assert.IsNull(module.Load<SaveData>("missing.json"));
        }
        finally
        {
            if (Directory.Exists(module.RootPath)) Directory.Delete(module.RootPath, true);
            module.Shutdown();
        }
    }
}
