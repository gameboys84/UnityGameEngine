using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.UI;
namespace GameRuntime
{
    public sealed class PoolBenchmarkView : MonoBehaviour
    {
        public Text result, status;
        public Button raw, pooled, assets, clear, close;
        public Button[] sizes;
        public int Count { get; private set; } = 1000;
        public int LastCreated { get; private set; }
        public int LastReused { get; private set; }
        public int LastActive { get; private set; }
        public bool Busy { get; private set; }
        private PrefabInstancePool pool;
        private AssetLease<GameObject> lease;
        private Transform root, parking;
        private readonly List<GameObject> batch = new List<GameObject>();
        public void Initialize(Action onClose)
        {
            root = new GameObject("ResourceBenchmarkInstances").transform;
            parking = new GameObject("ResourceBenchmarkParking").transform; parking.gameObject.SetActive(false);
            raw.onClick.AddListener(() => RunAsync(false).Forget(DemoUi.Report));
            pooled.onClick.AddListener(() => RunAsync(true).Forget(DemoUi.Report));
            assets.onClick.AddListener(() => ReadAssetsAsync().Forget(DemoUi.Report));
            clear.onClick.AddListener(() => { if (!Busy) { pool?.Dispose(); pool = null; status.text = "Pool cleared; next pool run is cold."; } });
            close.onClick.AddListener(() => { if (!Busy) onClose(); });
            int[] counts = { 100, 1000, 5000 }; for (int i = 0; i < sizes.Length; i++) { int count = counts[i]; sizes[i].onClick.AddListener(() => { Count = count; status.text = "Count: " + Count; }); }
            status.text = "Count: 1000 / 3D resource instances";
        }
        public async UniTask RunAsync(bool usePool, int requested = 0)
        {
            if (Busy) return; SetBusy(true);
            int count = Mathf.Clamp(requested > 0 ? requested : Count, 1, 5000); var token = this.GetCancellationTokenOnDestroy();
            var wall = Stopwatch.StartNew(); double cold = 0, warm = 0, release = 0;
            try
            {
                if (usePool)
                {
                    if (lease == null) lease = await new ResourceReference("Assets/AssetBundle/Prefabs/FoundationMarker.prefab").LoadAsync<GameObject>(token);
                    if (pool == null) pool = new PrefabInstancePool(lease.Asset, parking);
                }
                for (int pass = 0; pass < (usePool ? 2 : 1); pass++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        token.ThrowIfCancellationRequested(); var cpu = Stopwatch.StartNew();
                        var go = usePool ? pool.Rent(root) : await GameModule.Resource.LoadGameObjectAsync("Assets/AssetBundle/Prefabs/FoundationMarker.prefab", root, token);
                        if (go == null) throw new InvalidOperationException("Resource instance is missing.");
                        batch.Add(go); int width = Mathf.CeilToInt(Mathf.Sqrt(count)); go.transform.localScale = Vector3.one * .06f;
                        go.transform.localPosition = new Vector3((i % width - width * .5f) * .09f, .3f, (i / width - width * .5f) * .09f);
                        if (pass == 0) cold += cpu.Elapsed.TotalMilliseconds; else warm += cpu.Elapsed.TotalMilliseconds;
                        if (i % 100 == 99) { status.text = $"{(usePool ? "POOL" : "RAW")} pass {pass + 1} / {i + 1:N0} of {count:N0}"; await UniTask.NextFrame(token); }
                    }
                    await UniTask.NextFrame(token);
                    var cpuRelease = Stopwatch.StartNew(); foreach (var go in batch) { if (usePool) pool.Return(go); else Destroy(go); }
                    release += cpuRelease.Elapsed.TotalMilliseconds; batch.Clear(); await UniTask.NextFrame(token); await UniTask.NextFrame(token);
                }
                LastCreated = usePool ? pool.Created : count; LastReused = usePool ? pool.Reused : 0; LastActive = usePool ? pool.ActiveCount : 0;
                result.text = $"{(usePool ? "POOL" : "RAW")} {count:N0} objects\nFirst pass {cold:F1}ms / Warm {warm:F1}ms\nReturn/destroy requests {release:F1}ms / Wall {wall.Elapsed.TotalSeconds:F2}s\nCreated {LastCreated:N0} / Reused {LastReused:N0} / Active {LastActive}";
                status.text = "Editor timings / chunked operations / render settle included in wall time.";
            }
            finally
            {
                foreach (var go in batch) { if (go == null) continue; if (usePool) pool?.Return(go); else Destroy(go); } batch.Clear();
                if (this != null) SetBusy(false);
            }
        }
        public async UniTask ReadAssetsAsync()
        {
            if (Busy) return; SetBusy(true); var watch = Stopwatch.StartNew(); long bytes = 0;
            try
            {
                for (int i = 0; i < 256; i++)
                {
                    using (var item = await new ResourceReference($"Assets/AssetBundle/Stress/stress-data-{i:D4}.txt").LoadAsync<TextAsset>(this.GetCancellationTokenOnDestroy())) bytes += item.Asset.bytes.Length;
                    if (i % 16 == 15) { status.text = $"Loaded/released {i + 1}/256 assets"; await UniTask.NextFrame(this.GetCancellationTokenOnDestroy()); }
                }
                result.text = $"256 DISTINCT TEXT ASSETS\n{bytes:N0} bytes / {watch.Elapsed.TotalMilliseconds:F1}ms wall\nEvery resource reference disposed after reading.";
            }
            finally { if (this != null) SetBusy(false); }
        }
        private void SetBusy(bool value) { Busy = value; raw.interactable = pooled.interactable = assets.interactable = clear.interactable = close.interactable = !value; foreach (var button in sizes) button.interactable = !value; }
        private void OnDestroy() { pool?.Dispose(); lease?.Dispose(); if (root != null) Destroy(root.gameObject); if (parking != null) Destroy(parking.gameObject); }
    }
}
