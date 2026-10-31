using System;
using System.Collections.Generic;

namespace DE.Domain
{
    public sealed class ResourceSnapshot
    {
        public string Key { get; }
        public long Amount { get; }
        public ResourceSnapshot(string key, long amount)
        { if (string.IsNullOrWhiteSpace(key) || amount < 0) throw new ArgumentException("Invalid resource."); Key = key; Amount = amount; }
    }
    public sealed class BuildingSnapshot
    {
        public string Id { get; } public string Name { get; }
        public int Level { get; } public int MaximumLevel { get; }
        public BuildingSnapshot(string id, string name, int level, int maximumLevel)
        { ValidateLevel(id, level, maximumLevel); Id = id; Name = name; Level = level; MaximumLevel = maximumLevel; }
        internal static void ValidateLevel(string id, int level, int max)
        { if (string.IsNullOrWhiteSpace(id) || level < 0 || max < level) throw new ArgumentException("Invalid level snapshot."); }
    }
    public sealed class ResearchSnapshot
    {
        public string Id { get; } public string Name { get; }
        public int Level { get; } public int MaximumLevel { get; }
        public ResearchSnapshot(string id, string name, int level, int maximumLevel)
        { BuildingSnapshot.ValidateLevel(id, level, maximumLevel); Id = id; Name = name; Level = level; MaximumLevel = maximumLevel; }
    }
    public sealed class TroopSnapshot
    {
        public string Id { get; } public string Name { get; } public int Count { get; }
        public TroopSnapshot(string id, string name, int count)
        { if (string.IsNullOrWhiteSpace(id) || count < 0) throw new ArgumentException("Invalid troop."); Id = id; Name = name; Count = count; }
    }
    public sealed class QueueSnapshot
    {
        public string Id { get; } public string Kind { get; } public string TargetId { get; }
        public string TargetName { get; } public int Quantity { get; } public int TargetLevel { get; }
        public long StartTimeMs { get; } public long EndTimeMs { get; } public long RemainingMs { get; }
        public bool AwaitingConfirmation => RemainingMs == 0;
        public QueueSnapshot(string id, string kind, string targetId, string targetName, int quantity,
            int targetLevel, long startTimeMs, long endTimeMs, long serverTimeMs)
        {
            if (string.IsNullOrWhiteSpace(id) || quantity < 1 || targetLevel < 0 || startTimeMs < 0 || endTimeMs < startTimeMs || serverTimeMs < 0) throw new ArgumentException("Invalid operation.");
            Id = id; Kind = kind; TargetId = targetId; TargetName = targetName; Quantity = quantity; TargetLevel = targetLevel;
            StartTimeMs = startTimeMs; EndTimeMs = endTimeMs; RemainingMs = Math.Max(0, endTimeMs - serverTimeMs);
        }
    }
    public sealed class ItemSnapshot
    {
        public string Id { get; } public string Name { get; } public int Count { get; } public string Description { get; }
        public ItemSnapshot(string id, string name, int count, string description)
        { if (string.IsNullOrWhiteSpace(id) || count < 0) throw new ArgumentException("Invalid item."); Id = id; Name = name; Count = count; Description = description; }
    }
    public sealed class MailSnapshot
    {
        public string Id { get; } public string Title { get; } public string Body { get; }
        public bool IsRead { get; } public bool IsClaimed { get; } public string RewardText { get; }
        public MailSnapshot(string id, string title, string body, bool isRead, bool isClaimed, string rewardText)
        { if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Invalid mail."); Id = id; Title = title; Body = body; IsRead = isRead; IsClaimed = isClaimed; RewardText = rewardText; }
    }
    public sealed class ChatSnapshot
    {
        public string Id { get; } public string Sender { get; } public string Text { get; }
        public string Channel { get; } public long TimestampMs { get; }
        public ChatSnapshot(string id, string sender, string text, string channel, long timestampMs)
        { if (string.IsNullOrWhiteSpace(id) || timestampMs < 0) throw new ArgumentException("Invalid chat."); Id = id; Sender = sender; Text = text; Channel = channel; TimestampMs = timestampMs; }
    }
    public sealed class WorldNodeSnapshot
    {
        public string Id { get; } public string Name { get; } public double X { get; } public double Y { get; } public string Kind { get; }
        public WorldNodeSnapshot(string id, string name, double x, double y, string kind)
        { if (string.IsNullOrWhiteSpace(id) || double.IsNaN(x) || double.IsNaN(y) || double.IsInfinity(x) || double.IsInfinity(y)) throw new ArgumentException("Invalid node."); Id = id; Name = name; X = x; Y = y; Kind = kind; }
    }
    public sealed class MarchSnapshot
    {
        public string Id { get; } public string TargetId { get; } public string TargetName { get; }
        public string TroopId { get; } public int Count { get; } public long StartTimeMs { get; } public long EndTimeMs { get; }
        public double Progress { get; } public string State { get; }
        public MarchSnapshot(string id, string targetId, string targetName, string troopId, int count,
            long startTimeMs, long endTimeMs, long serverTimeMs, string state)
        {
            if (string.IsNullOrWhiteSpace(id) || count < 1 || startTimeMs < 0 || endTimeMs <= startTimeMs || serverTimeMs < 0) throw new ArgumentException("Invalid march.");
            Id = id; TargetId = targetId; TargetName = targetName; TroopId = troopId; Count = count;
            StartTimeMs = startTimeMs; EndTimeMs = endTimeMs; State = state;
            Progress = Math.Max(0, Math.Min(1, (double)(serverTimeMs - startTimeMs) / (endTimeMs - startTimeMs)));
        }
    }

