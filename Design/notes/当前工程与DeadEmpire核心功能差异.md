# 当前工程与 DeadEmpire 核心功能差异

核对日期：2026-10-26。

本报告记录同日包化前的源码快照。之后共用框架已迁入 TEngineNi 的 com.ni.tengine / com.ni.gamecore；当前路径、依赖与验证以 Doc/TEngine引入方式与来源.md 和 Doc/当前框架整体功能说明.md 为准。此处保留原比较依据，不作为包化后的目录清单。

比较对象：`E:/Git/MyUnityFramework/UnityProject1` 与 `E:/TAP/DE/DeadEmpire-DEV` 当前磁盘内容。本次检查目录、程序集、依赖、启动代码及各核心模块代表性实现；没有启动 Unity、构建、连接服务器或调用第三方服务。以下“已有实现”不等于当前环境可运行，也不代表线上服务仍可用。历史验证记录仅作历史证据，不视为本次重测。

## 1. 总体判断

当前工程是基于 TEngineNi 的通用客户端底座和测试演示工程；DeadEmpire 包含完整得多的联网 SLG 客户端业务、资源管线和平台接入代码。两者最大的差距在业务模型、服务器交互与产品运营链路。

当前工程已经具备资源、场景、窗口、事件、计时、对象池等通用能力，并有明确的 Launcher / GameCore / GameRuntime 分层。DeadEmpire 的对应能力承担了更多实际业务，但大量代码直接引用 FromLua、Protocol、GameData 和全局玩家数据，抽离成本更高。不能把 DeadEmpire 的代码量或功能目录直接等同于可复用框架的数量，也不能据此给出有意义的“完成百分比”。

## 2. 核心能力对照

| 能力 | 当前工程 | DeadEmpire | 实际差异 |
| --- | --- | --- | --- |
| 引擎与分层 | Unity 2022.3.62f2；TEngine.Runtime、Launcher、GameCore、GameRuntime 及测试程序集 | Unity 2018.4.36f1；大量游戏代码在默认程序集，部分资源和插件单独拆分 | 当前共用层边界较明确；旧工程迁入需同时处理 API、程序集和资产依赖 |
| 启动 | FSM 驱动资源包初始化、版本/清单、下载、预加载、主场景和反射入口；错误重试 | Boot、StartupMgr、更新器；启动 JSON 含停服、强更、网络地址、资源与热修版本；Boot 初始化 SDK 并等待更新 | 当前有技术启动链路；旧工程还承载面向产品运营的启动规则 |
| 资源管理 | YooAsset、DefaultPackage、资源引用、图标取消与释放、PrefabInstancePool | PackageResMgr、ABManager、旧 Packer/ResourcesWrap、SpawnPool 等并存 | 能力重叠，但路径、资源标识、缓存、异步接口和 Prefab 引用契约不同，不能直接替换方法名 |
| 资源更新 | 模拟、离线、Host 模式及清单/下载代码；真实远端与设备路径待验收 | Startup/Streaming/Background 更新器、DLC、AB 更新及构建脚本 | 当前未证明首包、后台更新和设备缓存策略已达到旧工程业务覆盖范围 |
| 代码热修/热更 | HybridCLR 8.8.0 已安装；启动反射调用已有 GameRuntime 类型 | HotfixDownloader 下载补丁，InjectFixManager 调用 PatchManager.Load，StartupMgr 有实际调用 | 当前启动流程没有热更 DLL/AOT 元数据加载步骤；包存在不等于代码热更落地 |
| 网络与协议 | 未见独立游戏网络模块、消息模型及联网业务；资源 HTTP 下载不算游戏网络 | NetManager、NetSession、ISession、SPack、ProtocolDefine/MVC；TCP 收发、Pike、LZ4、主线程消息分发及节点路由 | 当前缺少连接、协议、请求响应、推送、会话及断线后的业务恢复体系 |
| 账号和角色 | Demo 直接进入主场景 | SDKLogin、LoginMgr、账号界面、服务器/角色相关代码 | 当前无真实登录、鉴权、选服、角色加载闭环 |
| 配置表与状态模型 | 有 TEngine/Luban 编辑器入口，未建立当前业务表与加载链路；Demo 使用 FakeSlgState | GameDatas/GameData.cs 定义大量表和索引；GameGlobalData、Protocol 结构及各业务管理器持有状态 | 缺口是表生产/加载、数据模型和状态更新契约，远超过配置菜单本身 |
| 通用 UI | UIWindow/UIWidget、层级/缓存/异步显示、代码绑定、虚拟列表、循环滚动和异步图标 | UMenusMgr、UIManager、CustomUI、大量 UINew 窗口与真实资源 | 当前已能支撑通用窗口展示；旧工程拥有业务导航、引导、建筑头条等更丰富的场景语义 |
| 城建与经济 | 没有真实城建、资源产出和经济模型 | CityBuild、OwnBuildingMgr；建筑列表、建造升级取消、队列与推送处理 | 需引入建筑/经济规则、模型、命令和状态更新，不能靠复制界面实现 |
| 科技、训练、任务与进度 | 通用 Timer 与演示计时；未建立业务队列 | ResearchMgr、ProgressMgr、GameTimer 等与表、服务器时间和协议关联 | 运行时计时器不能直接承担跨重启、服务器权威的任务进度 |
| 世界地图、行军与联盟 | 无真实世界模型或地图业务 | WildMapMgr、WildMapTroopsMgr、TerritoryMgr、WarFog；联盟、GVG/KVK 等业务代码 | 尚缺地图对象/视野、部队状态、领地、跨服业务与服务端同步；具体算法和性能未逐项验收 |
| 角色、道具、邮件、聊天、商店 | 七类 SLG 假数据窗口；本地升级、领取去重、聊天列表、假币购买 | 对应管理器、协议、业务窗口；独立聊天 SDK；IAP 相关代码 | 当前是 UI 与性能演示，没有正式背包/奖励/社交/支付交易闭环 |
| 战斗与表现 | 测试场景、实例池和批量工作负载 | FPS、BattleUI、Zombie、Expedition、Arena 等代码与资产 | 旧工程有多类玩法表现；本次未证明所有目录均在当前版本启用，也未验证客户端/服务端战斗结算边界 |
| 多语言 | 保留 TEngine Localization/I2 衍生实现；当前 Demo 文案仍有硬编码 | StringManager 的语言切换、语言包、服务器/修正文案；阿拉伯语支持相关代码 | 当前尚未建立项目实际使用的语言表、字体和切换验收流程 |
| 音频 | TEngine AudioModule 有分组、音量、池等实现；当前演示启动未完成音频业务初始化 | SoundMgr、声音资产及业务调用 | 通用播放能力已有，业务音效、音乐规则和设置闭环尚未接入 |
| 本地存储 | 显式 LocalSaveModule；有读写/取消与路径校验；缺原子替换、备份、迁移和并发策略 | 文件/缓存/偏好设置分布于多个模块；关键 SLG 状态依赖服务端 | 不能把当前本地存档等同于旧工程账号数据，也不能断言旧工程有可直接抽出的统一存档系统 |
| 日志、诊断与埋点 | TEngine 日志、Debugger、测试面板；无独立用户行为采集模块 | TrackMgr 调用 AWSKinesisMgr，含 HTTP、连接和用户行为事件；有多类调试插件 | 当前即时调试能力不等于用户行为/故障上报链路；旧工程后端、开关和凭据有效性未验证 |
| 平台与发布 | 继承发布工具及部分插件；现有验证主要在 Windows Editor | Android/iOS 分支、原生插件、SDK 登录、IAP、通知与 make/Jenkins 等构建材料 | 旧工程具备更多设备及渠道接入代码；本次未构建，不能断言旧脚本现在可直接发布 |
| 自动验证 | Assets/Tests 下有基础、生命周期、启动及 UI/批量工作负载测试，Design 有历史结果 | 可见 Test、调试和性能工具；本次未系统盘点自动测试体系 | 当前有针对底座的可重复测试资产；无法仅凭此比较两者总体稳定性或设备性能 |

