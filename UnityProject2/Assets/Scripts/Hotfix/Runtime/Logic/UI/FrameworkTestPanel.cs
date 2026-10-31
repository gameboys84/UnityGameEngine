using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TEngine;
namespace GameRuntime
{
    /// <summary>Demo controls call actual framework interfaces; the reusable framework has no demo dependency.</summary>
    public sealed class FrameworkTestPanel : MonoBehaviour
    {
        public const string TestScene = "Assets/AssetBundle/Scenes/TestGarden.unity";
        public Text title, description, output;
        public Button[] actions;
        public Button close, nested;
        public string Topic { get; private set; }
        public int TickCount { get; private set; }
        private int timerId;
        private GameObject spawned;
        private bool busy, sceneOwned;
        private CancellationToken token;
        private ITimerModule timer;
        private ISceneModule scenes;
        public void Configure(string topic, Action closeAction)
        {
            Topic = topic; token = this.GetCancellationTokenOnDestroy();
            timer = GameModule.Timer; scenes = GameModule.Scene;
            title.text = topic.ToUpperInvariant() + " LAB";
            description.text = topic == "Resource" ? "Load and release real package content." : topic == "Scene" ? "Add and remove a second scene." : topic == "Save" ? "Write and read a dedicated demo save." : topic == "Timer" ? "Start, pause, resume and cancel a timer." : "A child window loaded by the UI module.";
            string[] labels = topic == "Resource" ? new[] { "LOAD TEXT", "SPAWN OBJECT", "RELEASE OBJECT", "RESOURCE STATUS" } : topic == "Scene" ? new[] { "LOAD ADDITIVE", "UNLOAD SCENE", "SCENE STATUS", "ACTIVE SCENE" } : topic == "Save" ? new[] { "SAVE", "LOAD", "SAVE + LOAD", "SAVE LOCATION" } : topic == "Timer" ? new[] { "START", "PAUSE", "RESUME", "CANCEL" } : new[] { "WINDOW STATUS", "SHOW MESSAGE", "SCENE STATUS", "CLEAR RESULT" };
            for (int i = 0; i < actions.Length; i++)
            {
                int index = i; actions[i].GetComponentInChildren<Text>().text = labels[i];
                actions[i].onClick.AddListener(() => RunAsync(index).Forget());
            }
            close.onClick.AddListener(() => { if (!busy) closeAction(); });
            nested.gameObject.SetActive(topic != "UI");
            nested.onClick.AddListener(() => OpenChildAsync().Forget());
            output.text = "Choose an operation. Results appear here.";
        }
        private async UniTask OpenChildAsync()
        {
            try { await GameModule.UI.ShowUIAsyncAwait<DetailsTestWindow>(token, "Parent: " + Topic + " LAB"); }
            catch (OperationCanceledException) { }
            catch (Exception error) { if (this != null) output.text = "ERROR: " + error.Message; }
        }
        public async UniTask RunAsync(int index)
        {
            if (busy) return;
            busy = true; SetInteractable(false);
            try
            {
                if (Topic == "Resource")
                {
                    if (index == 0)
                    {
                        using (var lease = await new ResourceReference("Assets/AssetBundle/Config/startup-message.txt").LoadAsync<TextAsset>(token))
                            output.text = "PASS: LoadAssetAsync<TextAsset>\n" + lease.Asset.text + "\nReference released after reading.";
                    }
                    else if (index == 1)
                    {
                        if (spawned != null) { output.text = "Object already loaded. Release it first."; return; }
                        spawned = await GameModule.Resource.LoadGameObjectAsync("Assets/AssetBundle/Prefabs/FoundationMarker.prefab", cancellationToken: token);
                        if (token.IsCancellationRequested) { if (spawned != null) Destroy(spawned); spawned = null; return; }
                        if (spawned == null) throw new InvalidOperationException("Prefab load returned null.");
                        spawned.transform.position = new Vector3(1.8f, .8f, -.5f); spawned.transform.localScale = Vector3.one * .65f;
                        output.text = "PASS: LoadGameObjectAsync\nA second mint object is visible in the scene.";
                    }
                    else if (index == 2) { if (spawned != null) Destroy(spawned); spawned = null; output.text = "PASS: instance destroyed; its resource reference is released by TEngine."; }
                    else output.text = "Package: " + GameModule.Resource.DefaultPackageName + "\nVersion: " + GameModule.Resource.PackageVersion + "\nSpawned: " + (spawned != null);
                }
                else if (Topic == "Scene")
                {
                    if (index == 0)
                    {
                        if (sceneOwned) { output.text = "Test scene is already loaded."; return; }
                        var scene = await GameModule.Scene.LoadSceneAsync(TestScene, LoadSceneMode.Additive, gcCollect: false);
                        if (!scene.IsValid() || !scene.isLoaded) throw new InvalidOperationException("Additive scene did not load.");
                        if (token.IsCancellationRequested) { await scenes.UnloadAsync(TestScene); return; }
                        sceneOwned = true; output.text = "PASS: LoadSceneAsync(Additive)\nCoral objects added to the stage.";
                    }
                    else if (index == 1) { if (sceneOwned) { await GameModule.Scene.UnloadAsync(TestScene); sceneOwned = false; } output.text = "PASS: test scene unloaded; Main remains active."; }
                    else if (index == 2) output.text = "IsContainScene: " + GameModule.Scene.IsContainScene(TestScene);
                    else output.text = "Active: " + SceneManager.GetActiveScene().name + "\nLoaded scene count: " + SceneManager.sceneCount;
                }
                else if (Topic == "Save")
                {
                    if (index == 0 || index == 2)
                    {
                        var data = new DemoSaveData { stamp = DateTime.UtcNow.ToString("O"), number = UnityEngine.Random.Range(100, 999) };
                        await GameModule.LocalSave.SaveAsync("framework-demo.json", data, cancellationToken: token);
                        output.text = "PASS: SaveAsync\nValue: " + data.number;
                    }
                    if (index == 1 || index == 2)
                    {
                        var data = await GameModule.LocalSave.LoadAsync<DemoSaveData>("framework-demo.json", cancellationToken: token);
                        output.text = "PASS: LoadAsync\nValue: " + data.number + "\nSaved at: " + data.stamp;
                    }
                    if (index == 3) output.text = "Demo file only: framework-demo.json\n" + Application.persistentDataPath + "/LocalSave";
                }
                else if (Topic == "Timer")
                {
                    if (index == 0)
                    {
                        StopTimer(); TickCount = 0;
                        timerId = GameModule.Timer.AddTimer(_ => { ++TickCount; output.text = "PASS: timer callback\nTicks: " + TickCount; }, 1, true, true);
                        output.text = "Timer started. One callback per second.";
                    }
                    else if (index == 3) { StopTimer(); output.text = "PASS: RemoveTimer\nTicks: " + TickCount; }
                    else if (timerId == 0) output.text = "Start a timer first.";
                    else if (index == 1) { GameModule.Timer.Stop(timerId); output.text = "PASS: Stop (paused)\nTicks: " + TickCount; }
                    else { GameModule.Timer.Resume(timerId); output.text = "PASS: Resume"; }
                }
                else
                    output.text = index == 0 ? "PASS: HasWindow<DetailsTestWindow> = " + GameModule.UI.HasWindow<DetailsTestWindow>() : index == 1 ? "PASS: refreshed child result. Parent window is retained below." : index == 2 ? "Active scene: " + SceneManager.GetActiveScene().name : "Choose an operation.";
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { }
            catch (Exception error) { if (this != null) output.text = "ERROR: " + error.Message; }
            finally { busy = false; if (this != null) SetInteractable(true); }
        }
        private void SetInteractable(bool value) { foreach (var button in actions) button.interactable = value; close.interactable = value; nested.interactable = value; }
        private void StopTimer() { if (timerId != 0) timer.RemoveTimer(timerId); timerId = 0; }
        private void OnDestroy()
        {
            StopTimer(); if (spawned != null) Destroy(spawned);
            if (sceneOwned) CleanupSceneAsync().Forget();
        }
        private async UniTask CleanupSceneAsync()
        {
            try { await scenes.UnloadAsync(TestScene); }
            catch (Exception error) { Debug.LogWarning("Demo scene cleanup: " + error.Message); }
        }
    }
    [Serializable]
    public sealed class DemoSaveData : ILocalSaveData
    {
        public string stamp;
        public int number;
        public string Serialize() => JsonUtility.ToJson(this);
        public void Deserialize(string json) => JsonUtility.FromJsonOverwrite(json, this);
    }
}
