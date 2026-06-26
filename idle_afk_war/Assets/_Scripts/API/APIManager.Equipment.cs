using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public EquipmentCatalogue GetEquipmentCatalogue(EEquipmentType equipmentType)
        {
            return qtGameExtension.Clone(_equipmentService.GetEquipmentCatalogue(equipmentType));
        }

        public Definition.Equipment GetEquippedEquipment(EEquipmentType equipmentType)
        {
            return qtGameExtension.Clone(_equipmentService.GetEquippedEquipment(equipmentType));
        }

        public Definition.Equipment GetEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            return qtGameExtension.Clone(_equipmentService.GetEquipment(equipmentType, equipmentID));
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