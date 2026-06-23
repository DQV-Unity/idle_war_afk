using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public void UnlockEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            _inventoryService.UnlockEquipment(equipmentType, equipmentID);
        }

        public bool ChangeEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            return _inventoryService.ChangeEquipment(equipmentType, equipmentID);
        }

        public void UpgradeEquipment(EEquipmentType equipmentType, params int[] equipmentIDs)
        {
            _inventoryService.UpgradeEquipment(equipmentType, equipmentIDs);
        }

        public EquipmentCatalogue GetEquipmentCatalogue(EEquipmentType equipmentType)
        {
            return _inventoryService.GetEquipmentCatalogue(equipmentType);
        }

        public EquipmentCatalogue[] GetEquipmentCatalogues()
        {
            return _inventoryService.GetEquipmentCatalogues();
        }
        
        public EquipmentSlot[] GetEquippedEquipments()
        {
            return  _inventoryService.GetEquippedEquipments();
        }
    }
}