## 3. 三条关键调用链

### 3.1 启动与代码更新

当前：`GameEntry.Start → ProcedureLaunch → ProcedureInitResources → ProcedureStartGame → Type.GetType/GetMethod → GameApp.Entrance → MainSceneView.Enter`。资源阶段执行 YooAsset 版本、清单和缺失资源下载。`StartupSettings` 默认 Editor 模拟、Player 离线；Host 模式需要配置地址。这里的反射调用本身不下载或装载新程序集。

DeadEmpire：`Boot → StartupMgr.Launch → HotfixDownloader.CheckAndDownload → InjectFixManager.ReloadPatch → PatchManager.Load`，并有后续资源更新。其补丁机制替换已编译方法，与 HybridCLR 热更程序集的路线不同。版本兼容、补丁失败策略和构建注入均需独立考虑。

特别注意：`XLuaManager.cs` 中实现已被注释，StartupMgr 对 XLua 的调用也处于注释中。`FromLua/` 内有大量正在被 C# 引用的业务类，目录名和 LuaCallback 名称不足以证明当前仍运行 Lua VM。

### 3.2 网络与真实城建

DeadEmpire 的 `NetManager.InitSession` 绑定连接成功回调与消息队列，`NetSession` 对消息编码、组包、收发和解码；`OwnBuildingMgr` 持有 `Protocol.BuildingInfo`、建筑队列及起止时间，代码包含建造请求和通知更新逻辑。`ResearchMgr` 同时依赖 GameData、玩家资源、ProgressMgr 和网络协议。

因此城建/科技不是独立的表现组件。迁移时需先确定配置、状态、命令、通知和时间语义，再接 UI。当前框架的 Timer、Event 和 UI 可以承接部分技术职责，但尚未实现这些业务契约。服务器侧实现不在本次两个客户端工程比较的验证范围内。

### 3.3 当前 SLG 窗口的真实边界

`SlgFeatureView` 通过 `FakeSlgState` 修改金币、角色等级、邮件领取集合和聊天记录；商店提示明确使用假币，聊天提示明确没有网络。邮件领取集合避免了本地演示会话中的重复加币，不能据此认定已实现服务端幂等、跨重启一致性或交易重试。

