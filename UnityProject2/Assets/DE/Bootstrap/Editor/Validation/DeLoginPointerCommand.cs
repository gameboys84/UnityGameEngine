using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DE.Bootstrap.Validation;
using DE.Presentation.LegacyUI;
using DE.Production.Runtime;
using UniCli.Server.Editor.Handlers;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DE.Bootstrap.Editor.Validation
{
    [Serializable]
    public sealed class DeLoginClickRequest
    {
        public string action;
    }

    [Serializable]
    public sealed class DeLoginClickResult
    {
        public string action, buttonPath, firstRaycastPath, clickHandlerPath, phaseBefore, phaseAfter;
        public string stage, errorStage, errorType, errorStack, cleanupErrors;
        public string currentModuleBefore, currentModuleDuringRaycast, currentModuleAfter;
        public float screenX, screenY;
        public int expectedPersistentListeners;
        public bool success, clicked, downProcessed, upAttempted, upProcessed, inputRestored, focusRestored, moduleRestored;
        public bool moduleTemporarilyActivated, dialogVisibleBefore, dialogVisibleAfter, isLoginComplete;
    }

    public sealed class DeLoginPointerCommand : CommandHandler<DeLoginClickRequest, DeLoginClickResult>
    {
        public override string CommandName => "DE.Login.Click";
        public override string Description => "Validate and click the original retry/cancel through StandaloneInputModule; returns explicit success and stage/stack diagnostics, never direct button callbacks or OS focus changes.";

        protected override ValueTask<DeLoginClickResult> ExecuteAsync(DeLoginClickRequest request, CancellationToken token)
        {
            var result = new DeLoginClickResult { stage = "ValidateRequest" };
            DeProductionRuntimeHost runtime = null;
            ProductionLoadingView view = null;
            EventSystem events = null;
            StandaloneInputModule module = null;
            DeLoginPointerInput input = null;
            BaseInput oldInput = null;
            BaseInputModule oldModule = null;
            GameObject oldSelection = null;
            FieldInfo focus = null;
            MethodInfo changeModule = null;
            bool oldFocus = false, captured = false, downAttempted = false;
            try
            {
                token.ThrowIfCancellationRequested();
                if (!EditorApplication.isPlaying || EditorApplication.isCompiling)
                    throw new InvalidOperationException("A running compiled Editor Play session is required.");
                string action = request?.action?.Trim().ToLowerInvariant();
                result.action = action;
                if (action != "retry" && action != "cancel") throw new ArgumentException("action must be retry or cancel.");
                result.stage = "ValidateProductionView";
                runtime = DeProductionRuntimeHost.Current;
                var views = UnityEngine.Object.FindObjectsOfType<ProductionLoadingView>();
                if (runtime == null || views.Length != 1) throw new InvalidOperationException("Exactly one genuine loading view is required.");
                view = views[0];
                result.phaseBefore = runtime.Phase;
                result.dialogVisibleBefore = view.FailureDialogVisible;
                if (!result.dialogVisibleBefore || view.OriginalFailurePanel == null)
                    throw new InvalidOperationException("The original login failure dialog is not visible.");

                result.stage = "ValidateOriginalButton";
                var panel = view.OriginalFailurePanel;
                var target = action == "retry" ? panel.btn_yes : panel.btn_no;
                var button = target == null ? null : target.GetComponent<Button>();
                if (button == null || !button.isActiveAndEnabled || !button.IsInteractable())
                    throw new InvalidOperationException("Original dialog button is not active and interactable.");
                result.buttonPath = Path(target.transform);
                string expectedMethod = action == "retry" ? "OnButtonYes" : "OnButtonNo";
                for (int i = 0; i < button.onClick.GetPersistentEventCount(); i++)
                    if (button.onClick.GetPersistentTarget(i) == panel && button.onClick.GetPersistentMethodName(i) == expectedMethod)
                        result.expectedPersistentListeners++;
                if (result.expectedPersistentListeners != 1) throw new InvalidOperationException("Expected one original persistent button binding.");

                result.stage = "ValidateEventSystem";
                events = EventSystem.current;
                module = events == null ? null : events.GetComponent<StandaloneInputModule>();
                if (events == null || !events.isActiveAndEnabled || module == null || !module.isActiveAndEnabled)
                    throw new InvalidOperationException("An active EventSystem and StandaloneInputModule are required.");
                oldModule = events.currentInputModule;
                result.currentModuleBefore = Name(oldModule);
                if (oldModule != null && oldModule != module)
                    throw new InvalidOperationException("A different active input module will not be replaced.");
                focus = typeof(EventSystem).GetField("m_HasFocus", BindingFlags.NonPublic | BindingFlags.Instance);
                changeModule = typeof(EventSystem).GetMethod("ChangeEventModule", BindingFlags.NonPublic | BindingFlags.Instance);
                if (focus == null || changeModule == null)
                    throw new InvalidOperationException("EventSystem logical focus/module adapter needs updating for this Unity version.");
                oldInput = module.inputOverride;
                oldFocus = (bool)focus.GetValue(events);
                oldSelection = events.currentSelectedGameObject;
                captured = true;

                result.stage = "InstallTemporaryInput";
                input = events.gameObject.AddComponent<DeLoginPointerInput>();
                if (input == null)
                    throw new InvalidOperationException("Unity could not attach the runtime-assembly validation input provider. Verify its MonoScript import and DE.Login.Validation.Input assembly.");
                input.hideFlags = HideFlags.HideAndDontSave;
                module.inputOverride = input;
                focus.SetValue(events, true); // Logical UI focus only; never focuses an Editor/OS window.
                result.stage = "InitializeInputModule";
                events.UpdateModules();
                module.UpdateModule();
                if (oldModule == null)
                {
                    result.stage = "ActivateInputModule";
                    result.moduleTemporarilyActivated = true;
                    // Same method as EventSystem.Update: ActivateModule followed by currentInputModule assignment.
                    // PanelRaycaster requires currentInputModule even before pointer input is processed.
                    changeModule.Invoke(events, new object[] { module });
                }
                if (events.currentInputModule != module)
                    throw new InvalidOperationException("StandaloneInputModule did not become the active event module.");

                result.stage = "ResolveButtonScreenPosition";
                var rect = button.GetComponent<RectTransform>();
                var canvas = button.GetComponentInParent<Canvas>();
                if (rect == null || canvas == null || canvas.rootCanvas == null)
                    throw new InvalidOperationException("Original button RectTransform/Canvas is missing.");
                Canvas.ForceUpdateCanvases();
                var rootCanvas = canvas.rootCanvas;
                Camera camera = rootCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : rootCanvas.worldCamera;
                if (rootCanvas.renderMode != RenderMode.ScreenSpaceOverlay && camera == null)
                    throw new InvalidOperationException("A non-overlay canvas must declare its event camera.");
                Vector2 point = RectTransformUtility.WorldToScreenPoint(camera, rect.TransformPoint(rect.rect.center));
                result.screenX = point.x; result.screenY = point.y;
                if (point.x < 0 || point.y < 0 || point.x >= Screen.width || point.y >= Screen.height)
                    throw new InvalidOperationException("Button center is outside the actual Game view.");
                input.Position = point;

                result.stage = "RaycastAll";
                result.currentModuleDuringRaycast = Name(events.currentInputModule);
                var pointer = new PointerEventData(events) { position = point, button = PointerEventData.InputButton.Left };
                var hits = new List<RaycastResult>();
                events.RaycastAll(pointer, hits);
                if (hits.Count == 0) throw new InvalidOperationException("No raycast target at the original button center.");
                result.firstRaycastPath = Path(hits[0].gameObject.transform);
                result.stage = "ValidateFirstRaycast";
                var clickHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(hits[0].gameObject);
                result.clickHandlerPath = clickHandler == null ? "<none>" : Path(clickHandler.transform);
                if (clickHandler != target) throw new InvalidOperationException("The first raycast does not reach the requested original button.");

                token.ThrowIfCancellationRequested();
                input.Down = input.Held = true;
                result.stage = "UpdateModuleDown";
                module.UpdateModule();
                result.stage = "ProcessDown";
                downAttempted = true;
                module.Process();
                result.downProcessed = true;
                input.Down = input.Held = false; input.Up = true;
                result.stage = "ProcessUp";
                result.upAttempted = true;
                module.Process();
                result.upProcessed = result.clicked = true;
                result.stage = "InputDispatched";
            }
            catch (Exception error) { RecordError(result, result.stage, error); }
            finally
            {
                if (input != null) input.Down = input.Up = input.Held = false;
                if (captured)
                {
                    Cleanup(result, "RestoreInputModule", () =>
                    {
                        if (module == null || events == null) throw new InvalidOperationException("EventSystem/module was destroyed during input.");
                        if (result.moduleTemporarilyActivated)
                        {
                            if (events.currentInputModule == module) changeModule.Invoke(events, new object[] { oldModule });
                            else if (events.currentInputModule != oldModule) throw new InvalidOperationException("Input handler changed the active module unexpectedly.");
                            if (oldSelection != null && oldSelection.activeInHierarchy) events.SetSelectedGameObject(oldSelection);
                        }
                        else if (downAttempted && !result.upProcessed) module.DeactivateModule();
                        result.currentModuleAfter = Name(events.currentInputModule);
                        result.moduleRestored = events.currentInputModule == oldModule;
                    });
                    Cleanup(result, "RestoreInputOverride", () =>
                    {
                        if (module == null) throw new InvalidOperationException("Input module no longer exists.");
                        module.inputOverride = oldInput;
                        result.inputRestored = module.inputOverride == oldInput;
                    });
                    Cleanup(result, "RestoreLogicalFocus", () =>
                    {
                        if (events == null) throw new InvalidOperationException("EventSystem no longer exists.");
                        focus.SetValue(events, oldFocus);
                        result.focusRestored = (bool)focus.GetValue(events) == oldFocus;
                    });
                }
                Cleanup(result, "DestroyTemporaryInput", () => { if (input != null) UnityEngine.Object.DestroyImmediate(input); });
            }
            result.dialogVisibleAfter = view != null && view.FailureDialogVisible;
            result.phaseAfter = runtime != null ? runtime.Phase : "NotRunning";
            result.isLoginComplete = runtime != null && runtime.IsLoginComplete;
            result.success = result.clicked && result.downProcessed && result.upProcessed && result.inputRestored && result.focusRestored
                && result.moduleRestored && string.IsNullOrEmpty(result.errorStage) && string.IsNullOrEmpty(result.cleanupErrors);
            if (result.success) result.stage = "Completed";
            // Diagnostic DTO intentionally returns on failure: UniCli may otherwise omit Exception.StackTrace.
            // Callers MUST check success/clicked. An exception during Up may follow a partial callback:
            // never automatically retry when upAttempted=true; inspect the real runtime phase first.
            return new ValueTask<DeLoginClickResult>(result);
        }

        private static void RecordError(DeLoginClickResult result, string stage, Exception error)
        {
            if (error is TargetInvocationException invocation && invocation.InnerException != null) error = invocation.InnerException;
            result.errorStage = stage; result.errorType = error.GetType().FullName;
            result.errorStack = error.StackTrace ?? "<no managed stack available>";
        }
        private static void Cleanup(DeLoginClickResult result, string stage, Action cleanup)
        {
            try { cleanup(); }
            catch (Exception error)
            {
                if (error is TargetInvocationException invocation && invocation.InnerException != null) error = invocation.InnerException;
                result.cleanupErrors = (result.cleanupErrors ?? "") + stage + ": " + error.GetType().FullName + "\n" + error.StackTrace + "\n";
            }
        }
        private static string Name(BaseInputModule module) { return module == null ? "<none>" : module.GetType().FullName; }
        private static string Path(Transform value)
        {
            var names = new List<string>();
            while (value != null) { names.Add(value.name); value = value.parent; }
            names.Reverse(); return string.Join("/", names);
        }
    }
}

