using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UniCli.Protocol;
using UniCli.Server.Editor.Handlers;
using UnityEditor;
using UnityEngine;

namespace DE.Bootstrap.Editor.Validation
{
    [Serializable]
    public sealed class DeLoginPortraitResult
    {
        public int width = 750, height = 1334, appliedViews;
        public bool createdPreset;
        public int[] selectedSizeIndices;
    }

    /// <summary>
    /// Unity 2022 equivalent of source OpenScene/Boot -> ResolutionXY(false).
    /// Uses the installed GameView/size-group API and never requests window focus.
    /// Player orientation remains the composition root's explicit project setting.
    /// </summary>
    public static class DeLoginPortrait
    {
        const BindingFlags All = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
        const int Width = 750, Height = 1334;

        [MenuItem("DE/Login/Original Portrait 750x1334")]
        public static void ApplyFromMenu() { Apply(); }

        public static DeLoginPortraitResult Apply()
        {
            if (EditorApplication.isCompiling) throw new InvalidOperationException("Wait for compilation before selecting the DE portrait view.");
            var assembly = typeof(EditorWindow).Assembly;
            var viewType = RequireType(assembly, "UnityEditor.GameView");
            var sizesType = RequireType(assembly, "UnityEditor.GameViewSizes");
            var sizeType = RequireType(assembly, "UnityEditor.GameViewSize");
            var kindType = RequireType(assembly, "UnityEditor.GameViewSizeType");
            var existing = UnityEngine.Resources.FindObjectsOfTypeAll(viewType);
            if (existing.Length == 0)
                throw new InvalidOperationException("No existing Game view was found. The portrait tool does not create or activate editor windows.");
            var singleton = sizesType.BaseType.GetProperty("instance", All);
            if (singleton == null) throw new MissingMemberException(sizesType.BaseType.FullName, "instance");
            var sizes = singleton.GetValue(null, null);
            var currentGroup = RequireProperty(viewType, "currentSizeGroupType");
            var selected = RequireProperty(viewType, "selectedSizeIndex");
            var callback = RequireMethod(viewType, "SizeSelectionCallback", typeof(int), typeof(object));
            var width = RequireProperty(sizeType, "width");
            var height = RequireProperty(sizeType, "height");
            var kind = RequireProperty(sizeType, "sizeType");
            var fixedResolution = Enum.Parse(kindType, "FixedResolution");
            var result = new DeLoginPortraitResult();
            var indices = new List<int>();
            foreach (var item in existing)
            {
                var view = item as EditorWindow;
                if (view == null) continue;
                var groupKind = currentGroup.GetValue(view, null);
                var group = RequireMethod(sizesType, "GetGroup", groupKind.GetType()).Invoke(sizes, new[] { groupKind });
                var groupType = group.GetType();
                var count = RequireMethod(groupType, "GetTotalCount");
                var getSize = RequireMethod(groupType, "GetGameViewSize", typeof(int));
                int targetIndex = -1;
                for (int index = 0, total = (int)count.Invoke(group, null); index < total; index++)
                {
                    var candidate = getSize.Invoke(group, new object[] { index });
                    if ((int)width.GetValue(candidate, null) == Width && (int)height.GetValue(candidate, null) == Height
                        && Equals(kind.GetValue(candidate, null), fixedResolution)) { targetIndex = index; break; }
                }
                if (targetIndex < 0)
                {
                    var constructor = sizeType.GetConstructor(All, null, new[] { kindType, typeof(int), typeof(int), typeof(string) }, null);
                    if (constructor == null) throw new MissingMethodException(sizeType.FullName, ".ctor(GameViewSizeType,int,int,string)");
                    var preset = constructor.Invoke(new object[] { fixedResolution, Width, Height, "DE Login Portrait" });
                    RequireMethod(groupType, "AddCustomSize", sizeType).Invoke(group, new[] { preset });
                    targetIndex = (int)count.Invoke(group, null) - 1;
                    result.createdPreset = true;
                }
                callback.Invoke(view, new object[] { targetIndex, null });
                if ((int)selected.GetValue(view, null) != targetIndex)
                    throw new InvalidOperationException("Unity did not select the requested DE portrait size.");
                view.Repaint();
                indices.Add(targetIndex); result.appliedViews++;
            }
            if (result.createdPreset) RequireMethod(sizesType, "SaveToHDD").Invoke(sizes, null);
            if (result.appliedViews == 0) throw new InvalidOperationException("No live Game view accepted the portrait setting.");
            result.selectedSizeIndices = indices.ToArray();
            return result;
        }

        static Type RequireType(Assembly assembly, string name)
            => assembly.GetType(name, false) ?? throw new TypeLoadException("Installed Unity Editor does not expose " + name);
        static PropertyInfo RequireProperty(Type type, string name)
            => type.GetProperty(name, All) ?? throw new MissingMemberException(type.FullName, name);
        static MethodInfo RequireMethod(Type type, string name, params Type[] parameters)
            => type.GetMethod(name, All, null, parameters, null) ?? throw new MissingMethodException(type.FullName, name);
    }

    public sealed class DeLoginPortraitCommand : CommandHandler<Unit, DeLoginPortraitResult>
    {
        public override string CommandName => "DE.Login.Portrait";
        public override string Description => "Select original DE 750x1334 portrait resolution on existing Game views without activating or focusing windows.";
        protected override ValueTask<DeLoginPortraitResult> ExecuteAsync(Unit request, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return new ValueTask<DeLoginPortraitResult>(DeLoginPortrait.Apply());
        }
    }
}
