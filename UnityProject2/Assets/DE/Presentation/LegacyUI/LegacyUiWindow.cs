using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;

namespace DE.Presentation.LegacyUI
{
    public enum LegacyUiScreen { LoadingSplash, AccountLogin, CityHud, KvkHud }

    /// <summary>
    /// Composition contract for real DE runtime services. Implementations must initialize the original
    /// business managers and reduce real server responses before permitting the matching source UI.
    /// An implementation backed only by Mock fixtures does not satisfy this contract.
    /// </summary>
    public interface ILegacyUiRuntime
    {
        UniTask EnsureReadyAsync(LegacyUiScreen screen, CancellationToken cancellationToken);
        void ValidatePrefab(LegacyUiScreen screen, GameObject sourcePrefab);
        IDisposable Attach(LegacyUiScreen screen, GameObject instance);
    }

    public sealed class LegacyUiWindowContext
    {
        public ILegacyUiRuntime Runtime { get; }
        public LegacyUiScreen Screen { get; }
        public LegacyUiWindowContext(ILegacyUiRuntime runtime, LegacyUiScreen screen)
        { Runtime = runtime ?? throw new ArgumentNullException(nameof(runtime)); Screen = screen; }
    }

    public static class LegacyUiWindows
    {
        public const string LoadingPath = "Assets/DE/LegacyAssets/Resources/UI/LoadingBG/LoadingScreenSplash.prefab";
        public const string LoginPath = "Assets/DE/LegacyAssets/ResourcesExtra/UINew/canvas/Account_Login.prefab";
        public const string HudPath = "Assets/DE/LegacyAssets/ResourcesExtra/UINew/canvas/UICanvas.prefab";
        public const string KvkHudPath = "Assets/DE/LegacyAssets/ResourcesExtra/UINew/canvas/UICanvasKVK.prefab";

        public static async UniTask<UIWindow> OpenAsync(ILegacyUiRuntime runtime, LegacyUiScreen screen,
            CancellationToken cancellationToken = default)
        {
            if (runtime == null) throw new ArgumentNullException(nameof(runtime));
            if (screen == LegacyUiScreen.LoadingSplash)
                throw new InvalidOperationException("The original loading prefab has a Transform/camera root. Open it with ProductionLoadingView.CreateAsync, preserving its hierarchy.");
            // This occurs before loading/instantiation: original Awake methods can read global game data.
            await runtime.EnsureReadyAsync(screen, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            using (var lease = await new ResourceReference(Path(screen)).LoadAsync<GameObject>(cancellationToken))
            {
                if (lease.Asset == null) throw new InvalidOperationException("Original DE prefab is unavailable: " + Path(screen));
                AssertNoMissingScripts(lease.Asset);
                if (lease.Asset.GetComponent<Canvas>() == null)
                    throw new InvalidOperationException("The original DE prefab needs a validated framework Canvas wrapper; its hierarchy must not be flattened or replaced.");
                runtime.ValidatePrefab(screen, lease.Asset);
            }
            var context = new LegacyUiWindowContext(runtime, screen);
            switch (screen)
            {
                case LegacyUiScreen.LoadingSplash: return await UIModule.Instance.ShowUIAsyncAwait<LegacyLoadingWindow>(cancellationToken, context);
                case LegacyUiScreen.AccountLogin: return await UIModule.Instance.ShowUIAsyncAwait<LegacyAccountLoginWindow>(cancellationToken, context);
                case LegacyUiScreen.CityHud: return await UIModule.Instance.ShowUIAsyncAwait<LegacyCityHudWindow>(cancellationToken, context);
                case LegacyUiScreen.KvkHud: return await UIModule.Instance.ShowUIAsyncAwait<LegacyKvkHudWindow>(cancellationToken, context);
                default: throw new ArgumentOutOfRangeException(nameof(screen));
            }
        }

        public static string Path(LegacyUiScreen screen)
        {
            switch (screen)
            {
                case LegacyUiScreen.LoadingSplash: return LoadingPath;
                case LegacyUiScreen.AccountLogin: return LoginPath;
                case LegacyUiScreen.CityHud: return HudPath;
                case LegacyUiScreen.KvkHud: return KvkHudPath;
                default: throw new ArgumentOutOfRangeException(nameof(screen));
            }
        }

        static void AssertNoMissingScripts(GameObject prefab)
        {
            foreach (var transform in prefab.GetComponentsInChildren<Transform>(true))
                foreach (var component in transform.GetComponents<Component>())
                    if (component == null)
                        throw new InvalidOperationException("Original DE UI has a missing script at " + transform.name + ". Import the validated component dependency closure before opening it.");
        }
    }

    /// <summary>Framework ownership adapter. It does not rebuild the original hierarchy or replace business listeners.</summary>
    public abstract class LegacyDeWindow : UIWindow
    {
        IDisposable binding;
        protected abstract LegacyUiScreen Screen { get; }
        protected override void OnCreate()
        {
            // Anchor the source root while preserving child layout, artwork, serialized component data and events.
            rectTransform.anchorMin = Vector2.zero; rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = rectTransform.offsetMax = Vector2.zero;
            rectTransform.localScale = Vector3.one; rectTransform.localRotation = Quaternion.identity;
        }
        protected override void OnRefresh()
        {
            var context = UserData as LegacyUiWindowContext;
            if (context == null || context.Screen != Screen) throw new InvalidOperationException("A matching real DE runtime context is required.");
            binding?.Dispose();
            binding = context.Runtime.Attach(Screen, gameObject);
            if (binding == null) throw new InvalidOperationException("Real DE runtime did not bind the original UI.");
        }
        protected override void OnDestroy() { binding?.Dispose(); binding = null; }
    }

    [Window(UILayer.System, LegacyUiWindows.LoadingPath, fullScreen: true, hideTimeToClose: 0)]
    public sealed class LegacyLoadingWindow : LegacyDeWindow { protected override LegacyUiScreen Screen => LegacyUiScreen.LoadingSplash; }
    [Window(UILayer.Top, LegacyUiWindows.LoginPath, fullScreen: true, hideTimeToClose: 0)]
    public sealed class LegacyAccountLoginWindow : LegacyDeWindow { protected override LegacyUiScreen Screen => LegacyUiScreen.AccountLogin; }
    [Window(UILayer.Bottom, LegacyUiWindows.HudPath, fullScreen: true, hideTimeToClose: 0)]
    public sealed class LegacyCityHudWindow : LegacyDeWindow { protected override LegacyUiScreen Screen => LegacyUiScreen.CityHud; }
    [Window(UILayer.Bottom, LegacyUiWindows.KvkHudPath, fullScreen: true, hideTimeToClose: 0)]
    public sealed class LegacyKvkHudWindow : LegacyDeWindow { protected override LegacyUiScreen Screen => LegacyUiScreen.KvkHud; }
}
