using UnityEngine;
using UnityEngine.UI;

namespace Launcher
{
    /// <summary>Procedural pill geometry with a fixed corner radius; no stretched sprite.</summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public sealed class RoundedProgressBar : MaskableGraphic
    {
        [SerializeField, Range(0, 1)] private float progress;
        [SerializeField] private Color trackColor = new Color(.10f, .16f, .21f);
        private float target;
        public float Progress => progress;
        public void SetProgress(float value, bool immediate = false)
        {
            target = Mathf.Clamp01(value);
            if (immediate || !Application.isPlaying) { progress = target; SetVerticesDirty(); }
        }
        private void Update()
        {
            if (!Application.isPlaying || Mathf.Approximately(progress, target)) return;
            progress = Mathf.MoveTowards(progress, target, Time.unscaledDeltaTime * 1.8f);
            SetVerticesDirty();
        }
        protected override void OnPopulateMesh(VertexHelper mesh)
        {
            mesh.Clear();
            var rect = GetPixelAdjustedRect();
            AddPill(mesh, rect, trackColor);
            const float inset = 2;
            var inner = new Rect(rect.x + inset, rect.y + inset, Mathf.Max(0, rect.width - inset * 2), Mathf.Max(0, rect.height - inset * 2));
            inner.width *= progress;
            if (inner.width > .1f) AddPill(mesh, inner, color);
        }
        private static void AddPill(VertexHelper mesh, Rect rect, Color tint)
        {
            if (rect.width <= 0 || rect.height <= 0) return;
            float radius = Mathf.Min(rect.height * .5f, rect.width * .5f);
            int start = mesh.currentVertCount;
            mesh.AddVert(rect.center, tint, Vector2.zero);
            const int segments = 8;
            for (int corner = 0; corner < 4; corner++)
            {
                var center = new Vector2(corner < 2 ? rect.xMax - radius : rect.xMin + radius,
                    corner == 0 || corner == 3 ? rect.yMax - radius : rect.yMin + radius);
                float firstAngle = 90 - corner * 90;
                for (int i = 0; i <= segments; i++)
                {
                    float radians = (firstAngle - 90f * i / segments) * Mathf.Deg2Rad;
                    mesh.AddVert(center + new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius, tint, Vector2.zero);
                }
            }
            int count = 4 * (segments + 1);
            for (int i = 0; i < count; i++) mesh.AddTriangle(start, start + 1 + i, start + 1 + (i + 1) % count);
        }
    }
}
