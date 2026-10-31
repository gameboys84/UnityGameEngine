using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DE.Infrastructure.Network;
using DE.Presentation.LegacyUI;
using DE.Production.Data;
using GameCore;
using TEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using YooAsset;

namespace DE.Production.Runtime
{
    public interface IProductionCityFlow
    {
        UniTask EnterCityAsync(DeProductionRuntimeHost runtime, CancellationToken token);
        bool IsReady { get; }
    }

    /// <summary>Real DE composition root: source assets, source tables, original wire protocol and actual development service.</summary>
    public sealed class DeProductionRuntimeHost : MonoBehaviour
    {
        [SerializeField] private DeProductionBootSettings settings;
        private bool started, ownsFramework, busy, resourcesReady, contentReady, cancelRequested;
        private CancellationTokenSource cancellation;
        private CancellationTokenSource loginAttempt;
        private ProductionLoadingView loadingView;
        public static DeProductionRuntimeHost Current { get; private set; }
        public DeProductionConnection Connection { get; private set; }
        public DeContentCatalog Content { get; private set; }
        public DeLocalization Localization { get; private set; }
        public ProductionLoadingCoordinator Loading { get; private set; }
        public bool InitialDataReceived => Loading?.Progress.InitialDataReceived == true;
        public bool IsReady { get; private set; }
        public bool IsLoginComplete { get; private set; }
        public string Phase { get; private set; } = "Created";
        public string Failure { get; private set; }
        public event Action StateChanged;

        public static DeProductionRuntimeHost StartProduction()
        {
            if (Current != null) return Current;
            var existing = UnityEngine.Object.FindObjectOfType<DeProductionRuntimeHost>();
            if (existing != null) { existing.Initialize(existing.settings ?? Resources.Load<DeProductionBootSettings>("DE/ProductionBootSettings")); return existing; }
            var instance = new GameObject("DE Production Runtime").AddComponent<DeProductionRuntimeHost>();
            instance.Initialize(Resources.Load<DeProductionBootSettings>("DE/ProductionBootSettings"));
            return instance;
        }
        private void Start() { if (!started) Initialize(settings ?? Resources.Load<DeProductionBootSettings>("DE/ProductionBootSettings")); }
        public void Initialize(DeProductionBootSettings configuration)
        {
            if (started) return;
            started = true; Current = this; settings = configuration;
            DontDestroyOnLoad(gameObject);
            UnityEngine.Application.runInBackground = true;
            if (RootModule.Instance == null) { gameObject.AddComponent<RootModule>(); ownsFramework = true; }
            ModuleSystem.GetModule<IUpdateDriver>();
            if (EventSystem.current == null) new GameObject("DE Event System", typeof(EventSystem), typeof(StandaloneInputModule)).transform.SetParent(transform, false);
            cancellation = CancellationTokenSource.CreateLinkedTokenSource(this.GetCancellationTokenOnDestroy());
            OpenAsync(cancellation.Token).Forget();
        }

        public void RetryLogin()
        {
            if (!started || busy || cancellation.IsCancellationRequested) return;
            loadingView?.HideLoginFailure();
            OpenAsync(cancellation.Token).Forget();
        }
        public void CancelLogin()
        {
            cancelRequested = true;
            loadingView?.HideLoginFailure();
            loginAttempt?.Cancel();
            Connection?.Dispose();
            IsReady = IsLoginComplete = false;
            SetPhase("Canceled");
            if (loadingView != null) loadingView.SetStage("登录已取消");
        }

