using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameCore;
using UnityEngine;
namespace GameRuntime
{
    public static class DemoUi
    {
        public static async UniTask<bool> ConfirmAsync(string message, CancellationToken token)
        {
            if (GameModule.UI.HasWindow<ConfirmWindow>()) throw new InvalidOperationException("A modal response is already pending.");
            var request = new ConfirmationRequest(message);
            try
            {
                await GameModule.UI.ShowUIAsyncAwait<ConfirmWindow>(token, request);
                return await request.Completion.Task.AttachExternalCancellation(token);
            }
            finally { GameModule.UI.CloseUI<ConfirmWindow>(); }
        }
        public static void Report(Exception error) { if (!(error is OperationCanceledException)) Debug.LogException(error); }
    }
    public sealed class ConfirmationRequest
    {
        public readonly string Message;
        public readonly UniTaskCompletionSource<bool> Completion = new UniTaskCompletionSource<bool>();
        public ConfirmationRequest(string message) { Message = message; }
    }
    public static class FakeSlgState
    {
        public static int Coins = 9600, HeroLevel = 21;
        public static readonly System.Collections.Generic.HashSet<int> ClaimedMail = new System.Collections.Generic.HashSet<int>();
        public static readonly System.Collections.Generic.List<string> ChatMessages = new System.Collections.Generic.List<string>();
        public static void Reset() { Coins = 9600; HeroLevel = 21; ClaimedMail.Clear(); ChatMessages.Clear(); }
    }
}
