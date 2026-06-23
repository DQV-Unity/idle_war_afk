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
		private int _selectedCharacterID;
		public int SelectedCharacterID => _selectedCharacterID;
		
		public void SelectCharacter(int characterID)
		{
			_selectedCharacterID = characterID;	
		}

		public bool EquipCharacter()
		{
			if (APIManager.Instance.EquippedCharacter(_selectedCharacterID))
			{
				RefreshData();				
				return true;
			}
			return false;
		}
		
		public bool IsEquipped(int characterID)
		{
			return Args.equippedCharacter.ID == characterID;
		}

		private void RefreshData()
		{
			Args.equippedCharacter = APIManager.Instance.GetEquippedCharacter();
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
			    ui.ShowCollection(Args.characterCollection, Args.equippedCharacter.ID, OnSelectCharacter,true);
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
	    
	    #region ----- Private Functions -----

	    private void OnSelectCharacter(int characterID)
	    {
		    _logic.SelectCharacter(characterID);
		    //Todo: update scroll view
	    }
	    
	    #endregion
	    
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
		    if (!_logic.EquipCharacter())
		    {
			    return;
		    }
		    
		    _ui.ShowCharacter(Args.equippedCharacter, true);
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