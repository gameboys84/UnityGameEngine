# MyUnityFramework

引用 TEngineNi 共用 UPM 包的 Unity 客户端底座，包含框架专项测试和 SLG 假数据演示。当前未实现联网 SLG 业务。

## 打开与运行

1. 使用 **Unity 2022.3.62f2** 打开 `UnityProject1/`，等待依赖解析与编译。
2. 打开 `Assets/Launcher/Scenes/Launcher.unity`，点击 Play，进入 Main。
3. 通过主场景按钮检查资源、场景、存档、计时及假数据 UI；右下角 `LOGIC TESTS` 打开城建、研究、训练与资源事务测试面板。

UniTask、YooAsset、HybridCLR 是 `Packages/` 内的本地源码包，必须随仓库保留；其余 UPM 依赖按 manifest/lock 解析，首次打开可能需要网络。当前处于逻辑重写开发阶段，两个 Ni 包通过相对路径引用同级 `TEngineNi_UPM` 工作树，需要同时取得该目录。稳定发布时再切换到已发布的固定 Git 提交；当前修改尚未发布。Unity MCP 已固定工程原有提交，避免开发期间隐式升级。

## 核心文档

| 文档 | 用途 |
| --- | --- |
| [当前框架整体功能说明](Doc/当前框架整体功能说明.md) | 已确认目标、架构、模块能力、成熟度和接口约定 |
| [启动与进入游戏流程](Doc/启动与进入游戏流程.md) | 启动入口、配置、资源模式及失败重试 |
| [测试与演示指南](Doc/测试与演示指南.md) | 自动测试、演示界面、工作负载与历史验证边界 |
| [TEngine引入方式与来源](Doc/TEngine引入方式与来源.md) | 共用包、修改/升级方式、源码来源与验证边界 |
| [TEngineNi修改台账](Doc/TEngineNi修改台账.md) | 本地改动、回传候选与同步状态 |
| [工程与版本管理约定](Doc/工程与版本管理约定.md) | Git 管理范围、忽略策略与文档维护 |
| [程序集与目录结构](Doc/AssemblyLayout.md) | 共用逻辑、业务测试、运行时、Editor 和测试程序集边界 |
| [核心逻辑与业务测试](Doc/LogicRewrite.md) | 新增核心 API、业务测试规则、入口和集成范围 |

候选比较和未决定的设计见 [Design 索引](Design/README.md)，不作为已确定架构。运行验证目前主要来自 Windows Editor，移动发布、真实远端资源下载和 HybridCLR 代码更新仍待独立验收。

## 仓库结构

```text
Doc/                    核心文档
Design/notes/           保留的分析与待讨论建议
Design/scripts/         分析、审计与辅助验证脚本
Design/reports/         整体忽略的本机报告、差异补丁和测试输出，需要时生成
Design/local/           忽略的本机备份与一次性脚本
UnityProject1/Assets/   产品代码、场景、资源、Editor 工具和测试，包含 .meta
UnityProject1/Packages/ 第三方本地包、Ni 包引用、manifest 与 lock
UnityProject1/ProjectSettings/ 共享工程设置
UnityProject1/Tools/    本地/Git 框架依赖切换工具
```

工程发布到 [UnityGameEngine](https://github.com/gameboys84/UnityGameEngine)。更新框架时先验证 UPM 仓库提交，再同步本工程的 manifest/lock；具体流程见来源说明。
