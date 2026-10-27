using GameCore;
using UnityEngine;
namespace GameRuntime
{
    public abstract class DemoWindow : UIWindow
    {
        protected override void OnCreate()
        {
            rectTransform.localScale = Vector3.one; rectTransform.localRotation = Quaternion.identity;
            rectTransform.anchorMin = Vector2.zero; rectTransform.anchorMax = Vector2.one; rectTransform.pivot = new Vector2(.5f, .5f);
            rectTransform.offsetMin = rectTransform.offsetMax = Vector2.zero;
            BindView();
        }
        protected abstract void BindView();
    }
    [Window(UILayer.Bottom, "Assets/AssetBundle/UI/SLG/Hud.prefab", hideTimeToClose: 0)]
    public sealed class SlgHudWindow : DemoWindow { protected override void BindView() => gameObject.GetComponent<SlgHudView>().Initialize(); }
    public abstract class SlgFeatureWindow : DemoWindow
    {
        protected abstract string Topic { get; }
        public SlgFeatureView View { get; private set; }
        protected override void BindView() { View = gameObject.GetComponent<SlgFeatureView>(); View.Initialize(Topic, () => GameModule.UI.CloseUI(GetType())); }
    }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Role.prefab", hideTimeToClose: 0)] public sealed class RoleWindow : SlgFeatureWindow { protected override string Topic => "Role"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Bag.prefab", hideTimeToClose: 0)] public sealed class BagWindow : SlgFeatureWindow { protected override string Topic => "Bag"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Guild.prefab", hideTimeToClose: 0)] public sealed class GuildWindow : SlgFeatureWindow { protected override string Topic => "Guild"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Events.prefab", hideTimeToClose: 0)] public sealed class EventsWindow : SlgFeatureWindow { protected override string Topic => "Events"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Shop.prefab", hideTimeToClose: 0)] public sealed class ShopWindow : SlgFeatureWindow { protected override string Topic => "Shop"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Mail.prefab", hideTimeToClose: 0)] public sealed class MailWindow : SlgFeatureWindow { protected override string Topic => "Mail"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/Chat.prefab", hideTimeToClose: 0)] public sealed class ChatWindow : SlgFeatureWindow { protected override string Topic => "Chat"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/ListBenchmark.prefab", hideTimeToClose: 0)] public sealed class ListBenchmarkWindow : SlgFeatureWindow { protected override string Topic => "List benchmark"; }
    [Window(UILayer.UI, "Assets/AssetBundle/UI/SLG/PoolBenchmark.prefab", hideTimeToClose: 0)] public sealed class PoolBenchmarkWindow : DemoWindow { public PoolBenchmarkView View { get; private set; } protected override void BindView() { View = gameObject.GetComponent<PoolBenchmarkView>(); View.Initialize(() => GameModule.UI.CloseUI<PoolBenchmarkWindow>()); } }
    [Window(UILayer.Top, "Assets/AssetBundle/UI/SLG/Confirm.prefab", hideTimeToClose: 0)] public sealed class ConfirmWindow : DemoWindow
    {
        public ConfirmView View { get; private set; }
        protected override void BindView() { View = gameObject.GetComponent<ConfirmView>(); }
        protected override void OnRefresh() => View.Bind((ConfirmationRequest)UserData);
        protected override void OnDestroy() => View?.Cancel();
    }
    [Window(UILayer.Tips, "Assets/AssetBundle/UI/SLG/Tips.prefab", hideTimeToClose: 0)] public sealed class TipsWindow : DemoWindow { protected override void BindView() => gameObject.GetComponent<TipsView>().Initialize(); }
    [Window(UILayer.Tips, "Assets/AssetBundle/UI/SLG/Marquee.prefab", hideTimeToClose: 0)] public sealed class MarqueeWindow : DemoWindow { protected override void BindView() => gameObject.GetComponent<MarqueeView>().Initialize(); }
}
