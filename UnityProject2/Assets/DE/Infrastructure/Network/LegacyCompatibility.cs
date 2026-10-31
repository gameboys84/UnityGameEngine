using System;
using Scpp;

// The generated DE protocol keeps its original global type names and source bytes.
// InjectFix itself is not part of the transport; this interface preserves its existing codec hook.
public interface IStubNetworkMessage
{
    void Decode(SPack pack);
    void Encode(SPack pack);
}

// Codec compatibility logging only. Never log HTTP bodies, LOGIN_REQ or token payloads.
public static class DLog
{
    [ThreadStatic] internal static bool StrictCodecRead;
    public static event Action<string> CodecError;
    public static void Error(string message) { if (StrictCodecRead) throw new System.IO.InvalidDataException("Original SPack failed to read a bounded protocol field."); CodecError?.Invoke(message); }
    public static void Error(string format, params object[] arguments) { if (StrictCodecRead) throw new System.IO.InvalidDataException("Original SPack failed to read a bounded protocol field."); CodecError?.Invoke(string.Format(format, arguments)); }
    public static void Warning(string format, params object[] arguments) { }
    public static void Log(string format, params object[] arguments) { }
}
