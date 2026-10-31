using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using DE.Production.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UnityEngine;

namespace DE.Production.Tests
{
    [Category("ProductionSourceData")]
    public sealed class DeRealContentTests
    {
        private static string DataRoot => Path.Combine(Environment.GetEnvironmentVariable("DE_PROJECT_ASSETS") ?? Application.dataPath, "AssetBundle/DE/Data");
        private static JObject Catalog => JObject.Parse(File.ReadAllText(Path.Combine(DataRoot, "catalog.json")));

        private static string Hash(string path)
        {
            using (var stream = File.OpenRead(path))
            using (var sha = SHA256.Create())
                return BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
        }

        [Test]
        public void GenuineCatalogDeclaresAll374TablesAnd19UniqueLanguages()
        {
            var catalog = Catalog;
            Assert.That((int)catalog["format"], Is.EqualTo(1));
            Assert.That((string)catalog["source"], Is.EqualTo("DeadEmpire-DEV"));
            var tables = (JArray)catalog["tables"];
            var languages = (JArray)catalog["languages"];
            Assert.That(tables.Count, Is.EqualTo(374));
            Assert.That(languages.Count, Is.EqualTo(19));
            Assert.That(tables.Select(value => (string)value["name"]).Distinct().Count(), Is.EqualTo(374));
            Assert.That(languages.Select(value => (string)value["name"]), Is.EquivalentTo(new[]
                { "ar", "cn", "de", "en", "fa", "fr", "id", "it", "jp", "kr", "nl", "pls", "po", "ro", "ru", "sp", "thai", "tr", "zh" }));
            Assert.That(tables.Select(value => (string)value["name"]), Does.Contain("building_KKeys"));
            Assert.That(tables.Select(value => (string)value["name"]), Does.Contain("researchlab_KKeys"));
            Assert.That(tables.Select(value => (string)value["name"]), Does.Contain("training_KArmory"));
        }

        [Test]
        public void SourcePackFingerprintsMatchTheAuthoritativeReadOnlyDEFiles()
        {
            var source = Environment.GetEnvironmentVariable("DE_SOURCE_ROOT") ?? "E:/TAP/DE/DeadEmpire-DEV";
            var catalog = Catalog;
            var game = Path.Combine(source, "Assets/StreamingAssets/GameData/gameData.pack");
            var localization = Path.Combine(source, "Assets/StreamingAssets/GameData/loc.pack");
            Assert.That(File.Exists(game) && File.Exists(localization), Is.True,
                "Set DE_SOURCE_ROOT to the authoritative original DE checkout; source provenance must not be silently skipped.");
            Assert.That(Hash(game), Is.EqualTo((string)catalog["gameDataSha256"]));
            Assert.That(Hash(localization), Is.EqualTo((string)catalog["localizationSha256"]));
        }

        [Test]
        public void EveryImportedTableAndLanguageMatchesItsDeclaredDigestAndRowCount()
        {
            var catalog = Catalog;
            foreach (var group in new[] { new[] { "tables", "Tables" }, new[] { "languages", "Languages" } })
            foreach (var entry in catalog[group[0]])
            {
                var name = (string)entry["name"];
                Assert.That(name, Does.Not.Contain("/"));
                Assert.That(name, Does.Not.Contain("\\"));
                var file = Path.Combine(DataRoot, group[1], name + ".json");
                Assert.That(File.Exists(file), Is.True, name);
                Assert.That(Hash(file), Is.EqualTo((string)entry["sha256"]), name);
                // The source JSON contains repeated root keys in ten tables. Manifest count is raw
                // properties, whereas the original Newtonsoft Dictionary and new JObject retain the last value.
                var text = File.ReadAllText(file);
                var rawProperties = 0;
                using (var reader = new JsonTextReader(new StringReader(text)))
                    while (reader.Read()) if (reader.TokenType == JsonToken.PropertyName && reader.Depth == 1) rawProperties++;
                Assert.That(rawProperties, Is.EqualTo((int)entry["count"]), name);
                var uniqueCount = JObject.Parse(text).Count;
                Assert.That(uniqueCount, Is.LessThanOrEqualTo(rawProperties), name);
                if (group[0] == "tables")
                {
                    Assert.That((int?)entry["rawEntryCount"], Is.EqualTo(rawProperties), name);
                    Assert.That((int?)entry["uniqueKeyCount"], Is.EqualTo(uniqueCount), name);
                    Assert.That((string)entry["duplicatePolicy"], Is.EqualTo("last-value-wins"), name);
                }
            }
        }

