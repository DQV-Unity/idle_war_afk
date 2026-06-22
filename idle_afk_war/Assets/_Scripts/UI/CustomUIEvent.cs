using _Scripts.UI.OverlayScene;
using _Scripts.UI.Scene.GameScene;
using qtLib.UI.Base;
using qtLib.UIScripts.Base.UIManager;
using UnityEngine;

namespace _Scripts.UI
{
    public class CustomUIEvent : MonoBehaviour, IUIEvent
    {
        public void OnStart()
        {
            qtUiFlow.Request<FooterSceneMediator>().Move();
            qtUiFlow.Request<GameSceneMediator>().Move();
        }
    }
}