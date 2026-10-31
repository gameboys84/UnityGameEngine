using DE.Presentation.LegacyUI;
using UnityEngine;
using UnityEngine.UI;

// Original serialized fields/GUID retained. Serialized background ownership remains with the parent asset lease.
[RequireComponent(typeof(RawImage))]
public sealed class LoadingBG : MonoBehaviour
{
    public bool isPortrait = true;
    public int resourceIndex;

    public void SetBGPath(string path, bool portrait, int index = 0)
    {
        var image = GetComponent<RawImage>();
        var configuration = LegacyLoadingContext.Current;
        if (configuration == null) throw new System.InvalidOperationException("Real loading configuration is required.");
        if (configuration.SplashOverride != null) { image.texture = configuration.SplashOverride; image.uvRect = new Rect(0, 0, 1, 1); }
        if (image.texture == null) throw new System.InvalidOperationException("Original DE Splash texture is missing: " + path);
        isPortrait = portrait; resourceIndex = index;
    }

    public static Rect GetUV(bool portrait, int index)
    {
        const int minimum = 1024, maximum = 1820, size = 2048;
        float aspect = Mathf.Min(Screen.width, Screen.height) / (float)Mathf.Max(1, Mathf.Max(Screen.width, Screen.height));
        int h = minimum, w = maximum;
        if (aspect > 9f / 16f) w = (int)(h / aspect); else h = (int)(w * aspect);
        if (portrait) { int temporary = h; h = w; w = temporary; }
        if (portrait)
        {
            float x = (index == 0 ? 0 : .5f) + (minimum - w) * .5f / size;
            float y = 1 - (maximum + h - (Mathf.Approximately(aspect, .75f) ? 155 : 0)) * .5f / size;
            return new Rect(x, y, w / (float)size, h / (float)size);
        }
        return new Rect((maximum - w) * .5f / size, 1 - (minimum + h) * .5f / size - (index == 0 ? 0 : .5f), w / (float)size, h / (float)size);
    }
}
