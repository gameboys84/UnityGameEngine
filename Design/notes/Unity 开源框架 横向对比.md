# 用异步与资源生命周期筛选 Unity 框架

**优先试跑 TEngine；将 QFramework + JEngine 作为轻量组合备选，将 UnityGameFramework 作为完整模块与调试能力的对照。** 这次补充筛选了满足至少 500 GitHub Star 的客户端方案，并把 UI 专项、战斗子框架和大型双端框架分开比较。对本项目而言，Star 只决定进入比较名单，最终排序取决于资源、场景和 UI 的异步接口、释放契约以及小游戏适配成本。TEngine 已有 YooAsset、HybridCLR、UniTask 和异步窗口管理，组合距离最短；但其 Unity 版本文件和 README 存在差异，仍须在 **Unity 2022.3.62f2** 验证。所有候选均未在当前工程编译或真机测试，本文不把作者的“轻量、零 GC、商业级”宣传当作实测结论。

## 七个主候选达到热度门槛，完整性与集成成本各有取舍

Star 为 **2026-10-11 查询时 GitHub 页面显示的约数**，部分页面存在缓存，API 未取得精确计数。UnityGameFramework 与 GameFramework 核心是同一方案的两部分，不算两个候选、不累加 Star。下表的许可证是仓库标注，实际采用仍需固定版本并检查所选模块及第三方依赖。

