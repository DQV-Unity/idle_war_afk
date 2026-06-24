using _Scripts.API;
using _Scripts.Definition;
using _Scripts.UI.Popup.CharacterCollectionPopup;
using _Scripts.UI.Popup.EquipmentPopup;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.CharacterPopup
{
	public class CharacterPopupParamInput : ParamInput
	{
		public Character equippedCharacter;
		public EquipmentSlot[] equipmentSlots;
	}
	
	public class CharacterPopupLogic : qtLogic
    {
	    private Character _equippedCharacter;
	    private EquipmentSlot[] _equipmentSlots;

	    public Character EquippedCharacter => _equippedCharacter;
	    public EquipmentSlot[] EquipmentSlots => _equipmentSlots;

	    public override UniTask Initialize()
	    {
		    LoadData();
		    return base.Initialize();
	    }

	    public Definition.Equipment GetEquipmentData(EEquipmentType equipmentType, int equipmentID)
	    {
		    return APIManager.Instance.GetEquipment(equipmentType,  equipmentID);
	    }

	    public void LoadData()
	    {
		    _equippedCharacter = APIManager.Instance.GetEquippedCharacter();
		    _equipmentSlots = APIManager.Instance.GetEquipmentSlot();
	    }
    }
	
    public class CharacterPopupMediator : qtMediator<CharacterPopup, CharacterPopupLogic>
    {
	    public CharacterPopupMediator() : base()
	    {
		    _configUI = (ui, logic, mediator) =>
		    {
			    ui.BtnChangeCharacter.onClick.AddListener(OnClickChangeCharacterButton);
			    
			    MessageDispatcher.Register(MessageDispatcher.EEvent.CharacterChanged, OnCharacterChanged);
			    MessageDispatcher.Register(MessageDispatcher.EEvent.EquipmentChanged, OnEquipmentChanged);
			   
			    return UniTask.CompletedTask;
		    };

		    _beforeUIShow = (ui, logic, mediator) =>
		    {
			    ui.ShowCharacterDetails(logic.EquippedCharacter);
			    ui.ShowEquipment(logic.EquipmentSlots, OnSelectEquipmentSlot, logic.GetEquipmentData);
			    return UniTask.CompletedTask;
		    };
	    }

	    protected override void RemoveEvent()
	    {
		    base.RemoveEvent();
		    _ui.BtnChangeCharacter.onClick.RemoveAllListeners();
		    
		    MessageDispatcher.UnRegister(MessageDispatcher.EEvent.CharacterChanged, OnCharacterChanged);
		    MessageDispatcher.UnRegister(MessageDispatcher.EEvent.EquipmentChanged, OnEquipmentChanged);
	    }

	    #region ----- Private Functions -----

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

	    private void ShowCollection()
	    {
		    _ui.ShowCharacterDetails(_logic.EquippedCharacter);
		    _ui.ShowEquipment(_logic.EquipmentSlots, OnSelectEquipmentSlot, _logic.GetEquipmentData);
	    }

	    private void OnCharacterChanged(object message)
	    {
		    _logic.LoadData();
		    ShowCollection();
	    }

	    private void OnEquipmentChanged(object message)
	    {
		    _logic.LoadData();
		    ShowCollection();
	    }

	    #endregion
    }
}