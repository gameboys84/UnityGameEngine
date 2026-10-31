using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DE.Infrastructure.Network;
using Newtonsoft.Json.Linq;

namespace DE.Production.Runtime
{
    public sealed class ProductionLoadingProgress
    {
        public int Completed { get; internal set; }
        public int Total => 21;
        public string Stage { get; internal set; }
        public bool InitialDataReceived { get; internal set; }
    }

    /// <summary>Ports GameLoadingMgr's real request/barrier semantics. Raw ingress readiness never means scene or business-module readiness.</summary>
    public sealed class ProductionLoadingCoordinator : IDisposable
    {
        private readonly DeProductionConnection connection;
        private readonly Func<bool?> kvkActive;
        private readonly HashSet<Protocol.MsgType> sent = new HashSet<Protocol.MsgType>();
        private readonly HashSet<string> completed = new HashSet<string>(StringComparer.Ordinal);
        private Exception failure;
        private bool running, disposed;
        private long expectedGeneration;
        private readonly string[] steps = { "REGISTER_AND_LOGINING", "SYNC_TIME", "USER_INFO", "SAVE_INFO", "DAILY_LOGS_INFO", "NATION_QUEST_INFO", "DAILY_AND_ALLIANCE_INFO", "MAIL_INFO", "ALLIANCE_INFO", "HELP_INFO", "CONFIG_CONST", "CITY_INFO", "RESEARCH_LIST_INFO", "RALLY_LIST", "JOIN_APPLY_LIST", "PERSONAL_INVITE_LIST", "ALLIANCE_GIFT", "EXPEDITION_INFO", "SERVER_SETTING", "GOVERNMENT_INFO", "DONE" };
        public ProductionLoadingProgress Progress { get; } = new ProductionLoadingProgress();
        public event Action<ProductionLoadingProgress> Changed;
        public Protocol.ResInfo Resources { get; private set; }
        public Protocol.BuildingNtfInfo Buildings { get; private set; }
        public JObject TutorialSave { get; private set; }
        public string BlacklistSave { get; private set; }
        public long ServerTime { get; private set; }

        public ProductionLoadingCoordinator(DeProductionConnection connection, Func<bool?> kvkActive = null)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.kvkActive = kvkActive;
            connection.MessageReceived += Observe;
            connection.SessionInvalidated += Invalidate;
        }

