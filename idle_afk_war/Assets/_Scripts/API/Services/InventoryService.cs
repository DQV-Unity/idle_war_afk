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

        public void UnlockEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);

            if (!equipmentCatalogue.isUnlock)
            {
                return;
            }

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
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);
            if (!equipmentCatalogue.isUnlock)
            {
                return false;
            }

            for (var i = 0; i < equipmentCatalogue.owned.Count; i++)
            {
                if (equipmentCatalogue.owned[i].ID != equipmentID)
                {
                    continue;
                }
                List<Definition.Equipment> equippedEquipment = _data.EquippedEquipments;

                for (var j = 0; j < equippedEquipment.Count; j++)
                {
                    if (equippedEquipment[j].equipmentType != equipmentType)
                    {
                        continue;
                    }

                    if (equippedEquipment[j].ID == equipmentID)
                    {
                        return false;
                    }
                    
                    equippedEquipment[j] = equipmentCatalogue.owned[i];
                    SaveData();
                    return true;
                }
                
                equippedEquipment.Add(equipmentCatalogue.owned[i]);
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

        public EquipmentCatalogue[] GetEquipmentCatalogues()
        {
            return _data.Equipments;
        }

        public List<Definition.Equipment> GetEquippedEquipments()
        {
            return  _data.EquippedEquipments;
        }
    }
}