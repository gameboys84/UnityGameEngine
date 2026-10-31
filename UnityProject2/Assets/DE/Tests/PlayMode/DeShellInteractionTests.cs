using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DE.Application;
using DE.Domain;
using DE.Infrastructure;
using DE.Presentation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace DE.Tests
{
    // Exercises the production shell in an isolated Canvas with real StandaloneInputModule processing.
    // Launcher, YooAsset bootstrap and target-player behavior require separate integration acceptance.
    [Category("HistoricalPrototype")]
    [Explicit("Historical Mock dashboard only; real DE visual and network acceptance uses the production entry.")]
    public sealed class DeShellInteractionTests
    {
        private GameObject root, eventRoot;
        private DEShellView view;
        private EventSystem events;
        private StandaloneInputModule module;
        private DeAcceptancePointerInput pointerInput;
        private IDeClient client;
        private readonly List<EventSystem> previousEvents = new List<EventSystem>();

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            foreach (var system in Object.FindObjectsOfType<EventSystem>())
                if (system.enabled) { previousEvents.Add(system); system.enabled = false; }
            eventRoot = new GameObject("DE.Acceptance.EventSystem", typeof(EventSystem), typeof(StandaloneInputModule), typeof(DeAcceptancePointerInput));
            events = eventRoot.GetComponent<EventSystem>();
            module = eventRoot.GetComponent<StandaloneInputModule>();
            pointerInput = eventRoot.GetComponent<DeAcceptancePointerInput>();
            module.inputOverride = pointerInput;
            root = new GameObject("DE.Acceptance.Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            var canvas = root.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay; canvas.sortingOrder = 30000;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1600, 900);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            var shell = new GameObject("DE.Acceptance.Shell", typeof(RectTransform));
            var rect = shell.GetComponent<RectTransform>();
            rect.SetParent(root.transform, false); rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one;
            rect.offsetMin = rect.offsetMax = Vector2.zero;
            client = DeClientFactory.CreateMock("acceptance-ui-a");
            view = shell.AddComponent<DEShellView>();
            view.Bind(client);
            yield return null;
            yield return null;
            Canvas.ForceUpdateCanvases();
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (root != null) Object.Destroy(root);
            if (eventRoot != null) Object.Destroy(eventRoot);
            yield return null;
            client?.Dispose();
            foreach (var system in previousEvents) if (system != null) system.enabled = true;
            previousEvents.Clear();
        }

        private DEUiId Element(string id)
        {
            var matches = view.GetComponentsInChildren<DEUiId>(false).Where(value => value.Id == id).ToArray();
            Assert.That(matches.Length, Is.EqualTo(1), "Expected one active element: " + id);
            return matches[0];
        }

        private Vector2 Position(DEUiId element)
        {
            Canvas.ForceUpdateCanvases();
            var rect = element.GetComponent<RectTransform>();
            return RectTransformUtility.WorldToScreenPoint(null, rect.TransformPoint(rect.rect.center));
        }

        private List<RaycastResult> Hits(Vector2 position)
        {
            var hits = new List<RaycastResult>();
            events.RaycastAll(new PointerEventData(events) { position = position }, hits);
            Assert.That(hits.Count, Is.GreaterThan(0), "No Graphic under the pointer.");
            return hits;
        }

        private void Click(string id)
        {
            var target = Element(id);
            var button = target.GetComponent<Button>();
            Assert.That(button, Is.Not.Null, id + " is not a Button.");
            Assert.That(button.IsInteractable(), Is.True, id + " is not interactable.");
            var position = Position(target);
            var hits = Hits(position);
            Assert.That(ExecuteEvents.GetEventHandler<IPointerClickHandler>(hits[0].gameObject), Is.EqualTo(button.gameObject),
                "Another Graphic blocks " + id + ": " + hits[0].gameObject.name);
            SendPointer(position);
        }

        private void SendPointer(Vector2 position)
        {
            var field = typeof(EventSystem).GetField("m_HasFocus", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(field, Is.Not.Null, "Unity EventSystem focus adapter needs updating for this Editor version.");
            var oldFocus = field.GetValue(events);
            try
            {
                field.SetValue(events, true);
                pointerInput.Position = position;
                pointerInput.Down = true; pointerInput.Held = true; pointerInput.Up = false;
                module.UpdateModule(); module.Process();
                pointerInput.Down = false; pointerInput.Held = false; pointerInput.Up = true;
                module.Process();
            }
            finally
            {
                pointerInput.Down = pointerInput.Up = pointerInput.Held = false;
                field.SetValue(events, oldFocus);
            }
        }

        [UnityTest]
        public IEnumerator AllExposedNavigationEntriesAreReachableThroughInputAndBackRestoresHistory()
        {
            foreach (var page in new[] { "research", "training", "bag", "mail", "chat", "map", "coverage", "queues", "city" })
            {
                Click("nav." + page);
                yield return null;
                Assert.That(view.CurrentPage, Is.EqualTo(page));
            }
            Click("nav.mail"); yield return null;
            Click("nav.back"); yield return null;
            Assert.That(view.CurrentPage, Is.EqualTo("city"));
        }

        [UnityTest]
        public IEnumerator ModalBlocksUnderlyingNavigationAndCancellationDoesNotSpendResources()
        {
            Click("building.upgrade.hq"); yield return null;
            Assert.That(view.ModalVisible, Is.True);
            var position = Position(Element("nav.mail"));
            var hits = Hits(position);
            Assert.That(ExecuteEvents.GetEventHandler<IPointerClickHandler>(hits[0].gameObject),
                Is.Not.EqualTo(Element("nav.mail").gameObject), "Modal must block the underlying navigation raycast.");
            SendPointer(position); yield return null;
            Assert.That(view.CurrentPage, Is.EqualTo("city"));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5000));
            Click("modal.cancel"); yield return null;
            Assert.That(view.ModalVisible, Is.False);
            Assert.That(client.Snapshot.Queues, Is.Empty);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5000));
        }

        [UnityTest]
        public IEnumerator ConfirmedUpgradeAndMailClaimReachTheApplicationAndRefreshTheShell()
        {
            Click("building.upgrade.hq"); yield return null;
            Click("modal.confirm"); yield return new WaitForSecondsRealtime(.5f);
            Assert.That(client.Snapshot.Queues.Length, Is.EqualTo(1));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(4760));
            Assert.That(client.Snapshot.GetBuildingLevel("hq"), Is.EqualTo(1));
            Assert.That(view.ModalVisible, Is.False);
            Click("nav.mail"); yield return null;
            Click("mail.claim.mail-1"); yield return new WaitForSecondsRealtime(.5f);
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5060));
            Assert.That(Element("mail.claim.mail-1").GetComponent<Button>().IsInteractable(), Is.False);
        }

        [UnityTest]
        public IEnumerator AccountSwitchClosesPendingModalAndDoesNotLeakTheOldConfirmation()
        {
            Click("nav.mail"); yield return null;
            Click("mail.claim.mail-1"); yield return new WaitForSecondsRealtime(.5f);
            Click("nav.city"); yield return null;
            Click("building.upgrade.hq"); yield return null;
            Assert.That(view.ModalVisible, Is.True);
            client.SwitchAccount("acceptance-ui-b");
            yield return new WaitForSecondsRealtime(.5f);
            Assert.That(view.ModalVisible, Is.False);
            Assert.That(view.CurrentPage, Is.EqualTo("city"));
            Assert.That(client.Snapshot.AccountId, Is.EqualTo("acceptance-ui-b"));
            Assert.That(client.Snapshot.GetResource("food"), Is.EqualTo(5000));
            Assert.That(client.Snapshot.Queues, Is.Empty);
        }
    }

    public sealed class DeAcceptancePointerInput : BaseInput
    {
        public Vector2 Position;
        public bool Down, Up, Held;
        public override bool mousePresent => true;
        public override Vector2 mousePosition => Position;
        public override Vector2 mouseScrollDelta => Vector2.zero;
        public override int touchCount => 0;
        public override bool GetMouseButtonDown(int button) => button == 0 && Down;
        public override bool GetMouseButtonUp(int button) => button == 0 && Up;
        public override bool GetMouseButton(int button) => button == 0 && Held;
        public override float GetAxisRaw(string axisName) => 0;
        public override bool GetButtonDown(string buttonName) => false;
    }
}
