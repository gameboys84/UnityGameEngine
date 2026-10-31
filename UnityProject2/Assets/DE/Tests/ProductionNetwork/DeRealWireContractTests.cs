using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using DE.Infrastructure.Network;
using NUnit.Framework;
using Scpp;
using UnityEngine;

namespace DE.Production.Tests
{
    [Category("ProductionWireContract")]
    public sealed class DeRealWireContractTests
    {
        [Test]
        public void ResourceReadRequestMatchesOriginalNetworkByteOrderGoldenFrame()
        {
            Assert.That(Protocol.Ver, Is.EqualTo(72));
            Assert.That((int)Protocol.MsgType.RES_REQ, Is.EqualTo(9));
            var body = DeWireCodec.EncodeBody(Protocol.MsgType.RES_REQ, null);
            Assert.That(body, Is.EqualTo(new byte[] { 0, 0, 0, 9 }));
            Assert.That(DeWireCodec.FrameBody(body), Is.EqualTo(new byte[] { 0, 4, 0, 0, 0, 9 }));
        }

        [Test]
        public void WrapperPayloadMatchesTheUnchangedGeneratedSPackEncoder()
        {
            DeWireCodec.Initialize();
            var message = new Protocol.ConstReq { m_keyword = "max_building_level" };
            var sourcePack = new SPack { buf = new byte[256], offset = 0 };
            message.Encode(sourcePack);
            var expected = new byte[4 + sourcePack.offset];
            expected[2] = 1; expected[3] = 54; // Source CONST_REQ=310, network byte order.
            Buffer.BlockCopy(sourcePack.buf, 0, expected, 4, sourcePack.offset);
            Assert.That(DeWireCodec.EncodeBody(Protocol.MsgType.CONST_REQ, message), Is.EqualTo(expected));
        }

        [Test]
        public void ExtendedLengthSentinelHasTheOriginalBoundaryAndFourByteLength()
        {
            var small = DeWireCodec.FrameBody(new byte[65534]);
            Assert.That(small.Length, Is.EqualTo(65536));
            Assert.That(small[0], Is.EqualTo(255)); Assert.That(small[1], Is.EqualTo(254));
            var extended = DeWireCodec.FrameBody(new byte[65535]);
            Assert.That(extended.Length, Is.EqualTo(65541));
            Assert.That(new ArraySegment<byte>(extended, 0, 6).ToArray(), Is.EqualTo(new byte[] { 255, 255, 0, 0, 255, 255 }));
        }

        [TestCase(0u, 0u, 0u)]
        [TestCase(0x01234567u, 0x89abcdefu, 0xbd2b1346u)]
        [TestCase(0xffffffffu, 0xffffffffu, 0xffffffffu)]
        [TestCase(0x80000000u, 1u, 0u)]
        public void PikeKeyMatchesFixedVectorsFromOriginalTokenBitSelection(uint first, uint second, uint expected)
        {
            Assert.That(DeWireCodec.DerivePikeKey(first, second), Is.EqualTo(expected));
        }

        [Test]
        public void KnownPayloadCannotBeAcceptedAsAHeaderOnlyDefaultObject()
        {
            var type = (ushort)Protocol.MsgType.TIME_NTF;
            var truncated = new byte[] { 0, 0, (byte)(type >> 8), (byte)type };
            Assert.Catch(() => { DeWireCodec.DecodeBody(truncated, out _); },
                "A missing TIME_NTF payload must never become a valid zero-time notification.");
        }

        [Test]
        public void FrameBoundsRejectNullShortAndOversizedBodies()
        {
            Assert.Throws<InvalidDataException>(() => DeWireCodec.FrameBody(null));
            Assert.Throws<InvalidDataException>(() => DeWireCodec.FrameBody(new byte[3]));
            Assert.Throws<InvalidDataException>(() => DeWireCodec.FrameBody(new byte[DeWireCodec.MaximumBodyLength + 1]));
        }

        [Test]
        public void DevelopmentOptionsCannotUseAnExistingAccountOrMismatchedVersionKey()
        {
            Assert.Throws<ArgumentException>(() => new ProductionSessionOptions("existing-account", "IOS_6900", "0.69.0"));
            Assert.Throws<ArgumentException>(() => new ProductionSessionOptions("de-rewrite-test-contract", "IOS_6800", "0.69.0"));
            Assert.Throws<ArgumentException>(() => new ProductionSessionOptions("de-rewrite-test-contract", "online", "0.69.0"));
            var options = new ProductionSessionOptions("de-rewrite-test-contract", "IOS_6900", "0.69.0");
            Assert.That(options.StartupVersionNumber, Is.EqualTo(6900));
            Assert.That(options.StartupUri.Host, Is.EqualTo("dev-global.de.t4f.cn"));
            Assert.That(options.StartupUri.AbsolutePath, Is.EqualTo("/urls/get/IOS_6900"));
        }

        [Test]
        public void ProtocolSPackPikeAndLz4SourceFilesRemainByteIdenticalToDE()
        {
            var original = Environment.GetEnvironmentVariable("DE_SOURCE_ROOT") ?? "E:/TAP/DE/DeadEmpire-DEV";
            var sourceNet = Path.Combine(original, "Assets/Scripts/Net");
            var imported = Path.Combine(Environment.GetEnvironmentVariable("DE_PROJECT_ASSETS") ?? EditorAssetsRoot(), "DE/Infrastructure/Network/Legacy");
            foreach (var name in new[] { "ProtocolDefine0.cs", "ProtocolDefine1.cs", "ProtocolDefine2.cs", "ProtocolDefine3.cs", "ProtocolDefine4.cs", "ProtocolDefine5.cs", "ProtocolTypeEnum.cs", "ProtocolMVC.cs", "ProtocolCreator.cs", "SPack.cs", "NetworkMessage.cs", "NetworkSerialization.cs" })
                AssertSame(Path.Combine(sourceNet, name), Path.Combine(imported, name));
            AssertSame(Path.Combine(sourceNet, "Pike/Pike.cs"), Path.Combine(imported, "Pike.cs"));
            foreach (var path in Directory.GetFiles(Path.Combine(original, "Assets/Scripts/Lib/LZ4"), "*.cs", SearchOption.AllDirectories))
                AssertSame(path, Path.Combine(imported, "LZ4", Path.GetFileName(path)));
        }

        private static void AssertSame(string source, string destination)
        {
            Assert.That(File.Exists(source), Is.True, source);
            Assert.That(File.Exists(destination), Is.True, destination);
            using (var sha = SHA256.Create())
            using (var sourceStream = File.OpenRead(source))
            using (var destinationStream = File.OpenRead(destination))
                Assert.That(sha.ComputeHash(destinationStream), Is.EqualTo(sha.ComputeHash(sourceStream)), destination);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private static string EditorAssetsRoot() { return Application.dataPath; }
    }
}
