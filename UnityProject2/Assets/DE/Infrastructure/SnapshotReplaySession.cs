using System;
using System.Collections.Generic;
using DE.Application;
using DE.Domain;

namespace DE.Infrastructure
{
    // A read-only ingress for externally supplied snapshots. Does not claim to decode legacy protocol recordings.
    // Snapshots preserve their original account/generation/version so the real client reducer validates every response.
    public sealed class SnapshotReplaySession : IDeSession
    {
        private readonly Queue<DeSnapshot> incoming = new Queue<DeSnapshot>();
        private bool open, disposed;
        public string Label => "SNAPSHOT REPLAY - no command transport";
        public event Action<DeSnapshot> SnapshotReceived;
        public void Open(string accountId, long generation)
        { if (disposed) throw new ObjectDisposedException(nameof(SnapshotReplaySession)); open = true; }
        public void Enqueue(DeSnapshot snapshot)
        { if (disposed) throw new ObjectDisposedException(nameof(SnapshotReplaySession)); if (snapshot == null) throw new ArgumentNullException(nameof(snapshot)); incoming.Enqueue(snapshot); }
        public DeResult Send(DeCommand command) { return DeResult.Rejected("replay_read_only", "Recorded snapshots cannot execute commands."); }
        public void Tick(double deltaSeconds)
        {
            if (disposed) throw new ObjectDisposedException(nameof(SnapshotReplaySession));
            if (!open) return;
            int count = incoming.Count;
            for (int i = 0; i < count && open && incoming.Count > 0; i++) SnapshotReceived?.Invoke(incoming.Dequeue());
        }
        public void Close() { open = false; incoming.Clear(); }
        public void Dispose() { if (disposed) return; disposed = true; Close(); SnapshotReceived = null; }
    }
}
