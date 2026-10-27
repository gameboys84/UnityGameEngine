using GameCore;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;
namespace GameRuntime
{
    public sealed class MainSceneView : MonoBehaviour
    {
        public Text message;
        public Button resourceButton, sceneButton, saveButton, timerButton;
        public bool IsReady { get; private set; }
        public bool DemoUiReady { get; private set; }
#if UNITY_EDITOR
        private void Start()
        {
            // Main is a package scene. Direct Editor Play must first establish the native bootstrap.
            if (TEngine.RootModule.Instance == null) StartFromLauncherAsync().Forget();
        }
        private static async UniTask StartFromLauncherAsync()
        {
            try
            {
                await UnityEditor.SceneManagement.EditorSceneManager.LoadSceneAsyncInPlayMode(
                    "Assets/Launcher/Scenes/Launcher.unity", new UnityEngine.SceneManagement.LoadSceneParameters(UnityEngine.SceneManagement.LoadSceneMode.Single));
            }
            catch (Exception error) { Debug.LogException(error); }
        }
#endif
        public void Enter(string content)
        {
            message.text = content; IsReady = true;
            resourceButton.onClick.AddListener(() => Open<ResourceTestWindow>().Forget());
            sceneButton.onClick.AddListener(() => Open<SceneTestWindow>().Forget());
            saveButton.onClick.AddListener(() => Open<SaveTestWindow>().Forget());
            timerButton.onClick.AddListener(() => Open<TimerTestWindow>().Forget());
            InitializeDemoUiAsync().Forget(DemoUi.Report);
        }
        private async UniTask InitializeDemoUiAsync()
        {
            FakeSlgState.Reset(); var token = this.GetCancellationTokenOnDestroy();
            await GameModule.UI.ShowUIAsyncAwait<SlgHudWindow>(token);
            await GameModule.UI.ShowUIAsyncAwait<TipsWindow>(token);
            await GameModule.UI.ShowUIAsyncAwait<MarqueeWindow>(token);
            DemoUiReady = true;
        }
        public async UniTask Open<T>() where T : UIWindow, new()
        {
            try { await GameModule.UI.ShowUIAsyncAwait<T>(this.GetCancellationTokenOnDestroy()); }
            catch (OperationCanceledException) { }
            catch (Exception error) { if (this != null) message.text = "Window error: " + error.Message; Debug.LogException(error); }
        }
        private void OnDestroy() { SingletonSystem.Release(); }
    }
}
