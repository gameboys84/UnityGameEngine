using System;
using System.IO;
using System.Linq;
using GameCore;
using GameRuntime.LogicTests;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Compilation;

public sealed class AssemblyBoundaryTests
{
    [Test] public void EveryProjectScriptHasAnExplicitAssemblyOwner()
    {
        foreach (string path in AssetDatabase.GetAllAssetPaths().Where(p => p.StartsWith("Assets/Scripts/", StringComparison.Ordinal) && p.EndsWith(".cs", StringComparison.Ordinal)))
        {
            string owner = CompilationPipeline.GetAssemblyNameFromScriptPath(path);
            Assert.IsNotNull(owner, path);
            Assert.IsFalse(owner.StartsWith("Assembly-CSharp", StringComparison.Ordinal), path + " is in a default assembly.");
            if (path.Contains("/Editor/"))
                Assert.AreEqual("GameProject.Editor", Path.GetFileNameWithoutExtension(owner), path);
        }
    }
    [Test] public void SharedLogicAndBusinessModelHaveNoUnityOrProjectFacadeDependency()
    {
        foreach (var assembly in new[] { typeof(ServerClock).Assembly, typeof(SettlementSimulation).Assembly })
            foreach (var reference in assembly.GetReferencedAssemblies())
            {
                Assert.IsFalse(reference.Name.StartsWith("Unity", StringComparison.Ordinal), reference.Name);
                Assert.AreNotEqual("GameRuntime", reference.Name); Assert.AreNotEqual("GameCore", reference.Name);
            }
        Assert.AreNotEqual(typeof(ServerClock).Assembly, typeof(SettlementSimulation).Assembly);
    }
    [Test] public void CompilerPluginsAreEditorOnly()
    {
        foreach (string path in AssetDatabase.GetAllAssetPaths().Where(p => p.StartsWith("Assets/Plugins/Roslyn/", StringComparison.Ordinal) && p.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)))
        {
            var importer = AssetImporter.GetAtPath(path) as PluginImporter; Assert.IsNotNull(importer, path);
            Assert.IsFalse(importer.GetCompatibleWithAnyPlatform(), path); Assert.IsTrue(importer.GetCompatibleWithEditor(), path);
        }
    }
}
