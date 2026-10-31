using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DE.Infrastructure.Network;
using NUnit.Framework;

namespace DE.Production.Tests
{
    // Real production ingress and Pump with recorded decoded packets, no network request.
    [Category("ProductionRecordedMessages")]
    public sealed class DeProductionIngressGenerationTests
    {
        private DeProductionConnection connection;
        private DeTcpSession transport;
        [SetUp]
        public void SetUp()
        {
            connection = DeProductionClientFactory.CreateDevelopment("de-rewrite-test-ingress-unit", "IOS_6900", "0.69.0");
            transport = new DeTcpSession();
            Set("transport", transport); Set("generation", 1L);
        }
        [TearDown] public void TearDown() { connection.Dispose(); }

        private void Set(string name, object value)
        {
            typeof(DeProductionConnection).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(connection, value);
        }
        private void Deliver(long generation, long time, DeTcpSession source = null)
        {
            var message = new Protocol.TimeNtfInfo { m_t = time };
            message.SetMessageType(Protocol.MsgType.TIME_NTF);
            var token = new TaskCompletionSource<Protocol.SessionTokenInfo>();
            var login = new TaskCompletionSource<Protocol.UserInfo>();
            typeof(DeProductionConnection).GetMethod("Receive", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(connection, new object[] { source ?? transport, generation, message, 12, token, login });
        }

        [Test]
        public void OldGenerationAndForeignTransportCannotEnterTheCurrentRawState()
        {
            Deliver(0, 100);
            using (var foreign = new DeTcpSession()) Deliver(1, 200, foreign);
            connection.Pump();
            Assert.That(connection.RawState.Count, Is.Zero);
            Assert.That(connection.RawState.History, Is.Empty);
        }

        [Test]
        public void QueuedPacketsAreRecheckedAgainstGenerationBeforeDispatch()
        {
            Deliver(1, 100);
            Set("generation", 2L);
            connection.Pump();
            Assert.That(connection.RawState.Count, Is.Zero);
            Assert.That(connection.Diagnostics.PendingMessages, Is.Zero);
        }

        [Test]
        public void FirstPacketOfANewGenerationClearsOldCachedNotifications()
        {
            Deliver(1, 100);
            connection.Pump();
            Assert.That(connection.RawState.Generation, Is.EqualTo(1));
            Set("generation", 2L);
            Deliver(2, 200);
            connection.Pump();
            Assert.That(connection.RawState.Generation, Is.EqualTo(2));
            Assert.That(connection.RawState.History.Length, Is.EqualTo(1));
            Assert.That(connection.RawState.GetLatest<Protocol.TimeNtfInfo>(Protocol.MsgType.TIME_NTF).m_t, Is.EqualTo(200));
        }

        [Test]
        public void WorkerIngressDoesNotInvokeUserCallbacksUntilCallerPumps()
        {
            var callerThread = Thread.CurrentThread.ManagedThreadId;
            var callbackThread = 0;
            connection.MessageReceived += _ => callbackThread = Thread.CurrentThread.ManagedThreadId;
            Task.Run(() => Deliver(1, 100)).GetAwaiter().GetResult();
            Assert.That(callbackThread, Is.Zero);
            connection.Pump();
            Assert.That(callbackThread, Is.EqualTo(callerThread));
        }

        [Test]
        public void ClosingTransportInvalidatesMessagesAlreadyWaitingForPump()
        {
            var callbacks = 0;
            connection.MessageReceived += _ => callbacks++;
            Deliver(1, 100);
            typeof(DeProductionConnection).GetMethod("CloseTransport", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(connection, null);
            connection.Pump();
            Assert.That(callbacks, Is.Zero, "Cancelled/failed sessions must not deliver queued state after close.");
            Assert.That(connection.RawState.Count, Is.Zero);
            Assert.That(connection.CurrentUser, Is.Null);
        }

        [Test]
        public void DisposalDropsQueuedAndLateMessagesWithoutCallbacks()
        {
            var callbacks = 0;
            connection.MessageReceived += _ => callbacks++;
            Deliver(1, 100);
            connection.Dispose();
            Deliver(1, 200);
            connection.Pump();
            Assert.That(callbacks, Is.Zero);
            Assert.That(connection.RawState.Count, Is.Zero);
            Assert.That(connection.Diagnostics.PendingMessages, Is.Zero);
            Assert.That(connection.CurrentUser, Is.Null);
        }

        [Test]
        public void CancelledHandshakeWaitCannotReportCompletedTaskAsSuccess()
        {
            using (var cancellation = new CancellationTokenSource())
            {
                cancellation.Cancel();
                var method = typeof(DeProductionConnection).GetMethod("AwaitWithTimeout", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(int));
                var pending = (Task<int>)method.Invoke(null, new object[] { Task.FromResult(1), 1000, cancellation.Token });
                Assert.Catch<OperationCanceledException>(() => pending.GetAwaiter().GetResult());
            }
        }
    }
}
