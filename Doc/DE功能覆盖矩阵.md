# DE 客户端重构功能覆盖与验收

目标：在 UnityProject2 中使用当前 Ni 共享包与新分层重写 DE 客户端的逻辑、交互和表现。此文档记录完整目标，不将首轮可运行切片视为全量完成。原 DE 工程保持只读；原服务器和平台服务不属于本次重写范围，但客户端协议和响应行为仍属于范围。

## 来源与可追踪清单

- DE：`E:/TAP/DE/DeadEmpire-DEV`，Unity 2018.4.36f1。
- 新框架：本仓库 UnityProject1，Unity 2022.3.62f2；新工程 UnityProject2。
- 全系统入口：DE `Tools/AI/architecture/03_模块划分.md`；详细索引为该目录 README，共 34 篇。
- 源码清单生成器：`Design/scripts/de-source-coverage.py`。使用 Python 3，例如 `py -3 Design/scripts/de-source-coverage.py --source E:/TAP/DE/DeadEmpire-DEV --output Design/reports/de-source-coverage`。
- 清单输出：`source-coverage.json/csv`，包含过滤 C# 注释后的菜单注册、全部 ActivityData 类（基类独立分类）、业务代码目录、全部 Assets Prefab 和 Scene 路径及源文件哈希；另索引客户端 MsgType 符号及全部引用位置，排除生成协议文件，避免目录级统计掩盖遗漏的业务协议分支。
- 清单中的预处理分支未求值；静态注册不证明运行可达，素材存在也不证明当前产品启用。保留这类差异供核实，不自动删除或认定完成。
- 每次生成的清单全部标记 `not_migrated`，不会因新项目存在同名按钮或展示页而自动标为完成。报告输出整体忽略，不入版本管理；正式结论维护在本文件。

## 状态与通过依据

状态应分别记录，不能仅存一个完成百分比：未迁入、已实现、自动测试通过、Editor 交互通过、构建验证通过、外部依赖阻断。

每个源功能至少对应：新逻辑位置、新 UI/资源位置、用户入口、前置数据、正常/异常操作、预期结果、自动测试、截图/日志、环境和版本。Mock、录制响应、真实测试服、设备验收分别标记，互不替代。未知与遗留入口保留待核实，不自动判定无需求。

## 全量系统矩阵

下表是功能组的完整目标边界，初始全部未验收。细粒度条目以生成清单和后续源代码核实补充。

