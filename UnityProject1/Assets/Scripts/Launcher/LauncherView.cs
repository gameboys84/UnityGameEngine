using UnityEngine;
using UnityEngine.UI;
namespace Launcher
{
    public sealed class LauncherView : MonoBehaviour
    {
        public Text status;
        public Text percentage;
        public RoundedProgressBar progressBar;
        public Button retry;
        public bool RetryRequested { get; private set; }
        private void Awake() { retry.onClick.AddListener(() => RetryRequested = true); progressBar.SetProgress(0, true); }
        public void Show(string message, float progress)
        {
            RetryRequested = false;
            retry.gameObject.SetActive(false);
            status.text = message;
            progressBar.SetProgress(progress);
            percentage.text = $"{Mathf.RoundToInt(Mathf.Clamp01(progress) * 100)}%";
        }
        public void ShowError()
        {
            status.text = "Unable to start. Please check your connection or game files.";
            retry.gameObject.SetActive(true);
            RetryRequested = false;
        }
        public void Hide() { gameObject.SetActive(false); }
    }
}
