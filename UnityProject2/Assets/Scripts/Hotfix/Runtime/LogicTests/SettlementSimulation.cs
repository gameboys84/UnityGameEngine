using System;
using System.Collections.Generic;
using GameCore;

namespace GameRuntime.LogicTests
{
    public sealed class SettlementSimulation
    {
        private readonly IndexedTable<OperationRule> rules = new IndexedTable<OperationRule>(r => r.Id);
        private readonly ServerClock clock;
        private BalanceLedger balances = new BalanceLedger();
        private Dictionary<int, int> levels = new Dictionary<int, int>();
        private Dictionary<string, QueuedAction> actions = new Dictionary<string, QueuedAction>(StringComparer.Ordinal);
        private OperationTimeline timeline = new OperationTimeline();
        private long revision;
        public OperationTimeline Timeline => timeline;
        public long NowMilliseconds => clock.NowMilliseconds;
        public long GetBalance(string key) => balances.Get(key);
        public int GetLevel(int id) => levels.TryGetValue(id, out int level) ? level : 0;
        public OperationRule[] GetRules()
        {
            var result = Array.ConvertAll(rules.GetAll(), r => r.Copy());
            Array.Sort(result, (a, b) => a.Id.CompareTo(b.Id)); return result;
        }
        public QueuedAction[] GetActions()
        {
            var list = new List<QueuedAction>(); foreach (var value in actions.Values) list.Add(value.Copy());
            list.Sort((a, b) => string.CompareOrdinal(a.Operation.Id, b.Operation.Id)); return list.ToArray();
        }
        public SettlementSimulation(IEnumerable<OperationRule> definitions, ServerClock clock)
        {
            this.clock = clock ?? throw new ArgumentNullException(nameof(clock));
            if (definitions == null) throw new ArgumentNullException(nameof(definitions));
            var copy = new List<OperationRule>();
            foreach (var rule in definitions) { if (rule == null) throw new ArgumentException("Null rule."); rule.Validate(); copy.Add(rule.Copy()); }
            rules.Replace(copy);
            foreach (var rule in copy)
                foreach (var requirement in rule.Requirements)
                    if (!rules.TryGet(requirement.RuleId, out var prerequisite) || requirement.Level > prerequisite.MaximumLevel)
                        throw new ArgumentException("Unknown or unreachable prerequisite.");
        }
        public LedgerResult Grant(string receipt, string key, long amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            return balances.TryApply("grant/" + ValidateRequestId(receipt), new Dictionary<string, long> { [key] = amount });
        }
        private static string ValidateRequestId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("A request id is required.");
            return id;
        }
        private static Dictionary<string, long> CostsFor(OperationRule rule, long multiplier)
        {
            var costs = new Dictionary<string, long>(StringComparer.Ordinal);
            foreach (var cost in rule.Costs)
            {
                costs.TryGetValue(cost.Key, out long current);
                costs[cost.Key] = checked(current - checked(cost.Amount * multiplier));
            }
            return costs;
        }
        public RequestResult Start(string requestId, int ruleId, int quantity = 1)
        {
            ValidateRequestId(requestId);
            if (balances.ContainsReceipt("start/" + requestId)) return RequestResult.Duplicate;
            if (!rules.TryGet(ruleId, out var rule)) return RequestResult.UnknownRule;
            if (quantity < 1 || quantity > 10000 || (rule.Kind != OperationKind.Training && quantity != 1)) return RequestResult.InvalidQuantity;
            int nextLevel = checked(GetLevel(ruleId) + 1);
            if (rule.Kind != OperationKind.Training && nextLevel > rule.MaximumLevel) return RequestResult.MaximumLevel;
            foreach (var requirement in rule.Requirements)
                if (GetLevel(requirement.RuleId) < requirement.Level) return RequestResult.PrerequisiteMissing;
            string group = rule.Kind.ToString();
            foreach (var action in actions.Values)
                if (action.Operation.Group == group) return RequestResult.QueueFull;
            long multiplier = rule.Kind == OperationKind.Training ? quantity : nextLevel;
            var costs = CostsFor(rule, multiplier);
            long start = clock.NowMilliseconds, end = checked(start + checked(rule.DurationMilliseconds * multiplier));
            if (revision == long.MaxValue) throw new InvalidOperationException("State revision exhausted.");
            var outcome = balances.TryApply("start/" + requestId, costs);
            if (outcome == LedgerResult.InsufficientBalance) return RequestResult.InsufficientBalance;
            var paid = new List<ResourceCost>(); foreach (var cost in costs) paid.Add(new ResourceCost { Key = cost.Key, Amount = -cost.Value });
            actions.Add(requestId, new QueuedAction
            {
                Operation = new TimedOperation { Id = requestId, Group = group, EntityId = ruleId, StartMilliseconds = start, EndMilliseconds = end },
                TargetLevel = nextLevel, Quantity = quantity, PaidCosts = paid.ToArray()
            });
            Publish(); return RequestResult.Accepted;
        }
        public bool SpeedUp(string receipt, string actionId, long milliseconds)
        {
            ValidateRequestId(receipt);
            if (milliseconds < 1 || !actions.TryGetValue(actionId, out var action)) return false;
            if (revision == long.MaxValue) throw new InvalidOperationException("State revision exhausted.");
            long remaining = action.Operation.Remaining(clock.NowMilliseconds);
            if (remaining == 0) return false;
            long applied = Math.Min(milliseconds, remaining);
            long end = action.Operation.EndMilliseconds - applied;
            long tokens = checked(1 + (applied - 1) / 1000);
            if (balances.TryApply("speed/" + receipt, new Dictionary<string, long> { ["Speedup"] = -tokens }) != LedgerResult.Applied) return false;
            action.Operation.EndMilliseconds = Math.Max(action.Operation.StartMilliseconds, end);
            Publish(); return true;
        }
        public bool Cancel(string actionId)
        {
            if (!actions.TryGetValue(actionId, out var action)) return false;
            if (action.Operation.Remaining(clock.NowMilliseconds) == 0) return false;
            if (revision == long.MaxValue) throw new InvalidOperationException("State revision exhausted.");
            var refund = new Dictionary<string, long>(StringComparer.Ordinal);
            foreach (var cost in action.PaidCosts) refund.Add(cost.Key, cost.Amount / 2);
            if (balances.TryApply("cancel/" + actionId, refund) != LedgerResult.Applied) return false;
            actions.Remove(actionId); Publish(); return true;
        }
        public int ConfirmElapsed()
        {
            long now = clock.NowMilliseconds;
            var ready = new List<string>();
            foreach (var pair in actions) if (pair.Value.Operation.EndMilliseconds <= now) ready.Add(pair.Key);
            ready.Sort(StringComparer.Ordinal);
            if (ready.Count > 0 && revision == long.MaxValue) throw new InvalidOperationException("State revision exhausted.");
            foreach (string id in ready)
            {
                var action = actions[id]; var rule = rules.Get(action.Operation.EntityId);
                var reward = new Dictionary<string, long>();
                if (rule.Kind == OperationKind.Training) reward.Add("Unit" + rule.Id, action.Quantity);
                var applied = balances.TryApply("finish/" + id, reward);
                if (applied == LedgerResult.Applied && rule.Kind != OperationKind.Training) levels[rule.Id] = action.TargetLevel;
                actions.Remove(id);
            }
            if (ready.Count > 0) Publish();
            return ready.Count;
        }
        private void Publish()
        {
            ++revision;
            foreach (OperationKind kind in Enum.GetValues(typeof(OperationKind)))
            {
                var group = new List<TimedOperation>();
                foreach (var action in actions.Values) if (action.Operation.Group == kind.ToString()) group.Add(action.Operation);
                timeline.ApplySnapshot(kind.ToString(), revision, group);
            }
        }
        public SettlementSnapshot Export()
        {
            var list = new List<LevelState>(); foreach (var level in levels) list.Add(new LevelState { RuleId = level.Key, Level = level.Value });
            list.Sort((a, b) => a.RuleId.CompareTo(b.RuleId));
            return new SettlementSnapshot { Revision = revision, Balances = balances.Export(), Levels = list.ToArray(), Actions = GetActions() };
        }
        public void Restore(SettlementSnapshot state)
        {
            if (state == null || state.Version != 1 || state.Revision < 0 || state.Levels == null || state.Actions == null) throw new ArgumentException("Invalid settlement snapshot.");
            var restoredBalances = new BalanceLedger(); restoredBalances.Restore(state.Balances);
            var restoredLevels = new Dictionary<int, int>();
            foreach (var level in state.Levels)
            {
                if (level == null || !rules.TryGet(level.RuleId, out var rule) || rule.Kind == OperationKind.Training || level.Level < 0 || level.Level > rule.MaximumLevel || restoredLevels.ContainsKey(level.RuleId))
                    throw new ArgumentException("Invalid saved level.");
                restoredLevels.Add(level.RuleId, level.Level);
            }
            var restoredActions = new Dictionary<string, QueuedAction>(StringComparer.Ordinal);
            var groups = new HashSet<string>(StringComparer.Ordinal);
            foreach (var action in state.Actions)
            {
                if (action?.Operation == null || action.PaidCosts == null) throw new ArgumentException("Invalid saved operation.");
                action.Operation.Validate();
                if (!rules.TryGet(action.Operation.EntityId, out var rule) || action.Operation.Group != rule.Kind.ToString() ||
                    !groups.Add(action.Operation.Group) || restoredActions.ContainsKey(action.Operation.Id) || action.Quantity < 1 || action.Quantity > 10000 ||
                    !restoredBalances.ContainsReceipt("start/" + action.Operation.Id) || restoredBalances.ContainsReceipt("finish/" + action.Operation.Id) || restoredBalances.ContainsReceipt("cancel/" + action.Operation.Id))
                    throw new ArgumentException("Invalid saved operation identity.");
                restoredLevels.TryGetValue(rule.Id, out int currentLevel);
                if (action.TargetLevel != checked(currentLevel + 1) || (rule.Kind != OperationKind.Training && (action.Quantity != 1 || action.TargetLevel > rule.MaximumLevel)))
                    throw new ArgumentException("Invalid saved operation target.");
                var paidKeys = new HashSet<string>();
                var expectedCosts = CostsFor(rule, rule.Kind == OperationKind.Training ? action.Quantity : action.TargetLevel);
                foreach (var cost in action.PaidCosts)
                    if (cost == null || string.IsNullOrWhiteSpace(cost.Key) || cost.Amount < 0 || !paidKeys.Add(cost.Key) || !expectedCosts.TryGetValue(cost.Key, out long expected) || expected != -cost.Amount)
                        throw new ArgumentException("Invalid saved operation cost.");
                if (paidKeys.Count != expectedCosts.Count) throw new ArgumentException("Missing saved operation cost.");
                restoredActions.Add(action.Operation.Id, action.Copy());
            }
            balances = restoredBalances; levels = restoredLevels; actions = restoredActions; revision = state.Revision;
            timeline = new OperationTimeline();
            foreach (OperationKind kind in Enum.GetValues(typeof(OperationKind)))
            {
                var group = new List<TimedOperation>(); foreach (var action in actions.Values) if (action.Operation.Group == kind.ToString()) group.Add(action.Operation);
                timeline.ApplySnapshot(kind.ToString(), revision, group);
            }
        }
    }
}
