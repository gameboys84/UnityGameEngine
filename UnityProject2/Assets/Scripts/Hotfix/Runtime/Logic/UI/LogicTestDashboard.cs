using System;
using GameCore;
using GameRuntime.LogicTests;
using UnityEngine;

namespace GameRuntime
{
    public sealed class LogicTestDashboard : MonoBehaviour
    {
        [Serializable] private sealed class SavedData : LocalSaveDataBase { public SettlementSnapshot State; public SavedData() {} }
        private SettlementSimulation simulation;
        private ServerClock clock;
        private long timeOffset, requestNumber;
        private bool visible;
        private string status = "Local authority test. No remote account or service is used.";
        private Rect window = new Rect(20, 60, 580, 540);
        private Vector2 scroll;
        private const string SaveName = "logic-test.json";
        public SettlementSimulation Model => simulation;
        public static void Attach(GameObject owner)
        {
            if (owner.GetComponent<LogicTestDashboard>() == null) owner.AddComponent<LogicTestDashboard>();
        }
        private OperationRule[] ReadRules()
        {
            var asset = Resources.Load<TextAsset>("LogicTests/Rules");
            if (asset == null) throw new InvalidOperationException("Logic test rules are missing.");
            return JsonUtility.FromJson<RuleCatalog>(asset.text).Rules;
        }
        private void Awake() { ResetSimulation(); }
        private void ResetSimulation()
        {
            timeOffset = 0;
            clock = new ServerClock(() => checked((long)(Time.realtimeSinceStartupAsDouble * 1000) + timeOffset));
            clock.Synchronize(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            simulation = new SettlementSimulation(ReadRules(), clock);
            simulation.Grant("seedFood", "Food", 5000);
            simulation.Grant("seedWood", "Wood", 5000);
            simulation.Grant("seedSpeedup", "Speedup", 100);
        }
        private string NextRequest() => Guid.NewGuid().ToString("N") + (++requestNumber);
        private void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width - 170, Screen.height - 44, 160, 34), "LOGIC TESTS")) visible = !visible;
            if (visible) window = GUI.Window(GetInstanceID(), window, DrawWindow, "Core and Business Logic Tests");
        }
        private void DrawWindow(int id)
        {
            try
            {
                GUILayout.Label(status);
                GUILayout.Label("Food " + simulation.GetBalance("Food") + "  Wood " + simulation.GetBalance("Wood") + "  Speedup " + simulation.GetBalance("Speedup") + "  Units " + simulation.GetBalance("Unit201"));
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Advance 10 seconds")) timeOffset = checked(timeOffset + 10000);
                if (GUILayout.Button("Confirm elapsed")) status = "Confirmed operations: " + simulation.ConfirmElapsed();
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Save")) { GameModule.LocalSave.Save(SaveName, new SavedData { State = simulation.Export() }); status = "Saved test state."; }
                if (GUILayout.Button("Load"))
                {
                    var data = GameModule.LocalSave.Load<SavedData>(SaveName);
                    if (data == null) status = "No saved state.";
                    else { simulation.Restore(data.State); status = "Restored test state."; }
                }
                if (GUILayout.Button("Reset")) { ResetSimulation(); status = "Reset test state."; }
                if (GUILayout.Button("Close")) visible = false;
                GUILayout.EndHorizontal();
                scroll = GUILayout.BeginScrollView(scroll);
                foreach (var rule in simulation.GetRules())
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(rule.Name + "  Level " + simulation.GetLevel(rule.Id), GUILayout.Width(300));
                    if (GUILayout.Button(rule.Kind == OperationKind.Training ? "Train 5" : "Build or upgrade"))
                        status = simulation.Start(NextRequest(), rule.Id, rule.Kind == OperationKind.Training ? 5 : 1).ToString();
                    GUILayout.EndHorizontal();
                }
                foreach (var action in simulation.GetActions())
                {
                    var operation = action.Operation;
                    GUILayout.Label(operation.Group + "  " + operation.EntityId + "  Remaining " + operation.Remaining(simulation.NowMilliseconds) + " ms");
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("Speed up 2 seconds")) status = "Accelerated: " + simulation.SpeedUp(NextRequest(), operation.Id, 2000);
                    if (GUILayout.Button("Cancel with half refund")) status = "Cancelled: " + simulation.Cancel(operation.Id);
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndScrollView();
            }
            catch (Exception error) { status = error.Message; }
            GUI.DragWindow(new Rect(0, 0, 10000, 20));
        }
    }
}