| ID | 系统组 | 验收范围 | 初始状态 |
| --- | --- | --- | --- |
| DE-01 | 启动/更新 | 启动阶段、资源清单、下载/缓存、错误重试、强更/停服展示、代码加载边界 | 未验收 |
| DE-02 | 账号/服务器 | 登录、角色与服务器、换号、绑定、迁服/合服、踢线/封号、重连 | 未验收 |
| DE-03 | 主城/城建 | 建筑选择、功能入口、升级条件、队列、取消、完成通知、产出气泡、城市氛围 | 未验收 |
| DE-04 | 队列/经济 | 服务器校时、免费完成/加速/求助、资源消耗与不足、版本拒旧、重复请求保护 | 未验收 |
| DE-05 | 兵营/修理/火车站 | 兵种解锁与训练、数量、队列、修理、火车站及权威状态同步 | 未验收 |
| DE-06 | 军官 | 升级、升星、军阶、技能、天赋/进修、主副将、3D 展示、解锁门控 | 未验收 |
| DE-07 | 科技/任务 | 全部前置条件、研究队列、主线/每日/章节、进度推送、奖励领取 | 未验收 |
| DE-08 | 道具/VIP/Buff | 背包、使用/批量使用、快捷购买、行动力、VIP 状态、Buff 时间和叠加 | 未验收 |
| DE-09 | 大地图 | 视野对象、迷雾/昼夜、地图数据、小地图、迁城、采集、侦查、领地 | 未验收 |
| DE-10 | 行军/集结 | 编队、容量与军官加成、出征/召回/到达、路线插值、节点与模式隔离 | 未验收 |
| DE-11 | 战斗/FPS | 回合表现与胜负来源、战报、FPS 输入/AI/关卡切换/退出恢复 | 未验收 |
| DE-12 | 联盟 | 入退盟、成员/权限、捐献/科技/帮助、礼物、领地/据点、战争大厅 | 未验收 |
| DE-13 | GVG/KVK | 报名、阶段、战场节点、跨服状态、任务/悬赏/战略/重建/补偿 | 未验收 |
| DE-14 | Arena/远征/Raid | 编队、挑战、回合播放、排行/历史、独立地图、退出及共享状态恢复 | 未验收 |
| DE-15 | 战舰/潜艇/武器 | 战舰、舰载武器、潜艇、军官专武、升级/改造/编组/进度 | 未验收 |
| DE-16 | 装备/军旗/制造 | 装备/材料/图纸、穿戴、制造、合成、军工厂及回收 | 未验收 |
| DE-17 | 指挥官/收藏 | 指挥官档案、派遣、3D 军官房间、博物馆/勋章/档案/荣誉/头像 | 未验收 |
| DE-18 | 政府/排行/城防 | 政府、市长、总部编制、排行、皮肤、城防/着火、警戒与来袭预警 | 未验收 |
| DE-19 | 社交/邮件/聊天 | 好友/黑名单、邮件分类/阅读/领取/战报、频道/消息、敏感词、公告/跑马灯 | 未验收 |
| DE-20 | 招募/商店/战令 | 招募、各货币商店、兑换、常驻/活动/KVK 战令、领取条件与幂等 | 未验收 |
| DE-21 | 活动框架 | 拉取/更新/删除、开关、图标排序、未知活动、页签、红点、自然开始与结束 | 未验收 |
| DE-22 | 全部活动玩法 | 按 ActivityData 每个具体类追踪；任务/兑换/排行/节日/小游戏/回归/签到等分别验收 | 未验收 |
| DE-23 | 引导/HUD/弹框 | 真新号引导与恢复、选军官、HUD 门控/红点、挖孔、弹框顺序/互斥与返回栈 | 未验收 |
| DE-24 | 支付/SDK 门面 | 商品/礼包、取消/失败/挂起/补单、收据交付、服务端确认后到账；平台登录/推送/客服/埋点 | 未验收 |
| DE-25 | 配置/语言/音频/设备 | 配置加载与常量、多语言和字体、声音/设置持久化、前后台/安全区/画质 | 未验收 |
| DE-26 | 资源/UI/工具/遗留 | 加载和释放、模型/动画/材质、窗口布局与输入、构建/热更、GM 隔离、视频频道可达性核实 | 未验收 |

## 必须保持的业务边界

1. 建筑、资源、部队、战斗结果和奖励以服务器状态为准。客户端倒计时归零不得自行授予完成结果。
2. 快照必须检查账号、会话代次和递增版本；旧响应、重复响应与上一账号的延迟回调不得污染当前状态。
3. 重复命令、重复奖励、失败与资源不足不能重复结算或部分扣费。测试预期来自独立固定夹具，不读取实现结果作为预期值。
4. 取消/重连/换号/停 Play 后监听、计时、实例与资源要正确清理；重新进入不重复注册。
5. Mock 必须在运行界面和验收记录明确标记。Mock 完成不代表兼容原服务、支付或聊天 SDK。
6. 原 DE 菜单和素材重用不等于新框架接入。保留旧活动源码驱动新 UI，不能计为完成逻辑重写。

## 自动与交互验收

- 新项目编译与程序集检查：依赖方向、无重复活动框架、无缺脚本/缺 GUID、Editor 插件不进入运行程序集。
- EditMode：条件与数据校验、快照版本/会话隔离、命令幂等、失败不变更、资源不足、权威完成、模型副本隔离。
- PlayMode：从启动入口进入实际新界面，通过 EventSystem 真实输入路径检查首个射线命中、模态拦截、导航/关闭、状态与画面一致。
- 异常恢复：加载失败、超时、弹框、断连、重复点击、退出后延迟响应、停止再运行。
- 构建验证：目标构建关键流程和资源加载独立执行；Editor 模拟通过不证明设备包资源齐全。

历史 UnityProject1 测试和 DE 架构手册仅为参考，不能作为本次 UnityProject2 已通过的证据。初次实际运行前，本文件不宣称任何功能组通过。

## 本机环境事项

