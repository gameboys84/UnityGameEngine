using System;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.UI;
namespace GameRuntime
{
    public sealed class SlgHudView : MonoBehaviour
    {
        public Text resources, status;
        public Button[] features, utilities;
        private Type selected;
        private int coins = -1;
        public void Initialize()
        {
            Type[] types = { typeof(RoleWindow), typeof(BagWindow), typeof(GuildWindow), typeof(EventsWindow), typeof(ShopWindow), typeof(MailWindow), typeof(ChatWindow) };
            for (int i = 0; i < features.Length; i++) { Type type = types[i]; features[i].onClick.AddListener(() => Open(type)); }
            utilities[0].onClick.AddListener(() => Open(typeof(ListBenchmarkWindow)));
            utilities[1].onClick.AddListener(() => Open(typeof(PoolBenchmarkWindow)));
            utilities[2].onClick.AddListener(() => ModalAsync().Forget(DemoUi.Report));
            utilities[3].onClick.AddListener(() => { var tips = FindObjectOfType<TipsView>(); if (tips != null) tips.BurstAsync(12).Forget(DemoUi.Report); });
            utilities[4].onClick.AddListener(() => { var marquee = FindObjectOfType<MarqueeView>(); if (marquee != null) marquee.Enqueue("Guild notice: fake rally begins in 5 minutes. Prepare your troops!"); });
            status.text = "SLG CLIENT SIMULATION / FAKE SESSION DATA";
        }
        public void Open(Type type)
        {
            if (selected != null && selected != type) GameModule.UI.CloseUI(selected);
            selected = type; GameModule.UI.ShowUIAsync(type);
        }
        private async UniTask ModalAsync() { bool yes = await DemoUi.ConfirmAsync("Continue this demo action?\nUnderlying UI is blocked until you respond.", this.GetCancellationTokenOnDestroy()); if (this != null) status.text = yes ? "Modal accepted." : "Modal cancelled."; }
        private void Update() { if (coins == FakeSlgState.Coins) return; coins = FakeSlgState.Coins; resources.text = $"COMMANDER LV 21     GOLD {coins:N0}     GEMS 500"; }
    }
}
