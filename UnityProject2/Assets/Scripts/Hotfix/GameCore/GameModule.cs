using TEngine;

namespace GameCore
{
    /// <summary>Shared framework access. No game data, protocols or network implementation dependencies.</summary>
    public static class GameModule
    {
        public static IResourceModule Resource => ModuleSystem.GetModule<IResourceModule>();
        public static ISceneModule Scene => ModuleSystem.GetModule<ISceneModule>();
        public static ITimerModule Timer => ModuleSystem.GetModule<ITimerModule>();
        public static IAudioModule Audio => ModuleSystem.GetModule<IAudioModule>();
        public static IFsmModule Fsm => ModuleSystem.GetModule<IFsmModule>();
        public static IDebuggerModule Debugger => ModuleSystem.GetModule<IDebuggerModule>();
        public static ILocalSaveModule LocalSave => ModuleSystem.GetModule<ILocalSaveModule>();
        public static UIModule UI => UIModule.Instance;
    }
}