主控在本轮发现 Unity/UPM 工具子进程启动环境缺少 `APPDATA`、`LOCALAPPDATA`、`USERPROFILE`，需显式继承用户环境后重新启动。此项属于已定位的环境问题；是否恢复、包解析是否成功以及测试结果，以主控实际重启和运行证据为准，不由此直接标记编译通过。

## 首轮源行为审查与新 API 对照

以下方法已读原代码核对；新实现状态需要独立验收。新 API 的 Mock 规则均为夹具，不等于原 DE 数值。

| 语义 | 原 DE 源依据 | 新 API 接入与验收要求 | 首轮差异 |
| --- | --- | --- | --- |
| 建筑定位 | `OwnBuildingMgr.RequestBuildingUpgrade`：tileIdx 经 building_pos.KPosIndex 映射 m_buildID | 命令目标必须保留真实建筑ID和地块对应；UI名称不能代替身份 | Mock 只有 hq/lab/barracks 三字符串ID |
| 建造并发 | `Progress.CastToProgressMap(List<BuildingProgInfo>)`：m_queue_id+1；`ProgressMgr.UpdateProgressData`处理槽位1/2/3 | 配置和权威快照携带可用槽位与占用；同一槽互斥，不同开放槽可并行 | Mock 初始一个 Building 组 |
| 建筑取消 | `OwnBuildingMgr.RequestBuildingCancel/AckHandlerBuildingCancel`；资源由 RES_NTF | ACK确认取消/更新队列；资源变化只接权威状态 | Mock 半价退款仅本地夹具 |
| 研究前置 | `ResearchMgr.GetResearchItemLockFlag`：m_PreTech1ID..3ID按 preID/100查研究类型、level>0；研究所满足m_BuildLevelReq | 配置驱动研究定义，三项前置同时检查；不要把preID后两位误当原逻辑要求等级 | Mock 两科技且只看研究所等级 |
| 科技同步 | `RequestUpgradeResearchItem`，UPGRADE_RESEARCH_NTF/RESEARCH_COMPLETE_NTF/TECH_ITEM_NTF | 命令接受不等于完成；通知更新等级和队列；拒绝与超时保留可恢复状态 | Mock Session自己模拟权威，不是旧协议适配 |
| 训练请求 | `OrdanceFactory.RequestTroopsTraining(List<ArmyInfo>,bool)` → TROOP_TRAIN_REQ | 保留兵种/数量列表与立即完成意图；完成数量由TROOP_NTF更新 | Mock单兵种和fixture成本 |
| 训练队列 | `OrdanceFactory.GetProgressTrainingTypeFromArmyID`：training.m_AtkType → PROG_TRAINING_JEEP+(AtkType-1)，即14..17 | Jeep/Tank/Helicopter/Cannon各类队列独立，同组互斥；GVG场景隔离另验 | Mock起初所有Training共用一槽，已交开发修复 |
| 加速与免费 | `ProgressMgr.CanUseFree`/`HandleFree`/`HandleHelp`；BUILDING_FREE_INFO_NTF；SpeedUpItemMgr | 免费只适用建造且使用权威freeTime；联盟求助类型/重复限制；道具与钻石分开 | UI曾把60秒道具发成1秒钻石命令，已交美术修复并需回归 |
| 邮件领取 | `MailManager.RequireClaimMail`发CLAIM_RTF_MAIL_REQ；`NtfHandlerMailReward`消费CLAIM_RTF_MAIL_REWARD_NTF，展示资源/道具 | ACK不直接加资源；奖励通知与资源状态分别处理；重复通知不重复效果，失败能恢复 | Mock mail-1固定300food，仅验证局部事务夹具 |
| 倒计时完成 | `ProgressMgr.UpdateProgressData/HandleProgressFinished`，架构33完成判定 | 时钟只供显示；真实客户端不得Tick到时自行发奖/升级 | DeClient与Mock authority已分开，仍需真实通知适配验收 |

首轮审计输出：菜单250、ActivityData具体类60及基类1、业务目录135、Prefab7142、Scene229、客户端协议符号1406，共9223条，重复身份0；这些是源码清单数量，不是已迁入数量。源码生成时全部标为未迁入。

## 当前验收资产及执行边界

已提供27个EditMode用例（模型、客户端权威隔离和Mock事务）以及4个PlayMode输入用例。PlayMode在隔离Canvas中使用生产DEShellView和真实StandaloneInputModule的按下/抬起处理，验证导航、返回、模态射线遮挡、取消不扣费、确认请求和换号清理；不直接调用Button.onClick。

