using System;
using System.Collections.Generic;
using DE.Application;
using DE.Domain;

namespace DE.Infrastructure
{
    public static class DeClientFactory
    {
        public static IDeClient CreateMock(string accountId = "commander-001")
        { return new DeClient(new MockDeSession(), accountId); }
    }

    // Deliberately separate from the client reducer: all fixture authority, settlement and rewards live here.
    // This is NOT an adapter to the original DE server and contains no production balance tables.
    public sealed class MockDeSession : IDeSession
    {
        private sealed class Receipt { public DeCommand Command; public DeResult Result; }
        private sealed class Operation
        {
            public string Id, Kind, TargetId, Name;
            public int Quantity, TargetLevel;
            public long Start, End;
            public ResourceCost[] Paid;
        }
        private sealed class Mail { public string Id, Title, Body; public long Food; public bool Read, Claimed; }
        private sealed class March
        {
            public string Id, TargetId, Name, TroopId, State;
            public int Count; public long Start, End;
        }
        private sealed class Account
        {
            public string Id; public long Revision = 1, Now = 1800000000000L, LastPublishedTime; public double FractionalMs;
            public readonly Dictionary<string, long> Resources = new Dictionary<string, long>(StringComparer.Ordinal);
            public readonly Dictionary<string, int> Buildings = new Dictionary<string, int>(StringComparer.Ordinal);
            public readonly Dictionary<string, int> Research = new Dictionary<string, int>(StringComparer.Ordinal);
            public readonly Dictionary<string, int> Troops = new Dictionary<string, int>(StringComparer.Ordinal);
            public readonly Dictionary<string, int> Items = new Dictionary<string, int>(StringComparer.Ordinal);
            public readonly List<Operation> Queues = new List<Operation>();
            public readonly List<Mail> Mails = new List<Mail>();
            public readonly List<ChatSnapshot> Chat = new List<ChatSnapshot>();
            public readonly List<March> Marches = new List<March>();
            public readonly Dictionary<string, Receipt> Receipts = new Dictionary<string, Receipt>(StringComparer.Ordinal);
        }
        private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>(StringComparer.Ordinal);
        private Account current;
        private long generation;
        private bool disposed;
        public string Label => "MOCK AUTHORITY - local fixtures, no DE server connection";
        public event Action<DeSnapshot> SnapshotReceived;
        public void Open(string accountId, long generation)
        {
            EnsureAlive();
            if (string.IsNullOrWhiteSpace(accountId) || generation < 1) throw new ArgumentException("Invalid session.");
            this.generation = generation;
            if (!accounts.TryGetValue(accountId, out current)) { current = CreateAccount(accountId); accounts.Add(accountId, current); }
            Publish(false);
        }
        public void Close() { current = null; generation = 0; }
        public void Dispose() { if (disposed) return; disposed = true; Close(); accounts.Clear(); SnapshotReceived = null; }
        private void EnsureAlive() { if (disposed) throw new ObjectDisposedException(nameof(MockDeSession)); }
        private static Account CreateAccount(string id)
        {
            var a = new Account { Id = id };
            foreach (var key in new[] { "food", "energy", "oil", "steel", "cash" }) a.Resources.Add(key, 5000);
            a.Resources.Add("diamond", 200);
            a.Buildings.Add("hq", 1); a.Buildings.Add("lab", 0); a.Buildings.Add("barracks", 0);
            a.Research.Add("industry", 0); a.Research.Add("leadership", 0);
            a.Troops.Add("jeep", 40); a.Troops.Add("tank", 0);
            a.Items.Add("food-crate", 5); a.Items.Add("speedup-60", 3);
            a.Mails.Add(new Mail { Id = "mail-1", Title = "Welcome, Commander", Body = "Mock fixture: claim once to receive 300 food.", Food = 300 });
            a.Mails.Add(new Mail { Id = "mail-2", Title = "Supply convoy", Body = "Mock fixture: claim once to receive 450 food.", Food = 450 });
            a.Mails.Add(new Mail { Id = "mail-3", Title = "Reconnaissance report", Body = "Mock report only. Real combat and server reports are not migrated.", Food = 0 });
            a.Chat.Add(new ChatSnapshot("welcome", "Operations", "Local Mock channel. Messages are not sent to other players.", "world", a.Now));
            return a;
        }
        private static readonly WorldNodeSnapshot[] nodes = {
            new WorldNodeSnapshot("node-1", "Abandoned Farm", 0.22, 0.27, "Resource"),
            new WorldNodeSnapshot("node-2", "Energy Depot", 0.68, 0.18, "Resource"),
            new WorldNodeSnapshot("node-3", "Rebel Outpost", 0.78, 0.48, "Rebel"),
            new WorldNodeSnapshot("node-4", "Steel Yard", 0.30, 0.72, "Resource"),
            new WorldNodeSnapshot("node-5", "Alliance Ruins", 0.60, 0.77, "Resource"),
            new WorldNodeSnapshot("node-6", "Northern Relay", 0.45, 0.38, "Resource")
        };
        public DeResult Send(DeCommand command)
        {
            EnsureAlive();
            if (current == null) return DeResult.Rejected("not_connected", "Open an account first.");
            if (command == null || string.IsNullOrWhiteSpace(command.RequestId) || command.RequestId.Length > 128)
                return DeResult.Rejected("invalid_request", "A bounded request id is required.");
            if (current.Receipts.TryGetValue(command.RequestId, out var prior))
                return prior.Command.HasSamePayload(command) ? prior.Result.AsDuplicate() : DeResult.Rejected("request_conflict", "This request id was already used for a different command.");
            if (current.Receipts.Count >= 4096) return DeResult.Rejected("request_capacity", "Mock request history is full. Recreate the test session.");
            DeResult result;
            if (command.Quantity < 1 || command.Quantity > 10000) result = DeResult.Rejected("invalid_quantity", "Quantity must be between 1 and 10000.");
            else
            {
                switch (command.Kind)
                {
                    case DeCommandKind.StartBuildingUpgrade:
                    case DeCommandKind.StartResearch:
                    case DeCommandKind.TrainTroops: result = StartOperation(command); break;
                    case DeCommandKind.CancelQueue: result = Cancel(command.TargetId); break;
                    case DeCommandKind.SpeedUpQueue: result = SpeedUp(command.TargetId, command.Quantity); break;
                    case DeCommandKind.UseItem: result = UseItem(command); break;
                    case DeCommandKind.ReadMail: result = ReadMail(command.TargetId); break;
                    case DeCommandKind.ClaimMail: result = ClaimMail(command.TargetId); break;
                    case DeCommandKind.SendChat: result = SendChat(command); break;
                    case DeCommandKind.CreateMarch: result = CreateMarch(command); break;
                    case DeCommandKind.RecallMarch: result = Recall(command.TargetId); break;
                    default: result = DeResult.Rejected("unsupported", "This command is not implemented."); break;
                }
            }
            current.Receipts.Add(command.RequestId, new Receipt { Command = command, Result = result });
            if (result.Success) Publish(true);
            return result;
        }
        private DeResult StartOperation(DeCommand command)
        {
            var preview = DeRules.Preview(Snapshot(), command);
            if (!preview.CanExecute) return DeResult.Rejected(preview.Code, preview.Message);
            var operation = new Operation { Id = command.RequestId, TargetId = command.TargetId, Quantity = command.Quantity,
                Start = current.Now, End = checked(current.Now + preview.DurationMs), Paid = preview.Costs };
            switch (command.Kind)
            {
                case DeCommandKind.StartBuildingUpgrade:
                    operation.Kind = "Building"; operation.TargetLevel = current.Buildings[command.TargetId] + 1;
                    operation.Name = BuildingName(command.TargetId); break;
                case DeCommandKind.StartResearch:
                    operation.Kind = "Research"; operation.TargetLevel = current.Research[command.TargetId] + 1;
                    operation.Name = ResearchName(command.TargetId); break;
                default:
                    operation.Kind = "Training"; operation.TargetLevel = 0; operation.Name = TroopName(command.TargetId); break;
            }
            // All validation precedes mutation; preview costs are bounded and nonnegative.
            foreach (var cost in operation.Paid) current.Resources[cost.Key] -= cost.Amount;
            current.Queues.Add(operation);
            return DeResult.Accepted("Mock authority accepted " + operation.Kind + ". Client waits for an authoritative snapshot.");
        }
        private DeResult Cancel(string id)
        {
            var operation = current.Queues.Find(q => q.Id == id);
            if (operation == null) return DeResult.Rejected("unknown_queue", "Queue no longer exists.");
            if (operation.End <= current.Now) return DeResult.Rejected("awaiting_confirmation", "Expired work awaits authority confirmation.");
            foreach (var cost in operation.Paid) current.Resources[cost.Key] = checked(current.Resources[cost.Key] + cost.Amount / 2);
            current.Queues.Remove(operation);
            return DeResult.Accepted("Mock cancellation returned half of paid resource costs.");
        }
        private DeResult SpeedUp(string id, int seconds)
        {
            var operation = current.Queues.Find(q => q.Id == id);
            if (operation == null) return DeResult.Rejected("unknown_queue", "Queue no longer exists.");
            long remaining = operation.End - current.Now;
            if (remaining <= 0) return DeResult.Rejected("awaiting_confirmation", "Work already elapsed; wait for authority confirmation.");
            long removed = Math.Min(remaining, seconds * 1000L);
            long price = 1 + (removed - 1) / 10000;
            if (current.Resources["diamond"] < price) return DeResult.Rejected("insufficient_resources", "Insufficient diamonds.");
            current.Resources["diamond"] -= price;
            operation.End = Math.Max(current.Now, operation.End - removed);
            return DeResult.Accepted("Mock acceleration removed " + removed + " ms for " + price + " diamonds.");
        }
        private DeResult UseItem(DeCommand command)
        {
            if (!current.Items.TryGetValue(command.TargetId, out int available)) return DeResult.Rejected("unknown_item", "Unknown item.");
            if (available < command.Quantity) return DeResult.Rejected("insufficient_items", "Insufficient item count.");
            if (command.TargetId == "food-crate")
            {
                long value = checked(current.Resources["food"] + command.Quantity * 200L);
                current.Resources["food"] = value;
            }
            else if (command.TargetId == "speedup-60")
            {
                var operation = string.IsNullOrEmpty(command.SecondaryId) ? (current.Queues.Count == 0 ? null : current.Queues[0]) : current.Queues.Find(q => q.Id == command.SecondaryId);
                if (operation == null) return DeResult.Rejected("unknown_queue", "Select an active queue to accelerate.");
                long remaining = operation.End - current.Now;
                if (remaining <= 0) return DeResult.Rejected("awaiting_confirmation", "Work already elapsed; wait for authority confirmation.");
                int necessary = (int)Math.Min(command.Quantity, 1 + (remaining - 1) / 60000);
                if (necessary != command.Quantity) return DeResult.Rejected("excess_items", "Requested more speedup items than this queue can use.");
                operation.End = Math.Max(current.Now, operation.End - command.Quantity * 60000L);
            }
            else return DeResult.Rejected("unsupported_item", "This item effect is not implemented.");
            current.Items[command.TargetId] -= command.Quantity;
            return DeResult.Accepted("Item effect applied by Mock authority.");
        }
        private DeResult ReadMail(string id)
        {
            var mail = current.Mails.Find(m => m.Id == id);
            if (mail == null) return DeResult.Rejected("unknown_mail", "Mail not found.");
            mail.Read = true; return DeResult.Accepted("Mail marked as read.");
        }
        private DeResult ClaimMail(string id)
        {
            var mail = current.Mails.Find(m => m.Id == id);
            if (mail == null) return DeResult.Rejected("unknown_mail", "Mail not found.");
            if (mail.Claimed) return DeResult.Rejected("already_claimed", "This mail reward was already claimed.");
            if (mail.Food == 0) return DeResult.Rejected("no_attachment", "This report has no reward attachment.");
            long value = checked(current.Resources["food"] + mail.Food);
            current.Resources["food"] = value; mail.Claimed = true; mail.Read = true;
            return DeResult.Accepted("Mock mail reward claimed once: " + mail.Food + " food.");
        }
        private DeResult SendChat(DeCommand command)
        {
            string text = command.Text.Trim(); string channel = string.IsNullOrEmpty(command.TargetId) ? "world" : command.TargetId;
            if (text.Length == 0 || text.Length > 200) return DeResult.Rejected("invalid_text", "Chat must contain 1 to 200 characters.");
            if (channel != "world" && channel != "alliance") return DeResult.Rejected("unknown_channel", "Choose world or alliance Mock channel.");
            foreach (char c in text) if (char.IsControl(c)) return DeResult.Rejected("invalid_text", "Control characters are not accepted.");
            current.Chat.Add(new ChatSnapshot(command.RequestId, current.Id, text, channel, current.Now));
            if (current.Chat.Count > 100) current.Chat.RemoveAt(0);
            return DeResult.Accepted("Saved in local Mock channel only.");
        }
        private DeResult CreateMarch(DeCommand command)
        {
            var node = Array.Find(nodes, n => n.Id == command.TargetId);
            if (node == null) return DeResult.Rejected("unknown_node", "Unknown world node.");
            // Battle outcomes cannot be invented by the client: unimplemented rebel combat is explicitly gated.
            if (node.Kind != "Resource") return DeResult.Rejected("not_migrated", "Rebel combat is not migrated. Choose a resource fixture node.");
            string troopId = string.IsNullOrEmpty(command.SecondaryId) ? "jeep" : command.SecondaryId;
            if (!current.Troops.TryGetValue(troopId, out int count)) return DeResult.Rejected("unknown_troop", "Unknown troop type.");
            if (count < command.Quantity) return DeResult.Rejected("insufficient_troops", "Insufficient available troops.");
            if (current.Marches.Count >= 3) return DeResult.Rejected("march_capacity", "All three Mock march slots are occupied.");
            current.Troops[troopId] -= command.Quantity;
            current.Marches.Add(new March { Id = command.RequestId, TargetId = node.Id, Name = node.Name, TroopId = troopId,
                Count = command.Quantity, Start = current.Now, End = checked(current.Now + 15000), State = "Outbound" });
            return DeResult.Accepted("Mock march dispatched. Troops are reserved until return.");
        }
        private DeResult Recall(string id)
        {
            var march = current.Marches.Find(m => m.Id == id);
            if (march == null) return DeResult.Rejected("unknown_march", "March not found.");
            if (march.State == "Returning") return DeResult.Rejected("already_returning", "March is already returning.");
            long elapsed = Math.Max(1000, Math.Min(15000, current.Now - march.Start));
            march.State = "Returning"; march.Start = current.Now; march.End = checked(current.Now + elapsed);
            return DeResult.Accepted("Recall accepted by Mock authority; no gathering reward awarded.");
        }
        public void Tick(double deltaSeconds)
        {
            EnsureAlive();
            if (double.IsNaN(deltaSeconds) || double.IsInfinity(deltaSeconds) || deltaSeconds < 0 || deltaSeconds > 86400) throw new ArgumentOutOfRangeException(nameof(deltaSeconds));
            if (current == null) return;
            double elapsed = deltaSeconds * 1000 + current.FractionalMs;
            long ms = (long)elapsed; current.FractionalMs = elapsed - ms;
            if (ms == 0) return;
            current.Now = checked(current.Now + ms);
            bool stateChanged = false;
            for (int i = current.Queues.Count - 1; i >= 0; i--)
            {
                var operation = current.Queues[i];
                if (operation.End > current.Now) continue;
                if (operation.Kind == "Building") current.Buildings[operation.TargetId] = operation.TargetLevel;
                else if (operation.Kind == "Research") current.Research[operation.TargetId] = operation.TargetLevel;
                else current.Troops[operation.TargetId] = checked(current.Troops[operation.TargetId] + operation.Quantity);
                current.Queues.RemoveAt(i);
                stateChanged = true;
            }
            for (int i = current.Marches.Count - 1; i >= 0; i--)
            {
                var march = current.Marches[i];
                if (march.End > current.Now) continue;
                stateChanged = true;
                if (march.State == "Outbound")
                {
                    // Local fixture authority grants, then schedules return from the actual arrival time.
                    current.Resources["food"] = checked(current.Resources["food"] + march.Count * 10L);
                    march.State = "Returning"; march.Start = march.End; march.End = checked(march.Start + 12000);
                }
                if (march.State == "Returning" && march.End <= current.Now)
                { current.Troops[march.TroopId] = checked(current.Troops[march.TroopId] + march.Count); current.Marches.RemoveAt(i); }
            }
            // Preserve input targets between updates; state transitions publish immediately, clock updates at 10Hz.
            if (stateChanged || current.Now - current.LastPublishedTime >= 100) Publish(true);
        }
        private void Publish(bool increment)
        {
            if (current == null) return;
            if (increment) current.Revision = checked(current.Revision + 1);
            current.LastPublishedTime = current.Now;
            SnapshotReceived?.Invoke(Snapshot());
        }
        private DeSnapshot Snapshot()
        {
            var resources = new List<ResourceSnapshot>(); foreach (var pair in current.Resources) resources.Add(new ResourceSnapshot(pair.Key, pair.Value));
            var buildings = new List<BuildingSnapshot>(); foreach (var pair in current.Buildings) buildings.Add(new BuildingSnapshot(pair.Key, BuildingName(pair.Key), pair.Value, 5));
            var research = new List<ResearchSnapshot>(); foreach (var pair in current.Research) research.Add(new ResearchSnapshot(pair.Key, ResearchName(pair.Key), pair.Value, 3));
            var troops = new List<TroopSnapshot>(); foreach (var pair in current.Troops) troops.Add(new TroopSnapshot(pair.Key, TroopName(pair.Key), pair.Value));
            var queues = new List<QueueSnapshot>(); foreach (var value in current.Queues) queues.Add(new QueueSnapshot(value.Id, value.Kind, value.TargetId, value.Name, value.Quantity, value.TargetLevel, value.Start, value.End, current.Now));
            var items = new List<ItemSnapshot>(); foreach (var pair in current.Items) items.Add(new ItemSnapshot(pair.Key, pair.Key == "food-crate" ? "Food crate" : "60s speedup", pair.Value, pair.Key == "food-crate" ? "Mock: grants 200 food per crate." : "Mock: removes up to 60 seconds from one selected queue."));
            var mails = new List<MailSnapshot>(); foreach (var value in current.Mails) mails.Add(new MailSnapshot(value.Id, value.Title, value.Body, value.Read, value.Claimed, value.Food == 0 ? "No attachment" : value.Food + " food"));
            var marches = new List<MarchSnapshot>(); foreach (var value in current.Marches) marches.Add(new MarchSnapshot(value.Id, value.TargetId, value.Name, value.TroopId, value.Count, value.Start, value.End, current.Now, value.State));
            return new DeSnapshot(current.Id, generation, current.Revision, current.Now, resources.ToArray(), buildings.ToArray(), research.ToArray(), troops.ToArray(), queues.ToArray(), items.ToArray(), mails.ToArray(), current.Chat.ToArray(), nodes, marches.ToArray());
        }
        private static string BuildingName(string id) { return id == "hq" ? "Headquarters" : id == "lab" ? "Laboratory" : "Barracks"; }
        private static string ResearchName(string id) { return id == "industry" ? "Industry" : "Leadership"; }
        private static string TroopName(string id) { return id == "jeep" ? "Jeep" : "Tank"; }
    }
}
