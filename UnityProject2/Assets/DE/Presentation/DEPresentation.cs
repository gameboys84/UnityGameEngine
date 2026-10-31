using System;
using Cysharp.Threading.Tasks;
using DE.Application;
using GameCore;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DE.Presentation
{
    public static class DEPresentation
    {
        public static async UniTask Bootstrap(IDeClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (GameObject.Find("UIRoot") == null)
            {
                var root = new GameObject("UIRoot");
                var canvas = new GameObject("Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
                canvas.transform.SetParent(root.transform, false);
                canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                var scaler = canvas.GetComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1600, 900);
                scaler.matchWidthOrHeight = .5f;
            }
            if (EventSystem.current == null)
            {
                var events = new GameObject("DE.EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
                UnityEngine.Object.DontDestroyOnLoad(events);
            }
            var existingScaler = GameObject.Find("UIRoot").GetComponentInChildren<CanvasScaler>();
            if (existingScaler != null)
            {
                existingScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                existingScaler.referenceResolution = new Vector2(1600, 900);
                existingScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            }
            await UIModule.Instance.ShowUIAsyncAwait<DEShellWindow>(client);
        }
    }

    [Window(UILayer.Bottom, true, "DE/Shell", fullScreen: true, hideTimeToClose: 0)]
    public sealed class DEShellWindow : UIWindow
    {
        protected override void OnCreate()
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = rectTransform.offsetMax = Vector2.zero;
            rectTransform.localScale = Vector3.one;
            rectTransform.localRotation = Quaternion.identity;
        }

        protected override void OnRefresh()
        {
            var view = gameObject.GetComponent<DEShellView>() ?? gameObject.AddComponent<DEShellView>();
            view.Bind((IDeClient)UserData);
        }
    }
}
