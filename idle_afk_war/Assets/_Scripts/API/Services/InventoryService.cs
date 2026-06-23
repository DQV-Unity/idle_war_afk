using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.API.Services
{
    public class InventoryService : APIService<InventoryData>
    {
        protected override string DataPath()
        {
            return "Inventory";
        }

        public void UnlockEquipmentSlot(EEquipmentType equipmentType)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(equipmentType);
            if (equipmentSlot.isUnlock)
            {
                return;
            }
            
            equipmentSlot.isUnlock = true;
            SaveData();
        }
        
        public void UnlockEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(equipmentType);
            if (!equipmentSlot.isUnlock)
            {
                return;
            }
            
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);

            for (var j = 0; j < equipmentCatalogue.owned.Count; j++)
            {
                if (equipmentCatalogue.owned[j].ID == equipmentID)
                {
                    return;
                }
            }        
            
            equipmentCatalogue.owned.Add(new Definition.Equipment()
            {
                ID = equipmentID,
                level = 1
            });
            SaveData();
        }

        public bool ChangeEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(equipmentType);
            if (!equipmentSlot.isUnlock)
            {
                return false;
            }

            equipmentSlot.equippedEquipment = default;
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);

            for (var i = 0; i < equipmentCatalogue.owned.Count; i++)
            {
                if (equipmentCatalogue.owned[i].ID != equipmentID)
                {
                    continue;
                }

                equipmentSlot.equippedEquipment = equipmentCatalogue.owned[i];
                SaveData();
                return true;
            }
            
            return false;
        }

        public void UpgradeEquipment(EEquipmentType equipmentType, params int[] equipmentIDs)
        {
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);
            for (var i = 0; i < equipmentIDs.Length; i++)
            {
                for (var j = 0; j < equipmentCatalogue.owned.Count; j++)
                {
                    if (equipmentCatalogue.owned[j].ID == equipmentIDs[i])
                    {
                        Definition.Equipment equipment = equipmentCatalogue.owned[j];
                        equipment.level += 1;
                    }
                }
            }
        }

        public EquipmentCatalogue GetEquipmentCatalogue(EEquipmentType equipmentType)
        {
            EquipmentCatalogue[] equipments = _data.Equipments;
            for (var i = 0; i < equipments.Length; i++)
            {
                if (equipments[i].equipmentType == equipmentType)
                {
                    return equipments[i];
                }
            }
            
            throw new KeyNotFoundException($"Equipment type {equipmentType} not found");
        }
        
        public Definition.Equipment GetEquippedEquipment(EEquipmentType equipmentType)
        {
            return GetEquipmentSlot(equipmentType).equippedEquipment;
        }

        public EquipmentCatalogue[] GetEquipmentCatalogues()
        {
            return _data.Equipments;
        }

        public EquipmentSlot[] GetEquippedEquipments()
        {
            return  _data.EquippedEquipments;
        }

        public EquipmentSlot GetEquipmentSlot(EEquipmentType equipmentType)
        {
            EquipmentSlot[] equipmentSlots = GetEquippedEquipments();
            for (var i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].equipmentType == equipmentType)
                {
                    return equipmentSlots[i];
                }
            }
            
            throw new KeyNotFoundException($"Equipment type {equipmentType} not found");
        }
    }
}