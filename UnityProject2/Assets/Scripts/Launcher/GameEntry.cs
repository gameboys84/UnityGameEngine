using Launcher;
using Procedure;
using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

/// <summary>Native entry, independent of the game assembly.</summary>
[RequireComponent(typeof(RootModule))]
public sealed class GameEntry : MonoBehaviour
{
    public StartupSettings settings;
    public LauncherView launcher;
    public bool IsReady { get; private set; }
    private static GameEntry instance;
    private StartupContext context;
    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(gameObject); return; }
        instance = this;
        ModuleSystem.GetModule<IUpdateDriver>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (instance != this || settings == null || launcher == null) return;
        context = new StartupContext(settings, launcher, this.GetCancellationTokenOnDestroy(), () => IsReady = true);
        var module = ModuleSystem.GetModule<IProcedureModule>();
        module.Initialize(ModuleSystem.GetModule<IFsmModule>(),
            new ProcedureLaunch(context), new ProcedureInitResources(context), new ProcedureStartGame(context));
        module.StartProcedure<ProcedureLaunch>();
    }

    private void OnDestroy()
    {
        if (instance != this) return;
        context?.Dispose();
#if UNITY_EDITOR
        ModuleSystem.Shutdown();
#endif
        instance = null;
    }
}
