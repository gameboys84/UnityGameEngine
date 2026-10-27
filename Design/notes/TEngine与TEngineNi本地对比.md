# TEngine 与 TEngineNi 本地对比

日期：2026-10-11。范围：两个本地 Git 工作树、提交历史、工程设置、依赖与重点源码。未访问远程更新，未运行 Unity、构建或真机测试，未修改两个来源工程。

## 结论

建议优先以 TEngineNi 的 testMain 分支作为验证基础，保留 TEngine/main 作为上游对照。fork 已包含当前本地上游全部提交，已升级到目标 Unity 版本，并具有程序集分层、多语言、存档和 Android 热更新相关改造。无需重新从上游逐项组装这些功能。

这仍是候选验证基础，不是已验收的可发布框架。优先解决退出、存档、图集加载生命周期和校验脚本路径问题，并将网络实现与业务入口解耦。

## Git 基线

| 项目 | TEngine | TEngineNi |
|---|---|---|
| 本地路径 | E:/Git/TEngine | E:/Git/TEngineNi |
| origin | git@github.com:Alex-Rachel/TEngine.git | git@github.com:gameboys84/TEngine.git |
| 当前分支 | main | testMain |
| HEAD | c06820cb92c5bde03e7d7b30b1b0e1427d33d388 | 4a65f9cd849ecd3e722875470e3d277a594f9f7b |
| HEAD 内容 | unity cli | Merge branch main into testMain |
| Unity | 2021.3.45f1 | 2022.3.62f2 |
| 工作树 | 干净 | 干净 |

`merge-base(TEngine HEAD, TEngineNi HEAD)` 等于 TEngine HEAD，证明当前本地上游是 fork HEAD 的祖先。fork 相对上游有 48 个可达提交，包含 merge 提交，不应称作 48 次独立功能改造。

两棵 HEAD 树的总差异为 1093 文件、130220 行新增、2033 行删除，包含目录移动、服务端、生成代码、第三方内容及资源，不代表核心框架改动规模。没有 fetch，不能据此宣称已经同步远程最新版本。

## 模块差异

| 范围 | 实际差异 | 复用判断 |
|---|---|---|
| 资源 | ResourceModule 仅新增 using/空白；Driver 增加空值访问保护。嵌入 YooAsset 只调整默认忽略规则 | 资源核心基本沿用上游，便于继续同步 |
| 场景 | SceneModule 路径在 Git 比较中无差异 | fork 未另造场景系统；异步取消和卸载风险仍按上游实现验证 |
| UI | GameScripts/HotFix/GameLogic/Module/UIModule 移到 Scripts/Hotfix/GameCore/Module/UIModule，命名空间改为 GameCore；额外只发现 Injector 可空标记去除与窗口准备日志等小改 | 生命周期/await 核心基本沿用上游，主要收益是 UI 框架与业务分离 |
| 程序集 | 从 GameProto、GameLogic 拆为 GameProto、GameCore、GameRuntime，另有 AOT | 适合长期复用与多个 Demo；AOT 内容仍有工具性质临时代码 |
| 热更新 | 主入口改为 GameCore.dll；热更列表/HybridCLR asmdef 配置对应三程序集；DLL 收集移到 AssetBundle/DLL | 配置结构比原样例更贴近当前目标；需重跑真实构建验证 |
| 多语言 | Launcher 与业务文本区分、Luban 文本表、StringManager、语言转换、Sprite 处理、RTL 格式化及 RTLTMPro | 是 fork 最有价值的扩展之一；字体与动态资源加载仍需真机验证 |
| 本地存档 | LocalSaveModule、序列化接口、可选加密、文件工具 | 能作为基础，但当前同步 IO、路径和失败反馈不适合直接作为最终接口 |
| 网络 | Fantasy Git 包、协议生成、NetworkFantasyModule、登录网络测试和 Server 目录 | 可以保留为可选实现，但目前 GameCore/GameApp/协议与 Fantasy 有实际耦合 |
| 配置与构建 | Luban 导出路径迁移；资源目录 AssetBundle；Bundle 输出目录与 Android APK 名称调整 | 值得保留；AI 校验脚本未完成同样的路径迁移 |

程序集定义显示 GameRuntime 引用 GameCore 和 GameProto，GameCore 引用 GameProto，已形成核心/业务分层。GameApp 还使用 Fantasy.Helper；GameModule.Network 返回具体 Fantasy 接口，不能仅通过删掉 Server 目录就认定网络依赖可选。

## 依赖与运行记录

- 两工程嵌入 YooAsset 版本均为 2.3.17、UniTask 均为 2.5.11，fork 资源库不是另一套重写实现。
- HybridCLR 在 manifest 中使用未带 tag/commit 的 Git URL，但 packages-lock 保存相同 hash：4df417e56ad827cd7e70a54662f0e8bab90aafe9。当前解析结果有锁，重解析时仍应控制版本。
- fork 新增 Fantasy Git 依赖，lock hash 为 eb3b6b06ba80b025fd12f3256f897aea561e8dee，并增加 TMP 3.0.9、2D Sprite、RTLTMPro 等。
- 两工程 manifest 都声明 uGUI 2.0.0。当前未通过 Unity 解析验证，不能仅凭版本文件断言兼容目标编辑器，也不应在未验证时自动升级或降级。
- fork Android 设置已配置 IL2CPP、ARM64 及热更宏。历史提交写有 Android 更新测试成功、裁剪配置试验、多语言测试完成；这是作者当时的记录，不等于当前 HEAD 已由本次检查验收。
- fork 的 Tools/build-luban.bat 使用外部 Luban 源目录并会拉取更新；复现流程应锁定工具版本，核对工作目录与输出路径。本次未运行该脚本。

