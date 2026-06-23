using _Scripts.API;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
	public class CharacterCollectionPopupParamInput : ParamInput
	{
		public CharacterCollection characterCollection;
		public Character equippedCharacter;
	}
	
	public class CharacterCollectionPopupLogic : qtLogic<CharacterCollectionPopupParamInput>
	{
		public bool IsEquipped(int characterID)
		{
			return Args.equippedCharacter.ID == characterID;
		}
	}
	
    public class CharacterCollectionPopupMediator : qtRequestMediator<CharacterCollectionPopup, CharacterCollectionPopupLogic, CharacterCollectionPopupParamInput>
    {
	    public CharacterCollectionPopupMediator() : base()
	    {
		    _configUI = (ui, logic, mediator) =>
		    {
			    ui.BtnClose.onClick.AddListener(OnClickCloseButton);
			    ui.BtnEnhance.onClick.AddListener(OnClickEnhanceButton);
			    ui.BtnEquip.onClick.AddListener(OnClickEquipButton);
			    return UniTask.CompletedTask;
		    };

		    _beforeUIShow = (ui, logic, mediator) =>
		    {
			    ui.ShowCollection(Args.characterCollection);
			    ui.ShowCharacter(Args.equippedCharacter, true);
			    return UniTask.CompletedTask;
		    };
	    }

	    protected override void RemoveEvent()
	    {
		    base.RemoveEvent();
		    _ui.BtnClose.onClick.RemoveAllListeners();
		    _ui.BtnEnhance.onClick.RemoveAllListeners();
		    _ui.BtnEquip.onClick.RemoveAllListeners();
	    }

	    #region ----- Button Event -----

	    private void OnClickCloseButton()
	    {
		    _ui.ControllerHide();
	    }

	    private void OnClickEnhanceButton()
	    {
		    
	    }

	    private void OnClickEquipButton()
	    {
		    
	    }

	    #endregion

	    public override UniTask<CharacterCollectionPopupParamInput> RequestData()
	    {
		    return  UniTask.FromResult(new CharacterCollectionPopupParamInput()
		    {
			    characterCollection = APIManager.Instance.GetCharacterCollection(),
			    equippedCharacter = APIManager.Instance.GetEquippedCharacter()
		    });
	    }
    }
}