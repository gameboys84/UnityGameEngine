using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.UI;
namespace GameRuntime
{
    public sealed class SlgFeatureView : MonoBehaviour
    {
        public Text title, result, statistics;
        public VirtualizedScrollList list;
        public Button close, primary, secondary;
        public Button[] sizes;
        public InputField chatInput;
        public bool Ready { get; private set; }
        public string Topic { get; private set; }
        private AssetLease<GameObject> lease;
        private PrefabInstancePool benchmarkPool;
        private readonly List<GameObject> batch = new List<GameObject>();
        private Transform parking;
        private int selected;
        private bool busy;
        private int lastLive = -1, lastCreated = -1;
        public void Initialize(string topic, Action onClose)
        {
            Topic = topic; title.text = topic.ToUpperInvariant();
            close.onClick.AddListener(() => { if (!busy) onClose(); });
            primary.GetComponentInChildren<Text>().text = topic == "List benchmark" ? "RAW CREATE / DESTROY" : topic == "Shop" ? "PURCHASE" : topic == "Mail" ? "CLAIM MAIL" : topic == "Chat" ? "SEND" : "APPLY ACTION";
            secondary.GetComponentInChildren<Text>().text = topic == "List benchmark" ? "POOL COLD / WARM" : "REFRESH DATA";
            primary.onClick.AddListener(() => RunPrimaryAsync().Forget(DemoUi.Report));
            secondary.onClick.AddListener(() => { if (topic == "List benchmark") BenchmarkAsync(true).Forget(DemoUi.Report); else Refresh(); });
            int[] counts = { 1000, 10000, 100000 };
            for (int i = 0; i < sizes.Length; i++) { int count = counts[i]; sizes[i].onClick.AddListener(() => { if (Ready && !busy) SetCount(count); }); }
            chatInput.gameObject.SetActive(topic == "Chat");
            LoadAsync().Forget(DemoUi.Report);
        }
        private async UniTask LoadAsync()
        {
            lease = await new ResourceReference("Assets/AssetBundle/UI/SLG/ListRow.prefab").LoadAsync<GameObject>(this.GetCancellationTokenOnDestroy());
            if (this == null) { lease.Dispose(); return; }
            list.Initialize(lease.Asset, BindRow); Ready = true;
            int count = Topic == "Role" ? 12 : Topic == "Guild" ? 200 : Topic == "Events" ? 50 : Topic == "Shop" ? 60 : Topic == "Mail" ? 10000 : Topic == "Chat" ? 5000 : 1000;
            SetCount(count); result.text = "FAKE DATA / SESSION ONLY\nSelect a row, then apply an action.";
        }
        public void SetCount(int count) { if (!Ready || busy) return; selected = 0; list.SetCount(count); lastLive = -1; }
        private void BindRow(GameObject go, int index) => go.GetComponent<DemoRow>().Bind(index, RowText(index), Select);
        private string RowText(int index)
        {
            switch (Topic)
            {
                case "Role": return $"Hero #{index + 1:D3}   LV {FakeSlgState.HeroLevel}   Power {1200 + index * 37}";
                case "Bag": return $"Item #{index + 1:D5}   Stack {1 + index % 99}   Quality {1 + index % 5}";
                case "Guild": return $"Member #{index + 1:D4}   Rank {1 + index % 5}   Contribution {index * 17}";
                case "Events": return $"Event #{index + 1:D3}   Progress {index % 10}/10   Reward {100 + index * 10}";
                case "Shop": return $"Offer #{index + 1:D3}   Price {20 + index * 5} coins   Stock 99";
                case "Mail": return $"Mail #{index + 1:D5}   {(FakeSlgState.ClaimedMail.Contains(index) ? "CLAIMED" : "REWARD READY")}";
                case "Chat": return index >= 5000 && index - 5000 < FakeSlgState.ChatMessages.Count ? "You: " + FakeSlgState.ChatMessages[index - 5000] : $"[Guild] Player #{index % 200:D3}: Rally message {index + 1}";
                default: return $"Row #{index + 1:D6}   Value {index * 13}   Pooled virtual cell";
            }
        }
        private void Select(int index) { selected = index; result.text = "Selected: " + RowText(index); }
        private void Refresh() { if (Ready && !busy) { int count = list.DataCount; list.SetCount(count); } }
        private void Update()
        {
            if (!Ready || (lastLive == list.LiveCount && lastCreated == list.CreatedCount)) return;
            lastLive = list.LiveCount; lastCreated = list.CreatedCount;
            statistics.text = $"Data {list.DataCount:N0} / Live rows {lastLive} / Created {lastCreated}";
        }
        public async UniTask RunPrimaryAsync()
        {
            if (!Ready || busy) return;
            if (Topic == "List benchmark") { await BenchmarkAsync(false); return; }
            SetBusy(true);
            try
            {
                if (Topic == "Shop")
                {
                    int price = 20 + selected * 5;
                    bool yes = await DemoUi.ConfirmAsync($"Purchase offer #{selected + 1} for {price} coins?\nFake currency, no real payment.", this.GetCancellationTokenOnDestroy());
                    if (yes && FakeSlgState.Coins >= price) { FakeSlgState.Coins -= price; result.text = "Purchased. Coins: " + FakeSlgState.Coins; }
                    else result.text = yes ? "Insufficient coins." : "Purchase cancelled.";
                }
                else if (Topic == "Mail") { bool first = FakeSlgState.ClaimedMail.Add(selected); if (first) FakeSlgState.Coins += 100; result.text = first ? "Mail claimed: +100 coins." : "Reward already claimed; no duplicate credit."; }
                else if (Topic == "Chat") { string text = chatInput.text.Trim(); if (text.Length == 0) { result.text = "Enter a message first."; return; } FakeSlgState.ChatMessages.Add(text.Substring(0, Mathf.Min(100, text.Length))); chatInput.text = ""; result.text = "Local message sent (no network)."; }
                else if (Topic == "Role") { if (FakeSlgState.Coins >= 20) { FakeSlgState.Coins -= 20; ++FakeSlgState.HeroLevel; } result.text = "Hero level: " + FakeSlgState.HeroLevel; }
                else if (Topic == "Guild") { FakeSlgState.Coins = Mathf.Max(0, FakeSlgState.Coins - 10); result.text = "Fake guild donation applied."; }
                else result.text = "Fake action applied to row " + (selected + 1);
            }
            finally
            {
                if (this != null) { SetBusy(false); list.SetCount(Topic == "Chat" ? 5000 + FakeSlgState.ChatMessages.Count : list.DataCount); lastLive = -1; }
            }
        }
        public async UniTask BenchmarkAsync(bool pooled, int requested = 0)
        {
            if (!Ready || busy) return; SetBusy(true);
            int count = Mathf.Clamp(requested > 0 ? requested : list.DataCount, 1, 5000);
            var token = this.GetCancellationTokenOnDestroy(); var wall = Stopwatch.StartNew();
            double createMs = 0, releaseMs = 0, warmMs = 0;
            try
            {
                list.SetCount(0); list.Scroll.content.sizeDelta = new Vector2(0, count * list.rowHeight);
                if (parking == null) { parking = new GameObject("BenchmarkPoolParking", typeof(RectTransform)).transform; parking.SetParent(transform, false); parking.gameObject.SetActive(false); }
                if (pooled && benchmarkPool == null) benchmarkPool = new PrefabInstancePool(lease.Asset, parking);
                for (int pass = 0; pass < (pooled ? 2 : 1); pass++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        token.ThrowIfCancellationRequested(); var cpu = Stopwatch.StartNew();
                        var go = pooled ? benchmarkPool.Rent(list.Scroll.content) : Instantiate(lease.Asset, list.Scroll.content, false);
                        var rect = (RectTransform)go.transform; rect.anchorMin = new Vector2(0, 1); rect.anchorMax = Vector2.one; rect.pivot = new Vector2(.5f, 1); rect.sizeDelta = new Vector2(0, 84); rect.anchoredPosition = new Vector2(0, -i * 90);
                        go.GetComponent<DemoRow>().Bind(i, "Benchmark row " + (i + 1), null); batch.Add(go);
                        if (pass == 0) createMs += cpu.Elapsed.TotalMilliseconds; else warmMs += cpu.Elapsed.TotalMilliseconds;
                        if (i % 100 == 99) await UniTask.NextFrame(token);
                    }
                    await UniTask.NextFrame(token);
                    var release = Stopwatch.StartNew(); foreach (var go in batch) { if (pooled) benchmarkPool.Return(go); else Destroy(go); }
                    releaseMs += release.Elapsed.TotalMilliseconds; batch.Clear();
                    await UniTask.NextFrame(token); await UniTask.NextFrame(token);
                }
                result.text = $"{(pooled ? "POOL" : "RAW")} {count:N0} rows (cap 5,000)\nCreate CPU {createMs:F1} ms / Release requests {releaseMs:F1} ms\nWarm rent+bind {warmMs:F1} ms / Wall {wall.Elapsed.TotalSeconds:F2}s" + (pooled ? $"\nCreated {benchmarkPool.Created} / Reused {benchmarkPool.Reused} / Active {benchmarkPool.ActiveCount}" : "\nDestroy completion includes frame waits.");
            }
            finally
            {
                foreach (var go in batch) { if (go == null) continue; if (pooled) benchmarkPool?.Return(go); else Destroy(go); } batch.Clear();
                if (this != null) { SetBusy(false); list.SetCount(1000); }
            }
        }
        private void SetBusy(bool value) { busy = value; primary.interactable = secondary.interactable = close.interactable = !value; foreach (var button in sizes) button.interactable = !value; }
        private void OnDestroy() { list.Dispose(); benchmarkPool?.Dispose(); lease?.Dispose(); }
    }
}
