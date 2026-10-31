# TEngineNi 修改台账

更新：2026-10-27。权威源码为独立 TEngineNi_UPM 仓库；已验证并发布的包提交为 `7a71e9eed0511767df01ac12deaf440d6843fa43`。Ni 迁移前 HEAD：2b13c76ff4bd61048143288556d9791088f77bc7；集成提交 `e1de1cdf620a9891bc180463c737265dd5daf60c` 已推送至 `tengineni_upm`，保留原 fork 历史。

当前状态优先于后文注明日期的历史记录：共用条目 T01–T06、C01–C07、E01 已独立发布，Ni 以 FrameworkPackages 子模块同步，本工程固定同一 Git SHA；项目门面、业务和 Demo 仍按 A01/D01/D02 单独管理。Ni 独立 Editor/PlayMode 尚未验收。

## 记录与同步规则

用户要求在 TEngineNi 基础上的修改持续记录，确定保留的内容后续同步回源工程。本台账区分“目标工程当前保留”和“回传决定”；2026-10-26 用户已确认本轮包化和共用源码合并：T01–T06、C01–C07、E01 归 Ni 的两个包维护，已合并到来源工作树，未提交/发布；Ni 独立 Editor 验收待执行。D01/D02 与项目门面 A01 继续按项目内容区分，后续新范围仍需确认。

审计由 `Design/scripts/audit-tengine-changes.ps1` 生成。独立仓库发布后清单 SchemaVersion=3，记录包身份、版本、两边依赖、来源文件 SHA256 与来源 Git 工作树变更；不再将两套已删除的 Assets 副本相互比较。审计同时记录独立包提交/脏工作树与 Ni 父仓库提交；当前 Git 消费和 Ni 子模块固定同一已发布提交。

`Design/reports/` 整体忽略，包括当前清单、文本补丁和 `TEngineNi-audits/<时间戳>` 快照。需要时重新运行审计脚本；新结果反映生成时的来源与目标工作树，不能原样还原历史差异。重要改动、验证摘要、回传决策和同步状态持续保留在本台账中。

## 功能改动登记

