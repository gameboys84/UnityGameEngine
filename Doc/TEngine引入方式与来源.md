# TEngine 引入方式与来源

更新：2026-10-27。共用 UPM 包独立发布到 [TEngineNi_UPM](https://github.com/gameboys84/TEngineNi_UPM)，消费工程通过完整 Git SHA 引用。

## 仓库与源码归属

| 内容 | 权威位置 | 程序集 |
| --- | --- | --- |
| 框架核心、事件、资源、场景、计时与编辑器工具 | TEngineNi_UPM/com.ni.tengine，版本 0.6.0 | TEngine.Runtime / TEngine.Editor |
| UI、存档、单例、集合、资源引用、实例池、列表 | TEngineNi_UPM/com.ni.gamecore，版本 0.1.0 | Ni.GameCore；命名空间 GameCore |
| UI 生成器、HTML 烘焙器和设置面板 | com.ni.gamecore/Editor | Ni.GameCore.Editor |
| GameModule、Ni GameApp/IEvent/Network、协议与业务配置 | 各自工程 Assets | 各项目 GameCore / GameRuntime |
| 启动器、资源采集、HTML、输入与生成设置 | 各自 Assets / ProjectSettings | 项目管理 |

TEngineNi 的 `tengineni_upm` 分支保留原 fork 历史，并以 `FrameworkPackages` Git 子模块引用独立包仓库。Ni UnityProject 中的两个 `file:../../FrameworkPackages/<包名>` 引用保持可用。克隆 Ni 后执行 `git submodule update --init FrameworkPackages`；修改包需在子模块建立分支并提交，随后提交父仓库指针。

本工程发布到 UnityGameEngine，两个 Ni 包采用 `https://github.com/gameboys84/TEngineNi_UPM.git?path=/<包名>#<完整SHA>`。无需同级 Ni 检出目录，manifest/lock 一同入库。UniTask 2.5.11、YooAsset 2.3.17、HybridCLR 8.8.0 继续保留当前嵌入包，避免改变已验证依赖。全新项目可使用包仓库 README 的五项 Git 安装模板或 Tools/Install-NiPackages.ps1；包内 package.json 不能声明传递 Git URL。

## 修改、上游同步与升级

1. 在独立包仓库建立功能分支，保留原 .meta / GUID；消费工程开发期可切换到本地包目录。
2. 修改登记《TEngineNi修改台账》，执行包导入和相关消费工程测试。项目题材、网络、假数据与 Demo 不并入共用包。
3. 包提交经验证后先推送 UPM 仓库，再更新 Ni 子模块指针和消费工程的固定 Git SHA。正常升级不再复制 Assets 下源码。
4. 验证消费工程重新解析及运行后，提交其 manifest/lock 和必要集成改动。回退时恢复已知可用提交与 lock。

本工程切换工具：

```powershell
# 默认本地目录为同级 TEngineNi_UPM；也可指定 Ni 的 FrameworkPackages 子模块
./UnityProject1/Tools/Set-NiFramework.ps1 -Mode Local -WhatIf
./UnityProject1/Tools/Set-NiFramework.ps1 -Mode Local -SourceRoot E:/Git/TEngineNi/FrameworkPackages
# SHA 必须存在于 SourceRoot 的包仓库，且先推送再消费
./UnityProject1/Tools/Set-NiFramework.ps1 -Mode Git -Revision <完整40位SHA> -WhatIf
./UnityProject1/Tools/Set-NiFramework.ps1 -Mode Git -Revision <完整40位SHA>
```

工具只更改两个 Ni 依赖，不提交或推送；切换后由 Unity 重新生成 lock。不要修改 Library/PackageCache。独立包仓库也保留第三方固定快照及原许可，供新项目安装完整依赖。

TEngineNi 仍可 fetch/merge 原 TEngine 上游，但目录移动后的重复源码不能直接覆盖合并。先在独立工作分支检查上游旧 Assets 目录差异，映射到对应包，保留项目配置；验证后将共用改动提交到 UPM，再更新 Ni 指针。旧 update-tengine.bat 已增加包布局保护，不运行覆盖式更新。

## 兼容与验证边界

330 个当前迁移脚本及 312 个 Ni 原脚本的 GUID/.meta 在拆分时已核对。GameCore 共用类型迁入 Ni.GameCore，命名空间和脚本 GUID 保留，原 GameCore 程序集仅保留项目门面。managed-reference、反射程序集名及既有热更产物仍需具体工程检查。

2026-10-26 已取得当前工程 Unity 编译、EditMode 3/3、PlayMode 10/10、26 Prefab 无缺失脚本及完整 .NET 构建证据。2026-10-27 独立发布验证见《测试与演示指南》及包仓库 VALIDATION.md。Ni 自身 CLI/Pipeline 缺失，尚无其独立 Editor/PlayMode 验收；包测试和消费工程测试不替代该项。IL2CPP、AOT 元数据、泛型、裁剪、设备热更与远端资源下载仍需专项验收。

原始日志、临时测试工程和迁移备份分别放在忽略的 Design/reports、Design/local；正式结论保留 Doc。

## 历史来源

初始框架来自 Ni 的 UnityProject/Assets/TEngine 及选取的 GameCore、生成器、本地依赖包。初始导入读取工作目录，未保存整套源码提交基线；`2b13c76ff4bd61048143288556d9791088f77bc7` 是当时及本轮迁移前的 Ni HEAD，不能证明初始全部文件等同该提交，也不包含本轮新包。

DeadEmpire 提取的七个已记录来源文件：HVScrollRect、T4fContentSizeFitter、HoleImage、TextGradientColor、UnityEngineObjectExtention、TimeUtility、BezierUtils；另有改造后的集合、循环列表和图标加载用途。现归共享 GameCore 包。初始源哈希仅保留本机 reports，不能由当前文件原样重建。未迁入 DeadEmpire 城建、战斗、协议、账号、SDK、签名和整套资产。

`Design/scripts/import-foundation.ps1` 仅是历史首次导入记录，不是包升级工具；目标存在时会拒绝覆盖。候选比较与旧实现研究保留在 Design/notes，不能覆盖当前包化事实。后续审计通过 `audit-tengine-changes.ps1` 记录包身份、两边依赖、来源工作树 SHA256 和 Git diff，所有 reports 仍不入库。

## 包版本与上游版本

当前采用映射约定：上游 TEngine `M.N.P` 对应 Ni TEngine `0.M.N`，完整上游版本另行记录。例如 `6.1.0 → 0.6.1`；当前上游 package.json 声明 `6.0.0`，故 Ni 包版本为 `0.6.0`。该声明不是已核验的纯净上游提交基线。

| Ni 包 | 当前版本 | 上游/依赖 |
| --- | --- | --- |
| com.ni.tengine | 0.6.0 | TEngine 声明版本 6.0.0；Ni 含本地改造 |
| com.ni.gamecore | 0.1.0 | 依赖 com.ni.tengine 0.6.0；使用独立版本序列 |

此映射不包含上游第三段补丁号，也没有额外容纳 Ni 自身修订号的位置。完整来源版本、补丁与兼容变更须另记变更说明；Git 消费用完整 commit SHA 区分工作版本。未来若要单独发布同一上游基线的多个 Ni 修订，应先明确转为独立递增版本规则，已发布版本不覆盖或复用，不用会产生倒序的预发布后缀冒充补丁升级。

