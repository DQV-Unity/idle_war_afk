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

        public bool EquipEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            return _inventoryService.EquipEquipment(equipmentType, equipmentID);
        }
        
        public bool UnEquipEquipment(EEquipmentType equipmentType)
        {
            return _inventoryService.UnEquipEquipment(equipmentType);
        }

        public void UpgradeEquipment(EEquipmentType equipmentType, params int[] equipmentIDs)
        {
            _inventoryService.UpgradeEquipment(equipmentType, equipmentIDs);
        }

        public EquipmentCatalogue GetEquipmentCatalogue(EEquipmentType equipmentType)
        {
            return _inventoryService.GetEquipmentCatalogue(equipmentType);
        }

        public Definition.Equipment GetEquippedEquipment(EEquipmentType equipmentType)
        {
            return _inventoryService.GetEquippedEquipment(equipmentType);
        }

        public Definition.Equipment GetEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            return _inventoryService.GetEquipment(equipmentType, equipmentID);
        }

        public EquipmentCatalogue[] GetEquipmentCatalogues()
        {
            return _inventoryService.GetEquipmentCatalogues();
        }
        
        public EquipmentSlot[] GetEquipmentSlot()
        {
            return  _inventoryService.GetEquipmentSlot();
        }
    }
}