| ID | 内容与目标位置 | 原因/验证 | 回传建议 | 状态 |
| --- | --- | --- | --- | --- |
| T01 | TEngine.Runtime/Editor asmdef 依赖调整，重复 Unsafe DLL 未导入 | 清理目标不存在的程序集引用、避免 Roslyn 重复 DLL；目标编译验证 | 工程依赖适配，按 Ni 实际环境重做；不直接覆盖 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| T02 | Utility.FileUtils.GetDocDataPath | 路径分隔符改为正确的 Path.Combine | 通用修正，建议回传 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| T03 | ResourceModule/IResourceModule：显式 EPlayMode 重载、设置默认包、资源池复用 | 启动配置独立于全局 EditorPrefs，支持重试；启动与资源测试 | 通用增强候选，需检查 Ni 原流程兼容 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| T04 | SceneModule：重复卸载、活动场景初始化与空值查询 | 附加场景/无内置首场景边界修正；资源/场景测试 | 通用修正，建议回传 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| T05 | TEngine/Runtime/Module/ResourceModule/ResourceModule.cs：Shutdown 清除资产池引用 | 真实 Stop 后 UI 延迟销毁仍向已关闭池 Unspawn；新增晚释放测试和实际 Play/Stop 验证 | 通用退出修正候选 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| T06 | TEngine/Runtime/Module/UpdataDriver/UpdateDriver.cs：移除监听不创建实体，关闭清空 Behaviour，异步注册校验原实体 | 退出时重新生成 UpdateDriver；覆盖关停后取消订阅及未完成注册 | 通用生命周期修正候选 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C01 | GameCore/UIModule、UIWindow：异步等待、取消、异常和共享加载状态 | 异步窗口生命周期、关闭和错误路径；UI/启动测试 | 高优先级通用候选；接入 Ni 窗口需回归 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C02 | LocalSaveModule/ILocalSaveModule | 去除旧业务依赖，路径校验、原生异步读写及取消；存档测试 | 可回传基础接口；原子写入/备份/迁移尚未补齐，不当作最终存档方案 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C03 | ResourceReference/AssetLease、AsyncIconLoader | 明确引用持有者与取消/释放语义 | 通用扩展候选 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C04 | Foundation 集合/时间/曲线，LoopScroll 与 UI 扩展 | 从旧工程迁入通用功能，替换资源管理与列表单元池依赖；部分集合/池测试 | 分项筛选，来源许可及项目需求需核对 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C05 | GameCore/ResourceModule/PrefabInstancePool（本轮） | TEngine SingleSpawn pool 管理 Unity 实例，区分取出/归还/最终销毁；调用方持有 Prefab 资源引用；退出时检查原池所有权，允许关停后的晚归还/重复释放，拒绝向已关闭池 Rent | 通用池化封装候选；批量与晚释放测试、打开背包后的实际 Stop 检查 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C06 | GameCore/UIModule/Extensions/VirtualizedScrollList（本轮） | 固定行高、按视口复用单元；100,000 条数据不实例化全部行 | 通用大列表候选；暂只支持固定行高竖向列表 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| C07 | GameCore/SingletonSystem/SingletonSystem.cs：DeInit 仅取消已有驱动监听并清除缓存 | 防止退出新建或下一会话复用旧驱动；晚释放/重新初始化测试 | 通用生命周期修正候选 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| E01 | UIScriptGenerator 设置/生成逻辑 | 调整目标 Runtime/Logic/UI 路径，GameCore 引用，RTL 类型可选 | 工具候选；目录约定需与 Ni 协调 | UPM 已发布；Ni tengineni_upm 已同步；Ni 独立 Editor 待验收 |
| A01 | GameCore.asmdef/GameModule | 目标共用层去掉业务/网络依赖 | 架构裁剪，不能据此删除 Ni 业务入口或网络文件 | 当前保留；待确认；未同步 |
| D01 | Launcher/Procedure、RoundedProgressBar、Editor 直接 Main 启动补偿 | 新 Demo 启动链路和展示 | 需要时作为模板单独迁移；不能替换 Ni 现有游戏流程 | Demo 保留；回传另议；未同步 |
| D02 | GameRuntime/Logic/UI 的 HUD、7 类假数据窗口、模态、Tips、跑马灯、压力界面，独立 Prefab 与生成器 | 真实 UI 层级/数据/压力验证 | Demo/Sample 候选，业务假数据不得混入 GameCore | Demo 保留；回传另议；未同步 |

## 不应按差异自动同步的内容

2026-10-12 启动日志排查：StartupFlowTests 的失败重试用例改用临时 StartupSettings 副本，只在测试作用域捕获并断言一次预期的空包名错误，其他异常继续正常记录；不修改运行时启动错误处理。补回 TEngineNi 原始 Assets/Launcher/Scripts/DisStripCode.cs 及原 .meta 到目标 Assets/Scripts/Launcher，修复原 GameEntry.prefab 的缺失脚本引用；原文件未改动，属于补齐导入，不是源工程待合并补丁。测试改动归目标验证环境，未同步。验证与证据见 Doc/测试与演示指南.md 的“已修正问题与验证边界”。

2026-10-12 资源清理：目标工程旧 SampleScene、FoundationBootstrap、FoundationValidationAssets 的旧 Bootstrap 创建菜单退役，默认模板场景指向 Launcher；清除测试生成场景与 AI 临时输出。属于目标 Demo/验证环境整理，不修改 TEngine/GameCore，也不删除 TEngineNi 源资源。清单在 Design/reports/resource-cleanup-manifest.json；未同步。

- source-only：表示当前源工程有而目标未迁入，例如 Ni GameApp、GameEventCore、NetworkModule；不是源工程应删除的清单。
- target-only：新增通用能力、旧工程移植物和本地适配要按用途逐项确认；新增 UI 演示属于 GameRuntime/Sample。
- asmdef/GUID、包配置和源工程工具路径是环境相关改动，需在 Ni 单独验证。

