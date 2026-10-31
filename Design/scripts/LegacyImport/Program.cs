using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using DE.Infrastructure;

internal static class Program
{
    private static string B64(string value) { return Convert.ToBase64String(Encoding.UTF8.GetBytes(value ?? "")); }
    private static string Value(JsonElement row, string key) { return row.TryGetProperty(key, out var value) ? value.ToString() : "0"; }
    private static string S(JsonElement row, string key) { return row.TryGetProperty(key, out var value) ? value.ToString() : ""; }
    private static void Main(string[] args)
    {
        if (args.Length < 2) throw new ArgumentException("Usage: LegacyImport <DE source root> <output directory>");
        string source = Path.GetFullPath(args[0]), output = Path.GetFullPath(args[1]);
        Directory.CreateDirectory(output);
        string aesSource = File.ReadAllText(Path.Combine(source, "Assets/T4F-BJ-Lib/Common/File/AES.cs"));
        string keyString = Regex.Match(aesSource, "return\\s+\"([^\"]+)\"").Groups[1].Value;
        string ivText = Regex.Match(aesSource, @"_key1\s*=\s*\{([^}]+)\}").Groups[1].Value;
        var iv = Regex.Matches(ivText, @"0x([0-9A-Fa-f]{2})").Cast<Match>().Select(m => byte.Parse(m.Groups[1].Value, NumberStyles.HexNumber)).ToArray();
        if (keyString.Length != 16 || iv.Length != 16) throw new InvalidDataException("Cannot identify source encryption parameters.");
        string packPath = Path.Combine(source, "Assets/StreamingAssets/GameData/gameData.pack");
        var rows = new List<string> { "# DE-LEGACY-RULES\t1", "# Source pack SHA256\t" + Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(packPath))).ToLowerInvariant() };
        using (var pack = new LegacyPackReader(File.OpenRead(packPath)))
        {
            var manifest = new List<object>();
            foreach (var table in new[] { "building_KKeys", "building_pos_KPos", "researchlab_KKeys", "training_KArmory", "items_KKeys" })
            {
                string json = pack.ReadEncryptedJson(table + ".bin", Encoding.UTF8.GetBytes(keyString), iv);
                using (var document = JsonDocument.Parse(json, new JsonDocumentOptions { AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip }))
                {
                    var allRows = document.RootElement.EnumerateObject().OrderBy(p => long.Parse(p.Name, CultureInfo.InvariantCulture)).ToArray();
                    File.WriteAllText(Path.Combine(output, table + ".json"), JsonSerializer.Serialize(document.RootElement, new JsonSerializerOptions { WriteIndented = false }), new UTF8Encoding(false));
                    foreach (var property in allRows)
                    {
                        var row = property.Value; var fields = new List<string>();
                        if (table == "building_KKeys")
                        {
                            fields.Add("B");
                            foreach (string field in new[] { "m_BUILDING_ID", "m_Type", "m_Level", "m_FoodReq", "m_EnergyReq", "m_OilReq", "m_SteelReq", "m_CashReq", "m_RareEarthReq", "m_BuildTime", "m_PreBuild1Type", "m_PreBuild1Level", "m_PreBuild2Type", "m_PreBuild2Level", "m_PreBuild3Type", "m_PreBuild3Level", "m_Item1Req", "m_Item1ReqCnt", "m_Item2Req", "m_Item2ReqCnt" }) fields.Add(Value(row, field));
                            fields.Add(B64(S(row, "m_PreBuildCond"))); fields.Add(B64(S(row, "m_ItemReqetc")));
                        }
                        else if (table == "researchlab_KKeys")
                        {
                            fields.Add("R");
                            foreach (string field in new[] { "m_TECH_ID", "m_Type", "m_Level", "m_MaxLevel", "m_BuildLevelReq", "m_FoodReq", "m_EnergyReq", "m_OilReq", "m_SteelReq", "m_CashReq", "m_RareEarthReq", "m_D2oReq", "m_TechTime", "m_PreTech1ID", "m_PreTech2ID", "m_PreTech3ID", "m_PreTech4ID", "m_PreTech5ID", "m_Item1Req", "m_Item1ReqCnt" }) fields.Add(Value(row, field));
                            fields.Add(B64(S(row, "m_ItemReqetc")));
                        }
                        else if (table == "training_KArmory")
                        {
                            fields.Add("T");
                            foreach (string field in new[] { "m_ARMORY_ID", "m_AtkType", "m_Level", "m_FoodReq", "m_EnergyReq", "m_OilReq", "m_SteelReq", "m_MoneyReq", "m_TrainTime", "m_PreBuildType", "m_PreBuildLevel", "m_PreResearchType", "m_BuildQueue" }) fields.Add(Value(row, field));
                            fields.Add(B64(S(row, "m_LC_N")));
                        }
                        else if (table == "building_pos_KPos")
                        {
                            fields.Add("P"); foreach (string field in new[] { "m_POS_ID", "m_Type", "m_buildID", "m_UnlockHQLevel", "m_available" }) fields.Add(Value(row, field));
                        }
                        else
                        {
                            fields.Add("I"); foreach (string field in new[] { "m_ID", "m_SubType", "m_ItemSubID", "m_Use", "m_UseNumLimit", "m_OpType", "m_OpValue", "m_Duration", "m_uselevel" }) fields.Add(Value(row, field));
                            fields.Add(B64(S(row, "m_LC_T"))); fields.Add(B64(S(row, "m_Pic"))); fields.Add(B64(S(row, "m_Params")));
                        }
                        rows.Add(string.Join("\t", fields));
                    }
                    manifest.Add(new { table, count = allRows.Length, sha256 = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(json))).ToLowerInvariant() });
                    Console.WriteLine(table + ": " + allRows.Length + " source rows");
                }
            }
            File.WriteAllText(Path.Combine(output, "LegacyRules.txt"), string.Join("\n", rows) + "\n", new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(output, "SourceManifest.json"), JsonSerializer.Serialize(new { format = 1, source = "DeadEmpire-DEV/Assets/StreamingAssets/GameData/gameData.pack", tables = manifest, note = "Read-only extraction. Static base values, not buff-adjusted costs or authoritative settlement." }, new JsonSerializerOptions { WriteIndented = true }));
        }
        ExportProtocol(source, output);
    }
    private static void ExportProtocol(string source, string output)
    {
        string net = Path.Combine(source, "Assets/Scripts/Net");
        string enumText = File.ReadAllText(Path.Combine(net, "ProtocolTypeEnum.cs"));
        var mapping = new Dictionary<string, string>(StringComparer.Ordinal);
        string creators = File.ReadAllText(Path.Combine(net, "ProtocolCreator.cs"));
        foreach (Match match in Regex.Matches(creators, @"case\s+MsgType\.(\w+):\s*msg\s*=\s*new\s+(\w+)\(")) mapping[match.Groups[1].Value] = match.Groups[2].Value;
        var schema = new Dictionary<string, object>(StringComparer.Ordinal);
        for (int i = 0; i <= 5; i++)
        {
            string text = File.ReadAllText(Path.Combine(net, "ProtocolDefine" + i + ".cs"));
            foreach (Match match in Regex.Matches(text, @"public\s+partial\s+class\s+(\w+)\s*:\s*NetworkMessage\s*\{([\s\S]*?)public\s+override\s+void\s+Decode"))
            {
                var fields = new List<object>();
                foreach (Match field in Regex.Matches(match.Groups[2].Value, @"public\s+(?!static)([\w<> ,\[\]]+)\s+(m_\w+)\s*;")) fields.Add(new { name = field.Groups[2].Value, type = field.Groups[1].Value.Trim() });
                schema[match.Groups[1].Value] = fields;
            }
        }
        var messages = new List<object>(); var protocolRows = new List<string> { "# DE-LEGACY-PROTOCOL\t1" };
        foreach (Match match in Regex.Matches(enumText, @"^\s*(\w+)\s*=\s*(\d+)\s*,?\s*$", RegexOptions.Multiline))
        {
            string name = match.Groups[1].Value; int id = int.Parse(match.Groups[2].Value); mapping.TryGetValue(name, out string payload);
            messages.Add(new { id, name, payload = payload ?? "" }); protocolRows.Add(id + "\t" + name + "\t" + (payload ?? ""));
        }
        string version = Regex.Match(enumText, @"public\s+static\s+int\s+Ver\s*=\s*(\d+)").Groups[1].Value;
        File.WriteAllText(Path.Combine(output, "LegacyProtocol.json"), JsonSerializer.Serialize(new { version, messages, structures = schema, wireCodecImplemented = false, note = "Declarative schema extracted from generated source. No authentication, SPack, encryption/compression or live-server compatibility claimed." }));
        File.WriteAllText(Path.Combine(output, "LegacyProtocol.txt"), string.Join("\n", protocolRows) + "\n", new UTF8Encoding(false));
        Console.WriteLine("Protocol v" + version + ": " + messages.Count + " messages, " + schema.Count + " payload structures (schema only)");
    }
}
