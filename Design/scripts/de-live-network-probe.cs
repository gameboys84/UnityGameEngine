// UniCli Eval body. Uses a dedicated new development identity; never prints credentials or packet contents.
var connection = DE.Infrastructure.Network.DeProductionClientFactory.CreateDevelopment(
    "de-rewrite-test-" + System.Guid.NewGuid().ToString("N"), "IOS_6900", "0.69.0");
var phases = new System.Collections.Generic.List<string>();
connection.StatusChanged += status => phases.Add(status.Phase.ToString());
try
{
    var start = connection.BeginSessionAsync(cancellationToken);
    var deadline = System.DateTime.UtcNow.AddSeconds(90);
    while (!start.IsCompleted && System.DateTime.UtcNow < deadline)
    {
        cancellationToken.ThrowIfCancellationRequested();
        connection.Pump();
        await System.Threading.Tasks.Task.Delay(20, cancellationToken);
    }
    if (!start.IsCompleted) return new { success = false, phase = connection.Status.Phase.ToString(), error = "probe_timeout", phases = phases.ToArray() };
    await start;
    connection.Pump();
    var diagnostics = connection.Diagnostics;
    return new { success = connection.Status.IsLoggedIn && connection.CurrentUser != null,
        phase = connection.Status.Phase.ToString(), protocolVersion = diagnostics.ProtocolVersion,
        encrypted = diagnostics.EncryptionActive, receivedPackets = diagnostics.ReceivedPackets,
        sentPackets = diagnostics.SentPackets, cachedMessageCount = connection.RawState.Count,
        phases = phases.ToArray(), cityReady = false };
}
catch (System.Exception error)
{
    connection.Pump();
    return new { success = false, phase = connection.Status.Phase.ToString(), errorType = error.GetType().Name,
        safeError = connection.Status.Message, code = connection.Status.ErrorCode, phases = phases.ToArray(), cityReady = false };
}
finally { connection.Dispose(); }
