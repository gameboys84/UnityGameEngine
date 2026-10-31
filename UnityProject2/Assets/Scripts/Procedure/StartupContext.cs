using System;
using System.Threading;
using Launcher;
using TEngine;
using UnityEngine;
using Cysharp.Threading.Tasks;
namespace Procedure
{
    public sealed class StartupContext : IDisposable
    {
        public readonly StartupSettings Settings;
        public readonly LauncherView View;
        public readonly CancellationToken Token;
        public readonly IResourceModule Resource;
        public readonly Action Ready;
        public TextAsset PreloadedText;
        public Exception Error;
        public bool Completed;
        private float stageStarted;
        public void ShowStage(string message, float progress)
        {
            stageStarted = Time.realtimeSinceStartup;
            View.Show(message, progress);
        }
        public async UniTask WaitStageAsync()
        {
#if UNITY_EDITOR
            float minimum = Settings.previewStageSeconds;
#else
            float minimum = Settings.previewDelaysInPlayer ? Settings.previewStageSeconds : 0;
#endif
            float remaining = Mathf.Clamp(minimum, 0, 2) - (Time.realtimeSinceStartup - stageStarted);
            if (remaining > 0) await UniTask.Delay(TimeSpan.FromSeconds(remaining), ignoreTimeScale: true, cancellationToken: Token);
        }
        public StartupContext(StartupSettings settings, LauncherView view, CancellationToken token, Action ready)
        {
            Settings = settings; View = view; Token = token; Ready = ready;
            Resource = ModuleSystem.GetModule<IResourceModule>();
        }
        public void Dispose()
        {
            if (PreloadedText != null) Resource.UnloadAsset(PreloadedText);
            PreloadedText = null;
        }
    }
}
