using System;
using System.IO;
using GameRuntime;
using Launcher;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>Authors the framework demo's presentation and test assets with Unity APIs.</summary>
public static class DemoPresentationBuilder
{
    [MenuItem("TEngine/Demo/Open Resource Lab (Play)")]
    public static void OpenResourceLab()
    {
        var view = UnityEngine.Object.FindObjectOfType<MainSceneView>();
        if (!EditorApplication.isPlaying || view == null || !view.IsReady) throw new InvalidOperationException("Enter Main through Launcher first.");
        view.resourceButton.onClick.Invoke();
    }
    private static readonly Color Navy = new Color(.035f, .055f, .095f);
    private static readonly Color Mint = new Color(.25f, .85f, .69f);
    private static readonly Color Coral = new Color(.95f, .44f, .34f);
    [MenuItem("TEngine/Demo/Apply Presentation and Test Panels")]
    public static void Apply()
    {
        if (EditorApplication.isPlaying) throw new InvalidOperationException("Stop Play first.");
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
        Directory.CreateDirectory("Assets/AssetBundle/UI");
        Directory.CreateDirectory("Assets/AssetBundle/Materials");
        AssetDatabase.Refresh();
        CreatePanel();
        var scene = EditorSceneManager.OpenScene(StartupSceneBuilder.MainScene);
        var view = UnityEngine.Object.FindObjectOfType<MainSceneView>();
        var canvas = GameObject.Find("UIRoot").GetComponentInChildren<Canvas>();
        for (int i = canvas.transform.childCount - 1; i >= 0; i--) UnityEngine.Object.DestroyImmediate(canvas.transform.GetChild(i).gameObject);
        Label(canvas.transform, "FRAMEWORK PLAYGROUND", 23, new Vector2(.06f, .90f), new Vector2(.94f, .96f), Mint);
        Label(canvas.transform, "READY TO EXPLORE", 45, new Vector2(.06f, .83f), new Vector2(.94f, .9f), Color.white);
        view.message = Label(canvas.transform, "Waiting for game entry", 23, new Vector2(.1f, .75f), new Vector2(.9f, .82f), new Color(.65f, .76f, .84f));
        Label(canvas.transform, "CHOOSE A FRAMEWORK TEST", 22, new Vector2(.08f, .34f), new Vector2(.92f, .39f), new Color(.7f, .8f, .9f));
        view.resourceButton = Button(canvas.transform, "RESOURCE", new Vector2(.1f, .24f), new Vector2(.48f, .32f), new Color(.10f, .28f, .28f));
        view.sceneButton = Button(canvas.transform, "SCENE", new Vector2(.52f, .24f), new Vector2(.9f, .32f), new Color(.27f, .17f, .24f));
        view.saveButton = Button(canvas.transform, "LOCAL SAVE", new Vector2(.1f, .14f), new Vector2(.48f, .22f), new Color(.16f, .20f, .33f));
        view.timerButton = Button(canvas.transform, "TIMER", new Vector2(.52f, .14f), new Vector2(.9f, .22f), new Color(.29f, .23f, .14f));
        Label(canvas.transform, "Async windows  /  Real resources  /  Visible results", 18, new Vector2(.04f, .04f), new Vector2(.96f, .09f), new Color(.45f, .57f, .68f));
        var camera = Camera.main;
        camera.transform.position = new Vector3(6, 5, -9);
        camera.transform.LookAt(new Vector3(0, .8f, 0));
        camera.orthographic = true; camera.orthographicSize = 4.8f; camera.backgroundColor = Navy;
        camera.allowHDR = true;
        var sun = GameObject.Find("Sun").GetComponent<Light>();
        sun.color = new Color(1, .88f, .74f); sun.intensity = 1.15f; sun.shadows = LightShadows.Soft;
        sun.transform.rotation = Quaternion.Euler(45, -35, 0);
        var fillGo = GameObject.Find("DemoFillLight") ?? new GameObject("DemoFillLight", typeof(Light));
        var fill = fillGo.GetComponent<Light>(); fill.type = LightType.Directional; fill.color = new Color(.48f, .69f, 1); fill.intensity = .45f;
        fill.transform.rotation = Quaternion.Euler(25, 145, 0);
        RenderSettings.ambientMode = AmbientMode.Trilight;
        RenderSettings.ambientSkyColor = new Color(.34f, .44f, .58f);
        RenderSettings.ambientEquatorColor = new Color(.14f, .19f, .28f);
        RenderSettings.ambientGroundColor = new Color(.06f, .08f, .13f);
        var floor = GameObject.Find("FoundationPlatform");
        floor.transform.localScale = new Vector3(5, .3f, 3.6f);
        floor.GetComponent<Renderer>().sharedMaterial = Material("StageMaterial", new Color(.15f, .21f, .29f));
        var marker = GameObject.Find("FoundationMarker");
        if (marker == null) marker = GameObject.Find("FoundationMarker(Clone)");
        if (marker != null) marker.transform.position = new Vector3(0, .85f, 0);
        var markerMaterial = AssetDatabase.LoadAssetAtPath<Material>("Assets/AssetBundle/Prefabs/FoundationMarkerMaterial.mat");
        markerMaterial.color = Mint; markerMaterial.SetFloat("_Glossiness", .38f); EditorUtility.SetDirty(markerMaterial);
        Shape("DemoCoralColumn", PrimitiveType.Cylinder, new Vector3(-1.5f, .8f, .55f), new Vector3(.85f, .65f, .85f), Material("CoralMaterial", Coral));
        Shape("DemoVioletSphere", PrimitiveType.Sphere, new Vector3(1.5f, .65f, .6f), Vector3.one * .95f, Material("VioletMaterial", new Color(.5f, .45f, .83f)));
        EditorSceneManager.SaveScene(scene);
        CreateGarden();
        var settings = AssetDatabase.LoadAssetAtPath<StartupSettings>("Assets/Launcher/Settings/StartupSettings.asset");
        settings.previewStageSeconds = .4f; EditorUtility.SetDirty(settings);
        AssetDatabase.SaveAssets();
        EditorSceneManager.OpenScene(StartupSceneBuilder.LauncherScene);
        SlgDemoAssetBuilder.Create();
        Debug.Log("Demo presentation and real framework test panels prepared.");
    }
    private static void CreatePanel()
    {
        var authoringCanvas = new GameObject("DemoAuthoringCanvas", typeof(RectTransform), typeof(Canvas));
        authoringCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        var root = new GameObject("FrameworkTestPanel", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster), typeof(FrameworkTestPanel));
        root.transform.SetParent(authoringCanvas.transform, false);
        root.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        var rect = root.GetComponent<RectTransform>(); rect.localScale = Vector3.one; rect.pivot = new Vector2(.5f, .5f); rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one; rect.offsetMin = rect.offsetMax = Vector2.zero;
        var panel = root.GetComponent<FrameworkTestPanel>();
        var scrim = Image(root.transform, "Scrim", new Vector2(0, 0), new Vector2(1, 1), new Color(.015f, .025f, .05f, .88f)); scrim.raycastTarget = true;
        Image(root.transform, "Card", new Vector2(.06f, .16f), new Vector2(.94f, .85f), new Color(.065f, .10f, .16f));
        Image(root.transform, "Accent", new Vector2(.06f, .846f), new Vector2(.94f, .85f), Mint);
        panel.title = Label(root.transform, "FRAMEWORK LAB", 39, new Vector2(.1f, .75f), new Vector2(.9f, .82f), Color.white);
        panel.description = Label(root.transform, "Choose an operation", 22, new Vector2(.1f, .67f), new Vector2(.9f, .75f), new Color(.65f, .77f, .88f));
        panel.actions = new[] {
            Button(root.transform, "ACTION 1", new Vector2(.11f, .57f), new Vector2(.48f, .64f), new Color(.13f, .29f, .32f)),
            Button(root.transform, "ACTION 2", new Vector2(.52f, .57f), new Vector2(.89f, .64f), new Color(.13f, .29f, .32f)),
            Button(root.transform, "ACTION 3", new Vector2(.11f, .48f), new Vector2(.48f, .55f), new Color(.14f, .22f, .32f)),
            Button(root.transform, "ACTION 4", new Vector2(.52f, .48f), new Vector2(.89f, .55f), new Color(.14f, .22f, .32f)) };
        Image(root.transform, "ResultCard", new Vector2(.11f, .29f), new Vector2(.89f, .45f), new Color(.035f, .055f, .09f));
        panel.output = Label(root.transform, "Choose an operation.", 23, new Vector2(.14f, .30f), new Vector2(.86f, .44f), Mint);
        panel.output.horizontalOverflow = HorizontalWrapMode.Wrap;
        panel.nested = Button(root.transform, "CHILD WINDOW", new Vector2(.11f, .20f), new Vector2(.57f, .27f), new Color(.18f, .22f, .34f));
        panel.close = Button(root.transform, "CLOSE", new Vector2(.61f, .20f), new Vector2(.89f, .27f), new Color(.30f, .18f, .21f));
        Directory.CreateDirectory("Assets/Editor/Templates"); AssetDatabase.Refresh();
        PrefabUtility.SaveAsPrefabAsset(root, "Assets/Editor/Templates/FrameworkTestPanel.prefab");
        UnityEngine.Object.DestroyImmediate(authoringCanvas);
    }
    private static void CreateGarden()
    {
        var main = SceneManager.GetActiveScene();
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        SceneManager.SetActiveScene(scene);
        var root = new GameObject("AdditiveGarden");
        for (int i = 0; i < 3; i++)
        {
            var shape = Shape("GardenGem" + i, PrimitiveType.Sphere, new Vector3(-1 + i, .6f, -1.1f), Vector3.one * .55f, Material("CoralMaterial", Coral));
            shape.transform.SetParent(root.transform);
        }
        EditorSceneManager.SaveScene(scene, FrameworkTestPanel.TestScene);
        EditorSceneManager.CloseScene(scene, true); SceneManager.SetActiveScene(main);
    }
    private static Material Material(string name, Color color)
    {
        string path = "Assets/AssetBundle/Materials/" + name + ".mat";
        var material = AssetDatabase.LoadAssetAtPath<Material>(path);
        if (material == null) { material = new Material(Shader.Find("Standard")); AssetDatabase.CreateAsset(material, path); }
        material.color = color; material.SetFloat("_Glossiness", .3f); material.SetFloat("_Metallic", .05f); EditorUtility.SetDirty(material); return material;
    }
    private static GameObject Shape(string name, PrimitiveType type, Vector3 position, Vector3 scale, Material material)
    {
        var go = GameObject.Find(name) ?? GameObject.CreatePrimitive(type); go.name = name;
        go.transform.position = position; go.transform.localScale = scale; go.GetComponent<Renderer>().sharedMaterial = material; return go;
    }
    private static Image Image(Transform parent, string name, Vector2 min, Vector2 max, Color color)
    {
        var go = new GameObject(name, typeof(RectTransform), typeof(Image)); go.transform.SetParent(parent, false);
        var rect = go.GetComponent<RectTransform>(); rect.anchorMin = min; rect.anchorMax = max; rect.offsetMin = rect.offsetMax = Vector2.zero;
        var image = go.GetComponent<Image>(); image.color = color; image.raycastTarget = false; return image;
    }
    private static Text Label(Transform parent, string value, int size, Vector2 min, Vector2 max, Color color)
    {
        var go = new GameObject("Label", typeof(RectTransform), typeof(Text)); go.transform.SetParent(parent, false);
        var rect = go.GetComponent<RectTransform>(); rect.anchorMin = min; rect.anchorMax = max; rect.offsetMin = rect.offsetMax = Vector2.zero;
        var text = go.GetComponent<Text>(); text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf"); text.text = value; text.fontSize = size;
        text.color = color; text.alignment = TextAnchor.MiddleCenter; text.raycastTarget = false; return text;
    }
    private static Button Button(Transform parent, string label, Vector2 min, Vector2 max, Color color)
    {
        var image = Image(parent, label, min, max, color); image.raycastTarget = true;
        var button = image.gameObject.AddComponent<Button>(); button.targetGraphic = image;
        var colors = button.colors; colors.highlightedColor = new Color(1.15f, 1.15f, 1.15f); colors.pressedColor = new Color(.65f, .75f, .8f); button.colors = colors;
        Label(image.transform, label, 25, Vector2.zero, Vector2.one, Color.white); return button;
    }
}
