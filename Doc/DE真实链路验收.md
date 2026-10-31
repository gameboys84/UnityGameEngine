# DE真实启动、登录与主城验收

用户已明确纠正目标：重构对象是`E:/TAP/DE/DeadEmpire-DEV`真实客户端，包括真实服务器通信、原视觉和业务行为。前期Mock界面、Mock事务、快照录制、源表导出或静态截图都不能作为真实链路通过的证据。Mock测试结果只保留为历史局部原型结果，不计本目标完成度。

当前用户明确缩小执行阶段为：真实启动 → dev HTTP引导 → HTTPS鉴权 → 网关 → session token → 确认有效LOGIN_ACK。以下R5及之后的21步、主城、业务与表现均暂停，本阶段不执行也不声称完成。本文保留后续计划仅作目标背景。

## 当前LOGIN_ACK阶段独立验收状态

- 完成标准：真实dev配置有效；鉴权返回code0、合法角色ID与JWT；TCP来自配置AddrList；收到原SESSION_TOKEN_NTF并按源规则建立方向独立Pike；真正解码LOGIN_ACK且UserInfo.m_id>0并匹配鉴权所选角色；当前连接代次有效且未取消/失败；不依赖本地构造UserInfo或Mock回退。
- 失败与隔离：错误身份/COMMON_ACK失败不置登录成功；超时、取消、关闭后不得交付旧队列；旧transport/旧generation不能进入RawState；回调由Pump调用线程派发；取消不能因某个Task恰已完成而被吞掉。
- 独立发现并交功能开发修复两项：CloseTransport后旧queued仍可回调，以及预取消AwaitWithTimeout对已完成Task报告成功。修后保持原断言重新验证。
- 当前仅运行`DE.Production.Network.EditModeTests`，包含真实源协议/wire11项、代次/关闭/取消/线程交付7项，共18项；独立离线执行通过，主控随后在实际 Unity Editor Test Runner 执行18/18通过、0失败、0跳过。这些是本地协议与会话契约测试，不能作为live登录证据。
- 限定编译只构建Network和其测试两程序集，2/2通过；Network保留一条离线Newtonsoft netstandard2.0→2.1的CS1701警告，测试程序集无输出。未用缺失程序集名称别名兼容；不能替代主控实际Unity编译。
- 之前Unity实编译暴露的ProductionData与ProductionLoading测试Newtonsoft依赖已完成实际落盘修复：overrideReferences=true，precompiledReferences含Newtonsoft.Json.dll及nunit.framework.dll，保留TestAssemblies。当前不运行这两阶段测试。
- 历史DeMockTransactionTests与DeShellInteractionTests保留原断言并标HistoricalPrototype/Explicit；DeClient/快照纯契约保留UnitTests分类，不作为真实服务器验收通过。
- 主控实际运行：真实资源初始化、dev HTTP引导200通过；鉴权TLS发现证书名称与证书链错误；按原Editor行为接入限域兼容后，真实HTTPS鉴权200、SESSION_TOKEN_NTF/Pike和LOGIN_ACK均通过，合法用户匹配鉴权角色及当前代次。最终35秒采样期间收包129→132、发包1→3，明确记录两条COMMON_ACK的API=HEART_BEAT_REQ、code=0，Console Error为0。实际Mono回调使用相对URI的合成GET，请求级捕获目标用于限域；绝对URI不匹配、取消、Dispose和缺证书仍拒绝。已通过原失败框的实际EventSystem down/up验证：取消使Faulted→Canceled并关闭弹框，重试关闭弹框并重新发起真实登录；首射线命中原按钮持久绑定，输入/焦点/模块均恢复。750×1334原资源截图已检查。证据见Design/reports/de-rebuild的unity-login-network-tests.json、real-cancel-pointer-runtime-provider.json、real-retry-pointer-runtime-provider.json、real-de-login-failure-portrait.png。

## 已核对的原工程环境

