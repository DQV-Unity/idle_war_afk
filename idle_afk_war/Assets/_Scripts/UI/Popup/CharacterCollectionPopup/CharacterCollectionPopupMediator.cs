using _Scripts.API;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
	
	public class CharacterCollectionPopupLogic : qtLogic
	{
		private CharacterCollection _characterCollection;
		private Character _equippedCharacter;
		private Character _selectedCharacter;
		
		public int SelectedCharacterID => _selectedCharacter.ID;
		public CharacterCollection CharacterCollection => _characterCollection;
		public Character SelectedCharacter => _selectedCharacter;


		public override UniTask Initialize()
		{
			_characterCollection = APIManager.Instance.GetCharacterCollection();
			_selectedCharacter = _equippedCharacter = APIManager.Instance.GetEquippedCharacter();
			return base.Initialize();
		}

		public void SelectCharacter(int characterID)
		{
			for (var i = 0; i < _characterCollection.characters.Count; i++)
			{
				if (_characterCollection.characters[i].ID == characterID)
				{
					_selectedCharacter = _characterCollection.characters[i];
				}
			}
		}

		public bool EquipCharacter()
		{
			if (APIManager.Instance.EquippedCharacter(_selectedCharacter.ID))
			{
				LoadData();				
				return true;
			}
			return false;
		}
		
		public bool IsEquipped(int characterID)
		{
			return _equippedCharacter.ID == characterID;
		}

		private void LoadData()
		{
			_equippedCharacter = APIManager.Instance.GetEquippedCharacter();
		}
	}
	
    public class CharacterCollectionPopupMediator : qtMediator<CharacterCollectionPopup, CharacterCollectionPopupLogic>
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
			    ui.ShowCollection(logic.CharacterCollection, logic.SelectedCharacterID, OnSelectCharacter,true);
			    ui.ShowCharacter(logic.SelectedCharacter, true);
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
		    ShowCollection();
	    }

	    private void ShowCollection()
	    {
		    _ui.ShowCollection(_logic.CharacterCollection, _logic.SelectedCharacterID, OnSelectCharacter);
		    _ui.ShowCharacter(_logic.SelectedCharacter, _logic.IsEquipped(_logic.SelectedCharacterID));
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
		    
		    //Todo: send message
		    _ui.ShowCharacter(_logic.SelectedCharacter, true);
		    MessageDispatcher.SendMessage(MessageDispatcher.EEvent.CharacterChanged);
	    }

	    #endregion
    }
}