虚拟列表、模态遮挡、窗口层级、资源释放及池化演示有复用价值，但它们与上述业务完整度必须分开评价。十万条列表数据也不能证明可支撑十万个联网地图实体。

## 4. 已从旧工程提取的部分

`Design/reports/imported-source-manifest.json` 记录七个来源文件：HVScrollRect、T4fContentSizeFitter、HoleImage、TextGradientColor、UnityEngineObjectExtention、TimeUtility、BezierUtils。对应目标文件仍可在 GameCore 找到。

这说明已经做过有限的基础工具/UI 提取，不代表已迁入旧工程的网络、更新、UI 管理器或玩法。清单记录导入时的源哈希；本次未重新计算逐文件相似度，不能据此声称这些文件现在与来源完全一致。

## 5. 针对当前工程的建议顺序（待决定）

1. **先补配置与最小业务模型。** 选城建或单机队列做一个纵向功能：表加载、建筑状态、升级条件、消耗、完成时间、存档和界面。将模型放在 GameRuntime；通用表加载、时间接口和存储增强可另评估为 GameCore 能力。
2. **若目标是联网 SLG，再明确服务端与协议路线。** 可借鉴旧工程的会话/消息分发职责，但不能在未确定兼容旧服务端的目标前直接复制其 Protocol、Pike、节点路由和全局管理器。
3. **补可发布的资源与代码更新验证。** 先跑离线安装包和 Host 真实下载，再验证 HybridCLR DLL/AOT、IL2CPP 与失败恢复；这些能力目前均不能从 Editor 模拟结果推定。
4. **按使用需求落地音频、多语言和数据采集。** 优先建立统一接口和一个完整使用场景，避免保留多个来源管理器同时驱动同一职责。
5. **按功能纵向迁移业务。** 城建/资源/队列后，再扩展科技训练、道具奖励、世界行军、联盟及运营。账号 SDK、支付、聊天和发布管线按产品需要与目标平台分别接入。

若目标只是通用框架，优先项应集中在配置、存档可靠性、取消/错误语义、资源更新、设备构建与诊断，不需要以复制 DeadEmpire 全部玩法作为框架完成标准。以上顺序是分析建议，尚未作为正式架构或迁移决定。

## 6. 证据索引

以下相对路径分别以两个 Unity 工程根目录为基准，可用文件名及方法名复核。

| 判断 | 当前工程证据 | DeadEmpire 证据 |
| --- | --- | --- |
| 版本/依赖/分层 | ProjectSettings/ProjectVersion.txt；Packages/manifest.json；Assets/Scripts/Hotfix 下 asmdef | ProjectSettings/ProjectVersion.txt；Packages/manifest.json；Assets/AssetManager |
| 启动/热更 | Assets/Scripts/Launcher/GameEntry.cs、StartupSettings.cs；Assets/Scripts/Procedure/StartupProcedures.cs | Assets/FPS/Scripts/GUI/Boot.cs；Assets/Scripts/StartupMgr.cs、HotfixDownloader.cs、InjectFixManager.cs、XLuaManager.cs |
| 资源体系 | Assets/TEngine/Runtime/Module/ResourceModule；GameCore/Module/ResourceModule | Assets/Scripts/Resource/ResourceMgr.cs；Assets/AssetManager/ABManager.cs；Assets/Scripts/AutoUpdate |
| 网络 | GameCore/GameModule.cs 及当前 Scripts 目录模块清单 | Assets/Scripts/Net/NetManager.cs、NetSession.cs、ProtocolDefine0–5.cs；FromLua/Common/NetMessageMgr.cs |
| 配置/业务 | Assets/Scripts/Hotfix/Runtime/Logic/UI/SlgFeatureView.cs、SlgHudView.cs | Assets/Scripts/FromLua/GameDatas/GameData.cs、GameGlobalData.cs、CityBuild/OwnBuildingMgr.cs、Research/ResearchMgr.cs、Process/ProgressMgr.cs |
| UI 耦合与地图 | GameCore/Module/UIModule；Runtime/Logic/UI | Assets/Scripts/UI/UIManager.cs；Assets/Scripts/UINew；Assets/WildMap/Script；Assets/CityBuild/Script |
| 多语言/音频 | Assets/TEngine/Runtime/Module/LocalizationModule、AudioModule | Assets/Scripts/Utils/StringManager.cs；FromLua/Utils/SoundMgr.cs |
| SDK/支付/追踪 | 当前 Scripts 未见相应独立实现 | Assets/Framework/SDK/Script/SDKLogin/SDKLogin.cs；Assets/Scripts/FromLua/IAP；FromLua/Track/TrackMgr_AWSKinesis.cs；Assets/Scripts/ThridParty/IAP |
| 测试/历史迁移 | Assets/Tests；仓库 Design/reports 下历史结果与 imported-source-manifest.json | 本次只读检查，未执行旧工程测试 |

本次仅新增本分析报告，未修改两个工程的产品代码，未执行任何向 TEngineNi 的回传或同步。