        private async UniTask OpenAsync(CancellationToken token)
        {
            if (busy) return;
            busy = true; cancelRequested = false; Failure = null; IsReady = IsLoginComplete = false;
            loginAttempt?.Dispose();
            loginAttempt = CancellationTokenSource.CreateLinkedTokenSource(token);
            loginAttempt.CancelAfter(TimeSpan.FromSeconds(90));
            var attemptToken = loginAttempt.Token;
            try
            {
                if (settings == null) throw new InvalidOperationException("Production boot settings are missing. Prepare the DE production project before running.");
                SetPhase("Initializing framework resources");
                if (!resourcesReady) { await InitializeResources(attemptToken); resourcesReady = true; }
                if (Content == null) Content = new DeContentCatalog();
                if (!contentReady) { await Content.InitializeAsync(attemptToken); contentReady = true; }
                if (Localization == null) Localization = await Content.LoadLanguageAsync(settings.language, attemptToken);
                if (loadingView == null) loadingView = await ProductionLoadingView.CreateAsync(new LegacyLoadingConfiguration(key => Localization.Get(key), settings.language), attemptToken);
                var bootCamera = GameObject.Find("DE Bootstrap Camera")?.GetComponent<Camera>();
                if (bootCamera != null) bootCamera.enabled = false;
                loadingView.SetProgress(.05f);
                var device = PlayerPrefs.GetString(settings.dedicatedDevicePreferenceKey, string.Empty);
                if (string.IsNullOrEmpty(device))
                {
                    device = "de-rewrite-test-" + Guid.NewGuid().ToString("N");
                    PlayerPrefs.SetString(settings.dedicatedDevicePreferenceKey, device); PlayerPrefs.Save();
                }
                if (Connection != null) { Connection.StatusChanged -= OnConnectionStatus; Connection.Dispose(); }
                Connection = DeProductionClientFactory.CreateDevelopment(device, settings.ResolveVersionKey(), settings.clientVersion);
                Connection.StatusChanged += OnConnectionStatus;
                await Connection.BeginSessionAsync(attemptToken).AsUniTask();
                Connection.Pump();
                if (!Connection.Status.IsLoggedIn || Connection.CurrentUser == null || Connection.CurrentUser.m_id <= 0)
                    throw new InvalidOperationException("A validated real LOGIN_ACK is required to finish login.");
                IsReady = IsLoginComplete = true;
                loginAttempt.CancelAfter(Timeout.InfiniteTimeSpan);
                Failure = null;
                loadingView.HideLoginFailure();
                loadingView.SetProgress(1, "登录完成");
                SetPhase("LoginComplete");
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { }
            catch (OperationCanceledException) when (cancelRequested) { }
            catch (Exception error)
            {
                Failure = error is OperationCanceledException ? "登录超时，请检查连接后重试。" : error.Message;
                SetPhase("Faulted");
                if (loadingView != null) loadingView.ShowLoginFailure(FriendlyNetworkFailure(), RetryLogin, CancelLogin);
                Debug.LogError("[DE production] " + error.GetType().Name + ": " + Failure);
            }
            finally { busy = false; }
        }

        private async UniTask InitializeResources(CancellationToken token)
        {
            var resource = ModuleSystem.GetModule<IResourceModule>();
#if UNITY_EDITOR
            var mode = EPlayMode.EditorSimulateMode;
#else
            var mode = EPlayMode.OfflinePlayMode;
#endif
            resource.DefaultPackageName = settings.resourcePackage;
            resource.PlayMode = mode;
            resource.Initialize();
            var package = YooAssets.TryGetPackage(settings.resourcePackage);
            if (package == null || package.InitializeStatus != EOperationStatus.Succeed)
            {
                var initialization = await resource.InitPackage(settings.resourcePackage, mode);
                if (initialization == null || initialization.Status != EOperationStatus.Succeed) throw new InvalidOperationException(initialization?.Error ?? "Resource package initialization failed.");
            }
            token.ThrowIfCancellationRequested();
            package = YooAssets.GetPackage(settings.resourcePackage);
            var version = package.RequestPackageVersionAsync();
            await version.ToUniTask().AttachExternalCancellation(token);
            if (version.Status != EOperationStatus.Succeed) throw new InvalidOperationException(version.Error);
            var manifest = package.UpdatePackageManifestAsync(version.PackageVersion);
            await manifest.ToUniTask().AttachExternalCancellation(token);
            if (manifest.Status != EOperationStatus.Succeed) throw new InvalidOperationException(manifest.Error);
            resource.PackageVersion = version.PackageVersion;
        }

        private void OnConnectionStatus(ProductionConnectionStatus status)
        {
            if (cancelRequested) return;
            if (status.Phase == ProductionConnectionPhase.LoginAck && status.IsLoggedIn && Connection?.CurrentUser?.m_id > 0)
            {
                IsReady = IsLoginComplete = true;
                Failure = null;
                if (loadingView != null) { loadingView.HideLoginFailure(); loadingView.SetProgress(1, "登录完成"); }
                SetPhase("LoginComplete"); return;
            }
            if (status.Phase == ProductionConnectionPhase.Disconnected || status.Phase == ProductionConnectionPhase.Faulted)
            {
                IsReady = IsLoginComplete = false;
                if (!busy)
                {
                    Failure = status.Message;
                    if (loadingView != null) loadingView.ShowLoginFailure(FriendlyNetworkFailure(), RetryLogin, CancelLogin);
                }
                SetPhase(status.Phase.ToString()); return;
            }
            if (!busy && Failure != null) return;
            if (!status.IsLoggedIn) IsReady = IsLoginComplete = false;
            SetPhase(status.Phase.ToString());
            if (loadingView != null)
            {
                var progress = status.Phase == ProductionConnectionPhase.FetchingStartup ? .1f : status.Phase == ProductionConnectionPhase.Authenticating ? .35f : status.Phase == ProductionConnectionPhase.ConnectingGateway ? .55f : status.Phase == ProductionConnectionPhase.WaitingSessionToken ? .65f : status.Phase == ProductionConnectionPhase.LoggingIn ? .8f : .05f;
                loadingView.SetProgress(progress, LocalizedOr("Fps_ui_text_14", "加载中…"));
            }
        }
        private string LocalizedOr(string key, string fallback)
        {
            var value = Localization?.Get(key);
            return value == null || value.StartsWith("lc_error:", StringComparison.Ordinal) ? fallback : value;
        }
        private string FriendlyNetworkFailure() => LocalizedOr("LC_COMMON_Cannot_login_text1", "无法连接服务器，请检查网络后重试。");
        private void OnLoadingProgress(ProductionLoadingProgress progress)
        {
            SetPhase(progress.Stage);
            if (loadingView != null) loadingView.SetProgress(.3f + .5f * progress.Completed / progress.Total, progress.Stage);
        }
        private void SetPhase(string value) { Phase = value; StateChanged?.Invoke(); }
        private void Update() { Connection?.Pump(); }
        private void OnDestroy()
        {
            if (!started) return;
            cancellation?.Cancel();
            loginAttempt?.Cancel();
            Loading?.Dispose(); Connection?.Dispose();
            loadingView?.Dispose(); Localization?.ClearServerOverrides(); Content?.Dispose();
            cancellation?.Dispose();
            loginAttempt?.Dispose();
            if (Current == this) Current = null;
            StateChanged = null;
            SingletonSystem.Release();
            if (ownsFramework) ModuleSystem.Shutdown();
        }
    }
}
