using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DE.Application;
using DE.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace DE.Presentation
{
    /// <summary>DE client presentation. Views submit commands; state and authority remain in IDeClient.</summary>
    public sealed class DEShellView : MonoBehaviour
    {
        static readonly Color Ink = Hex("101821"), Panel = Hex("182430"), Card = Hex("233340");
        static readonly Color Muted = Hex("9AABB7"), Light = Hex("EFF3EF"), Accent = Hex("E3AC55"), Mint = Hex("78BEA3");
        readonly Stack<string> history = new Stack<string>();
        readonly Dictionary<string, Text> resourceLabels = new Dictionary<string, Text>();
        readonly Dictionary<string, Button> navButtons = new Dictionary<string, Button>();
        readonly Dictionary<string, Text> queueCountdowns = new Dictionary<string, Text>();
        readonly Dictionary<string, RectTransform> queueBars = new Dictionary<string, RectTransform>();
        readonly Dictionary<string, RectTransform> marchBars = new Dictionary<string, RectTransform>();
        IDeClient client;
        Font font;
        RectTransform safe, pageContent, modalLayer;
        ScrollRect pageScroll;
        Text pageTitle, pageSubtitle, status, clock, account;
        InputField chatInput;
        string page = "city", selectedNode = "node-1", selectedTroop = "jeep", chatDraft = "", boundAccount, structure;
        bool initialized, dirty;
        float nextRefresh;
        Action pendingConfirmation;

        public string CurrentPage => page;
        public bool ModalVisible => modalLayer != null && modalLayer.gameObject.activeSelf;
        public string StatusText => status != null ? status.text : "";
        public string[] VisibleIds => GetComponentsInChildren<DEUiId>(false).Select(x => x.Id).ToArray();

        public void Bind(IDeClient value)
        {
            if (ReferenceEquals(client, value) && initialized) return;
            if (client != null) client.Changed -= OnState;
            client = value ?? throw new ArgumentNullException(nameof(value));
            client.Changed += OnState;
            boundAccount = client.Snapshot.AccountId;
            structure = Structure(client.Snapshot);
            history.Clear(); page = "city"; chatDraft = "";
            if (!initialized) Build();
            else CloseModal();
            RefreshHeader();
            RenderPage();
        }

        void OnDestroy() { if (client != null) client.Changed -= OnState; }
        void OnState(DeSnapshot snapshot)
        {
            if (boundAccount != null && boundAccount != snapshot.AccountId)
            {
                CloseModal(); history.Clear(); page = "city"; chatDraft = "";
            }
            boundAccount = snapshot.AccountId;
            string updated = Structure(snapshot);
            if (updated != structure) { structure = updated; dirty = true; }
        }
        void Update()
        {
            if (!initialized || client == null) return;
            if (Input.GetKeyDown(KeyCode.Escape)) Back();
            if (Time.unscaledTime < nextRefresh) return;
            nextRefresh = Time.unscaledTime + .4f;
            RefreshHeader();
            if (dirty && (chatInput == null || !chatInput.isFocused) && !ModalVisible)
            {
                dirty = false;
                float scroll = pageScroll.verticalNormalizedPosition;
                RenderPage();
                Canvas.ForceUpdateCanvases();
                pageScroll.verticalNormalizedPosition = scroll;
            }
        }

        void Build()
        {
            initialized = true;
            font = Resources.Load<Font>("DE/Fonts/DEChinese") ?? Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            var background = Block(transform, "shell.background", Ink);
            Fill(background);
            safe = Block(transform, "shell.safe-area", Color.clear);
            Fill(safe);
            var safeArea = safe.gameObject.AddComponent<DESafeArea>();

            var sidebar = Block(safe, "nav.sidebar", Panel);
            Place(sidebar, 0, 0, 224, 900);
            Label(sidebar, "brand.eyebrow", "DE / REFORGED", 16, Accent, 24, 26, 180, 25);
            Label(sidebar, "brand.title", "DEAD\nEMPIRE", 33, Light, 22, 64, 190, 90, FontStyle.Bold);
            Label(sidebar, "brand.subtitle", "CLIENT OPERATIONS", 12, Muted, 24, 163, 190, 25);
            Rule(sidebar, 24, 207, 176);
            string[] ids = { "city", "queues", "research", "training", "bag", "mail", "chat", "map", "coverage" };
            string[] labels = { "01   主城 / CITY", "02   进行中 / QUEUES", "03   科技 / RESEARCH", "04   部队 / TROOPS", "05   背包 / INVENTORY", "06   邮件 / MAIL", "07   聊天 / CHAT", "08   世界 / WORLD", "09   迁移清单 / SCOPE" };
            for (int i = 0; i < ids.Length; i++)
            {
                string target = ids[i];
                var button = Button(sidebar, "nav." + target, labels[i], () => Navigate(target), 16);
                Place((RectTransform)button.transform, 12, 234 + i * 53, 200, 45);
                navButtons[target] = button;
            }
            Rule(sidebar, 24, 748, 176);
            account = Label(sidebar, "session.account", "", 14, Light, 24, 764, 180, 45);
            Label(sidebar, "session.boundary", "本地协议模拟环境\n离线验收 · 非真实联网", 12, Muted, 24, 821, 180, 45);

            var workspace = Block(safe, "shell.workspace", Color.clear);
            workspace.anchorMin = new Vector2(0, 0); workspace.anchorMax = Vector2.one;
            workspace.offsetMin = new Vector2(244, 0); workspace.offsetMax = new Vector2(-22, 0);
            var header = Block(workspace, "hud.resources", Panel);
            Top(header, 0, 19, 0, 77);
            string[] keys = { "food", "energy", "oil", "steel", "cash", "diamond" };
            string[] names = { "粮食", "能源", "石油", "钢铁", "现金", "钻石" };
            for (int i = 0; i < keys.Length; i++)
            {
                float x = 15 + i * 151;
                var icon = Block(header, "resource.icon." + keys[i], Accent * new Color(1, 1, 1, .14f));
                Place(icon, x, 17, 35, 40);
                var texture = Resources.Load<Texture2D>("DE/Icons/" + keys[i]);
                if (texture != null) ApplyTexture(icon, texture, Color.white);
                else Label(icon, "resource.glyph." + keys[i], names[i].Substring(0, 1), 18, Accent, 3, 4, 30, 30);
                Label(header, "resource.name." + keys[i], names[i], 12, Muted, x + 43, 13, 100, 23);
                resourceLabels[keys[i]] = Label(header, "resource.value." + keys[i], "0", 19, Light, x + 43, 35, 102, 26, FontStyle.Bold);
            }
            clock = Label(header, "hud.clock", "", 12, Muted, 940, 21, 150, 45);
            var back = Button(workspace, "nav.back", "‹ 返回", Back, 15);
            Place((RectTransform)back.transform, 0, 114, 92, 35);
            pageTitle = Label(workspace, "page.title", "", 30, Light, 109, 106, 900, 47, FontStyle.Bold);
            pageSubtitle = Label(workspace, "page.subtitle", "", 13, Muted, 110, 154, 1050, 30);

            var body = Block(workspace, "page.scroll", Color.clear);
            body.anchorMin = Vector2.zero; body.anchorMax = Vector2.one;
            body.offsetMin = new Vector2(0, 63); body.offsetMax = new Vector2(0, -198);
            pageScroll = body.gameObject.AddComponent<ScrollRect>();
            pageScroll.horizontal = false; pageScroll.movementType = ScrollRect.MovementType.Clamped;
            var viewport = Block(body, "page.viewport", Color.clear); Fill(viewport);
            viewport.gameObject.AddComponent<RectMask2D>();
            pageScroll.viewport = viewport;
            pageContent = Block(viewport, "page.content", Color.clear);
            pageContent.anchorMin = new Vector2(0, 1); pageContent.anchorMax = Vector2.one;
            pageContent.pivot = new Vector2(.5f, 1); pageContent.sizeDelta = Vector2.zero;
            var layout = pageContent.gameObject.AddComponent<VerticalLayoutGroup>();
            layout.spacing = 13; layout.padding = new RectOffset(0, 8, 0, 18);
            layout.childControlWidth = true; layout.childControlHeight = true;
            layout.childForceExpandWidth = true; layout.childForceExpandHeight = false;
            var fit = pageContent.gameObject.AddComponent<ContentSizeFitter>(); fit.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            pageScroll.content = pageContent;

            var footer = Block(workspace, "status.background", Panel); Bottom(footer, 0, 14, 0, 38);
            status = Label(footer, "status.message", "READY / 客户端就绪。请选择功能。", 13, Mint, 13, 4, 1050, 30);
            BuildModal();
        }

        void RefreshHeader()
        {
            var state = client.Snapshot;
            foreach (var pair in resourceLabels) pair.Value.text = Number(state.GetResource(pair.Key));
            account.text = "COMMANDER\n" + state.AccountId;
            clock.text = "SERVER CLOCK\n" + DateTimeOffset.FromUnixTimeMilliseconds(state.ServerTimeMs).UtcDateTime.ToString("HH:mm:ss 'UTC'", CultureInfo.InvariantCulture);
            foreach (var queue in state.Queues)
            {
                if (queueCountdowns.TryGetValue(queue.Id, out var text) && text != null)
                    text.text = queue.Kind + "  ·  数量 " + queue.Quantity + "  ·  " + (queue.AwaitingConfirmation ? "等待完成确认" : TimeSpan.FromMilliseconds(Math.Max(0, queue.RemainingMs)).ToString(@"hh\:mm\:ss"));
                if (queueBars.TryGetValue(queue.Id, out var bar) && bar != null)
                    bar.anchorMax = new Vector2(Mathf.Clamp01(1 - (float)queue.RemainingMs / Math.Max(1, queue.EndTimeMs - queue.StartTimeMs)), 1);
            }
            foreach (var march in state.Marches)
                if (marchBars.TryGetValue(march.Id, out var bar) && bar != null) bar.anchorMax = new Vector2((float)march.Progress, 1);
        }

        public void Navigate(string target)
        {
            if (ModalVisible || target == page) return;
            history.Push(page); page = target; RenderPage(); pageScroll.verticalNormalizedPosition = 1;
        }

        public void Back()
        {
            if (ModalVisible) { CloseModal(); return; }
            page = history.Count > 0 ? history.Pop() : "city"; RenderPage(); pageScroll.verticalNormalizedPosition = 1;
        }

        void RenderPage()
        {
            if (chatInput != null) chatDraft = chatInput.text;
            queueCountdowns.Clear(); queueBars.Clear(); marchBars.Clear();
            Clear(pageContent); chatInput = null;
            foreach (var pair in navButtons) pair.Value.GetComponent<Image>().color = pair.Key == page ? Hex("425044") : Panel;
            var state = client.Snapshot;
            switch (page)
            {
                case "city": RenderCity(state); break;
                case "queues": RenderQueues(state); break;
                case "research": RenderResearch(state); break;
                case "training": RenderTraining(state); break;
                case "bag": RenderBag(state); break;
                case "mail": RenderMail(state); break;
                case "chat": RenderChat(state); break;
                case "map": RenderMap(state); break;
                default: RenderCoverage(); break;
            }
        }

        void Title(string title, string subtitle) { pageTitle.text = title; pageSubtitle.text = subtitle; }

        void RenderCity(DeSnapshot state)
        {
            Title("前线指挥部 / COMMAND CENTER", "建设基地、管理生产与部队。所有命令由客户端应用层处理，界面不直接修改资源。");
            var banner = Section("city.hero", 220, Hex("304239"));
            var texture = Resources.Load<Texture2D>("DE/Backgrounds/troops");
            if (texture != null) { var art = ApplyTexture(banner, texture, Color.white); art.uvRect = new Rect(0, .5f, .889f, .5f); }
            var shade = Block(banner, "city.hero.shade", new Color(.04f, .07f, .08f, .76f));
            shade.anchorMin = Vector2.zero; shade.anchorMax = new Vector2(.57f, 1); shade.offsetMin = shade.offsetMax = Vector2.zero;
            Label(banner, "city.hero.eyebrow", "FORWARD OPERATING BASE / 前线基地", 13, Accent, 25, 22, 700, 30);
            Label(banner, "city.hero.title", "重建秩序。\n守住防线。", 34, Light, 24, 61, 700, 93, FontStyle.Bold);
            Label(banner, "city.hero.description", "进行中的队列 " + state.Queues.Length + "     /     行军 " + state.Marches.Length, 15, Mint, 26, 172, 650, 32);
            Caption("BASE INFRASTRUCTURE / 基地设施");
            foreach (var building in state.Buildings)
            {
                var b = building;
                var row = Row("building." + b.Id, b.Name, "等级 " + b.Level + " / " + b.MaximumLevel + "   ·   建造需要资源与空闲队列", 116);
                var upgrade = RowButton(row, "building.upgrade." + b.Id, "升级 / UPGRADE", () => ConfirmCommand("升级 " + b.Name, new DeCommand(DeCommandKind.StartBuildingUpgrade, b.Id)), 210);
                upgrade.interactable = b.Level < b.MaximumLevel;
                MiniBar(row, (float)b.Level / Math.Max(1, b.MaximumLevel));
            }
            Caption("FIELD OPERATIONS / 快捷行动");
            var quick = Row("city.quick", "队列与世界行动", "查看建设进度，或派出部队前往世界目标。", 94);
            RowButton(quick, "city.open-map", "前往世界", () => Navigate("map"), 190);
        }

        void RenderQueues(DeSnapshot state)
        {
            Title("进行中的任务 / ACTIVE QUEUES", "倒计时仅表示进度；完成状态由权威状态确认。取消与加速不会绕过规则。");
            if (state.Queues.Length == 0) Empty("queues.empty", "没有进行中的队列", "在主城升级建筑、研究科技或训练部队后，进度会显示在这里。");
            foreach (var queue in state.Queues)
            {
                var q = queue;
                var row = Row("queue." + q.Id, q.TargetName, q.Kind + "  ·  数量 " + q.Quantity + "  ·  " + (q.AwaitingConfirmation ? "等待完成确认" : TimeSpan.FromMilliseconds(Math.Max(0, q.RemainingMs)).ToString(@"hh\:mm\:ss")), 144);
                queueCountdowns[q.Id] = row.Find("queue." + q.Id + ".description").GetComponent<Text>();
                double duration = q.EndTimeMs - q.StartTimeMs;
                queueBars[q.Id] = MiniBar(row, duration <= 0 ? 1 : (float)(1 - q.RemainingMs / duration), 79);
                var cancel = RowButton(row, "queue.cancel." + q.Id, "取消任务", () => Confirm("取消任务", "确认取消 " + q.TargetName + "？退款按业务规则处理。", () => Run(new DeCommand(DeCommandKind.CancelQueue, q.Id))), 150);
                Place((RectTransform)cancel.transform, 24, 91, 146, 35);
                var speed = RowButton(row, "queue.speedup." + q.Id, "加速 60 秒", () => Confirm("使用加速道具", "消耗一件 60 秒加速道具，为当前队列加速。", () => Run(new DeCommand(DeCommandKind.UseItem, "speedup-60", secondaryId: q.Id))), 170);
                Place((RectTransform)speed.transform, 181, 91, 170, 35);
            }
        }

        void RenderResearch(DeSnapshot state)
        {
            Title("科技研究 / RESEARCH", "研究受实验室等级、前置科技、资源和队列限制；不满足条件时会显示具体原因。");
            foreach (var research in state.Research)
            {
                var r = research;
                var row = Row("research." + r.Id, r.Name, "研究等级 " + r.Level + " / " + r.MaximumLevel, 116);
                var iconTexture = Resources.Load<Texture2D>("DE/Icons/research");
                if (iconTexture != null)
                {
                    var icon = Block(row, "research.icon." + r.Id, Color.clear); Place(icon, 820, 24, 48, 48); ApplyTexture(icon, iconTexture, Color.white);
                }
                MiniBar(row, (float)r.Level / Math.Max(1, r.MaximumLevel));
                RowButton(row, "research.start." + r.Id, "开始研究", () => ConfirmCommand("研究 " + r.Name, new DeCommand(DeCommandKind.StartResearch, r.Id)), 190).interactable = r.Level < r.MaximumLevel;
            }
        }

        void RenderTraining(DeSnapshot state)
        {
            Title("部队训练 / TROOP COMMAND", "训练批次：10。部队归属当前账号，行军会校验可用数量。");
            foreach (var troop in state.Troops)
            {
                var t = troop;
                var row = Row("troop." + t.Id, t.Name, "现有部队 " + t.Count + "   ·   兵营训练", 106);
                RowButton(row, "troop.train." + t.Id, "训练 ×10", () => ConfirmCommand("训练 " + t.Name, new DeCommand(DeCommandKind.TrainTroops, t.Id, 10)), 190);
            }
        }

        void RenderBag(DeSnapshot state)
        {
            Title("战备仓库 / INVENTORY", "资源箱通过命令领取；加速道具请在任务队列中选择目标使用。");
            if (state.Items.Length == 0) Empty("bag.empty", "仓库为空", "当前账号尚无可用道具。");
            foreach (var item in state.Items)
            {
                var i = item;
                var row = Row("item." + i.Id, i.Name + "  ×" + i.Count, i.Description, 110);
                bool speedup = i.Id.StartsWith("speedup", StringComparison.Ordinal);
                RowButton(row, "item.use." + i.Id, speedup ? "选择加速目标" : "使用 ×1", () =>
                {
                    if (speedup) Navigate("queues");
                    else Confirm("使用 " + i.Name, "确认使用一件道具？", () => Run(new DeCommand(DeCommandKind.UseItem, i.Id)));
                }, 190).interactable = i.Count > 0;
            }
        }

        void RenderMail(DeSnapshot state)
        {
            Title("通信中心 / MAIL", "附件领取须经业务确认，重复领取不能重复增加资源。");
            if (state.Mails.Length == 0) Empty("mail.empty", "没有邮件", "新的通知和奖励会显示在这里。");
            foreach (var mail in state.Mails)
            {
                var m = mail;
                var row = Row("mail." + m.Id, (m.IsRead ? "" : "● ") + m.Title, m.Body + "\n附件：" + m.RewardText, 154);
                var read = RowButton(row, "mail.read." + m.Id, m.IsRead ? "已读" : "标为已读", () => Run(new DeCommand(DeCommandKind.ReadMail, m.Id)), 140);
                Place((RectTransform)read.transform, 24, 105, 140, 33); read.interactable = !m.IsRead;
                var claim = RowButton(row, "mail.claim." + m.Id, m.IsClaimed ? "已领取" : "领取附件", () => Run(new DeCommand(DeCommandKind.ClaimMail, m.Id)), 170);
                Place((RectTransform)claim.transform, 177, 105, 170, 33); claim.interactable = !m.IsClaimed;
            }
        }

        void RenderChat(DeSnapshot state)
        {
            Title("战地通信 / CHAT", "本地传输模拟 · 消息不会发送给真实玩家。输入为空或超出业务长度限制会被拒绝。");
            var composer = Section("chat.composer", 116, Panel);
            var box = Block(composer, "chat.input", Ink); Place(box, 20, 17, 780, 46);
            chatInput = box.gameObject.AddComponent<InputField>(); chatInput.characterLimit = 500;
            var inputText = Label(box, "chat.input.text", "", 17, Light, 10, 2, 756, 40);
            var placeholder = Label(box, "chat.input.placeholder", "输入消息 / Enter a message…", 16, Muted, 10, 2, 756, 40);
            chatInput.textComponent = inputText; chatInput.placeholder = placeholder;
            chatInput.text = chatDraft;
            var send = Button(composer, "chat.send", "发送 / SEND", SendChat, 16); Place((RectTransform)send.transform, 820, 17, 180, 46);
            Label(composer, "chat.channel", "CHANNEL: WORLD / 世界频道模拟", 12, Muted, 21, 75, 900, 25);
            if (state.Chat.Length == 0) Empty("chat.empty", "尚无消息", "发送一条消息开始本地通信验证。");
            foreach (var message in state.Chat.Reverse().Take(80)) Row("chat.message." + message.Id, message.Sender + "  /  " + message.Channel, message.Text, 100);
        }

        void SendChat()
        {
            string text = chatInput != null ? chatInput.text : "";
            var result = Run(new DeCommand(DeCommandKind.SendChat, text: text));
            if (result != null && result.Success && chatInput != null) { chatInput.text = ""; chatDraft = ""; }
        }

        void RenderMap(DeSnapshot state)
        {
            Title("世界行动 / WORLD OPERATIONS", "当前为客户端二维战术展示；未迁移旧工程完整三维地图、战争迷雾和实时战斗表现。");
            var map = Section("world.map", 250, Hex("253E3A"));
            Label(map, "world.map.label", "SECTOR 07 / 战术区域", 14, Mint, 22, 13, 900, 26);
            int index = 0;
            foreach (var node in state.WorldNodes)
            {
                var n = node;
                float x = 36 + index % 3 * 325, y = 57 + index / 3 * 85;
                var button = Button(map, "world.node." + n.Id, n.Name + "\n(" + n.X + ", " + n.Y + ") · " + n.Kind, () => { selectedNode = n.Id; RenderPage(); }, 14);
                button.GetComponent<Image>().color = selectedNode == n.Id ? Hex("69724B") : Hex("324E48");
                Place((RectTransform)button.transform, x, y, 295, 65); index++;
            }
            var dispatch = Row("march.dispatch", "出征编队", "目标 " + selectedNode + "  ·  部队 " + selectedTroop + "  ·  数量 5", 148);
            int troopIndex = 0;
            foreach (var troop in state.Troops)
            {
                var t = troop;
                var select = Button(dispatch, "march.select." + t.Id, t.Name + " (" + t.Count + ")", () => { selectedTroop = t.Id; RenderPage(); }, 14);
                Place((RectTransform)select.transform, 24 + troopIndex * 190, 96, 180, 34);
                select.GetComponent<Image>().color = selectedTroop == t.Id ? Hex("69724B") : Panel; troopIndex++;
            }
            RowButton(dispatch, "march.create", "派遣 ×5", () => Confirm("确认出征", "派遣 5 单位前往 " + selectedNode + "，行军由应用层状态驱动。", () => Run(new DeCommand(DeCommandKind.CreateMarch, selectedNode, 5, secondaryId: selectedTroop))), 190);
            Caption("ACTIVE MARCHES / 行军状态");
            if (state.Marches.Length == 0) Empty("march.empty", "没有进行中的行军", "选择目标与兵种后派遣部队。");
            foreach (var march in state.Marches)
            {
                var m = march;
                var row = Row("march." + m.Id, m.TargetName, m.State + "  ·  " + m.TroopId + " ×" + m.Count, 111);
                marchBars[m.Id] = MiniBar(row, (float)m.Progress);
                RowButton(row, "march.recall." + m.Id, "召回", () => Run(new DeCommand(DeCommandKind.RecallMarch, m.Id)), 150);
            }
        }

        void RenderCoverage()
        {
            Title("重构边界 / MIGRATION SCOPE", "目录与菜单存在不等于功能已经迁移。此页明确展示当前界面的实现边界。");
            Row("coverage.implemented", "当前客户端纵向链路", "建筑升级、研究、训练、队列取消与加速、道具、邮件、聊天、二维地图与行军。\n实际覆盖以自动测试和界面验收报告为准。", 130);
            Row("coverage.transport", "数据与网络", client.TransportLabel + "\n真实账号登录、原 DE 协议兼容、线上服务与第三方 SDK 尚未接入。", 115);
            Row("coverage.pending", "尚未完成的原 DE 系统", "联盟 / GVG / KVK / 活动 / 军官养成 / 装备 / 战舰 / 抽奖 / 商店 / 支付 / 新手引导 / FPS\n完整三维主城和世界地图、美术表现、多语言、音频与发布仍需逐项重构和验收。", 145);
            Empty("coverage.policy", "未迁移功能没有成功按钮", "此版本不将演示数据或占位界面计为全量 DE 验收通过。");
            foreach (var feature in FeatureCatalog.All)
                Row("coverage.feature." + feature.Id, feature.Name + "  /  " + feature.Coverage, feature.Description, 120);
        }

        DeResult Run(DeCommand command)
        {
            DeResult result;
            try { result = client.Execute(command); }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                status.text = "ERROR / " + exception.Message; status.color = Hex("EE8F7D");
                ShowMessage("执行异常", exception.Message); return null;
            }
            status.text = (result.Success ? "OK / " : "REJECTED / ") + result.Message + "  [" + result.Code + "]";
            status.color = result.Success ? Mint : Hex("EE8F7D");
            if (!result.Success) ShowMessage("操作未完成 / " + result.Code, result.Message);
            dirty = true; return result;
        }

        void BuildModal()
        {
            modalLayer = Block(safe, "modal.blocker", new Color(0, 0, 0, .78f)); Fill(modalLayer);
            modalLayer.gameObject.SetActive(false);
        }

        void Confirm(string title, string description, Action confirm)
        {
            if (ModalVisible) return;
            OpenModal(title, description, true); pendingConfirmation = confirm;
        }

        void ConfirmCommand(string title, DeCommand command)
        {
            var preview = DeRules.Preview(client.Snapshot, command);
            if (!preview.CanExecute)
            {
                ShowMessage("条件不满足 / " + preview.Code, preview.Message);
                status.text = "REJECTED / " + preview.Message + " [" + preview.Code + "]";
                status.color = Hex("EE8F7D"); return;
            }
            string costs = string.Join("  /  ", preview.Costs.Select(x => x.Key + " " + x.Amount));
            Confirm(title, "预计耗时 " + TimeSpan.FromMilliseconds(preview.DurationMs).ToString(@"hh\:mm\:ss") + "\n资源消耗：" + (costs.Length == 0 ? "无" : costs) + "\n确认后提交请求，执行时再次校验。", () => Run(command));
        }

        void ShowMessage(string title, string description) { OpenModal(title, description, false); }

        void OpenModal(string title, string description, bool confirm)
        {
            Clear(modalLayer); modalLayer.gameObject.SetActive(true); modalLayer.SetAsLastSibling();
            var box = Block(modalLayer, "modal.panel", Panel);
            box.anchorMin = box.anchorMax = box.pivot = new Vector2(.5f, .5f); box.sizeDelta = new Vector2(660, 310); box.anchoredPosition = Vector2.zero;
            Label(box, "modal.title", title, 26, Light, 28, 25, 600, 45, FontStyle.Bold);
            Label(box, "modal.message", description, 17, Muted, 28, 83, 600, 120);
            var no = Button(box, "modal.cancel", confirm ? "取消 / CANCEL" : "关闭 / CLOSE", CloseModal, 16);
            Place((RectTransform)no.transform, confirm ? 235 : 438, 239, 190, 45);
            if (confirm)
            {
                var yes = Button(box, "modal.confirm", "确认 / CONFIRM", () => { var action = pendingConfirmation; CloseModal(); action?.Invoke(); }, 16);
                Place((RectTransform)yes.transform, 438, 239, 190, 45); yes.GetComponent<Image>().color = Hex("6B633E");
            }
            UnityEngine.EventSystems.EventSystem.current?.SetSelectedGameObject(no.gameObject);
        }

        public void CloseModal() { pendingConfirmation = null; modalLayer.gameObject.SetActive(false); }

        RectTransform Row(string id, string title, string detail, float height)
        {
            var row = Section(id, height, Card);
            Label(row, id + ".title", title, 21, Light, 23, 14, 740, 35, FontStyle.Bold);
            Label(row, id + ".description", detail, 14, Muted, 24, 53, 765, height - 58);
            return row;
        }

        Button RowButton(RectTransform parent, string id, string text, Action action, float width)
        {
            var button = Button(parent, id, text, action, 15);
            var rect = (RectTransform)button.transform;
            rect.anchorMin = rect.anchorMax = new Vector2(1, .5f); rect.pivot = new Vector2(1, .5f);
            rect.anchoredPosition = new Vector2(-22, 0); rect.sizeDelta = new Vector2(width, 43);
            return button;
        }

        RectTransform Section(string id, float height, Color color)
        {
            var row = Block(pageContent, id, color);
            var layout = row.gameObject.AddComponent<LayoutElement>(); layout.preferredHeight = height; layout.minHeight = height;
            return row;
        }

        void Caption(string text)
        {
            var row = Section("section." + text.Split('/')[0].Trim().Replace(' ', '-').ToLowerInvariant(), 32, Color.clear);
            Label(row, "section.caption", text, 13, Accent, 2, 1, 1000, 30);
        }

        void Empty(string id, string title, string detail) { Row(id, title, detail, 112); }

        RectTransform MiniBar(RectTransform row, float progress, float y = 91)
        {
            var track = Block(row, row.name + ".progress.track", Ink); Place(track, 24, y, 560, 4);
            var fill = Block(track, row.name + ".progress.fill", Mint);
            fill.anchorMin = Vector2.zero; fill.anchorMax = new Vector2(Mathf.Clamp01(progress), 1); fill.offsetMin = fill.offsetMax = Vector2.zero;
            return fill;
        }

        static RawImage ApplyTexture(RectTransform target, Texture texture, Color color)
        {
            target.GetComponent<Image>().enabled = false;
            var image = target.gameObject.AddComponent<RawImage>(); image.texture = texture; image.color = color; image.raycastTarget = false; return image;
        }

        static string Structure(DeSnapshot s)
        {
            var key = new StringBuilder(s.AccountId).Append('|').Append(s.SessionGeneration);
            foreach (var x in s.Resources) key.Append('|').Append(x.Key).Append(':').Append(x.Amount);
            foreach (var x in s.Buildings) key.Append('|').Append(x.Id).Append(':').Append(x.Level);
            foreach (var x in s.Research) key.Append('|').Append(x.Id).Append(':').Append(x.Level);
            foreach (var x in s.Troops) key.Append('|').Append(x.Id).Append(':').Append(x.Count);
            foreach (var x in s.Queues) key.Append('|').Append(x.Id).Append(':').Append(x.EndTimeMs);
            foreach (var x in s.Items) key.Append('|').Append(x.Id).Append(':').Append(x.Count);
            foreach (var x in s.Mails) key.Append('|').Append(x.Id).Append(':').Append(x.IsRead).Append(x.IsClaimed);
            foreach (var x in s.Chat) key.Append('|').Append(x.Id);
            foreach (var x in s.Marches) key.Append('|').Append(x.Id).Append(':').Append(x.State).Append(x.EndTimeMs);
            return key.ToString();
        }

        static RectTransform Block(Transform parent, string id, Color color)
        {
            var obj = new GameObject(id, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(DEUiId)); obj.layer = 5;
            obj.transform.SetParent(parent, false); obj.GetComponent<DEUiId>().Id = id;
            var image = obj.GetComponent<Image>(); image.color = color; image.raycastTarget = color.a > 0;
            return (RectTransform)obj.transform;
        }

        Text Label(Transform parent, string id, string value, int size, Color color, float x, float y, float width, float height, FontStyle style = FontStyle.Normal)
        {
            var obj = new GameObject(id, typeof(RectTransform), typeof(CanvasRenderer), typeof(Text), typeof(DEUiId)); obj.layer = 5;
            obj.transform.SetParent(parent, false); obj.GetComponent<DEUiId>().Id = id;
            var text = obj.GetComponent<Text>(); text.font = font; text.text = value; text.fontSize = size; text.color = color; text.fontStyle = style;
            text.raycastTarget = false; text.alignment = TextAnchor.MiddleLeft; text.horizontalOverflow = HorizontalWrapMode.Wrap; text.verticalOverflow = VerticalWrapMode.Truncate;
            Place((RectTransform)obj.transform, x, y, width, height); return text;
        }

        Button Button(Transform parent, string id, string caption, Action action, int size)
        {
            var rect = Block(parent, id, Hex("344650"));
            var button = rect.gameObject.AddComponent<Button>(); button.targetGraphic = rect.GetComponent<Image>();
            var colors = button.colors; colors.highlightedColor = Hex("D6DDC8"); colors.pressedColor = Hex("A7B3A0"); colors.disabledColor = new Color(.6f, .6f, .6f, .5f); button.colors = colors;
            var text = Label(rect, id + ".label", caption, size, Light, 10, 0, 170, 45);
            Fill((RectTransform)text.transform, 10, 4); text.alignment = TextAnchor.MiddleCenter;
            button.onClick.AddListener(() => { if (ModalVisible && !id.StartsWith("modal.", StringComparison.Ordinal)) return; action(); });
            return button;
        }

        static void Place(RectTransform rect, float x, float y, float width, float height)
        {
            rect.anchorMin = rect.anchorMax = new Vector2(0, 1); rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(x, -y); rect.sizeDelta = new Vector2(width, height);
        }
        static void Fill(RectTransform rect, float x = 0, float y = 0) { rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.offsetMin = new Vector2(x, y); rect.offsetMax = new Vector2(-x, -y); }
        static void Top(RectTransform rect, float left, float top, float right, float height) { rect.anchorMin = new Vector2(0, 1); rect.anchorMax = Vector2.one; rect.pivot = new Vector2(.5f, 1); rect.offsetMin = new Vector2(left, -top - height); rect.offsetMax = new Vector2(-right, -top); }
        static void Bottom(RectTransform rect, float left, float bottom, float right, float height) { rect.anchorMin = Vector2.zero; rect.anchorMax = new Vector2(1, 0); rect.pivot = new Vector2(.5f, 0); rect.offsetMin = new Vector2(left, bottom); rect.offsetMax = new Vector2(-right, bottom + height); }
        static void Rule(Transform parent, float x, float y, float width) { Place(Block(parent, "decoration.rule", Hex("344650")), x, y, width, 1); }
        static void Clear(Transform parent) { for (int i = parent.childCount - 1; i >= 0; i--) { var child = parent.GetChild(i).gameObject; child.SetActive(false); Destroy(child); } }
        static Color Hex(string hex) { ColorUtility.TryParseHtmlString("#" + hex, out var color); return color; }
        static string Number(long amount) { return amount >= 1000000 ? (amount / 1000000d).ToString("0.##") + "M" : amount >= 10000 ? (amount / 1000d).ToString("0.#") + "K" : amount.ToString("N0", CultureInfo.InvariantCulture); }
    }
}
