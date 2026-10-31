using System;
using GameCore;

namespace GameRuntime.LogicTests
{
    public enum OperationKind { Building, Research, Training }
    public enum RequestResult { Accepted, Duplicate, UnknownRule, PrerequisiteMissing, QueueFull, MaximumLevel, InsufficientBalance, InvalidQuantity }
    [Serializable] public sealed class ResourceCost { public string Key; public long Amount; }
    [Serializable] public sealed class LevelRequirement { public int RuleId, Level; }
    [Serializable] public sealed class OperationRule
    {
        public int Id;
        public string Name;
        public OperationKind Kind;
        public int MaximumLevel;
        public long DurationMilliseconds;
        public ResourceCost[] Costs = Array.Empty<ResourceCost>();
        public LevelRequirement[] Requirements = Array.Empty<LevelRequirement>();
        public void Validate()
        {
            if (Id <= 0 || string.IsNullOrWhiteSpace(Name) || !Enum.IsDefined(typeof(OperationKind), Kind) || MaximumLevel < 1 || DurationMilliseconds < 1 || Costs == null || Requirements == null)
                throw new ArgumentException("Invalid operation rule.");
            foreach (var cost in Costs)
                if (cost == null || string.IsNullOrWhiteSpace(cost.Key) || cost.Amount < 0) throw new ArgumentException("Invalid rule cost.");
            foreach (var requirement in Requirements)
                if (requirement == null || requirement.RuleId <= 0 || requirement.Level < 1 || requirement.RuleId == Id) throw new ArgumentException("Invalid rule requirement.");
        }
        public OperationRule Copy()
        {
            var result = (OperationRule)MemberwiseClone();
            result.Costs = Array.ConvertAll(Costs, c => new ResourceCost { Key = c.Key, Amount = c.Amount });
            result.Requirements = Array.ConvertAll(Requirements, r => new LevelRequirement { RuleId = r.RuleId, Level = r.Level });
            return result;
        }
    }
    [Serializable] public sealed class RuleCatalog { public OperationRule[] Rules; }
    [Serializable] public sealed class LevelState { public int RuleId, Level; }
    [Serializable] public sealed class QueuedAction
    {
        public TimedOperation Operation;
        public int TargetLevel, Quantity;
        public ResourceCost[] PaidCosts;
        public QueuedAction Copy() => new QueuedAction
        {
            Operation = Operation.Copy(), TargetLevel = TargetLevel, Quantity = Quantity,
            PaidCosts = Array.ConvertAll(PaidCosts, c => new ResourceCost { Key = c.Key, Amount = c.Amount })
        };
    }
    [Serializable] public sealed class SettlementSnapshot
    {
        public int Version = 1;
        public long Revision;
        public BalanceSnapshot Balances;
        public LevelState[] Levels;
        public QueuedAction[] Actions;
    }
}