- 原工程Unity 2018.4.36f1，新工程Unity 2022.3.62f2；原工程只读，不用2022打开原工程。
- 原`ProjectSettings.asset`版本0.69.0；`GameUtils.GetVersionNumber`计算6900；`ProtocolTypeEnum.cs`的`Protocol.Ver/RunVer`均72。
- `Assets/Resources/ServerEnvs.txt`的`cur_branch`为trunk，dev启动基址`http://dev-global.de.t4f.cn:2000/urls/get/`。只测试dev，不连接online/a104，不执行支付、GM或运营后台操作。
- `StartupMgr.StartGetStartupInfo`用`GetVersionKey()`加`?appVersion=6900&udid=<专用测试设备标识>`；原编译分支Editor未定义UNITY_ANDROID时使用IOS_6900，Android用ANDROID_6900。不能不顾平台/渠道硬编码不匹配的版本键。
- 启动JSON决定强更、停服、鉴权和网关。HTTP 200不等于有效配置：必须拒绝Error/can not find以及缺失鉴权/网关的响应。
- 鉴权走启动JSON`AuthAddrList`（无列表时`AuthAddr`）的HTTPS `/auth`；TCP目标来自`AddrList`，不是鉴权响应`gate_ip`。
- 鉴权返回的jwt及账号密码仅内存使用，不进入Console、截图、报告或Git。报告仅存脱敏账号标识、角色ID、服务器ID、阶段、计数与时间。

依据：原`.claude/skills/ask/SKILL.md`，架构04/07/08/09/15/21/30/33，及相应源方法。原手册为静态参考，尚未在本轮运行旧工程建立基准。

## 网络与客户端依赖

1. 原`NetSession`在TCP收到SESSION_TOKEN_NTF后解析key1/key2，按`InitPike`位操作派生密钥，创建独立收/发Pike状态；不能用任意加密或JSON socket替代。
2. `COMPRESSED_NTF`和`COMPRESSED4B_NTF`分别使用16位与32位压缩长度。解压后继续解析内层node/message header，不能把解压结果当作最终业务JSON。
3. 原`ProtocolDefine0..5/ProtocolTypeEnum/ProtocolCreator/ProtocolMVC`与`Scpp.SP​ack`及序列化器形成协议闭包；保持版本72与节点路由。生成文件只读迁移，不手改字段来适应伪造回包。
4. Pike位于`Assets/Scripts/Net/Pike/Pike.cs`，LZ4位于`Assets/Scripts/Lib/LZ4`，两者均C#实现；不需要为这两项猜测native库。
5. `FromLua.ext`的Editor native库为`Assets/Plugins/GameSwfProjDll.dll`，实际PE Machine=0x8664/x64，4,590,592字节。Android有armv7/arm64 `libT4FEngine.so`，iOS为`__Internal`。若新实现复用ext，必须正确配置PluginImporter和调用链；若平台门面被重写，需逐项替换真实语义，不能空实现静默成功。
6. `gameData.pack/loc.pack`及地图二进制来自`Assets/StreamingAssets/GameData`；配置/语言加载、旧资源路径映射、地图数据、模型/材质/动画/字体与脚本引用需成闭包。只迁入主城截图或一个空场景不通过。

## 可重复的真实链路验收步骤

