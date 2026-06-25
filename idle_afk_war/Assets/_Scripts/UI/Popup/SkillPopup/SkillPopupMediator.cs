using _Scripts.API;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.SkillPopup
{
    public class SkillPopupParamInput : ParamInput
    {
        public int skillID;
    }
    
    public class SkillPopupLogic : qtLogic<SkillPopupParamInput>
    {
        private Definition.Skill _skill;
        private bool _isEquipped;
        public Definition.Skill Skill => _skill;
        public bool IsEquipped => _isEquipped;
        
        public override UniTask Initialize()
        {
            LoadData();
            return base.Initialize();
        }

        public void LoadData()
        {
            _isEquipped = false;
            _skill = APIManager.Instance.GetSkill(Args.skillID);
            
            int[] equippedSkills = APIManager.Instance.GetEquippedSkills();
            for (var i = 0; i < equippedSkills.Length; i++)
            {
                if (equippedSkills[i] == _skill.ID)
                {
                    _isEquipped = true;
                }
            }
        }

        public bool UnEquipSkill()
        {
            return APIManager.Instance.UnEquipSkill(_skill.ID);
        }
    }
    
    public class SkillPopupMediator : qtRequestMediator<SkillPopup, SkillPopupLogic, SkillPopupParamInput>
    {
        public SkillPopupMediator() : base()
        {
            _configUI = (ui, logic, mediator) =>
            {
                ui.BtnClose.onClick.AddListener(OnClickCloseButton);
                ui.BtnEquip.onClick.AddListener(OnClickEquipButton);
                ui.BtnUnEquip.onClick.AddListener(OnClickUnEquipButton);
                ui.BtnFuse.onClick.AddListener(OnClickFuseButton);
                
                return UniTask.CompletedTask;
            };
            
            _beforeUIShow = (ui, logic, mediator) =>
            {
                ui.ShowSkill(logic.Skill, logic.IsEquipped);
                return UniTask.CompletedTask;
            };
        }

        protected override void RemoveEvent()
        {
            _ui.BtnClose.onClick.RemoveAllListeners();
            _ui.BtnEquip.onClick.RemoveAllListeners();
            _ui.BtnUnEquip.onClick.RemoveAllListeners();
            _ui.BtnFuse.onClick.RemoveAllListeners();
            
            base.RemoveEvent();
        }

        private void OnClickEquipButton()
        {
            
        }

        private void OnClickUnEquipButton()
        {
            if (!_logic.UnEquipSkill())
            {
                return;
            }
            
            MessageDispatcher.SendMessage(MessageDispatcher.EEvent.SkillChanged);
        }

        private void OnClickFuseButton()
        {
            
        }

        private void OnClickCloseButton()
        {
            _ui.ControllerHide();
        }
        
        public override UniTask<SkillPopupParamInput> RequestData()
        {
            return UniTask.FromResult(new SkillPopupParamInput());
        }
    }
}