        [Test]
        public void EnglishAndChineseSourceTextAreDistinctAndNotPlaceholderDictionaries()
        {
            var english = JObject.Parse(File.ReadAllText(Path.Combine(DataRoot, "Languages/en.json")));
            var chinese = JObject.Parse(File.ReadAllText(Path.Combine(DataRoot, "Languages/cn.json")));
            Assert.That(english.Count, Is.EqualTo(29368));
            Assert.That(chinese.Count, Is.EqualTo(29368));
            Assert.That(english.Properties().Any(value => chinese[value.Name] != null &&
                value.Value.Type == JTokenType.String && ((string)value.Value).Length > 0 &&
                (string)value.Value != (string)chinese[value.Name]), Is.True);
        }

        [Test]
        public void CatalogRejectsTableAccessBeforeInitialization()
        {
            using (var catalog = new DeContentCatalog())
                Assert.Throws<InvalidOperationException>(() => catalog.LoadTableAsync("building_KKeys", default).GetAwaiter().GetResult());
        }

        [Test]
        public void RepeatedSourceKeysFollowTheOriginalNewtonsoftLastValueWinsPolicy()
        {
            const string repeated = "{\"key\":{\"value\":1},\"key\":{\"value\":2}}";
            var sourceDictionary = JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, JObject>>(repeated);
            var importedObject = JObject.Parse(repeated);
            Assert.That(sourceDictionary.Count, Is.EqualTo(1));
            Assert.That((int)sourceDictionary["key"]["value"], Is.EqualTo(2));
            Assert.That((int)importedObject["key"]["value"], Is.EqualTo(2));
        }
    }

    [Category("ProductionLocalization")]
    public sealed class DeLocalizationSourceContractTests
    {
        [Test]
        public void PriorityIsServerThenCorrectionThenZombieThenBase()
        {
            var words = new JObject { ["LC_key"] = "base", ["LC_key_Zombies"] = "zombie" };
            var localization = new DeLocalization("en", words);
            Assert.That(localization.Get("LC_key"), Is.EqualTo("zombie"));
            localization.SetCorrection("LC_key", "correction");
            Assert.That(localization.Get("LC_key"), Is.EqualTo("correction"));
            localization.SetServerText("LC_key", "server");
            Assert.That(localization.Get("LC_key"), Is.EqualTo("server"));
            Assert.That(localization.Get("LC_key", true), Is.EqualTo("zombie"));
        }

        [Test]
        public void PresentEmptyTranslationsNeverFallBackToAnotherPriorityOrEnglish()
        {
            var localization = new DeLocalization("cn", new JObject { ["LC_key"] = "base", ["LC_key_Zombies"] = "" });
            Assert.That(localization.Get("LC_key"), Is.EqualTo(""));
            localization.SetCorrection("LC_key", "correction");
            localization.SetServerText("LC_key", "");
            Assert.That(localization.Get("LC_key"), Is.EqualTo(""));
            localization.ClearServerOverrides();
            localization.SetCorrection("LC_key", "");
            Assert.That(localization.Get("LC_key"), Is.EqualTo(""));
        }

        [Test]
        public void ClearingAccountOverridesRemovesBothServerAndCorrectionLayers()
        {
            var localization = new DeLocalization("en", new JObject { ["LC_key"] = "original" });
            localization.SetServerText("LC_key", "account-a");
            localization.SetCorrection("LC_key", "old-correction");
            localization.ClearServerOverrides();
            Assert.That(localization.Get("LC_key"), Is.EqualTo("original"));
            localization.SetCorrection("LC_key", "account-b-correction");
            Assert.That(localization.Get("LC_key"), Is.EqualTo("account-b-correction"));
        }

        [Test]
        public void ANewLanguageCannotRetainOldLanguageOverridesOrMutatedInput()
        {
            var englishWords = new JObject { ["LC_key"] = "English" };
            var english = new DeLocalization("en", englishWords);
            englishWords["LC_key"] = "mutated";
            english.SetServerText("LC_key", "account-a server");
            var chinese = new DeLocalization("cn", new JObject { ["LC_key"] = "中文" });
            Assert.That(chinese.Language, Is.EqualTo("cn"));
            Assert.That(chinese.Get("LC_key"), Is.EqualTo("中文"));
            english.ClearServerOverrides();
            Assert.That(english.Get("LC_key"), Is.EqualTo("English"));
        }

        [Test]
        public void MissingAndEmptyKeysFollowOriginalStringManagerContract()
        {
            var localization = new DeLocalization("en", new JObject());
            Assert.That(localization.Get("LC_missing"), Is.EqualTo("lc_error:LC_missing"));
            Assert.That(localization.Get(null), Is.EqualTo(""));
            Assert.That(localization.Get(""), Is.EqualTo(""));
        }
    }
}
