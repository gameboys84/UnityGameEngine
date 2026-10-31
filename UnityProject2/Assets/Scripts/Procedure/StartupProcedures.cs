using System;
using System.Reflection;
using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;
namespace Procedure
{
    public sealed class ProcedureLaunch : ProcedureBase
    {
        private readonly StartupContext context;
        public ProcedureLaunch(StartupContext context) { this.context = context; }
        protected override void OnEnter(IFsm<IProcedureModule> owner) { context.View.Show("Preparing your game", 0); }
        protected override void OnUpdate(IFsm<IProcedureModule> owner, float delta, float realDelta)
        { ChangeState<ProcedureInitResources>(owner); }
    }

    /// <summary>Init -> version -> manifest -> download -> preload. FSM owns all transitions.</summary>
    public sealed class ProcedureInitResources : ProcedureBase
    {
        private readonly StartupContext context;
        private ResourceDownloaderOperation downloader;
        public ProcedureInitResources(StartupContext context) { this.context = context; }
        protected override void OnEnter(IFsm<IProcedureModule> owner)
        {
            context.Completed = false; context.Error = null;
            InitializeAsync().Forget();
        }
        protected override void OnUpdate(IFsm<IProcedureModule> owner, float delta, float realDelta)
        {
            if (context.Completed) ChangeState<ProcedureStartGame>(owner);
            else if (context.Error != null && context.View.RetryRequested) ChangeState<ProcedureInitResources>(owner);
        }
        protected override void OnLeave(IFsm<IProcedureModule> owner, bool shutdown)
        {
            if (downloader != null) { downloader.DownloadUpdateCallback = null; if (shutdown) downloader.CancelDownload(); }
        }
        private async UniTask InitializeAsync()
        {
            try
            {
                var settings = context.Settings;
                var resource = context.Resource;
#if UNITY_EDITOR
                var mode = settings.editorMode;
#else
                var mode = settings.playerMode;
                if (mode == EPlayMode.EditorSimulateMode) throw new InvalidOperationException("Editor simulation cannot be used in a player.");
#endif
                if (string.IsNullOrWhiteSpace(settings.packageName)) throw new InvalidOperationException("Startup package is empty.");
                if (mode == EPlayMode.HostPlayMode && string.IsNullOrWhiteSpace(settings.hostServerURL))
                    throw new InvalidOperationException("Host mode requires a resource server URL.");
                resource.DefaultPackageName = settings.packageName;
                resource.PlayMode = mode;
                resource.HostServerURL = settings.hostServerURL;
                resource.FallbackHostServerURL = string.IsNullOrWhiteSpace(settings.fallbackServerURL) ? settings.hostServerURL : settings.fallbackServerURL;
                resource.Initialize();
                context.ShowStage("Initializing resources", .05f);
                await UniTask.Yield(context.Token);
                var package = YooAssets.GetPackage(settings.packageName);
                if (package.InitializeStatus != EOperationStatus.Succeed)
                {
                    var initialize = await resource.InitPackage(settings.packageName, mode);
                    if (initialize == null || initialize.Status != EOperationStatus.Succeed)
                        throw new InvalidOperationException(initialize?.Error ?? "Package initialization failed.");
                }
                context.Token.ThrowIfCancellationRequested();
                await context.WaitStageAsync();
                context.ShowStage("Checking game version", .2f);
                var version = package.RequestPackageVersionAsync();
                await version.ToUniTask().AttachExternalCancellation(context.Token);
                if (version.Status != EOperationStatus.Succeed) throw new InvalidOperationException(version.Error);
                await context.WaitStageAsync();
                context.ShowStage("Updating resource list", .3f);
                var manifest = package.UpdatePackageManifestAsync(version.PackageVersion);
                await manifest.ToUniTask().AttachExternalCancellation(context.Token);
                if (manifest.Status != EOperationStatus.Succeed) throw new InvalidOperationException(manifest.Error);
                resource.PackageVersion = version.PackageVersion;
                await context.WaitStageAsync();
                context.ShowStage("Preparing game files", .4f);
                downloader = package.CreateResourceDownloader(4, 2);
                if (downloader.TotalDownloadCount > 0)
                {
                    downloader.DownloadUpdateCallback = data => context.View.Show("Downloading game files",
                        .4f + .3f * (data.TotalDownloadBytes == 0 ? 1f : (float)data.CurrentDownloadBytes / data.TotalDownloadBytes));
                    downloader.BeginDownload();
                    await downloader.ToUniTask().AttachExternalCancellation(context.Token);
                    if (downloader.Status != EOperationStatus.Succeed) throw new InvalidOperationException(downloader.Error);
                }
                await context.WaitStageAsync();
                context.ShowStage("Loading essentials", .75f);
                context.Dispose();
                context.PreloadedText = await resource.LoadAssetAsync<TextAsset>(settings.preloadText, context.Token);
                if (context.PreloadedText == null) throw new InvalidOperationException("Required startup content is missing.");
                context.Token.ThrowIfCancellationRequested();
                await context.WaitStageAsync();
                context.Completed = true;
            }
            catch (OperationCanceledException) when (context.Token.IsCancellationRequested) { }
            catch (Exception error)
            {
                context.Error = error;
                Debug.LogError($"Startup failed: {error}");
                if (!context.Token.IsCancellationRequested) context.View.ShowError();
            }
        }
    }

    public sealed class ProcedureStartGame : ProcedureBase
    {
        private readonly StartupContext context;
        private bool busy;
        public ProcedureStartGame(StartupContext context) { this.context = context; }
        protected override void OnEnter(IFsm<IProcedureModule> owner) { StartAsync().Forget(); }
        protected override void OnUpdate(IFsm<IProcedureModule> owner, float delta, float realDelta)
        { if (!busy && context.Error != null && context.View.RetryRequested) StartAsync().Forget(); }
        private async UniTask StartAsync()
        {
            busy = true; context.Error = null;
            try
            {
                var type = Type.GetType(context.Settings.gameEntryType, true);
                var entrance = type.GetMethod("Entrance", BindingFlags.Public | BindingFlags.Static);
                if (entrance == null) throw new MissingMethodException(type.FullName, "Entrance");
                context.ShowStage("Entering the game", .85f);
                var scene = SceneManager.GetActiveScene();
                if (scene.path != context.Settings.mainScene)
                    scene = await ModuleSystem.GetModule<ISceneModule>().LoadSceneAsync(context.Settings.mainScene,
                        progressCallBack: progress => context.View.Show("Entering the game", .85f + progress * .14f));
                context.Token.ThrowIfCancellationRequested();
                if (!scene.IsValid() || !scene.isLoaded) throw new InvalidOperationException("Main scene could not be loaded.");
                SceneManager.SetActiveScene(scene);
                entrance.Invoke(null, new object[] { new object[] { context.PreloadedText.text } });
                context.Dispose();
                await context.WaitStageAsync();
                context.View.Show("Ready", 1);
                await UniTask.Yield(context.Token);
                context.View.Hide();
                context.Ready();
            }
            catch (OperationCanceledException) when (context.Token.IsCancellationRequested) { }
            catch (Exception error)
            {
                context.Error = error;
                Debug.LogError($"Game entry failed: {error}");
                if (!context.Token.IsCancellationRequested) context.View.ShowError();
            }
            finally { busy = false; }
        }
    }
}
