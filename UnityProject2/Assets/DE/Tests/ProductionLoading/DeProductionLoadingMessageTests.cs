using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DE.Infrastructure.Network;
using DE.Production.Runtime;
using NUnit.Framework;

namespace DE.Production.Tests
{
    // Recorded decoded protocol input only. Reflection reaches the production ingress without
    // opening a service connection or replacing its business code. This is not live acceptance.
    [Category("ProductionRecordedMessages")]
    public sealed class DeProductionLoadingMessageTests
    {
        private DeProductionConnection connection;
        private ProductionLoadingCoordinator loading;
        [SetUp]
        public void SetUp()
        {
            connection = DeProductionClientFactory.CreateDevelopment("de-rewrite-test-loading-unit", "IOS_6900", "0.69.0");
            loading = new ProductionLoadingCoordinator(connection);
            Field("running").SetValue(loading, true);
        }
        [TearDown] public void TearDown() { loading.Dispose(); connection.Dispose(); }

        private static FieldInfo Field(string name)
        {
            var field = typeof(ProductionLoadingCoordinator).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(field, Is.Not.Null, "Recorded-input adapter needs updating: " + name);
            return field;
        }
        private void Input(Protocol.MsgType type, NetworkMessage message, int node = 0)
        {
            message.SetMessageType(type); message.m_nodId = node;
            typeof(ProductionLoadingCoordinator).GetMethod("Observe", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(loading, new object[] { message });
        }
        private Task WaitFor(Func<bool> predicate, CancellationToken token)
        {
            return (Task)typeof(ProductionLoadingCoordinator).GetMethod("Until", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(loading, new object[] { predicate, token });
        }

        [Test]
        public void RepeatedTimeNotificationCountsOneMilestoneAndNeverClaimsCityReady()
        {
            Input(Protocol.MsgType.TIME_NTF, new Protocol.TimeNtfInfo { m_t = 123456 });
            Input(Protocol.MsgType.TIME_NTF, new Protocol.TimeNtfInfo { m_t = 123457 });
            Assert.That(loading.ServerTime, Is.EqualTo(123457));
            Assert.That(loading.Progress.Completed, Is.EqualTo(1));
            Assert.That(loading.Progress.InitialDataReceived, Is.False);
            Assert.That(loading.Progress.Stage, Is.Not.EqualTo("CityReady"));
        }

        [Test]
        public void ForeignNodeCannotSatisfyHomeTimeOrResourceMilestones()
        {
            Input(Protocol.MsgType.TIME_NTF, new Protocol.TimeNtfInfo { m_t = 123456 }, 51);
            Input(Protocol.MsgType.RES_NTF, new Protocol.ResInfo(), 51);
            Assert.That(loading.Progress.Completed, Is.Zero);
            Assert.That(loading.Resources, Is.Null);
            Assert.That(loading.ServerTime, Is.Zero);
        }

        [Test]
        public void OnlyTheExactBlacklistKeyCompletesDailyAllianceClientData()
        {
            Input(Protocol.MsgType.CLIENT_DATA_LOAD_ACK, new Protocol.ClientDataInfo { m_key = "another-key", m_value = "unrelated" });
            Assert.That(loading.Progress.Completed, Is.Zero);
            Input(Protocol.MsgType.CLIENT_DATA_LOAD_ACK, new Protocol.ClientDataInfo { m_key = "SaveBlackListData", m_value = "real-saved-value" });
            Assert.That(loading.Progress.Completed, Is.EqualTo(1));
            Assert.That(loading.BlacklistSave, Is.EqualTo("real-saved-value"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("null")]
        [TestCase("   ")]
        public void SourceCompatibleEmptyTutorialSaveCreatesANewUnfinishedTutorial(string data)
        {
            Input(Protocol.MsgType.CLIENT_LOAD_ACK, new Protocol.ClientSaveInfo { m_data = data });
            Assert.That(Field("failure").GetValue(loading), Is.Null);
            Assert.That(loading.TutorialSave, Is.Not.Null);
            Assert.That((int)loading.TutorialSave["order"], Is.EqualTo(1));
            Assert.That((int)loading.TutorialSave["step"], Is.Zero);
            Assert.That((int)loading.TutorialSave["tutorialVer"], Is.EqualTo(3));
            Assert.That((bool?)loading.TutorialSave["isStepComplete"] ?? false, Is.False);
        }

        [Test]
        public void UnrelatedAcknowledgementsDoNotFailLoadingButNegativeMatchedCodesDo()
        {
            ((HashSet<Protocol.MsgType>)Field("sent").GetValue(loading)).Add(Protocol.MsgType.CONST_REQ);
            Input(Protocol.MsgType.COMMON_ACK, new Protocol.CommonAckInfo { m_api = (short)Protocol.MsgType.HEART_BEAT_REQ, m_code = -5 });
            Assert.That(Field("failure").GetValue(loading), Is.Null);
            Input(Protocol.MsgType.COMMON_ACK, new Protocol.CommonAckInfo { m_api = (short)Protocol.MsgType.CONST_REQ, m_code = -5 });
            Assert.That(Field("failure").GetValue(loading), Is.Not.Null);
            Assert.That(loading.Progress.InitialDataReceived, Is.False);
        }

        [Test]
        public void ASatisfiedPredicateCannotHideAnAlreadyRecordedServerFailure()
        {
            var expected = new InvalidOperationException("Recorded rejection from original server API");
            Field("failure").SetValue(loading, expected);
            var actual = Assert.Throws<InvalidOperationException>(() => WaitFor(() => true, CancellationToken.None).GetAwaiter().GetResult());
            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void ASatisfiedPredicateCannotHideCancellation()
        {
            using (var cancellation = new CancellationTokenSource())
            {
                cancellation.Cancel();
                Assert.Catch<OperationCanceledException>(() => WaitFor(() => true, cancellation.Token).GetAwaiter().GetResult());
            }
        }

        [Test]
        public void WrongAllianceCannotSatisfyOwnAllianceMembership()
        {
            var user = new Protocol.UserInfo { m_alliance = new Protocol.UserAllianceBrief { m_id = 42 } };
            typeof(DeProductionConnection).GetProperty("CurrentUser").SetValue(connection, user);
            Input(Protocol.MsgType.ALLIANCE_MEMBER_ACK, new Protocol.AllianceMemberAckInfo { m_brief = new Protocol.AllianceBriefInfo { m_alliance_id = 43 } });
            Assert.That(loading.Progress.Completed, Is.Zero);
            Input(Protocol.MsgType.ALLIANCE_MEMBER_ACK, new Protocol.AllianceMemberAckInfo { m_brief = new Protocol.AllianceBriefInfo { m_alliance_id = 42 } });
            Assert.That(loading.Progress.Completed, Is.EqualTo(1));
        }
    }
}
