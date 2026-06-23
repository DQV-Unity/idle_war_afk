using _Scripts.API;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.UI.Base;

namespace _Scripts.UI.Popup.EquipmentPopup
{
	public class EquipmentPopupParamInput : ParamInput
	{
		public EEquipmentType equipmentType;
	}
	
	public class EquipmentPopupLogic : qtLogic<EquipmentPopupParamInput>
	{
		private int _selectedEquipmentID;
		private EquipmentCatalogue _equipmentCatalogue;
		private Definition.Equipment _equippedEquipment;
		
		public int SelectedEquipmentID => _selectedEquipmentID;
		public EquipmentCatalogue EquipmentCatalogue => _equipmentCatalogue;
		public Definition.Equipment EquippedEquipment => _equippedEquipment;
		
		
		public override UniTask Initialize()
		{
			return base.Initialize();
		}

		public void SelectEquipment(int equipmentID)
		{
			_selectedEquipmentID = equipmentID;	
		}

		public bool EquipEquipment()
		{
			if (APIManager.Instance.ChangeEquipment(Args.equipmentType, _selectedEquipmentID))
			{
				RefreshData();				
				return true;
			}
			return false;
		}
		
		public bool IsEquipped(int equipmentID)
		{
			return _equippedEquipment.ID == equipmentID;
		}

		private void RefreshData()
		{
			_equipmentCatalogue = APIManager.Instance.GetEquipmentCatalogue(Args.equipmentType);
			_equippedEquipment = APIManager.Instance.GetEquippedEquipment(Args.equipmentType);
		}
	}
	
    public class EquipmentPopupMediator : qtRequestMediator<EquipmentPopup, EquipmentPopupLogic, EquipmentPopupParamInput>
    {
	    public EquipmentPopupMediator() : base()
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
			    ui.ShowCollection(logic.EquipmentCatalogue, logic.EquippedEquipment.ID, OnSelectEquipment,true);
			    ui.ShowEquipment(logic.EquippedEquipment, true);
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

	    private void OnSelectEquipment(int characterID)
	    {
		    _logic.SelectEquipment(characterID);
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
		    if (!_logic.EquipEquipment())
		    {
			    return;
		    }
		    
		    _ui.ShowEquipment(_logic.EquippedEquipment, true);
	    }

	    #endregion

	    public override UniTask<EquipmentPopupParamInput> RequestData()
	    {
		    return  UniTask.FromResult(new EquipmentPopupParamInput());
	    }
    }
}