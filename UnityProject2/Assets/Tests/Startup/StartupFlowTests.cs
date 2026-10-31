using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using GameRuntime;
using Launcher;
using NUnit.Framework;
using TEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using YooAsset;
using GameCore;

public sealed class StartupFlowTests
{
    [UnityTest]
    public IEnumerator LauncherLoadsRealMainSceneAndHidesNativeUI() => Run(false).ToCoroutine();
    [UnityTest]
    public IEnumerator InvalidConfigurationCanRetryIntoGame() => Run(true).ToCoroutine();
    [UnityTest]
    public IEnumerator DemoButtonsExerciseRealFrameworkInterfaces() => Run(false, true).ToCoroutine();
    [UnityTest]
    public IEnumerator MainCanBePlayedDirectlyThroughLauncher() => Run(false, false, true).ToCoroutine();
    [UnityTest]
    public IEnumerator SlgIndependentUiLayersAndBulkWorkloads() => Run(false, false, false, true).ToCoroutine();

    private static async UniTask Run(bool testRetry, bool testLabs = false, bool directMain = false, bool testSlg = false)
    {
#if UNITY_EDITOR
        var assetSettings = UnityEditor.AssetDatabase.LoadAssetAtPath<StartupSettings>("Assets/Launcher/Settings/StartupSettings.asset");
        Assert.IsNotNull(assetSettings);
        string originalPackage = assetSettings.packageName;
        var settings = testRetry ? UnityEngine.Object.Instantiate(assetSettings) : assetSettings;
        int originalEditorMode = UnityEditor.EditorPrefs.GetInt("EditorPlayMode");
        GameEntry entry = null;
        UnityEngine.Events.UnityAction<Scene, LoadSceneMode> bindTestSettings = null;
        ExpectedStartupFailureLog expectedFailure = null;
        try
        {
            // Prove the entry uses scene settings instead of this unrelated global preference.
            UnityEditor.EditorPrefs.SetInt("EditorPlayMode", (int)EPlayMode.HostPlayMode);
            if (testRetry)
            {
                settings.packageName = "";
                // Use a transient settings clone, bound after Awake and before Start.
                // Never corrupt the project asset, even if the test is interrupted.
                bindTestSettings = (scene, mode) =>
                {
                    if (scene.path != "Assets/Launcher/Scenes/Launcher.unity") return;
                    // Awake has already moved the entry into DontDestroyOnLoad.
                    var sceneEntry = UnityEngine.Object.FindObjectOfType<GameEntry>();
                    if (sceneEntry != null) sceneEntry.settings = settings;
                };
                SceneManager.sceneLoaded += bindTestSettings;
                expectedFailure = new ExpectedStartupFailureLog(Debug.unityLogger.logHandler);
                Debug.unityLogger.logHandler = expectedFailure;
            }
            float started = Time.realtimeSinceStartup;
            await UnityEditor.SceneManagement.EditorSceneManager.LoadSceneAsyncInPlayMode(
                directMain ? "Assets/AssetBundle/Scenes/Main.unity" : "Assets/Launcher/Scenes/Launcher.unity", new LoadSceneParameters(LoadSceneMode.Single));
            if (directMain) await UniTask.WaitUntil(() => UnityEngine.Object.FindObjectOfType<GameEntry>() != null).Timeout(TimeSpan.FromSeconds(10));
            entry = UnityEngine.Object.FindObjectOfType<GameEntry>();
            Assert.IsNotNull(entry);
            if (testRetry)
            {
                await UniTask.WaitUntil(() => entry.launcher.retry.gameObject.activeSelf).Timeout(TimeSpan.FromSeconds(10));
                Assert.IsFalse(entry.IsReady);
                Assert.AreSame(settings, entry.settings);
                Assert.AreEqual(1, expectedFailure.CapturedCount, "Exactly the deliberate empty-package failure must be reported.");
                Debug.unityLogger.logHandler = expectedFailure.Original;
                SceneManager.sceneLoaded -= bindTestSettings;
                Assert.AreEqual(originalPackage, assetSettings.packageName);
                settings.packageName = originalPackage;
                entry.launcher.retry.onClick.Invoke();
            }
            if (!testRetry && !testLabs && !directMain && !testSlg)
            {
                await UniTask.WaitUntil(() => entry.launcher.percentage.text == "30%" && entry.launcher.progressBar.Progress >= .299f)
                    .Timeout(TimeSpan.FromSeconds(10));
                string preview = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, "../../Design/reports/progress-bar-running.png"));
                ScreenCapture.CaptureScreenshot(preview);
                await UniTask.NextFrame();
            }
            await UniTask.WaitUntil(() => entry.IsReady).Timeout(TimeSpan.FromSeconds(40));
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
            var view = UnityEngine.Object.FindObjectOfType<MainSceneView>();
            await UniTask.WaitUntil(() => view.DemoUiReady).Timeout(TimeSpan.FromSeconds(15));
            Assert.IsTrue(view.IsReady);
            Assert.That(view.message.text, Does.Contain("Your game is ready."));
            Assert.IsFalse(entry.launcher.gameObject.activeSelf);
            Assert.IsNotNull(UnityEngine.Object.FindObjectOfType<Camera>());
            Assert.IsNotNull(GameCore.UIModule.UIRoot);
            Assert.GreaterOrEqual(Time.realtimeSinceStartup - started, settings.previewStageSeconds * 5);
            if (testLabs) await ExerciseLabs(view);
            if (testSlg) await ExerciseSlg(view);
        }
        finally
        {
            if (bindTestSettings != null) SceneManager.sceneLoaded -= bindTestSettings;
            if (expectedFailure != null) Debug.unityLogger.logHandler = expectedFailure.Original;
            if (UIModule.UIRoot != null) GameModule.UI.CloseAll(isShutDown: true);
            await UniTask.NextFrame();
            UnityEditor.EditorPrefs.SetInt("EditorPlayMode", originalEditorMode);
            var view = UnityEngine.Object.FindObjectOfType<MainSceneView>();
            if (view != null) UnityEngine.Object.Destroy(view.gameObject);
            if (entry != null) UnityEngine.Object.Destroy(entry.gameObject);
            await UniTask.Yield();
            GameCore.SingletonSystem.Release();
            ModuleSystem.Shutdown();
            YooAssets.Destroy();
            if (testRetry) UnityEngine.Object.Destroy(settings);
        }