## 优先问题与证据

### 1. 未连接网络退出可能抛空引用

[NetworkFantasyModule.cs](E:/Git/TEngineNi/UnityProject/Assets/Scripts/Hotfix/GameCore/Module/NetworkModule/NetworkFantasyModule.cs:29) 在 Shutdown 开头无条件 `_scene.Dispose()`。当前文件定义 USING_FANTASY_RUNTIME，初始化路径不会创建 `_scene`，它在连接成功回调才赋值。因此模块初始化后尚未连接成功便关闭，是静态可确认的空引用路径。后续 Runtime.OnDestroy 也可能因此无法执行。

建议独立检查会话、Scene 和 Runtime 的所有权，支持未连接、连接失败与重复退出。

### 2. Player 存档路径拼接错误，失败结果没有传递

[Utility.FileUtils.cs](E:/Git/TEngineNi/UnityProject/Assets/TEngine/Runtime/Core/Utility/Utility.FileUtils.cs:126) 在非 Editor 分支拼接 `persistentDataPath + Path.PathSeparator + filePath`。Path.PathSeparator 是路径列表分隔符，不是目录分隔符；只把已拼好的单个字符串传给 Path.Combine 不会修复问题。Editor 使用另一分支，所以编辑器存档成功可能掩盖 Player 问题。

[LocalSaveModule.cs](E:/Git/TEngineNi/UnityProject/Assets/Scripts/Hotfix/GameCore/Module/LocalSaveModule/LocalSaveModule.cs:29) 的 Save 返回 void，忽略 SafeWriteAllText 的 bool 返回值。底层写入失败被记录日志后，上层没有成功/失败结果。Save/Load 使用同步文件 IO，且没有小游戏平台存储适配。

建议先修正 Path.Combine 的分段参数，明确存档失败反馈，再设计异步/平台存储接口。await 包装不能替代小游戏持久化适配。

### 3. 新图集加载器有并发与销毁竞争

[SpriteAtlasLoader.cs](E:/Git/TEngineNi/UnityProject/Assets/TEngine/Runtime/GameSupport/SpriteAtlasLoader.cs:37) 只缓存加载完成的图集，没有记录进行中的同名请求；同名并发加载完成后均执行 Dictionary.Add，存在重复 key 异常路径。

OnDestroy 只释放已记录句柄。尚未完成的加载仍保留 Completed 回调，可能在销毁后重新写缓存并留下句柄。加载失败未独立判断；还直接 Destroy 加载资源后再 Release 句柄，资源所有权需要统一。

建议合并同地址加载、跟踪所有进行中句柄、处理失败及销毁后完成，不直接销毁共享加载资源。尚未做运行复现。

### 4. 工程结构已迁移，AI 规则与校验脚本仍保留旧路径

fork 的 AGENTS.md、tengine-dev references 仍说明 GameScripts/HotFix/GameLogic 等旧结构。[workflow_lib/domains.py](E:/Git/TEngineNi/UnityProject/.codex/scripts/workflow_lib/domains.py:63) 的 Luban 检查/输出仍使用 Assets/GameScripts/HotFix/GameProto 与 Assets/AssetRaw/Configs/bytes；真实导出脚本使用 Assets/Scripts/Hotfix/AutoGenProto 与 Assets/AssetBundle/AutoGen/GameConfig。

因此不能未经适配就运行完整工作流并把结果当成当前 fork 的配置验收；还可能重新生成旧目录。分析脚本若引入当前项目，须放 Design，正式长期约定整理进 Doc。

### 5. AOT 中含桌面工具逻辑

[ProcessHelper.cs](E:/Git/TEngineNi/UnityProject/Assets/Scripts/AOT/Helper/ProcessHelper.cs:9) 包含 dotnet 全局工具安装与进程调用；所在 AOT.asmdef 没有仅 Editor 平台限制。目前检索未见调用点，不判为已发生的运行故障，但不宜作为移动/小游戏通用运行时内容直接继承。

## 验证与采用顺序

1. 以当前 fork HEAD 为对比基线，在当前工作区建立隔离验证基础；保留原两个仓库。
2. 先处理退出、存档、图集加载和脚本路径问题，核对依赖与程序集。
3. 验证无服务器启动、异步 UI 开关、同图集并发、2D/3D 场景装卸、语言切换与字体资源释放。
4. 执行 Android IL2CPP 首包和热更测试，确认三程序集、AOT 元数据与 DLL/资源收集一致。
5. 小游戏成为确定目标后，选择具体 SDK，验证文件缓存、存档、网络和热更平台行为。

正式采用、最终目录与平台范围尚未确定，本报告保留在 Design。本次仅做只读比较，不复制框架、不改来源仓库、不执行构建或安装。
