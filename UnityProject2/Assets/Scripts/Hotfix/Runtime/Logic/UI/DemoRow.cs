using System;
using GameCore;
using UnityEngine;
namespace GameRuntime
{
    public sealed class DemoRow : MonoBehaviour
    {
        public UnityEngine.UI.Text label;
        public UnityEngine.UI.Button select;
        private int index;
        private Action<int> selected;
        public void Bind(int id, string text, Action<int> callback)
        {
            index = id; selected = callback; label.text = text;
            select.onClick.RemoveAllListeners(); select.onClick.AddListener(() => selected?.Invoke(index));
        }
    }
}