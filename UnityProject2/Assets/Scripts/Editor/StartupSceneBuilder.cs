using System;
using System.IO;
using System.Linq;
using GameRuntime;
using Launcher;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YooAsset.Editor;

/// <summary>Creates the initial project assets using Unity APIs; never overwrites authored scenes.</summary>
public static class StartupSceneBuilder
{
    public const string LauncherScene = "Assets/Launcher/Scenes/Launcher.unity";
    public const string MainScene = "Assets/AssetBundle/Scenes/Main.unity";
    private static readonly Color Background = new Color(.035f, .055f, .09f);
    private static readonly Color Accent = new Color(.25f, .86f, .68f);

    [MenuItem("TEngine/Startup/Create Startup Assets")]
    public static void Create()
    {
        if (EditorApplication.isPlaying) throw new InvalidOperationException("Stop play mode first.");
        if (File.Exists(LauncherScene) || File.Exists(MainScene)) throw new InvalidOperationException("Startup scenes already exist; open them instead of overwriting.");
        foreach (var path in new[] { "Assets/Launcher/Scenes", "Assets/Launcher/Prefabs", "Assets/Launcher/Settings", "Assets/AssetBundle/Scenes", "Assets/AssetBundle/Config", "Assets/AssetBundle/Prefabs" })
            Directory.CreateDirectory(path);
        File.WriteAllText("Assets/AssetBundle/Config/startup-message.txt", "Your game is ready.\nScene and content loaded successfully.");
        AssetDatabase.Refresh();
        var settings = ScriptableObject.CreateInstance<StartupSettings>();
        AssetDatabase.CreateAsset(settings, "Assets/Launcher/Settings/StartupSettings.asset");
        var active = SceneManager.GetActiveScene();
        var nativeScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        SceneManager.SetActiveScene(nativeScene);
        var entry = new GameObject("GameEntry").AddComponent<GameEntry>();
        entry.settings = settings;
        var native = Canvas("Launcher", null);
        native.GetComponent<Canvas>().sortingOrder = 10000;
        var view = native.AddComponent<LauncherView>();
        Panel("Background", native.transform, Background, new Vector2(0, 0), new Vector2(1, 1));
        Label(native.transform, "MY UNITY FRAMEWORK", 22, .78f, new Color(.6f, .7f, .78f));
        Label(native.transform, "A NEW BEGINNING", 52, .62f, Color.white);
        Label(native.transform, "Preparing your next experience", 24, .55f, new Color(.65f, .75f, .83f));
        view.status = Label(native.transform, "Ready to launch", 25, .35f, Color.white);
        CreateProgressBar(view);
        view.percentage = Label(native.transform, "0%", 22, .24f, Accent);
        var retryImage = Panel("Retry", native.transform, Accent, new Vector2(.35f, .12f), new Vector2(.65f, .18f));
        view.retry = retryImage.gameObject.AddComponent<Button>();
        view.retry.targetGraphic = retryImage;
        retryImage.raycastTarget = true;
        Label(retryImage.transform, "TRY AGAIN", 23, .5f, Background);
        view.retry.gameObject.SetActive(false);
        var prefab = PrefabUtility.SaveAsPrefabAsset(native, "Assets/Launcher/Prefabs/LauncherView.prefab");
        UnityEngine.Object.DestroyImmediate(native);
        var instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, nativeScene);
        instance.transform.SetParent(entry.transform, false);
        entry.launcher = instance.GetComponent<LauncherView>();
        var events = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        events.transform.SetParent(entry.transform, false);
        Camera("LauncherCamera", new Vector3(0, 0, -10), Vector3.zero);
        EditorSceneManager.SaveScene(nativeScene, LauncherScene);
        EditorSceneManager.CloseScene(nativeScene, true);

        var main = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        SceneManager.SetActiveScene(main);
        var root = new GameObject("UIRoot");
        var canvas = Canvas("Canvas", root.transform);
        var flow = new GameObject("MainFlow").AddComponent<MainSceneView>();
        Label(canvas.transform, "WELCOME", 24, .88f, Accent);
        Label(canvas.transform, "ENTERED THE GAME", 46, .81f, Color.white);
        flow.message = Label(canvas.transform, "Waiting for game entry", 23, .72f, new Color(.7f, .8f, .85f));
        Label(canvas.transform, "Foundation demo  /  Ready for the next chapter", 20, .08f, new Color(.6f, .7f, .78f));
        var camera = Camera("MainCamera", new Vector3(6, 5, -8), new Vector3(0, 0, 0));
        camera.tag = "MainCamera";
        var light = new GameObject("Sun").AddComponent<Light>();
        light.type = LightType.Directional; light.intensity = 1.2f;
        light.transform.rotation = Quaternion.Euler(45, -30, 0);
        var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "FoundationPlatform"; floor.transform.localScale = new Vector3(5, .25f, 5);
        var marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        marker.name = "FoundationMarker"; marker.transform.position = new Vector3(0, 1, 0);
        marker.transform.rotation = Quaternion.Euler(0, 35, 0);
        var material = new Material(Shader.Find("Standard")) { color = Accent };
        AssetDatabase.CreateAsset(material, "Assets/AssetBundle/Prefabs/FoundationMarkerMaterial.mat");
        marker.GetComponent<Renderer>().sharedMaterial = material;
        var markerPrefab = PrefabUtility.SaveAsPrefabAsset(marker, "Assets/AssetBundle/Prefabs/FoundationMarker.prefab");
        UnityEngine.Object.DestroyImmediate(marker);
        PrefabUtility.InstantiatePrefab(markerPrefab, main);
        EditorSceneManager.SaveScene(main, MainScene);
        EditorSceneManager.CloseScene(main, true);
        SceneManager.SetActiveScene(active);

