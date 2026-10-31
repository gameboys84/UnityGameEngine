using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset.Editor;

/// <summary>Creates isolated foundation fixtures through Unity's asset APIs, without game content.</summary>
public static class FoundationValidationAssets
{
    [MenuItem("TEngine/Validation/Prepare Foundation Assets")]
    public static void Prepare()
    {
        const string folder = "Assets/Validation/Foundation";
        if (!AssetDatabase.IsValidFolder("Assets/Validation")) AssetDatabase.CreateFolder("Assets", "Validation");
        if (!AssetDatabase.IsValidFolder(folder)) AssetDatabase.CreateFolder("Assets/Validation", "Foundation");
        string textPath = folder + "/foundation-text.txt";
        if (!File.Exists(textPath)) File.WriteAllText(textPath, "foundation-resource-ok");
        AssetDatabase.ImportAsset(textPath);
        string prefabPath = folder + "/foundation-prefab.prefab";
        if (!File.Exists(prefabPath))
        {
            var instance = new GameObject("FoundationPrefab");
            PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);
            Object.DestroyImmediate(instance);
        }
        string scenePath = folder + "/FoundationAdditive.unity";
        if (!File.Exists(scenePath))
        {
            var active = SceneManager.GetActiveScene();
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            var marker = new GameObject("FoundationSceneMarker");
            SceneManager.MoveGameObjectToScene(marker, scene);
            EditorSceneManager.SaveScene(scene, scenePath);
            EditorSceneManager.CloseScene(scene, true);
            SceneManager.SetActiveScene(active);
        }
        var setting = AssetBundleCollectorSettingData.Setting;
        if (!setting.Packages.Exists(package => package.PackageName == "FoundationValidation"))
        {
            var package = new AssetBundleCollectorPackage { PackageName = "FoundationValidation", EnableAddressable = true };
            var group = new AssetBundleCollectorGroup { GroupName = "FoundationValidation" };
            group.Collectors.Add(new AssetBundleCollector { CollectPath = folder, CollectorGUID = AssetDatabase.AssetPathToGUID(folder) });
            package.Groups.Add(group);
            setting.Packages.Add(package);
            AssetBundleCollectorSettingData.SaveFile();
        }
        AssetDatabase.SaveAssets();
        Debug.Log("Foundation validation assets prepared.");
    }
}
