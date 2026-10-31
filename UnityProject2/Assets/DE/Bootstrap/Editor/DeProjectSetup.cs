using System;
using System.IO;
using DE.Production.Runtime;
using Launcher;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DE.Bootstrap.Editor
{
    public static class DeProjectSetup
    {
        public const string MainScene = "Assets/AssetBundle/DE/Scenes/DEBoot.unity";
        public const string SettingsPath = "Assets/DE/Production/Resources/DE/ProductionBootSettings.asset";
        public const string LoadingPrefab = "Assets/AssetBundle/DE/Legacy/Loading/LoadingScreenSplash.prefab";

        [MenuItem("DE/Prepare Production Project")]
        public static void Prepare()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) throw new InvalidOperationException("Stop Play Mode before preparing DE.");
            if (AssetDatabase.LoadAssetAtPath<GameObject>(LoadingPrefab) == null) throw new InvalidOperationException("The authentic DE loading asset dependency closure has not been imported.");
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath));
            var settings = AssetDatabase.LoadAssetAtPath<DeProductionBootSettings>(SettingsPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<DeProductionBootSettings>();
                AssetDatabase.CreateAsset(settings, SettingsPath);
            }
            Directory.CreateDirectory(Path.GetDirectoryName(MainScene));
            var scene = File.Exists(MainScene) ? EditorSceneManager.OpenScene(MainScene, OpenSceneMode.Additive) : EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            SceneManager.SetActiveScene(scene);
            DeProductionRuntimeHost runtime = null;
            foreach (var root in scene.GetRootGameObjects()) { runtime = root.GetComponentInChildren<DeProductionRuntimeHost>(); if (runtime != null) break; }
            if (runtime == null) runtime = new GameObject("DE Production Runtime").AddComponent<DeProductionRuntimeHost>();
            var serialized = new SerializedObject(runtime);
            serialized.FindProperty("settings").objectReferenceValue = settings;
            serialized.ApplyModifiedPropertiesWithoutUndo();
            bool hasCamera = false, hasLight = false;
            foreach (var root in scene.GetRootGameObjects()) { hasCamera |= root.GetComponentInChildren<Camera>() != null; hasLight |= root.GetComponentInChildren<Light>() != null; }
            if (!hasCamera)
            {
                var camera = new GameObject("DE Bootstrap Camera").AddComponent<Camera>();
                camera.tag = "MainCamera"; camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = Color.black; camera.transform.position = new Vector3(0, 0, -10);
            }
            if (!hasLight) { var light = new GameObject("DE Bootstrap Light").AddComponent<Light>(); light.type = LightType.Directional; light.intensity = 1; }
            EditorSceneManager.SaveScene(scene, MainScene);
            EditorSceneManager.CloseScene(scene, true);
            var legacySettings = AssetDatabase.LoadAssetAtPath<StartupSettings>("Assets/Launcher/Settings/StartupSettings.asset");
            if (legacySettings != null)
            {
                legacySettings.mainScene = MainScene;
                legacySettings.gameEntryType = "DE.Bootstrap.DeGameEntry, DE.Bootstrap";
                EditorUtility.SetDirty(legacySettings);
            }
            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(MainScene, true) };
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.Portrait;
            PlayerSettings.defaultScreenWidth = 750;
            PlayerSettings.defaultScreenHeight = 1334;
            PlayerSettings.bundleVersion = settings.clientVersion;
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorSceneManager.OpenScene(MainScene);
            Debug.Log("DE production entry configured: original source assets and actual development protocol. No prototype bootstrap is used.");
        }
    }
}