## 后续每次改动的要求

登记改动 ID、文件、目的、验证证据和回传分类，更新清单。确认回传后记录明确决定和适用源版本；先审阅源工程现有改动，合并最小补丁，运行源工程编译与相关测试，最后填写源提交/文件哈希及同步日期。本轮条目区分“源码已合并工作树”和“版本已提交/发布”；后者尚未完成，不把当前工程测试通过当作 Ni 独立验收。


## 2026-10-26 文档与版本管理整理

本次仅合并说明、整理分析与版本管理规则，未修改 TEngineNi 来源代码、GameCore、游戏代码或 Unity 资产。历史实施结论合并到《当前框架整体功能说明》《测试与演示指南》和《TEngine引入方式与来源》；原始结果及差异清单仅保留本机，不入库。现有差异清单仍为 2026-10-12 的工作树审计，不冒充本次重新审计。该文档整理阶段未同步代码；随后同日用户授权的包化合并状态见下节。

## 2026-10-26 包化与授权合并

- 权威位置：FrameworkPackages/com.ni.tengine 0.6.0（TEngine.Runtime/Editor），FrameworkPackages/com.ni.gamecore 0.1.0（Ni.GameCore/Editor）。原 GameCore 程序集保留各自门面，Ni 的 GameApp、Network、IEvent 和配置业务未删除或并入包。
- 本轮用户确认包化与包名后执行共用差异合并，包括既有八个 TEngine 文本适配、UI/存档/生命周期修正及集合、资源引用、池和虚拟列表。UI 生成器、设置面板、依赖它的 HTML 工具一并放到 GameCore Editor，避免反向依赖。
- Settings、InputActions、HTML 配置、生成器设置和各自启动资源保留项目。330 个当前脚本与 312 个 Ni 原脚本的 GUID/.meta 已核对；原输入备份保留 Design/local。重复 Unsafe 二进制一致，统一使用 Ni TEngine 包内副本，当前 Roslyn 目录的重复项移除。
- 当前项目 Unity 编译、EditMode 3/3、PlayMode 10/10、26 Prefab 无缺失脚本及完整 .NET 构建通过；Ni 主程序集对新包的 .NET 集成检查通过。详情见测试指南。
- Ni CLI/Pipeline 缺失，未取得源工程独立 Editor 验收；Ni.GameCore 为新增 AOT 共用程序集，发布前须重新生成 AOT 元数据/泛型与裁剪产物、核对热更列表。源码已合并，Git 尚未提交/推送/发布，不标记发布同步完成。
- 后续共用修改直接在 Ni 包分支维护，当前工程升级依赖；不恢复两套共用源码。差异清单和补丁继续仅存本机 reports，不入库。
- B01：Ni 根 README 增加共用包入口；旧 update-tengine.bat 检测到 FrameworkPackages 后在网络/复制/删除前退出，避免覆盖式更新重新创建旧 Assets 框架。仅检查了前置保护和 Git 差异，没有运行旧更新流程。当前保留；未提交/发布。

## 2026-10-26 版本映射调整

用户指定 TEngine 6.1.0 对应 Ni 0.6.1。当前原上游声明 6.0.0，com.ni.tengine 因此改为 0.6.0，GameCore 仍为 0.1.0；同步调整其 TEngine 依赖及两个工程 lock 的依赖记录。未改运行时源码或 .meta。两个包与 Ni 集成工程继续同仓库管理，包版本分别维护；未提交、未打标签、未发布。

## 2026-10-27 独立 UPM 发布与同步

