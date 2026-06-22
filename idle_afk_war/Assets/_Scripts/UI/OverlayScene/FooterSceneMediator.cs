using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;

namespace _Scripts.UI.OverlayScene
{
    public class FooterSceneLogic : qtLogic
    {
        public ETab currentTab;
        public bool ChangeTab(ETab tab)
        {
            if (tab == currentTab)
            {
                currentTab = ETab.None;
                return false;
            }
            currentTab = tab;
            return true;    
        }
    }
    
    public class FooterSceneMediator : qtMediator<FooterScene, FooterSceneLogic> 
    {
        public FooterSceneMediator() : base()
        {
            _configUI = (ui, logic, mediator) =>
            {
                ui.BtnCharacter.onClick.AddListener(OnclickButtonCharacter);
                ui.BtnCompanion.onClick.AddListener(OnClickButtonCompanion);
                ui.BtnFarm.onClick.AddListener(OnClickButtonFarm);
                ui.BtnInstitute.onClick.AddListener(OnClickButtonInstitute);
                ui.BtnArmory.onClick.AddListener(OnClickButtonArmory);
                ui.BtnShop.onClick.AddListener(OnClickButtonShop);
                return UniTask.CompletedTask;
            };
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            
            _ui.BtnCharacter.onClick.RemoveAllListeners();
            _ui.BtnCompanion.onClick.RemoveAllListeners();
            _ui.BtnFarm.onClick.RemoveAllListeners();
            _ui.BtnInstitute.onClick.RemoveAllListeners();
            _ui.BtnArmory.onClick.RemoveAllListeners();
            _ui.BtnShop.onClick.RemoveAllListeners();
        }

        #region ----- Button Event -----

        private void OnclickButtonCharacter()
        {
            ChangeTab(ETab.Character);
        }

        private void OnClickButtonCompanion()
        {
            ChangeTab(ETab.Companion);
        }

        private void OnClickButtonFarm()
        {
            ChangeTab(ETab.Farm);
        }

        private void OnClickButtonInstitute()
        {
            ChangeTab(ETab.Institute);
        }

        private void OnClickButtonArmory()
        {
            ChangeTab(ETab.Armory);
        }

        private void OnClickButtonShop()
        {
            ChangeTab(ETab.Shop);
        }

        #endregion

        #region ----- Private Functions -----

        private void ChangeTab(ETab tab)
        {
            MessageDispatcher.SendMessage(MessageDispatcher.EEvent.SwitchTab, new MessageDispatcher.SwitchFooterTabMessage()
            {
                tab = tab,
                isShow = _logic.ChangeTab(tab)
            });
        }

        #endregion
    }
}