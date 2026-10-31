using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.UI;
namespace GameRuntime
{
    public sealed class TipsView : MonoBehaviour
    {
        public GameObject template;
        private PrefabInstancePool pool;
        private Transform parking;
        private readonly List<GameObject> live = new List<GameObject>();
        private readonly List<float> ages = new List<float>();
        public int LiveCount => live.Count;
        public int CreatedCount => pool?.Created ?? 0;
        public void Initialize()
        {
            parking = new GameObject("InactiveTips", typeof(RectTransform)).transform; parking.SetParent(transform, false); parking.gameObject.SetActive(false);
            pool = new PrefabInstancePool(template, parking); template.SetActive(false);
        }
        public async UniTask BurstAsync(int count)
        {
            var token = this.GetCancellationTokenOnDestroy();
            for (int i = 0; i < Mathf.Clamp(count, 1, 30); i++)
            {
                token.ThrowIfCancellationRequested();
                if (live.Count >= 6) ReleaseAt(0);
                var go = pool.Rent(transform); var rect = (RectTransform)go.transform;
                rect.anchorMin = rect.anchorMax = new Vector2(.5f, .62f); rect.sizeDelta = new Vector2(700, 55); rect.anchoredPosition = new Vector2((i % 3 - 1) * 70, 0);
                go.GetComponent<Text>().text = "+" + (10 + i) + " GOLD   /   FAKE REWARD";
                live.Add(go); ages.Add(0); await UniTask.Delay(160, ignoreTimeScale: true, cancellationToken: token);
            }
        }
        private void Update()
        {
            for (int i = live.Count - 1; i >= 0; i--)
            {
                ages[i] += Time.unscaledDeltaTime;
                if (ages[i] > 1.2f) { ReleaseAt(i); continue; }
                var rect = (RectTransform)live[i].transform; rect.anchoredPosition += Vector2.up * (100 * Time.unscaledDeltaTime);
                var text = live[i].GetComponent<Text>(); text.color = new Color(.4f, 1, .75f, 1 - ages[i] / 1.2f);
            }
        }
        private void ReleaseAt(int index) { pool.Return(live[index]); live.RemoveAt(index); ages.RemoveAt(index); }
        private void OnDestroy() { pool?.Dispose(); }
    }
}