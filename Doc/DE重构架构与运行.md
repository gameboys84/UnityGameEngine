# DE 客户端重构

## 当前目标与范围

长期目标是在 UnityProject2 的新框架中重写真实 DE 客户端的逻辑和表现。当前按用户要求优先完成“启动到登录完成”：资源初始化、dev HTTP 引导、HTTPS 鉴权、TCP 网关、SESSION_TOKEN_NTF/Pike、真实有效 LOGIN_ACK。21 步玩家数据加载、主城与后续功能暂停，不能以本阶段结果宣称整体 DE 完成。

真实来源为 E:/TAP/DE/DeadEmpire-DEV（Unity 2018.4.36f1），只读分析和迁移，不用 Unity 2022 打开来源。目标 UnityProject2 使用 Unity 2022.3.62f2，两个 Ni 包直接引用同级 TEngineNi_UPM 工作树，不复制第二份框架源码。

## Team 与协作

| 角色 | 当前责任 |
| --- | --- |
| 主控 | Bootstrap、框架资源整合、唯一 Editor 操作者、真实 dev 联调与证据整理 |
| 功能开发 | 原 HTTP/鉴权字段、协议72、TCP、方向独立 Pike、会话代次、取消与重连 |
| 美术开发 | 原 LoadingScreenSplash、原登录失败弹框、字体与依赖闭包、2022 UGUI 适配 |
| 独立验收 | 真实协议契约与失效会话测试、原按钮 EventSystem 输入验证、失败记录 |

代码按职责分区；Play 期间不导入脚本，主控退出 Play 后统一刷新。原开发阶段修改留工作区；本次用户已授权按 package 分开提交到本地 Git，不推送或回传共享框架。

## 当前运行链路

DEBoot.unity → DeProductionRuntimeHost → Ni/TEngine 资源初始化 → 真实配置与语言 → 原加载界面 → DeProductionClientFactory.CreateDevelopment → dev 引导 → HTTPS /auth → 配置 AddrList 网关 → 原 session token 与 Pike → LOGIN_REQ/LOGIN_ACK。

生产入口不使用 MockDeSession 或 SnapshotReplaySession，不在失败时回退本地角色。历史 Mock 原型仅留作显式测试夹具，不计真实验收。EditorSimulateMode 仅表示 YooAsset 从真实本地资源加载，不模拟业务或服务器。

登录成功要求合法服务端 UserInfo.m_id 与鉴权角色一致，并属于当前有效、未取消的会话代次。完成后停留原加载画面并显示“登录完成”，不启动后续数据或主城加载。状态、网络计数与错误可通过 DE.Login.Status 读取，凭据和令牌不写日志。

原协议生成文件按来源迁入，未手改字段。配置与语言从真实 pack 导出；重复键遵循来源 Dictionary 的 last-value-wins，原始条目数与唯一键数分别记录。原 loading 和 CommonMsgBox 使用原素材、层级与绑定，并精确适配 UGUI 脚本引用。

## 打开与验证

1. 运行 UnityProject2/Tools/Start-DE.ps1，或用 Unity 2022.3.62f2 打开 UnityProject2。
2. 首次执行菜单 DE/Prepare Production Project，打开 Assets/AssetBundle/DE/Scenes/DEBoot.unity。
3. 执行 DE/Login/Original Portrait 750x1334，再进入 Play。
4. 使用独立的 de-rewrite-test- 设备身份访问固定 dev；真实完成以 LOGIN_ACK 证据为准。
5. 原登录失败框提供重试、取消。验证工具 DE.Login.Click 经 EventSystem down/up 与首命中校验操作原按钮，不直接调用按钮回调。

自动化使用固定 UniCli 1.7.0，与 Unity 2022 兼容，来源和适配见 Design/notes/UniCli-PIN.md。Tools/Invoke-UniCli.ps1 只连接既有目标 Editor，禁止自动启动或聚焦。Editor 域重载可能关闭管道，须读状态后决定是否重试操作。

## 环境与证书处理

Start-DE.ps1 补齐缺失的 Windows 标准用户目录环境变量，尤其 UPM 6.1.5 必需的 ALLUSERSPROFILE。Ni 和项目 asmdef 使用实际程序集 UnityEngine.UI（UPM 包名仍为 com.unity.ugui）；共享改动记录于 TEngineNi修改台账，未回传。

真实 dev 鉴权已确认存在证书名称及证书链错误。参照原 DE Editor 的行为，兼容策略仅用于 Editor、固定 dev 引导、独立测试身份和本次引导返回的鉴权 host:port；缺证书仍拒绝，其他域和 Player 保持严格校验。不设置全局证书放行或旧 TLS 协议降级。兼容回调与实际服务连接分别验证，不能以策略单测代替登录成功。

## 验收与证据

真实 Unity Editor 网络 EditMode 测试18/18通过；它们验证协议与失效会话等本地契约，不代表真实登录通过。主控已在实际 Unity Editor 完成 dev HTTP 引导200、HTTPS鉴权200、SESSION_TOKEN_NTF、Pike与合法身份一致的LOGIN_ACK；当前会话代次匹配，最终采样间隔35秒，收包129→132、发包1→3，明确记录两条HEART_BEAT_REQ:0对应的COMMON_ACK，Console Error为0；完成画面文字重叠已修复并复拍。最终网络回归18/18通过、0失败、0跳过。原失败框重试与取消也通过实际EventSystem输入验证。这是Windows Editor的本阶段通过证据，不代表Player构建或后续业务/主城验收。

截图、脱敏状态和测试输出保存到被忽略的 Design/reports/de-rebuild。详细门槛见 DE真实链路验收.md；后续全量范围见 DE功能覆盖矩阵.md。旧原型、静态资源或源工程运行结果均不能代替新工程真实链路验收。


## 本次提交边界

用户确认可以运行，但缺少足以定位实际执行阶段的日志。本次仅按 package 保存 Git 现状，不重跑真实服务器登录。上述历史验收结果不作为本次新产生的证据。静态 GUID/程序集审计通过；严格入口扫描因 Bootstrap 中保留历史 DeRuntimeHost.CreateMock 而未通过，生产 DeGameEntry 实际调用 DeProductionRuntimeHost，历史夹具进一步隔离仍待处理。