这些用例未覆盖全部DE功能。UI夹具不代替Launcher/YooAsset集成、原服务联调或设备验收。

本轮实际执行：

- Python 3清单注释解析回归3/3通过，实际源清单9223条。
- 独立.NET10编译测试源码成功，但Unity自带NUnit依赖旧CallContext，该运行器的执行被TypeLoadException阻断；此批没有业务断言结果。
- 随后使用已安装Unity 2022.3.62f2自带Mono，并用同一NUnit DLL与未修改的27个逻辑测试重新编译、离线执行：27/27通过、0失败。测试包括模型、客户端权威隔离与明确Mock事务；不是Unity Test Runner结果。
- 主控反馈Editor停在 `Corrupted Library Detected` 原生弹框，用户物理Esc已停止Computer Use。未执行Unity编译、EditMode、PlayMode、实际场景或目标构建验收。4个UI输入用例仅已编写，未运行；不得标为通过。

本轮新业务仍只是明确标记的Mock原型和首批重构基础，原DE全量功能没有完成迁移，不能据27个逻辑用例判定全量完成。

### 后续修错阶段的静态与离线编译审计

主控处理Unity包解析异常期间，验收侧未操作桌面、未启动Editor，对UnityProject2实际内容进行独立检查：

- Assets共467份有效meta；重复GUID、非法meta、重复程序集名称、项目程序集循环、无程序集归属C#以及缺失C# meta均为0。
- 按10个DE asmdef分别编译实际项目源码：Domain、Application、Infrastructure、Presentation、Bootstrap、EditModeTests、PlayModeTests、Presentation.Editor、Bootstrap.Editor、IntegrationTests全部通过，无编译器输出。
- 编译使用已安装Unity参考程序集与UnityProject1缓存的基础包DLL，不能证明UnityProject2包解析、全新导入或运行成功。离线过程把asmdef中的`Unity.ugui`引用映射到现有`UnityEngine.UI.dll`；Unity导入能否识别旧引用名称需包恢复后另查，不据此静默修改共享包。
- 审计工具为`Design/scripts/de-project-audit.py`与`de-compile-offline.py`，原始JSON放忽略的`Design/reports`。没有为了通过编译而修改测试断言。

### UGUI程序集引用针对修正

已核对UnityProject2本机解析出的`Library/PackageCache/com.unity.ugui@1.0.0`：UPM的`package.json.name`是`com.unity.ugui`，运行程序集`Runtime/UnityEngine.UI.asmdef.name`是`UnityEngine.UI`。项目、嵌入包、PackageCache和两个Ni包内未找到声明名称为`Unity.ugui`的asmdef。包标识与程序集标识不能互换。

仅将UnityProject2的Assets内11份asmdef引用从`Unity.ugui`修正为`UnityEngine.UI`：Launcher、GameCore、GameRuntime、GameProject.Editor、Foundation.EditModeTests、Foundation.PlayModeTests、Startup.PlayModeTests、DE.Presentation、DE.Presentation.Editor、DE.PlayModeTests、DE.IntegrationTests。未改UnityProject1及共享UPM源码。

修正后再次按10个DE程序集编译实际源码，10/10通过，编译器输出为空，离线引用别名映射全部为空。这仍是依赖已安装Unity与基础缓存DLL的离线编译，Unity包导入与运行结果另记。

共享源码仍保留旧引用，以下4份由主控在包恢复后决定修复并登记TEngineNi台账；本次未修改、未同步或发布共享包：

- `TEngineNi_UPM/com.ni.tengine/Runtime/TEngine.Runtime.asmdef`
- `TEngineNi_UPM/com.ni.tengine/Editor/TEngine.Editor.asmdef`
- `TEngineNi_UPM/com.ni.gamecore/Runtime/Ni.GameCore.asmdef`
- `TEngineNi_UPM/com.ni.gamecore/Editor/Ni.GameCore.Editor.asmdef`

项目修复前后SHA记录为`Design/reports/de-ugui-project-reference-fixes.json`；无别名编译报告为`Design/reports/de-offline-compile-ugui-fixed.json`。辅助离线编译器改用csc响应文件，避免Windows命令行长度限制；未改变产品源码或测试断言。
