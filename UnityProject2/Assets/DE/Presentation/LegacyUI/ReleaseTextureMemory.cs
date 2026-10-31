using UnityEngine;
using UnityEngine.UI;

public enum ReleaseMethod { Image, RawImage, None }

// Original field/GUID retained. Resources.UnloadAsset would invalidate shared YooAsset dependencies.
// ProductionLoadingView owns the source lease, so this component releases only this instance's visual reference.
public sealed class ReleaseTextureMemory : MonoBehaviour
{
    public ReleaseMethod m_method = ReleaseMethod.Image;
    void OnDestroy()
    {
        if (m_method == ReleaseMethod.Image) { var image = GetComponent<Image>(); if (image != null) image.sprite = null; }
        else if (m_method == ReleaseMethod.RawImage) { var image = GetComponent<RawImage>(); if (image != null) image.texture = null; }
    }
}
