using System;

namespace DE.Domain
{
    public enum DeCommandKind
    {
        StartBuildingUpgrade, StartResearch, TrainTroops, CancelQueue,
        SpeedUpQueue, UseItem, ReadMail, ClaimMail, SendChat, CreateMarch, RecallMarch
    }

    public sealed class DeCommand
    {
        public DeCommandKind Kind { get; }
        public string TargetId { get; }
        public int Quantity { get; }
        public string RequestId { get; }
        public string Text { get; }
        public string SecondaryId { get; }
        public DeCommand(DeCommandKind kind, string targetId = "", int quantity = 1,
            string requestId = null, string text = "", string secondaryId = "")
        {
            Kind = kind; TargetId = targetId ?? ""; Quantity = quantity;
            RequestId = requestId ?? Guid.NewGuid().ToString("N");
            Text = text ?? ""; SecondaryId = secondaryId ?? "";
        }
        public bool HasSamePayload(DeCommand other)
        {
            return other != null && Kind == other.Kind && TargetId == other.TargetId &&
                Quantity == other.Quantity && Text == other.Text && SecondaryId == other.SecondaryId;
        }
    }

    public sealed class DeResult
    {
        public bool Success { get; }
        public bool IsDuplicate { get; }
        public string Code { get; }
        public string Message { get; }
        public DeResult(bool success, string code, string message, bool isDuplicate = false)
        { Success = success; Code = code ?? ""; Message = message ?? ""; IsDuplicate = isDuplicate; }
        public static DeResult Accepted(string message = "Command accepted by Mock authority.")
        { return new DeResult(true, "accepted", message); }
        public static DeResult Rejected(string code, string message)
        { return new DeResult(false, code, message); }
        public DeResult AsDuplicate()
        { return new DeResult(Success, Code, Message, true); }
    }

    public sealed class ResourceCost
    {
        public string Key { get; }
        public long Amount { get; }
        public ResourceCost(string key, long amount)
        { if (string.IsNullOrWhiteSpace(key) || amount < 0) throw new ArgumentException("Invalid resource cost."); Key = key; Amount = amount; }
    }

    public sealed class OperationPreview
    {
        private readonly ResourceCost[] costs;
        public bool CanExecute { get; }
        public string Code { get; }
        public string Message { get; }
        public long DurationMs { get; }
        public ResourceCost[] Costs => (ResourceCost[])costs.Clone();
        public OperationPreview(bool canExecute, string code, string message, long durationMs = 0, ResourceCost[] costs = null)
        { CanExecute = canExecute; Code = code; Message = message; DurationMs = durationMs; this.costs = costs == null ? new ResourceCost[0] : (ResourceCost[])costs.Clone(); }
    }
}
