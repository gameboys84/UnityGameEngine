# 项目目录约定

- `Design/`：所有 AI 分析文档与辅助脚本，包括研究笔记、候选比较、探索性设计、临时验证和分析脚本。新生成的这类文件必须放在此目录下。
- `Doc/`：正式化文档，用于长期规划及已经确定的目标、架构、技术选型和规范。尚未确定的分析与建议先保留在 `Design/`，确定后再整理到 `Doc/`。
- Unity 产品代码、场景、资源和正式构建工具按工程结构存放；不要将 AI 分析辅助脚本混入产品代码。
- 根目录 `AGENTS.md` 用于记录 AI 工作约定，不作为分析报告。
- TEngineNi 来源代码的修改必须更新 `Doc/TEngineNi修改台账.md`，记录目的、目标文件、验证、保留/回传决策和同步状态；差异清单与补丁保存到 `Design/reports`。
- 新增 GameCore 共用能力列为回传候选，GameRuntime 的题材、假数据、Demo/UI 资产单独记录。源工程未迁入的文件不自动视为应删除的改动。
- 用户确定需要保留并同步的内容后，再执行到 TEngineNi 的回传；本工程测试通过不代表已获回传决定。未同步前明确标注“未同步”。

# 文档与 Git 维护

- 核心文档入口是根 `README.md`；稳定结论合并到 `Doc/` 对应主题，避免另建重复实施流水。
- 有持续参考价值的候选比较与待讨论设计放 `Design/notes/`；截图、日志、中间测试回执等放 `Design/reports/`，默认忽略。
- `Design/reports/` 整体忽略，不加入版本管理，包括来源清单、差异补丁和历史测试结果；需要时重新审计或运行测试。重要来源说明、改动决策与验证结论保留在 `Doc/`，历史结果不冒充重新生成时的结果。
- `Design/local/` 是忽略的本机备份与一次性操作目录。辅助脚本放 Design，不放产品代码目录。
- Unity 的有效 Assets 及 `.meta`、本地 Packages、manifest/lock 和 ProjectSettings 必须保留；缓存、构建输出及个人设置忽略。不要全局忽略 DLL 或仅凭静态引用删除动态加载资源。
- 根 `.gitignore` 仅管理通用、本机和 Design 产物；Unity 专有规则由 `UnityProject1/.gitignore` 管理，不在根规则中写 UnityProject1 的缓存/构建路径。
- 共用源码由独立 TEngineNi_UPM 仓库的 `com.ni.tengine` 和 `com.ni.gamecore` 维护；TEngineNi 的 FrameworkPackages 子模块固定该仓库提交，当前工程通过 UPM 引用；项目入口、配置、网络/业务门面留在各自 Assets。禁止重新复制整套框架形成第二份活动源码。
- 本地包引用会直接使用来源工作树，修改需在来源仓库审阅与版本管理。固定 Git revision 必须引用实际包含包内容且已可获取的提交；不得为补版本号擅自提交/推送。
