using System.Collections.Generic;
using _Scripts.API;
using _Scripts.Definition;
using _Scripts.UI.Popup.CharacterCollectionPopup;
using Cysharp.Threading.Tasks;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.CharacterPopup
{
	public class CharacterPopupParamInput : ParamInput
	{
		public Definition.Character equippedCharacter;
		public EquipmentSlot[] equipmentSlots;
	}
	
	public class CharacterPopupLogic : qtLogic
    {
	    
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
			    ui.ShowEquipment(Args.equipmentSlots, OnSelectEquipmentSlot);
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
		    //Todo: show popup equipment
	    }

	    public override UniTask<CharacterPopupParamInput> RequestData()
	    {
		    return UniTask.FromResult<CharacterPopupParamInput>(new CharacterPopupParamInput()
		    {
			    equippedCharacter = APIManager.Instance.GetEquippedCharacter(),
			    equipmentSlots = APIManager.Instance.GetEquippedEquipments(),
		    });
	    }
    }
}