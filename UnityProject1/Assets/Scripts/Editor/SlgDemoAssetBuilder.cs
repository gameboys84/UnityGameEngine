using System;
using System.IO;
using GameRuntime;
using GameCore;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public static class SlgDemoAssetBuilder
{
    private static readonly Color Card = new Color(.055f, .09f, .14f);
    private static readonly Color ButtonColor = new Color(.12f, .25f, .30f);
    private static readonly Color Mint = new Color(.3f, .9f, .7f);
    private const string Folder = "Assets/AssetBundle/UI/SLG/";
    [MenuItem("TEngine/Demo/Create Independent SLG Test Assets")]
    public static void Create()
    {
        if (EditorApplication.isPlaying) throw new InvalidOperationException("Stop Play first.");
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
        Directory.CreateDirectory(Folder); Directory.CreateDirectory("Assets/AssetBundle/Stress"); Directory.CreateDirectory("Assets/Editor/Templates"); AssetDatabase.Refresh();
        const string template = "Assets/Editor/Templates/FrameworkTestPanel.prefab";
        if (File.Exists("Assets/AssetBundle/UI/FrameworkTestPanel.prefab") && !File.Exists(template))
        {
            string error = AssetDatabase.MoveAsset("Assets/AssetBundle/UI/FrameworkTestPanel.prefab", template);
            if (!string.IsNullOrEmpty(error)) throw new IOException(error);
        }
        foreach (string name in new[] { "Resource", "Scene", "Save", "Timer", "Details" })
        {
            string destination = "Assets/AssetBundle/UI/" + name + "Test.prefab";
            if (!File.Exists(destination) && !AssetDatabase.CopyAsset(template, destination)) throw new IOException(destination);
        }
        CreateRow(); CreateHud(); CreateConfirm(); CreateTips(); CreateMarquee(); CreatePoolBenchmark();
        foreach (string topic in new[] { "Role", "Bag", "Guild", "Events", "Shop", "Mail", "Chat", "ListBenchmark" }) CreateFeature(topic);
        for (int i = 0; i < 256; i++)
        {
            string path = $"Assets/AssetBundle/Stress/stress-data-{i:D4}.txt";
            if (!File.Exists(path)) File.WriteAllText(path, $"Fake resource {i}\n" + new string((char)('A' + i % 26), 4096));
        }
        AssetDatabase.Refresh();
        var scene = EditorSceneManager.OpenScene(StartupSceneBuilder.MainScene);
        var main = UnityEngine.Object.FindObjectOfType<MainSceneView>();
        var canvas = GameObject.Find("UIRoot").GetComponentInChildren<Canvas>();
        foreach (var text in canvas.GetComponentsInChildren<Text>())
            if (text != main.message && text.GetComponentInParent<Button>() == null) UnityEngine.Object.DestroyImmediate(text.gameObject);
        Rect(main.message.rectTransform, .12f, .86f, .88f, .90f); main.message.fontSize = 18;
        var labs = new[] { main.resourceButton, main.sceneButton, main.saveButton, main.timerButton };
        for (int i = 0; i < labs.Length; i++)
        {
            Rect((RectTransform)labs[i].transform, .02f + i * .245f, .205f, .245f + i * .245f, .26f);
            labs[i].GetComponentInChildren<Text>().fontSize = 20;
        }
        EditorSceneManager.SaveScene(scene); AssetDatabase.SaveAssets(); EditorSceneManager.OpenScene(StartupSceneBuilder.LauncherScene);
        Debug.Log("Independent HUD, SLG features, modal, tips, marquee and bulk-test assets created.");
    }
    private static void CreateFeature(string topic)
    {
        var root = Root(topic); var view = root.AddComponent<SlgFeatureView>();
        Panel(root.transform, "Card", .05f, .27f, .95f, .94f, Card, true);
        view.title = Label(root.transform, topic.ToUpperInvariant(), .10f, .85f, .78f, .92f, 34, Color.white);
        view.close = Button(root.transform, "X", .81f, .86f, .91f, .91f);
        view.sizes = new[] { Button(root.transform, "1,000", .10f, .79f, .34f, .84f), Button(root.transform, "10,000", .38f, .79f, .62f, .84f), Button(root.transform, "100,000", .66f, .79f, .90f, .84f) };
        view.statistics = Label(root.transform, "Loading row resources...", .10f, .74f, .90f, .79f, 20, Mint);
        view.list = ScrollList(root.transform);
        view.primary = Button(root.transform, "ACTION", .10f, .40f, .54f, .45f);
        view.secondary = Button(root.transform, "REFRESH", .58f, .40f, .90f, .45f);
        view.result = Label(root.transform, "Fake data", .10f, .28f, .90f, .39f, 19, Mint);
        var inputImage = Panel(root.transform, "ChatInput", .1f, .34f, .9f, .39f, new Color(.16f, .20f, .28f), true);
        view.chatInput = inputImage.gameObject.AddComponent<InputField>();
        var inputText = Label(inputImage.transform, "", .03f, 0, .97f, 1, 22, Color.white); inputText.alignment = TextAnchor.MiddleLeft;
        view.chatInput.textComponent = inputText; view.chatInput.characterLimit = 100; view.chatInput.targetGraphic = inputImage;
        if (topic == "Chat") Rect(view.result.rectTransform, .1f, .28f, .9f, .335f);
        inputImage.gameObject.SetActive(false);
        Save(root, topic);
    }
    private static VirtualizedScrollList ScrollList(Transform parent)
    {
        var go = new GameObject("VirtualizedList", typeof(RectTransform), typeof(ScrollRect), typeof(VirtualizedScrollList)); go.transform.SetParent(parent, false);
        Rect((RectTransform)go.transform, .1f, .46f, .9f, .735f);
        var viewport = Panel(go.transform, "Viewport", 0, 0, 1, 1, new Color(.025f, .045f, .075f), true);
        viewport.gameObject.AddComponent<RectMask2D>();
        var content = new GameObject("Content", typeof(RectTransform)); content.transform.SetParent(viewport.transform, false);
        var rect = (RectTransform)content.transform; rect.anchorMin = new Vector2(0, 1); rect.anchorMax = Vector2.one; rect.pivot = new Vector2(.5f, 1); rect.sizeDelta = Vector2.zero;
        var scroll = go.GetComponent<ScrollRect>(); scroll.viewport = (RectTransform)viewport.transform; scroll.content = rect;
        scroll.horizontal = false; scroll.vertical = true; scroll.movementType = ScrollRect.MovementType.Clamped; scroll.scrollSensitivity = 45;
        return go.GetComponent<VirtualizedScrollList>();
    }
    private static void CreateRow()
    {
        var go = new GameObject("ListRow", typeof(RectTransform), typeof(Image), typeof(Button), typeof(DemoRow));
        var image = go.GetComponent<Image>(); image.color = new Color(.10f, .17f, .23f); image.raycastTarget = true;
        var view = go.GetComponent<DemoRow>(); view.select = go.GetComponent<Button>(); view.select.targetGraphic = image;
        view.label = Label(go.transform, "DATA ROW", .04f, 0, .96f, 1, 23, Color.white); view.label.alignment = TextAnchor.MiddleLeft;
        PrefabUtility.SaveAsPrefabAsset(go, Folder + "ListRow.prefab"); UnityEngine.Object.DestroyImmediate(go);
    }
    private static void CreateHud()
    {
        var root = Root("Hud"); var view = root.AddComponent<SlgHudView>();
        Panel(root.transform, "Profile", .02f, .90f, .98f, .96f, Card, false);
        view.resources = Label(root.transform, "COMMANDER", .04f, .91f, .96f, .95f, 22, Mint);
        view.status = Label(root.transform, "FAKE SLG DEMO", .04f, .015f, .96f, .04f, 16, Mint);
        string[] names = { "ROLE", "BAG", "GUILD", "EVENTS", "SHOP", "MAIL", "CHAT" }; view.features = new Button[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            int col = i % 4, row = i / 4; float y = row == 0 ? .125f : .055f;
            view.features[i] = Button(root.transform, names[i], .02f + col * .245f, y, .245f + col * .245f, y + .055f);
        }
        string[] utilities = { "LIST", "POOL", "MODAL", "TIPS", "NEWS" }; view.utilities = new Button[5];
        for (int i = 0; i < 5; i++) view.utilities[i] = Button(root.transform, utilities[i], .02f + i * .195f, .79f, .205f + i * .195f, .835f);
        Save(root, "Hud");
    }
    private static void CreateConfirm()
    {
        var root = Root("Confirm"); var view = root.AddComponent<ConfirmView>();
        Panel(root.transform, "ModalBlocker", 0, 0, 1, 1, new Color(0, .015f, .04f, .80f), true);
        Panel(root.transform, "Card", .10f, .35f, .90f, .68f, Card, true);
        Label(root.transform, "WAITING FOR YOUR RESPONSE", .13f, .61f, .87f, .66f, 24, Mint);
        view.message = Label(root.transform, "Confirm?", .15f, .46f, .85f, .60f, 26, Color.white);
        view.accept = Button(root.transform, "CONFIRM", .15f, .39f, .46f, .45f);
        view.reject = Button(root.transform, "CANCEL", .54f, .39f, .85f, .45f); Save(root, "Confirm");
    }
    private static void CreateTips()
    {
        var root = Root("Tips"); var view = root.AddComponent<TipsView>();
        view.template = Label(root.transform, "FLOATING TIP", .15f, .6f, .85f, .64f, 27, Mint).gameObject;
        view.template.SetActive(false); Save(root, "Tips");
    }
    private static void CreateMarquee()
    {
        var root = Root("Marquee"); var view = root.AddComponent<MarqueeView>();
        var viewport = Panel(root.transform, "MarqueeViewport", .02f, .966f, .98f, .999f, new Color(.04f, .14f, .16f, .95f), false);
        viewport.gameObject.AddComponent<RectMask2D>(); view.viewport = (RectTransform)viewport.transform;
        view.text = Label(viewport.transform, "", 0, 0, 1, 1, 21, Mint); view.text.horizontalOverflow = HorizontalWrapMode.Overflow; view.text.alignment = TextAnchor.MiddleLeft;
        view.text.rectTransform.anchorMin = view.text.rectTransform.anchorMax = new Vector2(0, .5f); view.text.rectTransform.pivot = new Vector2(0, .5f); Save(root, "Marquee");
    }
    private static void CreatePoolBenchmark()
    {
        var root = Root("PoolBenchmark"); var view = root.AddComponent<PoolBenchmarkView>();
        Panel(root.transform, "Card", .05f, .27f, .95f, .94f, Card, true);
        Label(root.transform, "BULK RESOURCE / INSTANCE POOL", .08f, .85f, .80f, .92f, 27, Color.white);
        view.close = Button(root.transform, "X", .82f, .86f, .92f, .91f);
        view.sizes = new[] { Button(root.transform, "100", .10f, .77f, .34f, .83f), Button(root.transform, "1,000", .38f, .77f, .62f, .83f), Button(root.transform, "5,000", .66f, .77f, .90f, .83f) };
        view.status = Label(root.transform, "Choose a workload", .1f, .69f, .9f, .76f, 21, Mint);
        view.raw = Button(root.transform, "RAW LOAD / DESTROY", .1f, .60f, .9f, .67f);
        view.pooled = Button(root.transform, "POOL FIRST / REUSE", .1f, .51f, .9f, .58f);
        view.assets = Button(root.transform, "READ 256 DISTINCT ASSETS", .1f, .42f, .9f, .49f);
        view.clear = Button(root.transform, "CLEAR POOL", .1f, .34f, .44f, .40f);
        view.result = Label(root.transform, "Ready", .46f, .28f, .92f, .41f, 18, Mint); Save(root, "PoolBenchmark");
    }
    private static GameObject Root(string name)
    {
        var parent = new GameObject("AuthoringCanvas", typeof(RectTransform), typeof(Canvas)); parent.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        var go = new GameObject(name, typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster)); go.transform.SetParent(parent.transform, false);
        go.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay; Rect((RectTransform)go.transform, 0, 0, 1, 1); return go;
    }
    private static void Save(GameObject root, string name) { PrefabUtility.SaveAsPrefabAsset(root, Folder + name + ".prefab"); UnityEngine.Object.DestroyImmediate(root.transform.parent.gameObject); }
    private static Image Panel(Transform parent, string name, float x0, float y0, float x1, float y1, Color color, bool raycast)
    {
        var go = new GameObject(name, typeof(RectTransform), typeof(Image)); go.transform.SetParent(parent, false); Rect((RectTransform)go.transform, x0, y0, x1, y1);
        var image = go.GetComponent<Image>(); image.color = color; image.raycastTarget = raycast; return image;
    }
    private static Text Label(Transform parent, string value, float x0, float y0, float x1, float y1, int size, Color color)
    {
        var go = new GameObject("Label", typeof(RectTransform), typeof(Text)); go.transform.SetParent(parent, false); Rect((RectTransform)go.transform, x0, y0, x1, y1);
        var text = go.GetComponent<Text>(); text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf"); text.text = value; text.fontSize = size; text.color = color; text.alignment = TextAnchor.MiddleCenter; text.raycastTarget = false; return text;
    }
    private static Button Button(Transform parent, string name, float x0, float y0, float x1, float y1)
    {
        var image = Panel(parent, name, x0, y0, x1, y1, ButtonColor, true); var button = image.gameObject.AddComponent<Button>(); button.targetGraphic = image;
        Label(image.transform, name, 0, 0, 1, 1, 22, Color.white); return button;
    }
    private static void Rect(RectTransform rect, float x0, float y0, float x1, float y1) { rect.localScale = Vector3.one; rect.anchorMin = new Vector2(x0, y0); rect.anchorMax = new Vector2(x1, y1); rect.offsetMin = rect.offsetMax = Vector2.zero; }
}
