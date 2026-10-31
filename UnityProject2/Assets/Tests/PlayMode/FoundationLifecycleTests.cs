using System;
using System.Collections;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameCore;
using NUnit.Framework;
using TEngine;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YooAsset;

public class FoundationLifecycleTests
{
    [UnityTest]
    public IEnumerator RealResourceAndAdditiveSceneLifecycle() => ResourcesAsync().ToCoroutine();
    [UnityTest]
    public IEnumerator LateConsumersCanReleaseAfterModuleShutdown() => ResourcesAsync(true).ToCoroutine();
    private sealed class ShutdownSingleton : ISingleton
    {
        public void Active() { }
        public void Release() { }
    }
    private async UniTask ResourcesAsync(bool lateRelease = false)
    {
#if UNITY_EDITOR
        int originalMode = UnityEditor.EditorPrefs.GetInt("EditorPlayMode");
        UnityEditor.EditorPrefs.SetInt("EditorPlayMode", (int)EPlayMode.EditorSimulateMode);
        var root = new GameObject("FoundationResourceRoot");
        root.AddComponent<RootModule>();
        IResourceModule resource = GameModule.Resource;
        resource.DefaultPackageName = "FoundationValidation";
        resource.Initialize();
        TextAsset text = null;
        GameObject instance = null;
        GameObject parking = null;
        PrefabInstancePool latePool = null;
        Scene loadedScene = default;
        try
        {
            var initialized = await resource.InitPackage("FoundationValidation", true);
            Assert.AreEqual(EOperationStatus.Succeed, initialized.Status);
            text = await resource.LoadAssetAsync<TextAsset>("foundation-text");
            Assert.AreEqual("foundation-resource-ok", text.text);
            resource.UnloadAsset(text);
            text = null;
            instance = await resource.LoadGameObjectAsync("foundation-prefab");
            Assert.IsNotNull(instance);
            loadedScene = await GameModule.Scene.LoadSceneAsync("FoundationAdditive", LoadSceneMode.Additive, gcCollect: false);
            Assert.IsTrue(loadedScene.isLoaded);
            Assert.IsTrue(await GameModule.Scene.UnloadAsync("FoundationAdditive"));
            Assert.IsFalse(GameModule.Scene.IsContainScene("FoundationAdditive"));
            loadedScene = default;
            if (lateRelease)
            {
                // Reproduce Stop: modules close before Unity destroys consumers.
                text = await resource.LoadAssetAsync<TextAsset>("foundation-text");
                var pooledPrefab = await resource.LoadAssetAsync<GameObject>("foundation-prefab");
                parking = new GameObject("LatePoolParking");
                latePool = new PrefabInstancePool(pooledPrefab, parking.transform);
                var pooledInstance = latePool.Rent(parking.transform);
                SingletonSystem.Retain(new ShutdownSingleton());
                ModuleSystem.Shutdown();
                Assert.DoesNotThrow(() => resource.UnloadAsset(text));
                Assert.DoesNotThrow(() => latePool.Return(pooledInstance));
                Assert.AreEqual(0, latePool.ActiveCount);
                Assert.AreEqual(0, latePool.CachedCount);
                Assert.Throws<ObjectDisposedException>(() => latePool.Rent(parking.transform));
                Assert.DoesNotThrow(() => latePool.Dispose());
                resource.UnloadAsset(pooledPrefab);
                text = null;
                UnityEngine.Object.Destroy(instance);
                instance = null;
                SingletonSystem.Release();
                await UniTask.NextFrame();
                Assert.IsNull(GameObject.Find("[UpdateDriver]"), "Unsubscribing during shutdown must not recreate the driver.");
                // A new session must bind to a new driver, not a stale module.
                SingletonSystem.Retain(new ShutdownSingleton());
                await UniTask.NextFrame();
                Assert.IsNotNull(GameObject.Find("[UpdateDriver]"));
                SingletonSystem.Release();
                ModuleSystem.Shutdown();
                await UniTask.NextFrame();
                Assert.IsNull(GameObject.Find("[UpdateDriver]"));
            }
        }
        finally
        {
            latePool?.Dispose();
            if (parking != null) UnityEngine.Object.Destroy(parking);
            if (text != null) resource.UnloadAsset(text);
            if (instance != null) UnityEngine.Object.Destroy(instance);
            if (loadedScene.IsValid() && loadedScene.isLoaded) await GameModule.Scene.UnloadAsync("FoundationAdditive");
            await UniTask.Yield();
            SingletonSystem.Release();
            UnityEngine.Object.Destroy(root);
            ModuleSystem.Shutdown();
            YooAssets.Destroy();
            UnityEditor.EditorPrefs.SetInt("EditorPlayMode", originalMode);
        }
#else
        Assert.Ignore("This case requires editor simulation. Device builds need their own resource bundles.");
        await UniTask.Yield();
#endif
    }
    [Window(UILayer.UI, "acceptance-window", hideTimeToClose: 0)]
    public class AcceptanceWindow : UIWindow { }

