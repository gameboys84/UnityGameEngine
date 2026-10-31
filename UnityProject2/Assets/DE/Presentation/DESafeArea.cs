using UnityEngine;

namespace DE.Presentation
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class DESafeArea : MonoBehaviour
    {
        Rect previous;
        Vector2 size;
        void Update()
        {
            Rect area = Screen.safeArea;
            var screen = new Vector2(Screen.width, Screen.height);
            if (screen.x <= 0 || screen.y <= 0 || (previous == area && size == screen)) return;
            previous = area; size = screen;
            var rect = (RectTransform)transform;
            rect.anchorMin = new Vector2(area.xMin / screen.x, area.yMin / screen.y);
            rect.anchorMax = new Vector2(area.xMax / screen.x, area.yMax / screen.y);
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }
    }
}
