#if UNITY_EDITOR
using System.Collections;
using DE.Bootstrap;
using DE.Presentation;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace DE.IntegrationTests
{
    [Category("HistoricalPrototype")]
    [Explicit("Historical prototype only; not a production DE acceptance test.")]
    public sealed class DeLauncherIntegrationTests
    {
        [UnityTest]
        public IEnumerator LauncherLoadsDEThroughResourcePipeline()
        {
            yield return EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Launcher/Scenes/Launcher.unity",
                new LoadSceneParameters(LoadSceneMode.Single));
            var deadline = Time.realtimeSinceStartup + 60;
            while ((DeRuntimeHost.Current == null || !DeRuntimeHost.Current.IsReady) && Time.realtimeSinceStartup < deadline)
            {
                if (DeRuntimeHost.Current != null && !string.IsNullOrEmpty(DeRuntimeHost.Current.StartupError))
                    Assert.Fail(DeRuntimeHost.Current.StartupError);
                yield return null;
            }
            Assert.That(DeRuntimeHost.Current, Is.Not.Null, "Launcher never invoked the DE composition root.");
            Assert.That(DeRuntimeHost.Current.IsReady, Is.True, "DE UI startup timed out.");
            Assert.That(Object.FindObjectOfType<GameEntry>().IsReady, Is.True);
            Assert.That(SceneManager.GetActiveScene().path, Is.EqualTo("Assets/AssetBundle/DE/Scenes/DEMain.unity"));
            Assert.That(Object.FindObjectsOfType<DEShellView>().Length, Is.EqualTo(1));
            var shell = Object.FindObjectOfType<DEShellView>();
            Assert.That(shell.CurrentPage, Is.EqualTo("city"));
            Assert.That(shell.VisibleIds, Does.Contain("nav.city"));
            Assert.That(DeRuntimeHost.Current.Client.TransportLabel, Does.Contain("MOCK"));
            Assert.That(TEngine.RootModule.Instance, Is.Not.Null);
            LogAssert.NoUnexpectedReceived();
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (DeRuntimeHost.Current != null) Object.Destroy(DeRuntimeHost.Current.gameObject);
            foreach (var entry in Object.FindObjectsOfType<GameEntry>()) Object.Destroy(entry.gameObject);
            yield return null;
            GameCore.SingletonSystem.Release();
            yield return null;
        }
    }
}
#endif
