using System;
using DE.Presentation.LegacyUI;
using UnityEngine;
using UnityEngine.UI;

// Original CommonMsgBox controller identity, fields and persistent button method names are retained.
public sealed class UPopMsgBoxLoginCommon : MonoBehaviour
{
    public Text title, content, okTxt, noTxt, yesTxt;
    public GameObject btn_yes, btn_no, btn_ok;
    public delegate void OnButtonClicked();
    OnButtonClicked onYesOrOk, onNo;
    Action close;
    bool onTapCloseUI = true, consumed;

    public void BindClose(Action onClose) { close = onClose ?? throw new ArgumentNullException(nameof(onClose)); }
    public void ValidateBindings()
    {
        if (title == null || content == null || okTxt == null || noTxt == null || yesTxt == null
            || btn_yes == null || btn_no == null || btn_ok == null)
            throw new InvalidOperationException("Original DE CommonMsgBox serialized bindings are incomplete.");
        if (btn_yes.GetComponent<Button>() == null || btn_no.GetComponent<Button>() == null || btn_ok.GetComponent<Button>() == null)
            throw new InvalidOperationException("Original DE CommonMsgBox buttons were not preserved.");
    }

    public void ShowMsgBox(int msgType, string strTitle, string strContent, OnButtonClicked onBtn,
        OnButtonClicked onBtnNO, string btnYesOrOkTxt = "", string btnNoTxt = "", bool tapCloseUI = true)
    {
        ValidateBindings();
        if (msgType != 1 && msgType != 2) throw new ArgumentOutOfRangeException(nameof(msgType));
        btn_yes.SetActive(false); btn_no.SetActive(false); btn_ok.SetActive(false);
        SetText(title, strTitle); SetText(content, strContent);
        onYesOrOk = onBtn; onNo = onBtnNO; onTapCloseUI = tapCloseUI; consumed = false;
        if (msgType == 2)
        {
            btn_yes.SetActive(true); btn_no.SetActive(true);
            SetText(yesTxt, string.IsNullOrEmpty(btnYesOrOkTxt) ? LegacyLoadingContext.Localize("LC_COMMON_Yes") : btnYesOrOkTxt);
            SetText(noTxt, string.IsNullOrEmpty(btnNoTxt) ? LegacyLoadingContext.Localize("LC_COMMON_No") : btnNoTxt);
        }
        else
        {
            btn_ok.SetActive(true);
            SetText(okTxt, string.IsNullOrEmpty(btnYesOrOkTxt) ? LegacyLoadingContext.Localize("LC_COMMON_Ok") : btnYesOrOkTxt);
        }
    }

    public void OnButtonYes() { Complete(true); }
    public void OnButtonOK() { Complete(true); }
    public void OnButtonNo() { Complete(false); }
    public void ClearCallbacks() { onYesOrOk = null; onNo = null; consumed = true; }

    void Complete(bool affirmative)
    {
        if (consumed || !isActiveAndEnabled) return;
        var callback = affirmative ? onYesOrOk : onNo;
        ClearCallbacks();
        // Close this attempt before invoking retry: its callback may synchronously show a new failure panel.
        if (onTapCloseUI) close?.Invoke();
        callback?.Invoke();
    }
    void OnDestroy() { ClearCallbacks(); close = null; }
    static void SetText(Text target, string value)
    {
        if (target is TextCustom localized) localized.RuntimeControlled = true;
        target.text = value ?? "";
    }
}