- 用户明确授权将两个包提交并推送 TEngineNi_UPM、Ni 分支 tengineni_upm 和当前 UnityGameEngine 工程；此前“先不提交”的整理阶段已结束。
- 包源码提交 `7a71e9eed0511767df01ac12deaf440d6843fa43`；com.ni.tengine 0.6.0、com.ni.gamecore 0.1.0。UniTask/YooAsset/HybridCLR 固定快照及许可证供全新工程安装，五项 Git 模板避免传递 Git 依赖缺失。
- P01：com.ni.tengine/package.json 增加 HybridCLR 和实际使用的 Unity 内置模块依赖，补齐原工程模板掩盖的依赖声明；两个包 repository/documentationUrl 改为独立仓库。无运行时逻辑变化，三种安装验证通过。
- P02：第三方 YooAsset 编辑器 AssetArtScannerSetting.cs 移除未使用的 NUnit using，让无测试框架的新工程编译；仅独立包快照做此兼容修正，Ni 原有第三方包未升级。
- P03：Ni/FrameworkPackages 改为子模块，Ni 提交 `e1de1cdf620a9891bc180463c737265dd5daf60c` 已推送；原目录在本机 Design/local 备份。Ni 的锁文件共用包依赖按声明更新，尚未取得其独立 Editor 解析/PlayMode 验收。
- 消费工程使用已发布 HTTPS Git SHA，Unity 生成 manifest/lock 配套记录；本轮重新验证结果见测试指南。EditorSettings 中用户已有的 Enter Play Mode Options 关闭值保留。
- 新增同步范围仍遵循逐项确认规则；本轮授权不自动授权未来业务、Demo 或其他共用改动回传。

## 2026-10-27 共用工具与 UI 扩展归口

- C08：将 `UnityEngineObjectExtention`、`HVScrollRect`、`HoleImage`、`TextGradientColor` 及 `LoopScroll/*` 统一到 GameCore 命名空间，消除共用实现对全局及 Unity UI 命名空间的占用。布局组件使用 `ParentContentSizeFitter`，脚本与 .meta 成对迁移，保留原 GUID。补齐显式 UnityEngine/UI 引用及 Object 别名，方法逻辑未变。
- 验证：包静态检查、五组基础检查通过；隔离消费工程 EditMode 3/3、PlayMode 10/10；12 个运行时类型归属正确，布局脚本 GUID 正确解析到新类，26 个 Prefab 缺失脚本为 0；51 份运行时元数据 GUID 核对一致。结果与差异补丁仅保存在忽略的 Design/reports/gamecore-cleanup-*。
- 保留决定：按用户要求保留共用代码归口。修改仅在独立 UPM 工作树中，尚未提交/推送；Ni 子模块和当前消费工程仍固定原发布提交，未同步本次修改。外部代码使用旧类型位置时需调整命名空间和布局组件类型名。

## 2026-10-27 核心逻辑重写与项目程序集整理

- C09：独立包 `com.ni.gamecore/Runtime/Logic` 新增 Ni.GameCore.Logic。包含表索引、ServerClock、BalanceLedger、OperationTimeline、报文读写、拆包、路由和 TcpPacketSession；无 Unity、项目门面或业务程序集依赖。目的为优先承接原逻辑的基础设施，并将协议、配置和表现从共用机制中分离。
- 网络采用长度、节点与消息标识的通用帧格式；处理分片、粘包、扩展长度、取消、关闭、主线程 Pump 派发和有界收包。队列同时限制数量及总字节。鉴权、加密、压缩、产品协议和平台传输适配未接入。
- D03：业务重写仅放在 UnityProject1 的 GameRuntime.LogicTests 与 GameRuntime 测试面板中。当前覆盖城建升级、科技前置、训练、资源扣除、加速、取消退款、确认结算、请求防重和快照恢复；数值为独立测试配置，未导入旧业务资产或服务地址。
- A02：新增 GameProject.Editor、GameRuntime.LogicTests、GameLogic.EditModeTests 和 GameLogic.PlayModeTests，明确运行时、Editor、业务模型与测试边界。四份 Roslyn 插件导入设置经 Unity API 改为 Editor-only，原 GUID 保留。Unity MCP 固定工程已有提交，未升级依赖。
- 验证：纯核心与业务模型 .NET Standard 2.1 构建 0 错误、0 警告；Unity EditMode 最终 30/30，PlayMode 11/11，均无失败或跳过；程序集归属/依赖环检查通过。原始证据和源文件哈希仅放 Design/reports/logic-rewrite-*。
- 保留/回传：用户已要求以新结构重写共用核心与业务测试，本轮改动保留在独立包与当前工程工作树。未提交/推送，Ni 子模块未同步；当前工程已切本地开发包引用。后续发布仍需先推送验证过的包，再升级各消费工程固定提交与 AOT/裁剪配置。


