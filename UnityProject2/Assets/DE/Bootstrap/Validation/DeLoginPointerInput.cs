#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;

namespace DE.Bootstrap.Validation
{
    // Transient Editor validation input; never changes OS focus or uses the hardware pointer.
    public sealed class DeLoginPointerInput : BaseInput
    {
        public Vector2 Position;
        public bool Down, Up, Held;
        public override bool mousePresent => true;
        public override Vector2 mousePosition => Position;
        public override Vector2 mouseScrollDelta => Vector2.zero;
        public override int touchCount => 0;
        public override bool GetMouseButtonDown(int button) => button == 0 && Down;
        public override bool GetMouseButtonUp(int button) => button == 0 && Up;
        public override bool GetMouseButton(int button) => button == 0 && Held;
        public override float GetAxisRaw(string axisName) => 0;
        public override bool GetButtonDown(string buttonName) => false;
    }
}

#endif