| 阶段 | 操作与前置 | 通过证据 | 不通过情况 |
| --- | --- | --- | --- |
| R0 默认入口 | 冷启动新工程默认Launcher，使用专用dev测试设备ID | StartupSettings和实际创建对象均指向生产连接，无Mock/Replay回退 | 仍进入GameRuntime demo、CreateMock或伪造数据 |
| R1 HTTP引导 | GET匹配版本键的dev启动地址 | 有效启动配置、来源、平台/版本、脱敏地址集合和阶段时间 | 仅HTTP200，或Error配置继续运行 |
| R2 鉴权/角色 | 按原请求字段HTTPS /auth；已有专用测试角色或显式选角 | code0、合法jwt存在但不记录内容、角色/服务器匹配、失败可重试 | 本地构造角色、任意鉴权失败仍进入场景 |
| R3 TCP会话 | 连接配置AddrList，等待SESSION_TOKEN_NTF | 真实远端端点、收发字节/包计数、token阶段和Pike启用顺序 | TCP连接成功就当登录；重复使用同一Pike收发状态 |
| R4 协议登录 | 发送真实LOGIN_REQ并等待LOGIN_ACK或精确COMMON_ACK | 对应协议号、服务端成功码、合法UserInfo/角色；拒绝错误角色 | 忽略COMMON_ACK、用本地UserInfo冒充 |
| R5 玩家加载 | 按原GameLoadingMgr.TypeGameStart共21项（含DONE）拉取与等待 | 每项请求/回包/完成状态，版本72真实推送，所需配置齐全 | LOGIN_ACK后直接宣布主城Ready |
| R6 原视觉主城 | 加载原main_city对应迁移资源，构建MainUI/HUD、建筑/角色/资源显示 | 活动场景、资产闭包、无缺脚本/材质、可回看截图，与实际服务端数据一致 | 新dashboard或固定截图、空壳Prefab、固定5000资源 |
| R7 主城可操作 | 用实际输入选择建筑并打开原对应功能入口 | 首次射线命中、原视觉界面、展示真实等级/消耗、无新增异常 | 只调用按钮回调或仅检查对象存在 |
| R8 失败恢复 | dev不可达、鉴权拒绝、网关关闭；恢复后重试 | 明确失败状态、连接/监听清理、无Mock回退、旧会话不污染 | 失败转离线模拟、“成功”但没有网络 |

原主城判据是`NCurrentStateID==STATE_CITYBUILD`且`BCurrentSceneHasLoad`，并有MainUI/HUD和原建筑表现；新框架可采用等价的新状态机，但必须保留语义和证据。不能用`IsLoggedIn`一个标志代替R5-R7。

初次只进行读取与导航，不发送建造、消费、部队出征、支付等变更请求。真实业务变更后续使用专用dev角色单列验收，不用生产或个人账号。

## 默认入口必须排除的旧内容

- `StartupSettings.asset`不得指回`GameRuntime.GameApp`和`Assets/AssetBundle/Scenes/Main.unity`的底座假数据演示。
- `DE/Prepare Rebuild Project`不得再将入口设置为调用Mock的DeRuntimeHost；生产准备菜单应配置真实连接与真实视觉路径。
- 生产Bootstrap中禁止`CreateMock`、`new MockDeSession`、`SnapshotReplaySession`、`FakeSlgState`及失败后的隐式回退。
- 前期MockShell和MockIntegration断言（例如要求TransportLabel含MOCK）隔离到非默认原型验收，不能放在真实功能验收结果中。
- Mock fixture公式/50%退款/300food邮件奖励不得进入真实业务规则；原通知决定资源，ACK不直接加资源。
- 检查器`Design/scripts/de-real-entry-audit.py`只做严格静态门禁，不连接服务；即使通过仍需R1-R8真实证据。

## 原工程与新工程结果分离

分别记录环境、源码版本、Unity版本、配置/资源哈希、专用测试设备ID的哈希、服务器/角色ID、每阶段耗时、协议计数、实际场景与截图。旧工程运行通过只建立参考，不证明新工程通过；新网络离线对照通过不证明服务端联通；新场景独立打开通过不证明启动登录链路成立。

当前Windows Editor的R0–R4真实启动至LOGIN_ACK已通过；最终证据为live-login-final.json、live-login-final-heartbeats.json（含UTC采样时间及COMMON_ACK对应API）、console-login-final.json和unity-login-network-tests-final.json；关键源码SHA256见login-final-source-fingerprints.json，原画面见real-de-login-complete-final.png。R5–R8的完整矩阵仍未执行；本阶段仅验证了原失败框重试/取消，不宣称所有网关关闭/重连场景通过。Player构建及移动平台未验收，后续数据与原视觉主城保持暂停。
