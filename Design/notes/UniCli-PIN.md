# UniCli integration pin

- Official Unity CLI already installed: 1.0.0-beta.8. Its Pipeline Editor bridge requires Unity 6.0 LTS or newer and is not selected for Unity 2022.3.62f2.
- Selected upstream: https://github.com/yucchiy/UniCli
- Package/CLI version: 1.7.0; tag v1.7.0; source revision 647b1f41c755fdc10985b0166938b68f0545210c.
- Package declares Unity 2022.3 minimum and no package dependencies. Editor bridge is required; installing a CLI binary alone cannot inspect the Editor.
- Windows release: https://github.com/yucchiy/UniCli/releases/download/v1.7.0/unicli-win-x64.zip
- ZIP SHA256 verified against GitHub asset digest: ce599721bd6c793853e517aa98a971632bfbd3fdb83c219f307b3fe9522a738b.
- Downloaded executable and unmodified upstream clone remain under ignored Design/local.
- Embedded package preserves upstream sources, metadata, package identity and root license. Local adaptation: remove the unconditional Unity.Recorder.Editor reference from Editor/UniCli.Server.Editor.asmdef, because Recorder is absent and all recorder handlers already use UNICLI_RECORDER conditional compilation. No Recorder package is installed. Original asmdef is available in the pinned clone. No other source changes.
- Tools/Invoke-UniCli.ps1 sets UNICLI_FOCUS=0, validates CLI version and, for commands, validates server.pid, Unity.exe identity/version and exact -projectPath. It uses UniCli's version-1 named-pipe protocol directly, avoiding the upstream exec auto-launch fallback entirely. It has a total timeout, including command execution after ACK.
- `check` and `status` use upstream read-only probing paths, with no launch/focus fallback. Commands that show modal dialogs or focus windows are not suitable for unattended automation.
- Initial binary checks passed: version 1.7.0, check correctly reported bridge not installed, status reported no server. No Editor process was opened or restarted by these checks. Subsequent actual Editor validation succeeded: state/console reads, script refresh and reload, Play enter/exit, 18 passing network EditMode tests, 750x1334 screenshots, and original DE retry/cancel EventSystem pointer input. Domain reload can temporarily close the pipe; inspect state before retrying any mutation.

Examples from the repository root:

```powershell
pwsh -File UnityProject2/Tools/Invoke-UniCli.ps1 -Action check
pwsh -File UnityProject2/Tools/Invoke-UniCli.ps1 -Action status
pwsh -File UnityProject2/Tools/Invoke-UniCli.ps1 -Action exec -CommandName Editor.Status
pwsh -File UnityProject2/Tools/Invoke-UniCli.ps1 -Action exec -CommandName Console.GetLog -DataJson '{"logType":"Error","count":100}'
pwsh -File UnityProject2/Tools/Invoke-UniCli.ps1 -Action eval -Code 'return UnityEngine.Application.unityVersion;'
```

Official compatibility reference: https://unity.com/blog/meet-the-unity-cli (Pipeline Unity 6.0 LTS+).
Upstream requirements/focus behavior: https://github.com/yucchiy/UniCli/blob/647b1f41c755fdc10985b0166938b68f0545210c/README.md.
