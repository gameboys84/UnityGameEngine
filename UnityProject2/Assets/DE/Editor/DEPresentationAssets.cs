using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DE.Presentation.Editor
{
    public static class DEPresentationAssets
    {
        public const string ShellPath = "Assets/DE/Presentation/Resources/DE/Shell.prefab";

        [MenuItem("DE/Prepare Presentation Shell")]
        public static void Prepare()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ShellPath));
            var existing = AssetDatabase.LoadAssetAtPath<GameObject>(ShellPath);
            if (existing != null && existing.GetComponent<Canvas>() != null && existing.GetComponent<GraphicRaycaster>() != null) return;
            var shell = new GameObject("DE.Shell", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster));
            shell.layer = 5;
            PrefabUtility.SaveAsPrefabAsset(shell, ShellPath);
            Object.DestroyImmediate(shell);
            AssetDatabase.SaveAssets();
        }
    }
}
