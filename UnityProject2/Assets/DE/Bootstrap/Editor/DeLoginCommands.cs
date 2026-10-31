using System;
using System.Threading;
using System.Threading.Tasks;
using DE.Presentation.LegacyUI;
using DE.Production.Runtime;
using UniCli.Protocol;
using UniCli.Server.Editor.Handlers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DE.Bootstrap.Editor
{
    [Serializable]
    public sealed class DeLoginStatus
    {
        public bool isPlaying, isCompiling, compilationFailed, isLoginComplete, isReady, loadingVisible, failureDialogVisible;
        public string scene, phase, failure, networkPhase, lastHttpSummary;
        public string[] httpAttempts;
        public bool encryptionActive, validatedUserPresent, currentGenerationMatches;
        public string sampledAtUtc;
        public string[] receivedMessageTypes, commonAcknowledgements;
        public bool certificatePolicyAttached;
        public string certificatePolicy, lastSslPolicyErrors, lastCertificateDecision;
        public int certificateValidationCount, certificateCompatibilityCount, certificateRejectionCount;
        public long receivedPackets, sentPackets;
        public int protocolVersion;
    }

    public sealed class DeLoginStatusCommand : CommandHandler<Unit, DeLoginStatus>
    {
        public override string CommandName => "DE.Login.Status";
        public override string Description => "Read the genuine DE login stage and redacted wire diagnostics; no credentials or account payloads.";
        protected override ValueTask<DeLoginStatus> ExecuteAsync(Unit request, CancellationToken token)
        {
            var runtime = DeProductionRuntimeHost.Current;
            var loading = UnityEngine.Object.FindObjectOfType<ProductionLoadingView>();
            var diagnostics = runtime?.Connection?.Diagnostics;
            return new ValueTask<DeLoginStatus>(new DeLoginStatus
            {
                isPlaying = EditorApplication.isPlaying, isCompiling = EditorApplication.isCompiling,
                sampledAtUtc = DateTime.UtcNow.ToString("O"),
                compilationFailed = EditorUtility.scriptCompilationFailed,
                scene = SceneManager.GetActiveScene().path, phase = runtime?.Phase ?? "NotStarted",
                failure = runtime?.Failure ?? string.Empty, networkPhase = runtime?.Connection?.Status.Phase.ToString() ?? string.Empty,
                isLoginComplete = runtime?.IsLoginComplete == true, isReady = runtime?.IsReady == true,
                loadingVisible = loading != null && loading.gameObject.activeInHierarchy,
                failureDialogVisible = loading != null && loading.FailureDialogVisible,
                encryptionActive = diagnostics?.EncryptionActive == true,
                validatedUserPresent = runtime?.Connection?.Status.IsLoggedIn == true && runtime.Connection.CurrentUser?.m_id > 0,
                currentGenerationMatches = runtime?.Connection != null && runtime.Connection.RawState.Generation == runtime.Connection.CurrentSessionGeneration,
                receivedMessageTypes = runtime?.Connection == null ? Array.Empty<string>() : Array.ConvertAll(runtime.Connection.RawState.History, item => item.Type.ToString()),
                commonAcknowledgements = runtime?.Connection == null ? Array.Empty<string>() : Array.ConvertAll(
                    Array.FindAll(runtime.Connection.RawState.History, item => item.Message is Protocol.CommonAckInfo),
                    item => { var ack = (Protocol.CommonAckInfo)item.Message; return ((Protocol.MsgType)ack.m_api) + ":" + ack.m_code; }),
                receivedPackets = diagnostics?.ReceivedPackets ?? 0, sentPackets = diagnostics?.SentPackets ?? 0,
                protocolVersion = diagnostics?.ProtocolVersion ?? 72,
                lastHttpSummary = diagnostics?.LastHttpSummary ?? string.Empty,
                httpAttempts = diagnostics == null ? Array.Empty<string>() : Array.ConvertAll(diagnostics.HttpAttempts, item => item.SafeSummary),
                certificatePolicyAttached = diagnostics?.CertificatePolicyAttached == true,
                certificatePolicy = diagnostics?.CertificatePolicy ?? string.Empty,
                lastSslPolicyErrors = diagnostics?.LastSslPolicyErrors ?? string.Empty,
                lastCertificateDecision = diagnostics?.LastCertificateDecision ?? string.Empty,
                certificateValidationCount = diagnostics?.CertificateValidationCount ?? 0,
                certificateCompatibilityCount = diagnostics?.CertificateCompatibilityCount ?? 0,
                certificateRejectionCount = diagnostics?.CertificateRejectionCount ?? 0
            });
        }
    }

    public sealed class DeLoginRetryCommand : CommandHandler<Unit, Unit>
    {
        public override string CommandName => "DE.Login.Retry";
        public override string Description => "Retry the current genuine DE login without starting later gameplay loading.";
        protected override ValueTask<Unit> ExecuteAsync(Unit request, CancellationToken token)
        {
            var runtime = DeProductionRuntimeHost.Current;
            if (runtime == null) throw new InvalidOperationException("The DE production login scene is not running.");
            runtime.RetryLogin(); return new ValueTask<Unit>(Unit.Value);
        }
    }

    public sealed class DeLoginCancelCommand : CommandHandler<Unit, Unit>
    {
        public override string CommandName => "DE.Login.Cancel";
        public override string Description => "Cancel the current genuine DE connection attempt and invalidate its session.";
        protected override ValueTask<Unit> ExecuteAsync(Unit request, CancellationToken token)
        {
            var runtime = DeProductionRuntimeHost.Current;
            if (runtime == null) throw new InvalidOperationException("The DE production login scene is not running.");
            runtime.CancelLogin(); return new ValueTask<Unit>(Unit.Value);
        }
    }
}