    private sealed class TestLoader : IUIResourceLoader
    {
        public int Loads;
        public bool Fail;
        public GameObject LoadGameObject(string location, Transform parent = null, string packageName = "") => Create(parent);
        public async UniTask<GameObject> LoadGameObjectAsync(string location, Transform parent = null, CancellationToken cancellationToken = default, string packageName = "")
        {
            ++Loads;
            await UniTask.Delay(30, cancellationToken: cancellationToken);
            return Fail ? null : Create(parent);
        }
        private static GameObject Create(Transform parent)
        {
            var panel = new GameObject("acceptance-window", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster));
            panel.transform.SetParent(parent, false);
            return panel;
        }
    }
    [UnityTest]
    public IEnumerator AsyncWindowLifecycle() => WindowLifecycleAsync().ToCoroutine();

    private async UniTask WindowLifecycleAsync()
    {
        var root = new GameObject("FoundationTestRoot");
        root.AddComponent<RootModule>();
        var uiRoot = new GameObject("UIRoot", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        var ui = UIModule.Instance;
        var loader = new TestLoader();
        UIModule.Resource = loader;
        try
        {
            var first = ui.ShowUIAsyncAwait<AcceptanceWindow>().AsTask();
            var second = ui.ShowUIAsyncAwait<AcceptanceWindow>().AsTask();
            Assert.IsFalse(second.IsCompleted, "Repeated open must wait for the shared load.");
            var window = await first;
            Assert.AreSame(window, await second);
            Assert.IsTrue(window.IsPrepare);
            Assert.AreEqual(1, loader.Loads);
            ui.HideUI<AcceptanceWindow>();
            ui.ShowUI<AcceptanceWindow>();
            ui.CloseUI<AcceptanceWindow>();
            await UniTask.Yield();
            Assert.IsTrue(window.gameObject == null);

            var pending = ui.ShowUIAsyncAwait<AcceptanceWindow>().AsTask();
            ui.CloseUI<AcceptanceWindow>();
            try { await pending; Assert.Fail("Close during load must cancel the await."); }
            catch (OperationCanceledException) { }

            loader.Fail = true;
            try { await ui.ShowUIAsyncAwait<AcceptanceWindow>(); Assert.Fail("Null resource must fail."); }
            catch (InvalidOperationException) { }
        }
        finally
        {
            SingletonSystem.Release();
            UnityEngine.Object.Destroy(uiRoot);
            UnityEngine.Object.Destroy(root);
        }
    }
    [Serializable]
    public class SaveData : LocalSaveDataBase { public int Number; }

    [UnityTest]
    public IEnumerator AsyncSaveRoundTripAndCancellation() => SaveAsync().ToCoroutine();

    [UnityTest]
    public IEnumerator LoopCellPoolPreservesPrefabsAndSeparatesTypes()
    {
        var firstPrefab = new GameObject("FirstCell", typeof(RectTransform));
        var secondPrefab = new GameObject("SecondCell", typeof(RectTransform));
        var source = new LoopScrollPrefabSource();
        GameObject first = null;
        GameObject second = null;
        try
        {
            source.RegisterPrefab(firstPrefab);
            source.RegisterPrefab(secondPrefab);
            first = source.GetObject("FirstCell");
            second = source.GetObject("SecondCell");
            source.ReturnObject(first.transform);
            source.ReturnObject(second.transform);
            Assert.AreSame(first, source.GetObject("FirstCell"));
            Assert.AreSame(second, source.GetObject("SecondCell"));
            source.ReturnObject(first.transform);
            source.ReturnObject(first.transform);
            Assert.IsNotNull(firstPrefab);
        }
        finally
        {
            source.Dispose();
            UnityEngine.Object.Destroy(firstPrefab);
            UnityEngine.Object.Destroy(secondPrefab);
        }
        yield return null;
        Assert.IsTrue(first == null);
        Assert.IsTrue(second == null);
    }
    private async UniTask SaveAsync()
    {
        var module = new LocalSaveModule();
        module.OnInit();
        module.RootPath = Path.GetFullPath(Path.Combine("Temp", "FoundationTests", Guid.NewGuid().ToString("N")));
        try
        {
            await module.SaveAsync("state.json", new SaveData { Number = 83 });
            Assert.AreEqual(83, (await module.LoadAsync<SaveData>("state.json")).Number);
            using (var cancel = new CancellationTokenSource())
            {
                cancel.Cancel();
                try { await module.SaveAsync("state.json", new SaveData { Number = 0 }, cancellationToken: cancel.Token); Assert.Fail("Cancelled save must not write."); }
                catch (OperationCanceledException) { }
            }
            Assert.AreEqual(83, module.Load<SaveData>("state.json").Number);
            module.Save("sync.json", new SaveData { Number = 61 });
            Assert.AreEqual(61, (await module.LoadAsync<SaveData>("sync.json")).Number);
        }
        finally
        {
            if (Directory.Exists(module.RootPath)) Directory.Delete(module.RootPath, true);
            module.Shutdown();
        }
    }
}
