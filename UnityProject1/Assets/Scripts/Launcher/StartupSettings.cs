using UnityEngine;
using YooAsset;
namespace Launcher
{
    [CreateAssetMenu(menuName = "TEngine/Startup Settings")]
    public sealed class StartupSettings : ScriptableObject
    {
        public string packageName = "DefaultPackage";
        public EPlayMode editorMode = EPlayMode.EditorSimulateMode;
        public EPlayMode playerMode = EPlayMode.OfflinePlayMode;
        public string hostServerURL;
        public string fallbackServerURL;
        public string mainScene = "Assets/AssetBundle/Scenes/Main.unity";
        public string preloadText = "Assets/AssetBundle/Config/startup-message.txt";
        public string gameEntryType = "GameRuntime.GameApp, GameRuntime";
        [Range(0, 2)] public float previewStageSeconds = .4f;
        public bool previewDelaysInPlayer;
    }
}
