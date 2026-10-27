using GameCore;
using UnityEngine;
namespace GameRuntime
{
    public static class GameApp
    {
        public static void Entrance(object[] args)
        {
            var view = Object.FindObjectOfType<MainSceneView>();
            if (view == null) throw new System.InvalidOperationException("MainSceneView is missing.");
            _ = GameModule.UI;
            view.Enter((string)args[0]);
        }
    }
}
