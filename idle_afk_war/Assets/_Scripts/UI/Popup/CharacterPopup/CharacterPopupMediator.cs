using _Scripts.API;
using _Scripts.Definition;
using _Scripts.UI.Popup.CharacterCollectionPopup;
using _Scripts.UI.Popup.EquipmentPopup;
using _Scripts.UI.Popup.SkillPopup;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterPopup
{
	public class CharacterPopupLogic : qtLogic
    {
	    public enum ETab
	    {
		    Character,
		    Skill,
	    }
	    
	    private Character _equippedCharacter;
	    private EquipmentSlot[] _equipmentSlots;
	    
	    private SkillCollection _skillCollection;
	    private int[] _equippedSkills;

	    public Character EquippedCharacter => _equippedCharacter;
	    public EquipmentSlot[] EquipmentSlots => _equipmentSlots;

	    public SkillCollection SkillCollection => _skillCollection;
	    public int[] EquippedSkills => _equippedSkills;

	    public ETab CurrentTab;
	    
	    public override UniTask Initialize()
	    {
		    LoadCharacterData();
		    LoadSkillData();
		    return base.Initialize();
	    }

	    public Definition.Equipment GetEquipmentData(EEquipmentType equipmentType, int equipmentID)
	    {
		    return APIManager.Instance.GetEquipment(equipmentType,  equipmentID);
	    }

	    public Definition.Skill GetSkillData(int skillID)
	    {
		    return APIManager.Instance.GetSkill(skillID);
	    }

	    public bool IsSkillEquip(int skillID)
	    {
		    for (var i = 0; i < _equippedSkills.Length; i++)
		    {
			    if (_equippedSkills[i] == skillID)
			    {
				    return true;
			    }
		    }
		    
		    return false;
	    }
	    
	    public void LoadCharacterData()
	    {
		    _equippedCharacter = APIManager.Instance.GetEquippedCharacter();
		    _equipmentSlots = APIManager.Instance.GetEquipmentSlot();
	    }

	    public void LoadSkillData()
	    {
		    _skillCollection = APIManager.Instance.GetSkillCollection();
		    _equippedSkills = APIManager.Instance.GetEquippedSkills();
	    }
    }
	
    public class CharacterPopupMediator : qtMediator<CharacterPopup, CharacterPopupLogic>
    {
	    public CharacterPopupMediator() : base()
	    {
		    _configUI = (ui, logic, mediator) =>
		    {
			    ui.BtnCharacterTab.onClick.AddListener(OnClickCharacterTab);
			    ui.BtnSkillTab.onClick.AddListener(OnClickSkillTab);
			    
			    ui.BtnChangeCharacter.onClick.AddListener(OnClickChangeCharacterButton);

			    MessageDispatcher.Register(MessageDispatcher.EEvent.CharacterChanged, OnCharacterChanged);
			    MessageDispatcher.Register(MessageDispatcher.EEvent.EquipmentChanged, OnEquipmentChanged);
			   
			    return UniTask.CompletedTask;
		    };

		    _beforeUIShow = (ui, logic, mediator) =>
		    {
			    logic.CurrentTab = CharacterPopupLogic.ETab.Character;
			    ui.OpenTab(logic.CurrentTab);
			    ui.ShowCharacterDetails(logic.EquippedCharacter);
			    ui.ShowEquipment(logic.EquipmentSlots, OnSelectEquipmentSlot, logic.GetEquipmentData);
			    return UniTask.CompletedTask;
		    };
	    }

	    protected override void RemoveEvent()
	    {
		    base.RemoveEvent();
		    _ui.BtnCharacterTab.onClick.RemoveAllListeners();
		    _ui.BtnSkillTab.onClick.RemoveAllListeners();
		    
		    _ui.BtnChangeCharacter.onClick.RemoveAllListeners();

		    MessageDispatcher.UnRegister(MessageDispatcher.EEvent.CharacterChanged, OnCharacterChanged);
		    MessageDispatcher.UnRegister(MessageDispatcher.EEvent.EquipmentChanged, OnEquipmentChanged);
	    }

	    #region ----- Tab -----

	    private void OnClickCharacterTab()
	    {
		    if (_logic.CurrentTab == CharacterPopupLogic.ETab.Character)
		    {
			    return;
		    }
		    
		    _logic.CurrentTab = CharacterPopupLogic.ETab.Character;
		    _ui.OpenTab(CharacterPopupLogic.ETab.Character);
		    _ui.ShowCharacterDetails(_logic.EquippedCharacter);
		    _ui.ShowEquipment(_logic.EquipmentSlots, OnSelectEquipmentSlot, _logic.GetEquipmentData);
	    }
	    
	    private void OnClickSkillTab()
	    {
		    if (_logic.CurrentTab == CharacterPopupLogic.ETab.Skill)
		    {
			    return;
		    }
		    
		    _logic.CurrentTab = CharacterPopupLogic.ETab.Skill;
		    _ui.OpenTab(CharacterPopupLogic.ETab.Skill);
		    
		    ShowSkillCollection();
		    ShowEquippedSkills();
	    }

	    #endregion
	    
	    #region ----- Private Functions -----

	    //Character
	    private void ShowCharacter()
	    {
		    _ui.ShowCharacterDetails(_logic.EquippedCharacter);
		    _ui.ShowEquipment(_logic.EquipmentSlots, OnSelectEquipmentSlot, _logic.GetEquipmentData);
	    }

	    private void OnClickChangeCharacterButton()
	    {
		    qtUiFlow.Request<CharacterCollectionPopupMediator>().Move();
	    }

	    private void OnSelectEquipmentSlot(EEquipmentType equipmentType)
	    {
		    qtUiFlow.Request<EquipmentPopupMediator>()
			    .SetParam(new EquipmentPopupParamInput()
			    {
				    equipmentType = equipmentType,
			    })
			    .Move();
	    }

	    private void OnCharacterChanged(object message)
	    {
		    _logic.LoadCharacterData();
		    ShowCharacter();
	    }

	    private void OnEquipmentChanged(object message)
	    {
		    _logic.LoadCharacterData();
		    ShowCharacter();
	    }
	    
	    //Skill
	    private void ShowEquippedSkills()
	    {
		    _ui.ShowEquippedSkills(_logic.EquippedSkills, _logic.GetSkillData, OnSelectSkill);
	    }

	    private void ShowSkillCollection()
	    {
		    _ui.ShowSkillCollection(_logic.SkillCollection.skills, _logic.IsSkillEquip, OnSelectSkill);
	    }

	    private void OnSelectSkill(int skillID)
	    {
		    qtUiFlow.Request<SkillPopupMediator>().SetParam(new SkillPopupParamInput()
		    {
			    skillID = skillID
		    }).Move();
	    }

	    #endregion
    }
}