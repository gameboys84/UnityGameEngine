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
