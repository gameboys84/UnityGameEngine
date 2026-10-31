using System;
using Cysharp.Threading.Tasks;
using DE.Application;
using DE.Infrastructure;
using GameCore;
using UnityEngine;

namespace DE.Bootstrap
{
    public sealed class DeRuntimeHost : MonoBehaviour
    {
        public static DeRuntimeHost Current { get; private set; }
        public IDeClient Client { get; private set; }
        public bool IsReady { get; private set; }
        public string StartupError { get; private set; }

        public void Initialize()
        {
            Current = this;
            Client = DeClientFactory.CreateMock("commander-001");
            OpenAsync().Forget();
        }

        private async UniTask OpenAsync()
        {
            try
            {
                await DE.Presentation.DEPresentation.Bootstrap(Client);
                if (this != null) IsReady = true;
            }
            catch (OperationCanceledException) when (this == null) { }
            catch (Exception error)
            {
                StartupError = error.ToString();
                Debug.LogException(error);
            }
        }

        private void Update()
        {
            if (Client != null) Client.Tick(Time.unscaledDeltaTime);
        }

        private void OnDestroy()
        {
            IsReady = false;
            Client?.Dispose();
            Client = null;
            if (Current == this) Current = null;
            SingletonSystem.Release();
        }
    }
}

