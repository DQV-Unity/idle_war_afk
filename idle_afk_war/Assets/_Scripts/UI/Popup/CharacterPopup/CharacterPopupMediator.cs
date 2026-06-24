using _Scripts.API;
using _Scripts.Definition;
using _Scripts.UI.Popup.CharacterCollectionPopup;
using _Scripts.UI.Popup.EquipmentPopup;
using Cysharp.Threading.Tasks;
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
	    public Definition.Equipment GetEquipmentData(EEquipmentType equipmentType, int equipmentID)
	    {
		    return APIManager.Instance.GetEquipment(equipmentType,  equipmentID);
	    }
    }
	
    public class CharacterPopupMediator : qtRequestMediator<CharacterPopup, CharacterPopupLogic, CharacterPopupParamInput>
    {
	    public CharacterPopupMediator() : base()
	    {
		    _configUI = (ui, logic, mediator) =>
		    {
			    ui.BtnChangeCharacter.onClick.AddListener(OnClickChangeCharacterButton);
			    return UniTask.CompletedTask;
		    };

		    _beforeUIShow = (ui, logic, mediator) =>
		    {
			    ui.ShowCharacterDetails(Args.equippedCharacter);
			    ui.ShowEquipment(Args.equipmentSlots, OnSelectEquipmentSlot, logic.GetEquipmentData);
			    return UniTask.CompletedTask;
		    };
	    }

	    protected override void RemoveEvent()
	    {
		    base.RemoveEvent();
		    _ui.BtnChangeCharacter.onClick.RemoveAllListeners();
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

	    public override UniTask<CharacterPopupParamInput> RequestData()
	    {
		    return UniTask.FromResult<CharacterPopupParamInput>(new CharacterPopupParamInput()
		    {
			    equippedCharacter = APIManager.Instance.GetEquippedCharacter(),
			    equipmentSlots = APIManager.Instance.GetEquipmentSlot(),
		    });
	    }
    }
}