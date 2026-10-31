using System;
using GameCore;
using UnityEngine;
namespace GameRuntime
{
    public sealed class ConfirmView : MonoBehaviour
    {
        public UnityEngine.UI.Text message;
        public UnityEngine.UI.Button accept, reject;
        private ConfirmationRequest request;
        public bool IsBound => request != null;
        public void Bind(ConfirmationRequest value)
        {
            request = value; message.text = value.Message;
            accept.onClick.RemoveAllListeners(); reject.onClick.RemoveAllListeners();
            accept.onClick.AddListener(() => Respond(true)); reject.onClick.AddListener(() => Respond(false));
        }
        public void Respond(bool yes) { request?.Completion.TrySetResult(yes); }
        public void Cancel() { request?.Completion.TrySetResult(false); }
    }
}