#else
        Assert.Ignore("Editor simulation test; device acceptance uses built resource bundles.");
        await UniTask.Yield();
#endif
    }

    // LogAssert.Expect validates a message but still leaves it in the user's Console.
    // Capture only this one deliberate failure; every other error remains visible
    // and is handled normally by the Unity Test Framework.
    private sealed class ExpectedStartupFailureLog : ILogHandler
    {
        public readonly ILogHandler Original;
        public int CapturedCount { get; private set; }
        public ExpectedStartupFailureLog(ILogHandler original) { Original = original; }
        public void LogFormat(LogType type, UnityEngine.Object context, string format, params object[] args)
        {
            if (type == LogType.Error && CapturedCount == 0 &&
                string.Format(format, args).StartsWith("Startup failed: System.InvalidOperationException: Startup package is empty.", StringComparison.Ordinal))
            {
                CapturedCount++;
                return;
            }
            Original.LogFormat(type, context, format, args);
        }
        public void LogException(Exception exception, UnityEngine.Object context) => Original.LogException(exception, context);
    }

    private static async UniTask ExerciseSlg(MainSceneView main)
    {
        var hud = UnityEngine.Object.FindObjectOfType<SlgHudView>();
        Assert.IsNotNull(hud);
        Assert.IsTrue(GameModule.UI.HasWindow<SlgHudWindow>());
        var bag = await GameModule.UI.ShowUIAsyncAwait<BagWindow>();
        await UniTask.WaitUntil(() => bag.View.Ready).Timeout(TimeSpan.FromSeconds(10));
        bag.View.SetCount(100000); await UniTask.NextFrame();
        Assert.AreEqual(100000, bag.View.list.DataCount);
        Assert.Less(bag.View.list.LiveCount, 30);
        int created = bag.View.list.CreatedCount;
        bag.View.list.Scroll.verticalNormalizedPosition = 0;
        bag.View.list.Refresh(); await UniTask.NextFrame();
        Assert.LessOrEqual(bag.View.list.CreatedCount, created + 2);
        Assert.Less(bag.View.list.LiveCount, 30);
        ScreenCapture.CaptureScreenshot(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, "../../Design/reports/slg-bag.png")));
        await UniTask.NextFrame();
        GameModule.UI.CloseUI<BagWindow>(); await UniTask.NextFrame();

        var modalResult = DemoUi.ConfirmAsync("Modal layer test", main.GetCancellationTokenOnDestroy()).Preserve();
        await UniTask.WaitUntil(() => UnityEngine.Object.FindObjectOfType<ConfirmView>() != null && UnityEngine.Object.FindObjectOfType<ConfirmView>().IsBound).Timeout(TimeSpan.FromSeconds(5));
        var modal = UnityEngine.Object.FindObjectOfType<ConfirmView>();
        await UniTask.NextFrame();
        Canvas.ForceUpdateCanvases();
        var buttonRect = hud.features[0].GetComponent<RectTransform>();
        var pointer = new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current) { position = RectTransformUtility.WorldToScreenPoint(null, buttonRect.TransformPoint(buttonRect.rect.center)) };
        var hits = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>(); UnityEngine.EventSystems.EventSystem.current.RaycastAll(pointer, hits);
        Assert.AreEqual("ModalBlocker", hits[0].gameObject.name,
            $"Modal canvas order {modal.GetComponent<Canvas>().sortingOrder}, rect {modal.GetComponent<RectTransform>().rect}; hits: " + string.Join(", ", hits.ConvertAll(hit => hit.gameObject.name + "@" + hit.sortingOrder + "/" + hit.depth)));
        modal.Respond(true); Assert.IsTrue(await modalResult); await UniTask.NextFrame();

        var mail = await GameModule.UI.ShowUIAsyncAwait<MailWindow>(); await UniTask.WaitUntil(() => mail.View.Ready);
        int coins = FakeSlgState.Coins;
        await mail.View.RunPrimaryAsync(); await mail.View.RunPrimaryAsync();
        Assert.AreEqual(coins + 100, FakeSlgState.Coins); GameModule.UI.CloseUI<MailWindow>(); await UniTask.NextFrame();
        var chat = await GameModule.UI.ShowUIAsyncAwait<ChatWindow>(); await UniTask.WaitUntil(() => chat.View.Ready);
        chat.View.chatInput.text = "Test guild message"; await chat.View.RunPrimaryAsync();
        Assert.AreEqual(1, FakeSlgState.ChatMessages.Count); GameModule.UI.CloseUI<ChatWindow>(); await UniTask.NextFrame();

        var list = await GameModule.UI.ShowUIAsyncAwait<ListBenchmarkWindow>(); await UniTask.WaitUntil(() => list.View.Ready);
        await list.View.BenchmarkAsync(false, 1000); Assert.That(list.View.result.text, Does.Contain("RAW"));
        await list.View.BenchmarkAsync(true, 1000); Assert.That(list.View.result.text, Does.Contain("Reused 1000"));
        GameModule.UI.CloseUI<ListBenchmarkWindow>(); await UniTask.NextFrame();

        var bulk = await GameModule.UI.ShowUIAsyncAwait<PoolBenchmarkWindow>();
        await bulk.View.RunAsync(true, 1000); Assert.AreEqual(1000, bulk.View.LastCreated); Assert.GreaterOrEqual(bulk.View.LastReused, 1000); Assert.AreEqual(0, bulk.View.LastActive);
        await bulk.View.RunAsync(false, 1000); Assert.AreEqual(0, bulk.View.LastActive);
        await bulk.View.ReadAssetsAsync(); Assert.That(bulk.View.result.text, Does.Contain("256 DISTINCT"));
        ScreenCapture.CaptureScreenshot(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, "../../Design/reports/slg-bulk.png"))); await UniTask.NextFrame();
        GameModule.UI.CloseUI<PoolBenchmarkWindow>(); await UniTask.NextFrame();

        var tips = UnityEngine.Object.FindObjectOfType<TipsView>(); await tips.BurstAsync(12); Assert.LessOrEqual(tips.CreatedCount, 6);
        await UniTask.Delay(1400); Assert.AreEqual(0, tips.LiveCount);
        var news = UnityEngine.Object.FindObjectOfType<MarqueeView>(); news.Enqueue("Test announcement"); Assert.Greater(news.Pending, 0);
    }

    private static async UniTask ExerciseLabs(MainSceneView view)
    {
        ClickThroughInputModule(view.resourceButton);
        await UniTask.WaitUntil(() => GameModule.UI.HasWindow<ResourceTestWindow>()).Timeout(TimeSpan.FromSeconds(5));
        var resource = await GameModule.UI.ShowUIAsyncAwait<ResourceTestWindow>();
        await UniTask.NextFrame();
        Canvas.ForceUpdateCanvases();
        Assert.IsTrue(resource.Panel.gameObject.activeInHierarchy);
        Assert.Greater(resource.Panel.GetComponent<RectTransform>().rect.width, 100);
        var buttonRect = resource.Panel.actions[0].GetComponent<RectTransform>();
        var pointer = new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current)
        { position = RectTransformUtility.WorldToScreenPoint(null, buttonRect.TransformPoint(buttonRect.rect.center)) };
        var hits = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>();
        UnityEngine.EventSystems.EventSystem.current.RaycastAll(pointer, hits);
        Assert.That(hits.Count, Is.GreaterThan(0));
        Assert.AreEqual(resource.Panel.actions[0].gameObject, hits[0].gameObject, "The button must be the FIRST hit, not hidden under a blocker.");
        string preview = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.dataPath, "../../Design/reports/demo-panel-test.png"));
        ScreenCapture.CaptureScreenshot(preview);
        await UniTask.NextFrame();
        await resource.Panel.RunAsync(0);
        Assert.That(resource.Panel.output.text, Does.Contain("PASS: LoadAssetAsync"));
        await resource.Panel.RunAsync(1);
        Assert.IsNotNull(GameObject.Find("FoundationMarker(Clone)"));
        await resource.Panel.RunAsync(2);
        await UniTask.NextFrame();
        Assert.IsNull(GameObject.Find("FoundationMarker(Clone)"));
        resource.Panel.nested.onClick.Invoke();
        var child = await GameModule.UI.ShowUIAsyncAwait<DetailsTestWindow>("Parent: Resource LAB");
        Assert.That(child.Panel.output.text, Does.Contain("Resource LAB"));
        child.Panel.close.onClick.Invoke();
        await UniTask.NextFrame();
        Assert.IsFalse(GameModule.UI.HasWindow<DetailsTestWindow>());
        Assert.IsTrue(GameModule.UI.HasWindow<ResourceTestWindow>());
        resource.Panel.close.onClick.Invoke();
        await UniTask.NextFrame();
        Assert.IsFalse(GameModule.UI.HasWindow<ResourceTestWindow>());

        ClickThroughInputModule(view.sceneButton);
        var scene = await GameModule.UI.ShowUIAsyncAwait<SceneTestWindow>();
        await scene.Panel.RunAsync(0);
        Assert.IsTrue(GameModule.Scene.IsContainScene(FrameworkTestPanel.TestScene));
        Assert.IsNotNull(GameObject.Find("AdditiveGarden"));
        Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
        await scene.Panel.RunAsync(1);
        Assert.IsFalse(GameModule.Scene.IsContainScene(FrameworkTestPanel.TestScene));
        await scene.Panel.RunAsync(0);
        scene.Panel.close.onClick.Invoke();
        await UniTask.WaitUntil(() => !GameModule.Scene.IsContainScene(FrameworkTestPanel.TestScene)).Timeout(TimeSpan.FromSeconds(5));

        var saves = (LocalSaveModule)GameModule.LocalSave;
        string oldPath = saves.RootPath;
        saves.RootPath = System.IO.Path.Combine(Application.temporaryCachePath, "DemoUITest-" + Guid.NewGuid().ToString("N"));
        try
        {
            ClickThroughInputModule(view.saveButton);
            var save = await GameModule.UI.ShowUIAsyncAwait<SaveTestWindow>();
            await save.Panel.RunAsync(2);
            Assert.That(save.Panel.output.text, Does.Contain("PASS: LoadAsync"));
            Assert.IsTrue(System.IO.File.Exists(System.IO.Path.Combine(saves.RootPath, "framework-demo.json")));
            save.Panel.close.onClick.Invoke();
        }
        finally
        {
            if (System.IO.Directory.Exists(saves.RootPath)) System.IO.Directory.Delete(saves.RootPath, true);
            saves.RootPath = oldPath;
        }
        ClickThroughInputModule(view.timerButton);
        var timer = await GameModule.UI.ShowUIAsyncAwait<TimerTestWindow>();
        await timer.Panel.RunAsync(0);
        await UniTask.WaitUntil(() => timer.Panel.TickCount > 0).Timeout(TimeSpan.FromSeconds(4));
        await timer.Panel.RunAsync(1);
        int pausedCount = timer.Panel.TickCount;
        await UniTask.Delay(1200);
        Assert.AreEqual(pausedCount, timer.Panel.TickCount);
        await timer.Panel.RunAsync(2);
        await UniTask.WaitUntil(() => timer.Panel.TickCount > pausedCount).Timeout(TimeSpan.FromSeconds(4));
        await timer.Panel.RunAsync(3);
        int stoppedCount = timer.Panel.TickCount;
        await UniTask.Delay(1200);
        Assert.AreEqual(stoppedCount, timer.Panel.TickCount);
        timer.Panel.close.onClick.Invoke();
    }

    private static void ClickThroughInputModule(UnityEngine.UI.Button button)
    {
        Canvas.ForceUpdateCanvases();
        var events = UnityEngine.EventSystems.EventSystem.current;
        Assert.IsNotNull(events, "An active EventSystem must survive startup.");
        var module = events.GetComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        Assert.IsNotNull(module);
        var rect = button.GetComponent<RectTransform>();
        var position = RectTransformUtility.WorldToScreenPoint(null, rect.TransformPoint(rect.rect.center));
        var pointer = new UnityEngine.EventSystems.PointerEventData(events) { position = position };
        var hits = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>();
        events.RaycastAll(pointer, hits);
        Assert.That(hits.Count, Is.GreaterThan(0));
        Assert.AreEqual(button.gameObject, hits[0].gameObject, "Another Graphic blocks the visible button.");
        var fake = events.gameObject.AddComponent<DemoPointerInput>();
        var oldInput = module.inputOverride;
        var focusField = typeof(UnityEngine.EventSystems.EventSystem).GetField("m_HasFocus", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var oldFocus = focusField.GetValue(events);
        try
        {
            focusField.SetValue(events, true); // Headless test runner focus; unchanged outside this helper.
            module.inputOverride = fake; fake.Position = position;
            fake.Down = true; fake.Held = true;
            module.UpdateModule(); module.Process();
            fake.Down = false; fake.Held = false; fake.Up = true;
            module.Process();
        }
        finally
        {
            module.inputOverride = oldInput; focusField.SetValue(events, oldFocus);
            UnityEngine.Object.DestroyImmediate(fake);
        }
    }
}

public sealed class DemoPointerInput : UnityEngine.EventSystems.BaseInput
{
    public Vector2 Position;
    public bool Down, Up, Held;
    public override bool mousePresent => true;
    public override Vector2 mousePosition => Position;
    public override Vector2 mouseScrollDelta => Vector2.zero;
    public override int touchCount => 0;
    public override bool GetMouseButtonDown(int button) => button == 0 && Down;
    public override bool GetMouseButtonUp(int button) => button == 0 && Up;
    public override bool GetMouseButton(int button) => button == 0 && Held;
    public override float GetAxisRaw(string axisName) => 0;
    public override bool GetButtonDown(string buttonName) => false;
}
