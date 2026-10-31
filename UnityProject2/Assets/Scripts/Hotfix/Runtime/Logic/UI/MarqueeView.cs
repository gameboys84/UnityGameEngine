using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.UI;
namespace GameRuntime
{
    public sealed class MarqueeView : MonoBehaviour
    {
        public Text text;
        public RectTransform viewport;
        private readonly Queue<string> queue = new Queue<string>();
        private bool running;
        public int Completed { get; private set; }
        public int Pending => queue.Count;
        public void Initialize() { text.text = ""; Enqueue("Welcome commander! All SLG data in this demo is simulated locally."); }
        public void Enqueue(string message) { if (queue.Count < 40) queue.Enqueue(message); }
        private void Update()
        {
            var rect = text.rectTransform;
            if (!running)
            {
                if (queue.Count == 0) return;
                text.text = queue.Dequeue(); rect.sizeDelta = new Vector2(Mathf.Max(500, text.preferredWidth + 30), 50);
                rect.anchoredPosition = new Vector2(viewport.rect.width, 0); running = true;
            }
            rect.anchoredPosition += Vector2.left * (180 * Time.unscaledDeltaTime);
            if (rect.anchoredPosition.x < -rect.rect.width) { running = false; ++Completed; text.text = ""; }
        }
    }
}
