using _Scripts.API;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.EquipmentPopup
{
	public class EquipmentPopupParamInput : ParamInput
	{
		public EEquipmentType equipmentType;
	}
	
	public class EquipmentPopupLogic : qtLogic<EquipmentPopupParamInput>
	{
		private EquipmentCatalogue _equipmentCatalogue;
		private Definition.Equipment _selectedEquipment;
		private Definition.Equipment _equippedEquipment;
		
		public int SelectedEquipmentID => SelectedEquipment.ID;

		public int EquippedEquipmentID
		{
			get
			{
				if (_equippedEquipment.ID <= 0)
				{
					return -1;
				}
				return _equippedEquipment.ID;
			}
		}
		public EquipmentCatalogue EquipmentCatalogue => _equipmentCatalogue;
		public Definition.Equipment SelectedEquipment => _selectedEquipment;
		public Definition.Equipment EquippedEquipment => _equippedEquipment;
		
		
		public override UniTask Initialize()
		{
			RefreshData();
			return base.Initialize();
		}

		public void SelectEquipment(int equipmentID)
		{
			for (var i = 0; i < EquipmentCatalogue.owned.Count; i++)
			{
				if (EquipmentCatalogue.owned[i].ID == equipmentID)
				{
					_selectedEquipment = EquipmentCatalogue.owned[i];
				}
			}
		}

		public bool EquipEquipment()
		{
			if (APIManager.Instance.EquipEquipment(Args.equipmentType, SelectedEquipmentID))
			{
				RefreshData();				
				return true;
			}
			return false;
		}

		public bool UnEquipEquipment()
		{
			if (APIManager.Instance.UnEquipEquipment(Args.equipmentType))
			{
				RefreshData();
				return true;
			}

			return false;
		}
		
		public bool IsEquipped(int equipmentID)
		{
			if (_equippedEquipment.ID <= 0)
			{
				return false;
			}
			return _equippedEquipment.ID == equipmentID;
		}

		private void RefreshData()
		{
			_equipmentCatalogue = APIManager.Instance.GetEquipmentCatalogue(Args.equipmentType);
			_selectedEquipment = _equippedEquipment = APIManager.Instance.GetEquippedEquipment(Args.equipmentType);
			if (_selectedEquipment.ID <= 0)
			{
				_selectedEquipment = _equipmentCatalogue.owned[0];
			}
		}
	}
	
    public class EquipmentPopupMediator : qtRequestMediator<EquipmentPopup, EquipmentPopupLogic, EquipmentPopupParamInput>
    {
	    public EquipmentPopupMediator() : base()
	    {
		    _configUI = (ui, logic, mediator) =>
		    {
			    ui.BtnClose.onClick.AddListener(OnClickCloseButton);
			    ui.BtnFuse.onClick.AddListener(OnClickEnhanceButton);
			    ui.BtnEquip.onClick.AddListener(OnClickEquipButton);
			    ui.BtnUnEquip.onClick.AddListener(OnClickUnEquipButton);
			    return UniTask.CompletedTask;
		    };

		    _beforeUIShow = (ui, logic, mediator) =>
		    {
			    ui.ShowCollection(logic.EquipmentCatalogue, logic.SelectedEquipmentID, logic.EquippedEquipmentID, OnSelectEquipment,true);
			    ui.ShowEquipment(logic.SelectedEquipment, logic.IsEquipped(logic.SelectedEquipmentID));
			    return UniTask.CompletedTask;
		    };
	    }

	    protected override void RemoveEvent()
	    {
		    base.RemoveEvent();
		    _ui.BtnClose.onClick.RemoveAllListeners();
		    _ui.BtnFuse.onClick.RemoveAllListeners();
		    _ui.BtnEquip.onClick.RemoveAllListeners();
	    }
	    
	    #region ----- Private Functions -----

	    private void OnSelectEquipment(int characterID)
	    {
		    _logic.SelectEquipment(characterID);
		    ShowCollection();
	    }

	    private void ShowCollection()
	    {
		    _ui.ShowCollection(_logic.EquipmentCatalogue, _logic.SelectedEquipmentID, _logic.EquippedEquipmentID,
			    OnSelectEquipment);
		    _ui.ShowEquipment(_logic.SelectedEquipment, _logic.IsEquipped(_logic.SelectedEquipmentID));
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
		    if (!_logic.EquipEquipment())
		    {
			    return;
		    }

		    MessageDispatcher.SendMessage(MessageDispatcher.EEvent.EquipmentChanged);
		    ShowCollection();
	    }

	    private void OnClickUnEquipButton()
	    {
		    if (!_logic.UnEquipEquipment())
		    {
			    return;
		    }
		   
		    MessageDispatcher.SendMessage(MessageDispatcher.EEvent.EquipmentChanged);
		    ShowCollection();
	    }
	    
	    #endregion

	    public override UniTask<EquipmentPopupParamInput> RequestData()
	    {
		    return  UniTask.FromResult(new EquipmentPopupParamInput());
	    }
    }
}