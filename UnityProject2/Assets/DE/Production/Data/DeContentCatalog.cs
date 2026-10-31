using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameCore;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DE.Production.Data
{
    /// <summary>Loads genuine DE table assets through the framework; owns and releases each successful resource load.</summary>
    public sealed class DeContentCatalog : IDisposable
    {
        public const string Root = "Assets/AssetBundle/DE/Data/";
        private readonly Dictionary<string, JObject> tables = new Dictionary<string, JObject>(StringComparer.Ordinal);
        private readonly List<AssetLease<TextAsset>> leases = new List<AssetLease<TextAsset>>();
        private JObject manifest;
        private bool disposed;
        public int TableCount => (manifest?["tables"] as JArray)?.Count ?? 0;
        public int LanguageCount => (manifest?["languages"] as JArray)?.Count ?? 0;

        public async UniTask InitializeAsync(CancellationToken cancellationToken)
        {
            EnsureAlive();
            manifest = await ReadAsync("catalog.json", cancellationToken);
            if ((int?)manifest["format"] != 1 || (string)manifest["source"] != "DeadEmpire-DEV")
                throw new InvalidOperationException("DE content source identity is invalid.");
        }

        public async UniTask<JObject> LoadTableAsync(string name, CancellationToken cancellationToken)
        {
            EnsureAlive();
            if (manifest == null) throw new InvalidOperationException("Initialize the source catalog before requesting tables.");
            if (!IsDeclared("tables", name)) throw new KeyNotFoundException("Unknown DE source table: " + name);
            if (!tables.TryGetValue(name, out var table))
            {
                table = await ReadAsync("Tables/" + name + ".json", cancellationToken);
                tables[name] = table;
            }
            return (JObject)table.DeepClone();
        }

        public async UniTask<DeLocalization> LoadLanguageAsync(string language, CancellationToken cancellationToken)
        {
            EnsureAlive();
            if (!IsDeclared("languages", language)) language = "en";
            var words = await ReadAsync("Languages/" + language + ".json", cancellationToken);
            return new DeLocalization(language, words);
        }

        private bool IsDeclared(string group, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || manifest?[group] == null) return false;
            foreach (var item in manifest[group]) if ((string)item["name"] == name) return true;
            return false;
        }

        private async UniTask<JObject> ReadAsync(string relative, CancellationToken cancellationToken)
        {
            var lease = await new ResourceReference(Root + relative).LoadAsync<TextAsset>(cancellationToken);
            if (disposed) { lease.Dispose(); throw new ObjectDisposedException(nameof(DeContentCatalog)); }
            try { var value = JObject.Parse(lease.Asset.text); leases.Add(lease); return value; }
            catch { lease.Dispose(); throw; }
        }

        private void EnsureAlive() { if (disposed) throw new ObjectDisposedException(nameof(DeContentCatalog)); }
        public void Dispose() { if (disposed) return; disposed = true; foreach (var lease in leases) lease.Dispose(); leases.Clear(); tables.Clear(); manifest = null; }
    }

    public sealed class DeLocalization
    {
        private readonly JObject original;
        private readonly Dictionary<string, string> server = new Dictionary<string, string>(StringComparer.Ordinal);
        private readonly Dictionary<string, string> corrections = new Dictionary<string, string>(StringComparer.Ordinal);
        public string Language { get; }
        public DeLocalization(string language, JObject original) { Language = language; this.original = (JObject)(original ?? throw new ArgumentNullException(nameof(original))).DeepClone(); }
        public void SetServerText(string key, string value) { server[key] = value; }
        public void SetCorrection(string key, string value) { corrections[key] = value; }
        public void ClearServerOverrides() { server.Clear(); corrections.Clear(); }
        public string Get(string key, bool useOriginal = false)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;
            if (!useOriginal && server.TryGetValue(key, out var value)) return value;
            if (!useOriginal && corrections.TryGetValue(key, out value)) return value;
            var token = original[key + "_Zombies"] ?? original[key];
            return token == null ? "lc_error:" + key : token.Value<string>();
        }
    }
}