    public sealed class DeSnapshot
    {
        private readonly ResourceSnapshot[] resources; private readonly BuildingSnapshot[] buildings;
        private readonly ResearchSnapshot[] research; private readonly TroopSnapshot[] troops;
        private readonly QueueSnapshot[] queues; private readonly ItemSnapshot[] items;
        private readonly MailSnapshot[] mails; private readonly ChatSnapshot[] chat;
        private readonly WorldNodeSnapshot[] worldNodes; private readonly MarchSnapshot[] marches;
        public string AccountId { get; } public long SessionGeneration { get; } public long Revision { get; } public long ServerTimeMs { get; }
        public ResourceSnapshot[] Resources => (ResourceSnapshot[])resources.Clone();
        public BuildingSnapshot[] Buildings => (BuildingSnapshot[])buildings.Clone();
        public ResearchSnapshot[] Research => (ResearchSnapshot[])research.Clone();
        public TroopSnapshot[] Troops => (TroopSnapshot[])troops.Clone();
        public QueueSnapshot[] Queues => (QueueSnapshot[])queues.Clone();
        public ItemSnapshot[] Items => (ItemSnapshot[])items.Clone();
        public MailSnapshot[] Mails => (MailSnapshot[])mails.Clone();
        public ChatSnapshot[] Chat => (ChatSnapshot[])chat.Clone();
        public WorldNodeSnapshot[] WorldNodes => (WorldNodeSnapshot[])worldNodes.Clone();
        public MarchSnapshot[] Marches => (MarchSnapshot[])marches.Clone();
        public DeSnapshot(string accountId, long sessionGeneration, long revision, long serverTimeMs,
            ResourceSnapshot[] resources = null, BuildingSnapshot[] buildings = null, ResearchSnapshot[] research = null,
            TroopSnapshot[] troops = null, QueueSnapshot[] queues = null, ItemSnapshot[] items = null,
            MailSnapshot[] mails = null, ChatSnapshot[] chat = null, WorldNodeSnapshot[] worldNodes = null, MarchSnapshot[] marches = null)
        {
            if (string.IsNullOrWhiteSpace(accountId) || sessionGeneration < 0 || revision < 0 || serverTimeMs < 0) throw new ArgumentException("Invalid snapshot header.");
            AccountId = accountId; SessionGeneration = sessionGeneration; Revision = revision; ServerTimeMs = serverTimeMs;
            this.resources = CopyUnique(resources, v => v.Key); this.buildings = CopyUnique(buildings, v => v.Id);
            this.research = CopyUnique(research, v => v.Id); this.troops = CopyUnique(troops, v => v.Id);
            this.queues = CopyUnique(queues, v => v.Id); this.items = CopyUnique(items, v => v.Id);
            this.mails = CopyUnique(mails, v => v.Id); this.chat = CopyUnique(chat, v => v.Id);
            this.worldNodes = CopyUnique(worldNodes, v => v.Id); this.marches = CopyUnique(marches, v => v.Id);
        }
        private static T[] CopyUnique<T>(T[] input, Func<T, string> key) where T : class
        {
            if (input == null) return new T[0];
            var result = (T[])input.Clone(); var keys = new HashSet<string>(StringComparer.Ordinal);
            foreach (var item in result) if (item == null || !keys.Add(key(item))) throw new ArgumentException("Null or duplicate snapshot entry.");
            return result;
        }
        public long GetResource(string key) { foreach (var value in resources) if (value.Key == key) return value.Amount; return 0; }
        public int GetBuildingLevel(string id) { foreach (var value in buildings) if (value.Id == id) return value.Level; return 0; }
        public int GetResearchLevel(string id) { foreach (var value in research) if (value.Id == id) return value.Level; return 0; }
    }
}
