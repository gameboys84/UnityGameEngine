using GameCore;
using UnityEngine;
namespace GameRuntime
{
    public abstract class FrameworkTestWindow : UIWindow
    {
        protected abstract string Topic { get; }
        public FrameworkTestPanel Panel { get; private set; }
        protected override void OnCreate()
        {
            // This demo uses full-parent overlay panels; normalize root Canvas driven values after parenting.
            rectTransform.localScale = Vector3.one;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.pivot = new Vector2(.5f, .5f);
            rectTransform.offsetMin = rectTransform.offsetMax = Vector2.zero;
            Panel = gameObject.GetComponent<FrameworkTestPanel>();
            Panel.Configure(Topic, () => GameModule.UI.CloseUI(GetType()));
        }
        protected override void OnRefresh()
        {
            if (Topic == "UI") Panel.output.text = "Opened through ShowUIAsyncAwait.\n" + (UserData as string ?? "Nested window ready.");
        }
    }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/ResourceTest.prefab", hideTimeToClose: 0)]
    public sealed class ResourceTestWindow : FrameworkTestWindow { protected override string Topic => "Resource"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SceneTest.prefab", hideTimeToClose: 0)]
    public sealed class SceneTestWindow : FrameworkTestWindow { protected override string Topic => "Scene"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SaveTest.prefab", hideTimeToClose: 0)]
    public sealed class SaveTestWindow : FrameworkTestWindow { protected override string Topic => "Save"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/TimerTest.prefab", hideTimeToClose: 0)]
    public sealed class TimerTestWindow : FrameworkTestWindow { protected override string Topic => "Timer"; }
    [Window(UILayer.Top, "Assets/AssetBundle/UI/DetailsTest.prefab", hideTimeToClose: 0)]
    public sealed class DetailsTestWindow : FrameworkTestWindow { protected override string Topic => "UI"; }
}