        public async Task RunAsync(CancellationToken token)
        {
            if (disposed) throw new ObjectDisposedException(nameof(ProductionLoadingCoordinator));
            if (running) throw new InvalidOperationException("DE initial loading is already running.");
            if (!connection.Status.IsLoggedIn || connection.CurrentUser == null) throw new InvalidOperationException("Real LOGIN_ACK is required before initial loading.");
            running = true;
            expectedGeneration = connection.CurrentSessionGeneration;
            failure = null; completed.Clear(); sent.Clear(); Resources = null; Buildings = null; TutorialSave = null; BlacklistSave = null; ServerTime = 0;
            Progress.InitialDataReceived = false;
            try
            {
                Done("REGISTER_AND_LOGINING");
                // TIME_NTF can precede LOGIN_ACK. Replay only receipts from this authenticated connection generation.
                if (connection.RawState.Generation == expectedGeneration)
                    foreach (var receipt in connection.RawState.History) Observe(receipt.Message);
                Stage("USER_INFO");
                await Send(Protocol.MsgType.RES_REQ, null, token);
                await Until(() => completed.Contains("USER_INFO"), token);
                int allianceId = connection.CurrentUser.m_alliance?.m_id ?? 0;
                Stage("SAVE_INFO");
                await Send(Protocol.MsgType.CLIENT_LOAD_V2_REQ, new Protocol.ClientLoadV2ReqInfo { m_ver = 3 }, token);
                await Send(Protocol.MsgType.DAILY_EVENT_REQ, null, token);
                await Send(Protocol.MsgType.QUEST_LIST_REQ, new Protocol.QuestListReqInfo { m_begin_id = 0 }, token); Done("NATION_QUEST_INFO");
                await Send(Protocol.MsgType.GET_DAILY_QUEST_LIST_REQ, new Protocol.GetDailyQuestListReqInfo(), token);
                await Send(Protocol.MsgType.CLIENT_DATA_LOAD_REQ, new Protocol.ClientDataKey { m_key = "SaveBlackListData" }, token);
                await Send(Protocol.MsgType.QUEST_COUNTDOWN_LIST_REQ, null, token);
                for (short category = 1; category <= 4; category++)
                    await Send(Protocol.MsgType.GET_RTF_MAIL_LIST_REQ, new Protocol.GetRtfMailListReqInfo { m_start_id = "0", m_mail_type = category, m_direction = false, m_count = 500 }, token);
                Done("MAIL_INFO");
                if (allianceId != 0) await Send(Protocol.MsgType.ALLIANCE_MEMBER_REQ, new Protocol.AllianceReqInfo { m_alliance_id = allianceId }, token);
                else Done("ALLIANCE_INFO");
                if (allianceId != 0) await Send(Protocol.MsgType.ALLIANCE_LIST_HELP_REQ, null, token);
                Done("HELP_INFO");
                await Send(Protocol.MsgType.CONST_REQ, new Protocol.ConstReq { m_keyword = "max_building_level" }, token);
                await Send(Protocol.MsgType.BUILDING_INFO_REQ, null, token);
                await Send(Protocol.MsgType.GET_RESEARCH_LIST_REQ, new Protocol.GetResearchListReqInfo { m_start_type = 0 }, token); Done("RESEARCH_LIST_INFO");
                await RequestRallies(allianceId, token); Done("RALLY_LIST");
                if (allianceId > 0) await Send(Protocol.MsgType.GET_ALLIANCE_RESEARCH_LIST_REQ, new Protocol.GetAllianceResearchListReqInfo { m_type = 0 }, token);
                Done("JOIN_APPLY_LIST");
                if (allianceId == 0) await Send(Protocol.MsgType.LIST_INVITE_REQ, null, token);
                Done("PERSONAL_INVITE_LIST");
                if (allianceId != 0)
                {
                    await Send(Protocol.MsgType.LIST_ALLIANCE_GIFT_REQ, new Protocol.ListAllianceGiftReqInfo { m_drop_expired = false }, token);
                    await Send(Protocol.MsgType.ALLIANCE_FORTUNE_GIFT_REQ, null, token);
                }
                Done("ALLIANCE_GIFT");
                await Send(Protocol.MsgType.EXPEDITION_STATE_REQ, null, token);
                await Send(Protocol.MsgType.EXPEDITION_STORE_INFO_REQ, null, token); Done("EXPEDITION_INFO");
                await Send(Protocol.MsgType.GET_SETTING_REQ, null, token); Done("SERVER_SETTING");
                await Send(Protocol.MsgType.GOV_INFO_REQ, null, token); Done("GOVERNMENT_INFO");
                Stage("Waiting for authoritative initial data");
                await Until(() => completed.Count == steps.Length - 1, token);
                ThrowIfStopped(token);
                Done("DONE");
                ThrowIfStopped(token);
                Progress.InitialDataReceived = true;
                Progress.Stage = "Initial wire data received; city and business readiness require their own validation";
                Changed?.Invoke(Progress);
            }
            finally { running = false; }
        }

        private async Task RequestRallies(int allianceId, CancellationToken token)
        {
            if (allianceId == 0 && connection.CurrentUser.m_hq_level < 15) return;
            await Send(allianceId != 0 ? Protocol.MsgType.RALLY_LIST_REQ : Protocol.MsgType.RALLY_DEFENCE_REQ, null, token);
            bool? active = kvkActive?.Invoke();
            if (!active.HasValue) throw new InvalidOperationException("Authoritative KVK participation state is required before loading battle rally data.");
            if (active.Value) await Send(allianceId != 0 ? Protocol.MsgType.KVK_RALLY_LIST_REQ : Protocol.MsgType.RALLY_DEFENCE_REQ, null, token);
        }

        private async Task Send(Protocol.MsgType type, NetworkMessage payload, CancellationToken token)
        {
            ThrowIfStopped(token);
            sent.Add(type);
            await connection.SendAsync(type, payload, 0, token);
            ThrowIfStopped(token);
        }

