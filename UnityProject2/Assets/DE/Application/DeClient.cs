using System;
using DE.Domain;

namespace DE.Application
{
    public interface IDeSession : IDisposable
    {
        string Label { get; }
        event Action<DeSnapshot> SnapshotReceived;
        void Open(string accountId, long generation);
        DeResult Send(DeCommand command);
        void Tick(double deltaSeconds);
        void Close();
    }
    public interface IDeClient : IDisposable
    {
        DeSnapshot Snapshot { get; }
        string TransportLabel { get; }
        event Action<DeSnapshot> Changed;
        DeResult Execute(DeCommand command);
        void Tick(double deltaSeconds);
        void SwitchAccount(string accountId);
    }
    public sealed class DeClient : IDeClient
    {
        private readonly IDeSession session;
        private bool disposed;
        private long generation;
        public DeSnapshot Snapshot { get; private set; }
        public string TransportLabel => session.Label;
        public event Action<DeSnapshot> Changed;
        public DeClient(IDeSession session, string accountId)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
            session.SnapshotReceived += OnSnapshot;
            SwitchAccount(accountId);
        }
        public void SwitchAccount(string accountId)
        {
            EnsureAlive();
            if (string.IsNullOrWhiteSpace(accountId) || accountId.Length > 128) throw new ArgumentException("A valid account id is required.");
            generation = checked(generation + 1);
            // Change the rejection boundary before closing the old transport; a late callback cannot repopulate old data.
            Snapshot = new DeSnapshot(accountId, generation, 0, 0);
            session.Close();
            Changed?.Invoke(Snapshot);
            session.Open(accountId, generation);
        }
        public bool ApplySnapshot(DeSnapshot snapshot)
        {
            if (disposed || snapshot == null || Snapshot == null ||
                snapshot.AccountId != Snapshot.AccountId || snapshot.SessionGeneration != generation ||
                snapshot.Revision <= Snapshot.Revision || snapshot.ServerTimeMs < Snapshot.ServerTimeMs) return false;
            Snapshot = snapshot;
            Changed?.Invoke(snapshot);
            return true;
        }
        private void OnSnapshot(DeSnapshot snapshot) { ApplySnapshot(snapshot); }
        public DeResult Execute(DeCommand command)
        {
            EnsureAlive();
            if (command == null || string.IsNullOrWhiteSpace(command.RequestId)) return DeResult.Rejected("invalid_request", "A command and request id are required.");
            if (command.RequestId.Length > 128) return DeResult.Rejected("invalid_request", "Request id is too long.");
            return session.Send(command);
        }
        public void Tick(double deltaSeconds)
        {
            EnsureAlive();
            if (double.IsNaN(deltaSeconds) || double.IsInfinity(deltaSeconds) || deltaSeconds < 0 || deltaSeconds > 86400)
                throw new ArgumentOutOfRangeException(nameof(deltaSeconds));
            // A transport pump only. Client code never completes queues or grants rewards based on elapsed time.
            session.Tick(deltaSeconds);
        }
        public void Dispose()
        {
            if (disposed) return;
            disposed = true; session.SnapshotReceived -= OnSnapshot; session.Close(); session.Dispose(); Changed = null;
        }
        private void EnsureAlive() { if (disposed) throw new ObjectDisposedException(nameof(DeClient)); }
    }
}
