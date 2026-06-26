using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public EquipmentCatalogue GetEquipmentCatalogue(EEquipmentType equipmentType)
        {
            return _equipmentService.GetEquipmentCatalogue(equipmentType).Clone();
        }

        public Definition.Equipment GetEquippedEquipment(EEquipmentType equipmentType)
        {
            return _equipmentService.GetEquippedEquipment(equipmentType).Clone();
        }

        public Definition.Equipment GetEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            return _equipmentService.GetEquipment(equipmentType, equipmentID).Clone();
        }

        public EquipmentCatalogue[] GetEquipmentCatalogues()
        {
            return qtGameExtension.Clone(_equipmentService.GetEquipmentCatalogues());
        }
        
        public EquipmentSlot[] GetEquipmentSlot()
        {
            return qtGameExtension.Clone(_equipmentService.GetEquipmentSlot());
        }
        
        public void UnlockEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            _equipmentService.UnlockEquipment(equipmentType, equipmentID);
        }

        public bool EquipEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            return _equipmentService.EquipEquipment(equipmentType, equipmentID);
        }
        
        public bool UnEquipEquipment(EEquipmentType equipmentType)
        {
            return _equipmentService.UnEquipEquipment(equipmentType);
        }

        public void UpgradeEquipment(EEquipmentType equipmentType, params int[] equipmentIDs)
        {
            _equipmentService.UpgradeEquipment(equipmentType, equipmentIDs);
        }
    }
}