        var setting = AssetBundleCollectorSettingData.Setting;
        // Existing imported sample collectors reference assets absent from this project.
        var package = setting.Packages.Find(p => p.PackageName == settings.packageName);
        if (package == null) { package = new AssetBundleCollectorPackage { PackageName = settings.packageName }; setting.Packages.Add(package); }
        package.EnableAddressable = true;
        package.Groups.Clear();
        var group = new AssetBundleCollectorGroup { GroupName = "GameContent" };
        group.Collectors.Add(new AssetBundleCollector { CollectPath = "Assets/AssetBundle", CollectorGUID = AssetDatabase.AssetPathToGUID("Assets/AssetBundle") });
        package.Groups.Add(group);
        AssetBundleCollectorSettingData.SaveFile();
        var other = EditorBuildSettings.scenes.Where(s => s.path != LauncherScene && s.path != MainScene).ToArray();
        EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(LauncherScene, true) }.Concat(other).ToArray();
        AssetDatabase.SaveAssets();
        EditorSceneManager.OpenScene(LauncherScene);
        Debug.Log("Startup assets created. Press Play in Launcher to enter Main through YooAsset.");
    }

    [MenuItem("TEngine/Startup/Configure Native UI")]
    public static void ConfigureNativeUI()
    {
        const string path = "Assets/Launcher/Prefabs/LauncherView.prefab";
        var go = PrefabUtility.LoadPrefabContents(path);
        try
        {
            var view = go.GetComponent<LauncherView>();
            view.retry.targetGraphic.raycastTarget = true;
            var old = go.transform.Find("ProgressTrack");
            if (old != null) UnityEngine.Object.DestroyImmediate(old.gameObject);
            var existing = go.transform.Find("ProgressBar");
            if (existing != null) UnityEngine.Object.DestroyImmediate(existing.gameObject);
            CreateProgressBar(view);
            PrefabUtility.SaveAsPrefabAsset(go, path);
        }
        finally { PrefabUtility.UnloadPrefabContents(go); }
    }

    private static void CreateProgressBar(LauncherView view)
    {
        var go = new GameObject("ProgressBar", typeof(RectTransform), typeof(CanvasRenderer), typeof(RoundedProgressBar));
        go.transform.SetParent(view.transform, false);
        var rect = go.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(.15f, .295f); rect.anchorMax = new Vector2(.85f, .295f);
        rect.sizeDelta = new Vector2(0, 18); rect.anchoredPosition = Vector2.zero;
        view.progressBar = go.GetComponent<RoundedProgressBar>();
        view.progressBar.color = Accent; view.progressBar.raycastTarget = false;
        view.progressBar.SetProgress(0, true);
    }

    private static GameObject Canvas(string name, Transform parent)
    {
        var go = new GameObject(name, typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        go.transform.SetParent(parent, false);
        go.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        var scaler = go.GetComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1080, 1920); scaler.matchWidthOrHeight = .5f;
        return go;
    }
    private static Image Panel(string name, Transform parent, Color color, Vector2 min, Vector2 max)
    {
        var go = new GameObject(name, typeof(RectTransform), typeof(Image)); go.transform.SetParent(parent, false);
        var rect = go.GetComponent<RectTransform>(); rect.anchorMin = min; rect.anchorMax = max; rect.offsetMin = rect.offsetMax = Vector2.zero;
        var image = go.GetComponent<Image>(); image.color = color; image.raycastTarget = false; return image;
    }
    private static Text Label(Transform parent, string value, int size, float y, Color color)
    {
        var go = new GameObject(value.Split('\n')[0], typeof(RectTransform), typeof(Text)); go.transform.SetParent(parent, false);
        var rect = go.GetComponent<RectTransform>(); rect.anchorMin = new Vector2(.08f, y - .035f); rect.anchorMax = new Vector2(.92f, y + .035f); rect.offsetMin = rect.offsetMax = Vector2.zero;
        var text = go.GetComponent<Text>(); text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.text = value; text.fontSize = size; text.color = color; text.alignment = TextAnchor.MiddleCenter; text.raycastTarget = false;
        return text;
    }
    private static GameObject Camera(string name, Vector3 position, Vector3 target)
    {
        var go = new GameObject(name, typeof(Camera)); go.transform.position = position; go.transform.LookAt(target);
        var camera = go.GetComponent<Camera>(); camera.clearFlags = CameraClearFlags.SolidColor; camera.backgroundColor = Background;
        return go;
    }
}
