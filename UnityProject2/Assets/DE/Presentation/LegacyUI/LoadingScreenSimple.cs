using System;
using DE.Presentation.LegacyUI;
using UnityEngine;
using UnityEngine.UI;

// Serialized contract retained from Assets/Scripts/UINew/LoadingScreenSimple.cs (original .meta GUID preserved).
public sealed class LoadingScreenSimple : MonoBehaviour
{
    public Slider loading;
    public Text txtLoading, percent, txtLoadingDLC, percentDLC;
    public LoadingBG splashBG;
    public RectTransform logoTsf, loadingBarBG;
    public Transform loadingEffect;
    public static LoadingScreenSimple ins;
    public Text m_txtTip;
    public bool IsInitialized { get; private set; }
    readonly Vector3[] corners = new Vector3[4];
    Color normalColor;
    float tipElapsed;

    void Awake()
    {
        if (LegacyLoadingContext.Current == null) throw new InvalidOperationException("Real loading services are required.");
        if (loading == null || txtLoading == null || percent == null || splashBG == null)
            throw new InvalidOperationException("Original DE loading field references are incomplete.");
        ins = this; normalColor = txtLoading.color;
        splashBG.SetBGPath("UI/LoadingBG/Splash", true);
        // Source SetLogoPos uses DeviceRelated's portrait design scale (750x1334).
        if (logoTsf != null)
        {
            var sourcePosition = logoTsf.anchoredPosition3D;
            float sourceScale = Mathf.Min(Screen.width / 750f, Screen.height / 1334f);
            logoTsf.anchoredPosition3D = sourcePosition * sourceScale;
        }
        if (m_txtTip != null) m_txtTip.gameObject.SetActive(false);
        IsInitialized = true;
    }

    public void LoadTip()
    {
        if (m_txtTip == null) return;
        string tip = GetNextTip(); m_txtTip.text = tip;
        m_txtTip.gameObject.SetActive(!string.IsNullOrEmpty(tip));
    }
    // Tip selection/persistence belongs to the real account/config service supplied by the composition root.
    public void SaveTip(int hqlv) { throw new NotSupportedException("Account-specific loading tip persistence has not been migrated. Do not treat a visual load as game-state completion."); }
    public string GetNextTip() => LegacyLoadingContext.Current?.NextTip?.Invoke() ?? "";
    void Update() { tipElapsed += Time.unscaledDeltaTime; if (tipElapsed >= 10) { tipElapsed = 0; LoadTip(); } }
    void OnDestroy() { if (ins == this) ins = null; }

    public void SetLoadingView(bool dlc)
    {
        if (txtLoading != null) txtLoading.gameObject.SetActive(!dlc);
        if (percent != null) percent.gameObject.SetActive(!dlc);
        if (txtLoadingDLC != null) txtLoadingDLC.gameObject.SetActive(dlc);
        if (percentDLC != null) percentDLC.gameObject.SetActive(dlc);
    }

    public void SetLoadingPercentage(float progress, string dlctext, string dlcnum)
    {
        if (float.IsNaN(progress) || float.IsInfinity(progress)) throw new ArgumentOutOfRangeException(nameof(progress));
        loading.value = Mathf.Clamp01(progress * .01f);
        percent.text = Mathf.Clamp(progress, 0, 100).ToString("0.#") + "%";
        if (txtLoadingDLC != null) txtLoadingDLC.text = dlctext;
        if (percentDLC != null) percentDLC.text = dlcnum;
        if (loadingBarBG != null && loadingEffect != null)
        {
            loadingBarBG.GetWorldCorners(corners); loadingEffect.position = (corners[2] + corners[3]) * .5f;
        }
    }

    public void SetRuntimeStatus(string stage, float? progress, bool failure)
    {
        SetLoadingView(false);
        if (txtLoading is TextCustom localized) localized.RuntimeControlled = true;
        txtLoading.text = stage ?? ""; txtLoading.color = failure ? new Color(1, .37f, .28f) : normalColor;
        if (progress.HasValue)
        {
            SetLoadingPercentage(progress.Value, "", "");
            // Source layout places the short loading label immediately before the percentage.
            // This login-only flow keeps the screen after completion; prefer its completion label
            // over a simultaneous three-digit percentage without changing the original geometry.
            if (progress.Value >= 100f && !string.IsNullOrEmpty(stage)) percent.gameObject.SetActive(false);
        }
        else percent.text = ""; // Network authentication has no measurable percentage; do not invent one.
    }
}