        private void Observe(NetworkMessage message)
        {
            if (!running || message == null || (message.m_nodId != 0 && message.m_nodId != connection.CurrentUser?.m_location_server_id)) return;
            try
            {
                switch (message.GetMessageType())
                {
                    case Protocol.MsgType.TIME_NTF:
                        if (message is Protocol.TimeNtfInfo time && time.m_t > 0) { ServerTime = time.m_t; Done("SYNC_TIME"); }
                        break;
                    case Protocol.MsgType.RES_NTF:
                        Resources = message as Protocol.ResInfo ?? throw new InvalidOperationException("Invalid RES_NTF payload."); Done("USER_INFO"); break;
                    case Protocol.MsgType.CLIENT_LOAD_ACK:
                        var save = message as Protocol.ClientSaveInfo ?? throw new InvalidOperationException("Invalid tutorial payload.");
                        var tutorial = string.IsNullOrWhiteSpace(save.m_data) ? null : JToken.Parse(save.m_data);
                        TutorialSave = tutorial == null || tutorial.Type == JTokenType.Null ? new JObject { ["order"] = 1, ["step"] = 0, ["tutorialVer"] = 3 } : tutorial as JObject ?? throw new InvalidOperationException("Tutorial save must be an object or null.");
                        Done("SAVE_INFO"); break;
                    case Protocol.MsgType.DAILY_EVENT_ACK: Done("DAILY_LOGS_INFO"); break;
                    case Protocol.MsgType.CLIENT_DATA_LOAD_ACK:
                        if (message is Protocol.ClientDataInfo clientData && clientData.m_key == "SaveBlackListData") { BlacklistSave = clientData.m_value; Done("DAILY_AND_ALLIANCE_INFO"); }
                        break;
                    case Protocol.MsgType.ALLIANCE_MEMBER_ACK:
                        if (message is Protocol.AllianceMemberAckInfo alliance && alliance.m_brief != null && alliance.m_brief.m_alliance_id == connection.CurrentUser?.m_alliance?.m_id) Done("ALLIANCE_INFO");
                        break;
                    case Protocol.MsgType.CONST_ACK:
                        if (message is Protocol.ConstInfo constant && constant.m_keyword == "max_building_level") Done("CONFIG_CONST"); break;
                    case Protocol.MsgType.BUILDING_NTF:
                        Buildings = message as Protocol.BuildingNtfInfo ?? throw new InvalidOperationException("Invalid BUILDING_NTF payload."); Done("CITY_INFO"); break;
                    case Protocol.MsgType.COMMON_ACK:
                        if (message is Protocol.CommonAckInfo ack && ack.m_code != 0 && sent.Contains((Protocol.MsgType)ack.m_api))
                            failure = new InvalidOperationException("DE server rejected loading API " + ack.m_api + " with code " + ack.m_code + ".");
                        break;
                }
            }
            catch (Exception error) { failure = error; }
        }

        private async Task Until(Func<bool> condition, CancellationToken token)
        {
            var deadline = DateTime.UtcNow.AddSeconds(45);
            while (true)
            {
                ThrowIfStopped(token);
                if (condition()) break;
                if (DateTime.UtcNow >= deadline) throw new TimeoutException("DE initial loading timed out at " + Progress.Stage + "; required server notifications were not fabricated.");
                await Task.Delay(25, token);
            }
            ThrowIfStopped(token);
        }
        private void ThrowIfStopped(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            if (disposed) throw new ObjectDisposedException(nameof(ProductionLoadingCoordinator));
            if (failure != null) throw failure;
            if (connection.CurrentSessionGeneration != expectedGeneration) throw new InvalidOperationException("The authenticated DE connection generation changed during initial loading.");
        }
        private void Stage(string name) { Progress.Stage = name; Changed?.Invoke(Progress); }
        private void Done(string name) { if (!completed.Add(name)) return; Progress.Completed = completed.Count; Changed?.Invoke(Progress); }
        private void Invalidate() { if (running && connection.CurrentSessionGeneration == expectedGeneration) return; if (running) failure = new InvalidOperationException("The DE connection generation changed during initial loading."); Progress.InitialDataReceived = false; Resources = null; Buildings = null; TutorialSave = null; BlacklistSave = null; ServerTime = 0; }
        public void Dispose() { if (disposed) return; disposed = true; connection.MessageReceived -= Observe; connection.SessionInvalidated -= Invalidate; Changed = null; }
    }
}