## 2026-10-31 提交前清理决定

- 当前工程保留 D03 本地业务模型、规则资源、演示面板及回归测试，A02 保留程序集隔离与 Roslyn Editor-only 元数据；不包含生产业务或远端服务接入。
- 删除与 Doc/LogicRewrite.md 重复的 Design 草稿及一次性 ProjectAssemblyTools 配置入口；精简 GameProject.Editor 的无用引用。现有 DLL 导入元数据及原 GUID 保留。
- C09 共用逻辑仍属于回传候选，源码留在独立 TEngineNi_UPM 工作树；该工作树基于 5009668c98e1013b47bc90385497adc78c3d36ff，Logic 目录与包 README 尚未提交。本次仅提交 MyUnityFramework，不提交/推送包仓库，不推进 Ni 子模块；**未同步**。当前消费依赖本地工作树，仅检出消费仓库不能复现该依赖。

## 2026-10-31 UnityProject2 编译修复

- C10：修正 TEngine.Runtime、TEngine.Editor、Ni.GameCore、Ni.GameCore.Editor 四份 asmdef 的 UGUI 引用，从不存在的 Unity.ugui 改为实际程序集 UnityEngine.UI。UPM 包名仍是 com.unity.ugui，不更改包版本或来源，不修改运行时逻辑和 GUID。
- 依据：UnityProject2 实际 com.unity.ugui@1.0.0/Runtime/UnityEngine.UI.asmdef 的 name；包名与程序集名不能混用。UnityProject2 项目自身 11 份 asmdef 已同样修正；10 个 DE 程序集按实际源码离线编译通过，不再采用引用别名映射。
- 验证边界：离线编译依赖已安装 Unity 2022.3.62f2 参考程序集和底座缓存，Editor 重启后包解析已恢复，实际 Unity 编译通过，DE.Production.Network 的 Editor 测试18/18通过；真实鉴权仍在联调，此项不代表登录验收。另已修复 Start-DE.ps1 缺失 ALLUSERSPROFILE 造成的 UPM 全局配置路径异常，独立只读 UPM registry API 返回 HTTP 200。
- 保留/回传：为本次新工程修错在共用包权威工作树保留最小引用修正；未提交、未推送、未发布，Ni 子模块未更新，未同步。差异补丁保存在忽略的 Design/reports/de-rebuild/ugui-package-reference.patch。


## 2026-10-31 按 package 提交

- 用户授权先提交 Git，并按 package 分开保存。独立 TEngineNi_UPM 中：`eac3d5a` 仅包含 com.ni.tengine 的 UGUI 引用修复；`706f398` 包含 com.ni.gamecore 的纯逻辑、TCP 会话、UGUI 引用修复和包说明。
- C09/C10 已提交到独立包仓库本地 Git，不再属于未提交工作树。当前工程保持本地包引用；未推送、未发布、未更新 TEngineNi 的 FrameworkPackages 子模块，**未同步**。不为填写版本擅自切换 Git revision。
- 用户确认新工程可以运行，但现有日志不足以判断实际执行阶段。本轮仅保存现状，未重新连接真实服务或运行 Unity 测试；既有真实链路与测试记录均保留原验证边界。
- 提交前静态审计：UnityProject2 的 GUID、脚本归属与程序集依赖检查通过，来源覆盖脚本单测 3/3。严格入口扫描仍发现历史 DeRuntimeHost 的 CreateMock；实际 DeGameEntry 调用生产入口，此历史文件尚未按该门禁要求隔离，记录为待处理项。