| 框架 / Star / 许可 | 定位与主要模块 | UI 与调试特点 | Unity 2022 与采用判断 |
|---|---|---|---|
| [TEngine](https://github.com/Alex-Rachel/TEngine) / ≈2.4k / MIT | 完整客户端；资源、场景、UI、流程/FSM、事件、对象池、音频、设置、定时器、调试器、本地化；集成 YooAsset、HybridCLR、Luban | UIWindow/UIWidget、层级、全屏隐藏下层、绑定代码生成、事件解绑 | README 支持 2022.3；[工程版本](https://raw.githubusercontent.com/Alex-Rachel/TEngine/main/UnityProject/ProjectSettings/ProjectVersion.txt)仍为 2021.3.45f1；**第一验证对象** |
| [UnityGameFramework](https://github.com/EllanJiang/UnityGameFramework) / ≈2.6k / MIT | 19 模块：配置、数据节点/表、调试、下载、实体、事件、文件系统、FSM、本地化、网络、对象池、流程、资源、场景、设置、声音、UI、WebRequest | UIGroup、覆盖暂停、优先级、实例池；运行时调试器可扩展 | 最低版本元数据不等于 2022 实测；模块完整，换 YooAsset 和补 await 成本较高 |
| [QFramework](https://github.com/liangxiegame/QFramework) / ≈5.5k / MIT | 轻量架构核心与可选工具包；UIKit、ResKit、AudioKit、ActionKit、事件、池、IOC、日志、代码生成、LocaleKit | UIKit 层级/堆栈、代码生成、可替换 PanelLoader；架构便于局部组合 | 声明覆盖 2018.4 至 Unity 6；适合轻量组合，但场景、热更、发布链需补齐 |
| [JEngine](https://github.com/JasonXuDeveloper/JEngine) / ≈2.2k / MIT | 热更新/发布底座；启动、资源、加密、更新；UniTask、YooAsset、HybridCLR、Nino、Obfuz；可选动作与对象池 | UI 包主要是异步 MessageBox 和编辑器控件；**不是完整游戏窗口管理器** | [样例工程](https://raw.githubusercontent.com/JasonXuDeveloper/JEngine/master/UnityProject/ProjectSettings/ProjectVersion.txt)为 2022.3.62f2；适合给 QFramework 等补热更发布 |
| [BDFramework.Core](https://github.com/yimengfan/BDFramework.Core) / ≈2.7k / Apache-2.0 | 完整开发发布工作流；自有可寻址 AB、热更、分包/增量构建、DevOps、表格与 SQLite | UFlux：Flux/MVI、窗口/组件/状态、数据绑定、DI；支持 uGUI/FairyGUI | [文档](https://github.com/yimengfan/BDFramework.Core/blob/master/Doc/README.cn.md)将 2021/2022 指向 v-4.0.0 工作分支，同时称主干为 2019；**须先确定正确分支** |
| [HTFramework](https://github.com/SaiTingHu/HTFramework) / ≈830 / MIT | 资源、UI、音频、实体/ECS、流程/FSM、输入、事件、池、任务/步骤、协程、调试/异常、网络；可选 AI、部署、游戏组件 | 编辑器与调试工具丰富；协程跟踪、终止、重启；本地化在可选 GameComponent | README 环境 2022.3.34；推荐单入口场景动态装载，与频繁多场景切换诉求有差异 |
| [TinaX](https://github.com/yomunsam/TinaX) / ≈887 / LICENSE 同列 Anti 996 与 MIT | 模块化 Core、VFS、UIKit、事件、DI、C#/Lua 热更、服务生命周期 | uGUI Page、动画、异步打开；资源显式 Release/using | 2019.4；明确不支持 WebGL；**2026-03-12 归档，不建议新立项采用** |

TEngine 的近期提交记录可见 SetSprite 取消重复释放修复与 Unity2022 API 修复，QFramework 可见 2026 年版本发布和 WebGL Build 修复，说明相关路径持续被维护；抓取页不保证是最新 HEAD。GF、HT 与 Loxodon 未取得可靠的最后提交日期，不能据此说它们停更。([TEngine 提交](https://github.com/Alex-Rachel/TEngine/commits/main/)、[QFramework 提交](https://github.com/liangxiegame/QFramework/commits/master/))

## 异步是否易用，要看 await、取消和释放三个边界

**异步加载不等于可直接 await，更不等于取消安全。** 下表区分已看到的源码/文档证据和仍待验证的部分。“接入成本”是依据模块耦合做的工程判断，不是测量结果。

| 框架 | 资源与释放 | 场景管理 | UI 与 await | YooAsset / HybridCLR / 多语言 | 小游戏证据与主要风险 |
|---|---|---|---|---|---|
| TEngine | UniTask 加载，资源接口有 CancellationToken；引用组件随对象销毁释放，裸资源仍需管理 | UniTask，Single/Additive、进度、挂起/激活、子场景卸载；可见签名无取消令牌 | ShowUIAsync、异步 Widget、SetSprite 取消；缓存和隐藏不等于卸载 | 前两者已集成；有 Localization，字体/图片、自动刷新等未验证 | **有微信文件系统条件编译源码**；WebGL 下部分强制卸载接口不可用；场景异常清理需测 |
| UnityGameFramework | 自有资源栈；回调式加载、显式卸载、资源池过期释放 | 成功/失败/进度事件，接口返回 void | OpenUIForm 返回序号；分组/暂停/池完整；需 await 包装 | 原版前两者未确认内置；本地化包含文本与任意资源 | 未取得具体小游戏适配证据；YooAsset 替换涉及 UI/实体/声音/场景契约 |
| QFramework | ResKit 文档为回调加载、引用计数、ResLoader 回收 | 完整调度能力需另配/核验 | UIKit loader 可替换；文档异步接口为回调，全面 await 未核验 | YooAsset 可接 PanelLoader；热更需组合；旧文档有 LocaleKit，当前完整性待核 | 有 WebGL 修复，**不是小游戏 SDK 证据**；绕开 ResKit 还要改音频加载器 |
| JEngine | YooAsset 与 UniTask 底座；实例引用自动释放未核实 | 完整场景调度未核实 | 异步提示框；窗口栈与完整 UI 需另配 | 前两者已集成；完整本地化未确认 | README 声明微信/抖音等；本轮没有完整平台样例证据 |
| BDFramework.Core | 自有 AB 系统，同步/异步、分包/增量；取消/await 未核实 | 完整生命周期证据不足 | UFlux 状态/数据绑定强；原生 await 打开未核实 | YooAsset 未确认；存在 HybridCLRData 不能代替集成验证；本地化未确认 | 未找到小游戏证据；替换资源系统会影响现成流水线价值 |
| HTFramework | 文档称只支持异步，Resources/AB/Addressables；await 与 Handle 释放未核实 | 单入口场景优先，其他场景可打 AB | UI 自动调用资源模块；原生 UniTask 接口未核实 | YooAsset 待接；有 HybridCLR 教程链接；本地化为可选组件 | 未找到小游戏证据；反射 Hotfix 不等于 Android IL2CPP 热更 |
| TinaX | VFS 原生 await/UniTask，IAsset.Release/using | 当前适配不再验证 | OpenUIAsync、Page | 自有 VFS；历史 C#/Lua 热更 | 明确排除 WebGL且归档，保留作设计参考 |

TEngine 的资源所有权、Sprite 取消与异步窗口有具体文档，场景能力有源码支撑，因此更接近本项目优先级。仍要验证并发打开同一窗口、加载中关闭窗口、切场景后旧请求完成、下载失败重试与重复场景装卸。UI 实例池、图集、TMP 字体和长期隐藏窗口会影响内存，不能把自动引用组件理解为“无需资源管理”。([资源文档](https://github.com/Alex-Rachel/TEngine/blob/main/Books/3-1-%E8%B5%84%E6%BA%90%E6%A8%A1%E5%9D%97.md)、[UI 文档](https://github.com/Alex-Rachel/TEngine/blob/main/Books/3-5-UI%E6%A8%A1%E5%9D%97.md)、[场景源码](https://raw.githubusercontent.com/Alex-Rachel/TEngine/main/UnityProject/Assets/TEngine/Runtime/Module/SceneModule/SceneModule.cs))

GF 的资源管理不仅加载，还管版本、更新、文件系统与池；只换 ResourceHelper 不足以证明完成 YooAsset 迁移。QFramework 的 PanelLoader 边界较窄，更适合组合，但需统一音频和场景加载。**QFramework + JEngine 是待验证的组合路线，不能当成官方现成模板**；初始化、包名、热更程序集和资源 Handle 应由一套机制负责。([GF 资源源码](https://raw.githubusercontent.com/EllanJiang/UnityGameFramework/master/Scripts/Runtime/Resource/ResourceComponent.cs)、[QFramework loader 文档](https://raw.githubusercontent.com/liangxiegame/QFramework/master/Doc.md))

## UI 专项与战斗框架可以补能力，不能代替主框架

[Loxodon Framework](https://github.com/vovgou/loxodon-framework) 约 2.2k Star、MIT，偏 MVVM、数据绑定、多语言、窗口容器、消息和异步任务，适合 UI 较复杂的项目。它有自有 AsyncResult/CoroutineTask 及 await 扩展，文档窗口加载示例却是同步 LoadWindow，不能直接标为完整 await UI。可选 Addressables、FairyGUI、UIToolkit、XLua/ILRuntime 不代表已集成 YooAsset/HybridCLR；与主框架组合还要处理重复任务与窗口生命周期。([手册](https://github.com/vovgou/loxodon-framework/blob/master/docs/LoxodonFramework_en.md))

[EGamePlay](https://github.com/m969/EGamePlay) 约 2.4k Star、MIT，提供 Entity-Component 战斗、技能/Buff、ScriptableObject/Excel 配置，适合未来题材 Demo，不能替代资源/UI/发布底座。[ET10](https://github.com/egametang/ET) 约 9.9k Star，面向分布式 MMO、Fiber/Actor 和双端开发，本项目暂不需要其服务器复杂度；当前 [ET License](https://github.com/egametang/ET/blob/master/LICENSE) 限制修改后开源再分发，并要求商业上线授权，应作为源码学习及特殊需求候选独列，不能与 MIT 项目按宽松开源条件并列推荐。

严格按独立客户端仓库门槛，[GameFrameX.Unity](https://github.com/GameFrameX/GameFrameX.Unity) 约 214 Star，不能借总仓热度达标；OxGFrame、UniFramework、CatAsset、CosmosFramework 等也未达 500，未列主候选。这不会证明它们技术差，只是遵守本次筛选规则。

## 小游戏可移植性取决于平台边界，不能只看 WebGL 标签

TEngine 资源源码有微信用户数据目录与文件系统实现，是本轮最具体的框架级证据；JEngine 的多小游戏支持目前主要来自 README。YooAsset 2.x 官方说明包含微信/抖音适配，但框架、YooAsset、转换 SDK 与 HybridCLR 必须组合验证。([TEngine 平台源码](https://raw.githubusercontent.com/Alex-Rachel/TEngine/main/UnityProject/Assets/TEngine/Runtime/Module/ResourceModule/ResourceModule.cs)、[YooAsset](https://github.com/tuyoogame/YooAsset))

优先使用 PlayerLoop 驱动的异步调用，把存档、文件系统、网络和音频平台接口隔离。UniTask 的主要 PlayerLoop 操作适用于 WebGL/wasm，但线程池操作不能因此视为小游戏可用。Unity 官方微信文档指出普通 C# IO 不自动持久化，须走 WX 文件接口或下载缓存；缓存 manifest 和资源 URL 的版本策略也需要验证。([UniTask](https://github.com/Cysharp/UniTask)、[Unity 微信缓存文档](https://docs.unity.cn/cn/tuanjiemanual/Manual/WechatHttpCache.html))

不能假定社区版 HybridCLR 在各平台与商业版本有相同泛型能力，应按具体版本核验构建模式和 AOT 元数据。YooAsset [issue #746](https://github.com/tuyoogame/YooAsset/issues/746) 也提示 2.3.18 微信包内加载配置需要实测，不应泛化成永久限制。([HybridCLR 版本化平台说明](https://www.hybridclr.cn/docs/7.8.1/basic/supportedplatformanduniyversion))

## 以同一组验证结果决定主框架

建议先锁定 TEngine 的 commit 与依赖版本，在独立验证工程完成 Android IL2CPP 首包、代码/资源更新、两种语言切换、异步 UI 取消、2D/3D 场景装卸。随后用相同用例衡量 QFramework + JEngine，决定轻量组合节省的理解成本是否足以抵消补齐成本；GF 则用于比较调试与模块完整性。BD 和 HT 只有在其 UI 工作流或工具带来明确收益时再深入。

小游戏一旦成为实际目标，应尽早做最小微信真机包，验证冷启动、二次缓存、断网重试、缓存清理恢复、加载中取消和内存峰值。最终选择依据应是这些用例的结果与剩余维护工作量，而非框架功能数量。当前阶段适合选定试跑对象，尚不适合宣称任何方案已满足发布验收。
