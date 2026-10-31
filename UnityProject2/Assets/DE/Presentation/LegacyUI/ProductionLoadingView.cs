using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DE.Presentation.LegacyUI
{
    public sealed class LegacyLoadingConfiguration
    {
        public Func<string, string> Localize { get; }
        public string LanguageCode { get; }
        public Func<string> NextTip { get; }
        public Texture2D SplashOverride { get; }
        public LegacyLoadingConfiguration(Func<string, string> localize, string languageCode = "en",
            Func<string> nextTip = null, Texture2D splashOverride = null)
        {
            Localize = localize ?? throw new ArgumentNullException(nameof(localize));
            LanguageCode = languageCode ?? "en"; NextTip = nextTip; SplashOverride = splashOverride;
        }
    }

    public static class LegacyLoadingContext
    {
        internal static LegacyLoadingConfiguration Current;
        public static bool IsCjk => Current != null && IsCjkLanguage(Current.LanguageCode);
        public static bool IsCjkLanguage(string language)
        {
            if (string.IsNullOrEmpty(language)) return false;
            return language.Equals("cn", StringComparison.OrdinalIgnoreCase) || language.Equals("jp", StringComparison.OrdinalIgnoreCase)
                || language.Equals("kr", StringComparison.OrdinalIgnoreCase) || language.StartsWith("zh", StringComparison.OrdinalIgnoreCase)
                || language.StartsWith("ja", StringComparison.OrdinalIgnoreCase) || language.StartsWith("ko", StringComparison.OrdinalIgnoreCase);
        }
        public static string Localize(string key)
        {
            if (Current == null) throw new InvalidOperationException("Configure the real DE loading localization before instantiation.");
            return Current.Localize(key);
        }
    }

    /// <summary>Owns the unmodified DE loading hierarchy and its YooAsset lease; accepts real startup/network progress only.</summary>
    public sealed class ProductionLoadingView : MonoBehaviour, IDisposable
    {
        public const string AssetPath = "Assets/AssetBundle/DE/Legacy/Loading/LoadingScreenSplash.prefab";
        public const string FailureAssetPath = "Assets/AssetBundle/DE/Legacy/Loading/LoginFailureCommon.prefab";
        AssetLease<GameObject> source;
        AssetLease<GameObject> failureSource;
        LegacyLoadingConfiguration configuration;
        LoadingScreenSimple screen;
        bool disposed;
        GameObject failureHost;
        UPopMsgBoxLoginCommon failurePanel;
        public LoadingScreenSimple OriginalScreen => screen;
        public UPopMsgBoxLoginCommon OriginalFailurePanel => failurePanel;
        public string CurrentStage { get; private set; }
        public bool HasFailure { get; private set; }
        public bool FailureDialogVisible => failureHost != null && failureHost.activeSelf;

        public static UniTask<ProductionLoadingView> CreateAsync(Func<string, string> localize,
            CancellationToken cancellationToken = default)
            => CreateAsync(new LegacyLoadingConfiguration(localize), cancellationToken);

        public static async UniTask<ProductionLoadingView> CreateAsync(LegacyLoadingConfiguration configuration,
            CancellationToken cancellationToken = default)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (LegacyLoadingContext.Current != null) throw new InvalidOperationException("A real DE loading screen is already active.");
            var lease = await new ResourceReference(AssetPath).LoadAsync<GameObject>(cancellationToken);
            AssetLease<GameObject> errorLease = null;
            GameObject instance = null;
            try
            {
                errorLease = await new ResourceReference(FailureAssetPath).LoadAsync<GameObject>(cancellationToken);
                foreach (var transform in lease.Asset.GetComponentsInChildren<Transform>(true))
                    foreach (var component in transform.GetComponents<Component>())
                        if (component == null) throw new InvalidOperationException("Original DE loading prefab has a missing component at " + transform.name);
                var original = lease.Asset.GetComponent<LoadingScreenSimple>();
                if (original == null || original.loading == null || original.txtLoading == null || original.percent == null || original.splashBG == null)
                    throw new InvalidOperationException("Original DE loading prefab is missing its serialized control bindings.");
                foreach (var transform in errorLease.Asset.GetComponentsInChildren<Transform>(true))
                    foreach (var component in transform.GetComponents<Component>())
                        if (component == null) throw new InvalidOperationException("Original DE login CommonMsgBox has a missing component at " + transform.name);
                var common = errorLease.Asset.GetComponent<UPopMsgBoxLoginCommon>();
                if (common == null) throw new InvalidOperationException("Original CommonMsgBox controller was not preserved.");
                common.ValidateBindings();
                LegacyLoadingContext.Current = configuration;
                instance = Instantiate(lease.Asset);
                DontDestroyOnLoad(instance);
                var view = instance.AddComponent<ProductionLoadingView>();
                view.configuration = configuration; view.source = lease;
                view.failureSource = errorLease;
                view.screen = instance.GetComponent<LoadingScreenSimple>();
                if (view.screen == null) throw new InvalidOperationException("Original DE LoadingScreenSimple component was not retained.");
                if (!view.screen.IsInitialized) throw new InvalidOperationException("Original DE loading Awake failed; do not continue startup behind a broken visual.");
                view.screen.SetLoadingView(false);
                var localized = view.screen.txtLoading as TextCustom;
                view.SetStage(localized != null && !string.IsNullOrEmpty(localized.GetLOCKey())
                    ? configuration.Localize(localized.GetLOCKey()) : view.screen.txtLoading.text);
                return view;
            }
            catch
            {
                if (instance != null) Destroy(instance);
                lease.Dispose();
                errorLease?.Dispose();
                if (ReferenceEquals(LegacyLoadingContext.Current, configuration)) LegacyLoadingContext.Current = null;
                throw;
            }
        }

        public void SetStage(string message)
        {
            RequireAlive(); CurrentStage = message ?? ""; HasFailure = false;
            HideLoginFailure();
            screen.SetRuntimeStatus(CurrentStage, null, false);
        }

        public void SetProgress(float progress, string stage = null)
        {
            RequireAlive();
            if (float.IsNaN(progress) || float.IsInfinity(progress) || progress < 0 || progress > 1)
                throw new ArgumentOutOfRangeException(nameof(progress), "Progress is a real measured fraction in [0,1].");
            if (stage != null) CurrentStage = stage;
            HideLoginFailure();
            HasFailure = false; screen.SetRuntimeStatus(CurrentStage, progress * 100f, false);
        }

        public void SetFailure(string message)
        {
            RequireAlive(); CurrentStage = message ?? ""; HasFailure = true;
            screen.SetRuntimeStatus(CurrentStage, null, true);
        }

        public void ShowLoginFailure(string safeMessage, Action retry, Action cancel)
        {
            RequireAlive();
            if (retry == null) throw new ArgumentNullException(nameof(retry));
            SetFailure(safeMessage);
            if (failureHost == null)
            {
                failureHost = new GameObject("DE.OriginalLoginFailure.Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
                failureHost.layer = 5; failureHost.transform.SetParent(transform, false);
                var canvas = failureHost.GetComponent<Canvas>(); canvas.renderMode = RenderMode.ScreenSpaceOverlay; canvas.sortingOrder = 30000;
                var scaler = failureHost.GetComponent<CanvasScaler>();
                // Exact original DeviceRelated scale: min(width/750,height/1334).
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(750, 1334); scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                failurePanel = Instantiate(failureSource.Asset, failureHost.transform, false).GetComponent<UPopMsgBoxLoginCommon>();
                failurePanel.BindClose(HideLoginFailure);
            }
            failureHost.SetActive(true);
            failurePanel.ShowMsgBox(2, configuration.Localize("LC_COMMON_splash_hint_2_title"), safeMessage,
                () => retry(), () => cancel?.Invoke(), configuration.Localize("LC_OTHER_FPS_Result_Retry"), configuration.Localize("LC_COMMON_Cancel"));
            EventSystem.current?.SetSelectedGameObject(failurePanel.btn_yes);
        }

        public void HideLoginFailure()
        {
            if (failurePanel != null) failurePanel.ClearCallbacks();
            if (failureHost != null) failureHost.SetActive(false);
        }

        void RequireAlive() { if (disposed || screen == null) throw new ObjectDisposedException(nameof(ProductionLoadingView)); }
        public void Dispose() { if (disposed) return; disposed = true; if (this != null) Destroy(gameObject); }
        void OnDestroy()
        {
            disposed = true;
            source?.Dispose(); source = null;
            failureSource?.Dispose(); failureSource = null;
            if (ReferenceEquals(LegacyLoadingContext.Current, configuration)) LegacyLoadingContext.Current = null;
        }
    }
}
