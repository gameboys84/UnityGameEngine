using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DE.Infrastructure.Network;

internal static class MonoHttpNativeContract
{
    private static int passed;
    private static void Check(bool value, string label) { if (!value) throw new Exception(label); passed++; Console.WriteLine("PASS Mono native " + label); }
    private static string expectedHttpHash;
    private static void Main(string[] args)
    {
        if (args.Length != 1) throw new ArgumentException("Expected SHA256 of the Editor unityjit System.Net.Http.dll.");
        expectedHttpHash = args[0]; Run().GetAwaiter().GetResult();
    }
    private static async Task Run()
    {
        Check(Type.GetType("Mono.Runtime") != null, "running actual Unity-bundled Mono");
        string actualHttpPath = typeof(HttpClient).Assembly.Location;
        Check(string.Equals(Path.GetFullPath(actualHttpPath), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "System.Net.Http.dll"), StringComparison.OrdinalIgnoreCase), "loading the staged Editor HTTP implementation, not Mono default 4.5");
        using (var sha = SHA256.Create()) using (var file = File.OpenRead(actualHttpPath))
            Check(BitConverter.ToString(sha.ComputeHash(file)).Replace("-", "").Equals(expectedHttpHash, StringComparison.OrdinalIgnoreCase), "runtime HTTP implementation hash matches Editor unityjit library");
        var reserve = new TcpListener(IPAddress.Loopback, 0); reserve.Start(); int port = ((IPEndPoint)reserve.LocalEndpoint).Port; reserve.Stop();
        string prefix = "http://127.0.0.1:" + port + "/";
        var diagnostics = new List<ProductionHttpAttempt>();
        using (var timeout = new CancellationTokenSource(10000))
        using (var listener = new HttpListener())
        using (var client = new HttpClient(new HttpClientHandler { UseProxy = false, AllowAutoRedirect = false, AutomaticDecompression = DecompressionMethods.GZip }))
        {
            listener.Prefixes.Add(prefix); listener.Start();
            Task server = Task.Run(async () => {
                for (int i = 0; i < 3; i++)
                {
                    var context = await listener.GetContextAsync().ConfigureAwait(false);
                    if (i == 0 || i == 2)
                    {
                        Check(context.Request.HttpMethod == "GET" && !context.Request.HasEntityBody, "GET reaches HttpListener with no entity body");
                        using (var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
                            Check((await reader.ReadToEndAsync().ConfigureAwait(false)).Length == 0, "GET entity stream is empty");
                    }
                    else
                    {
                        Check(context.Request.HttpMethod == "POST" && context.Request.HasEntityBody, "POST retains original raw UTF8 entity");
                        using (var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
                            Check(await reader.ReadToEndAsync().ConfigureAwait(false) == "{\"locale\":\"中文\"}", "POST UTF8 bytes survive native Mono HTTP stack");
                        Check(string.IsNullOrEmpty(context.Request.ContentType), "POST has no invented Content-Type");
                    }
                    Check(context.Request.UserAgent == "BestHTTP", "source BestHTTP User-Agent reaches server");
                    byte[] body = Encoding.UTF8.GetBytes(i == 1 ? "post-ok" : "get-ok");
                    if (i == 2)
                    {
                        using (var compressed = new MemoryStream())
                        { using (var gzip = new GZipStream(compressed, CompressionMode.Compress, true)) gzip.Write(body, 0, body.Length); body = compressed.ToArray(); }
                        context.Response.AddHeader("Content-Encoding", "gzip");
                    }
                    context.Response.StatusCode = 200; context.Response.ContentLength64 = body.Length;
                    await context.Response.OutputStream.WriteAsync(body, 0, body.Length).ConfigureAwait(false); context.Response.Close();
                }
            });
            Type bootstrapType = typeof(DeProductionConnection).Assembly.GetType("DE.Infrastructure.Network.ProductionHttpBootstrap", true);
            object bootstrap = Activator.CreateInstance(bootstrapType, new object[] { client,
                new ProductionSessionOptions("de-rewrite-test-mono-native", "IOS_6900", "0.69.0"), new Action<ProductionHttpAttempt>(diagnostics.Add), null, null });
            MethodInfo getText = bootstrapType.GetMethod("GetTextAsync", BindingFlags.Instance | BindingFlags.NonPublic);
            string first = await Invoke(getText, bootstrap, new Uri(prefix + "startup"), null, timeout.Token).ConfigureAwait(false);
            Check(first == "get-ok", "actual production GetTextAsync GET succeeds under Mono");
            string second = await Invoke(getText, bootstrap, new Uri(prefix + "auth-contract"), "{\"locale\":\"中文\"}", timeout.Token).ConfigureAwait(false);
            Check(second == "post-ok", "actual production GetTextAsync POST succeeds under Mono");
            string third = await Invoke(getText, bootstrap, new Uri(prefix + "gzip"), null, timeout.Token).ConfigureAwait(false);
            Check(third == "get-ok", "native Mono gzip response is decoded before UTF8 conversion");
            await server.ConfigureAwait(false);
            Check(diagnostics.Count == 3 && diagnostics.TrueForAll(d => d.HttpStatus == 200 && d.Outcome == "Success"), "native diagnostics retain all HTTP 200 outcomes");

            using (var bad = new HttpRequestMessage(HttpMethod.Get, new Uri(prefix + "must-not-arrive")))
            {
                bad.Content = new ByteArrayContent(new byte[0]);
                bool rejected = false;
                try { using (var result = await client.SendAsync(bad, timeout.Token).ConfigureAwait(false)) { } }
                catch (Exception error)
                { for (Exception current = error; current != null; current = current.InnerException) if (current is ProtocolViolationException) rejected = true; }
                Check(rejected, "regression reproduction: GET with even empty Content is rejected by native Mono");
            }
            listener.Stop();
        }
        Console.WriteLine("MONO NATIVE HTTP " + passed + " assertions passed; loopback HttpListener only, no dev endpoint contacted.");
    }
    private static Task<string> Invoke(MethodInfo method, object instance, Uri uri, string body, CancellationToken cancellationToken)
    {
        return (Task<string>)method.Invoke(instance, new object[] { uri, body, cancellationToken,
            body == null ? ProductionConnectionPhase.FetchingStartup : ProductionConnectionPhase.Authenticating, 1, 1 });
    }
}
