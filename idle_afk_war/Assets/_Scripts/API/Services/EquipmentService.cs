using System;
using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API.Services
{
    public class EquipmentService : APIService<EquipmentData>
    {
        protected override string DataPath => "Inventory";
        
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
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);
            int equippedEquipment = GetEquipmentSlot(equipmentType).equippedEquipment;
            if (equippedEquipment <= 0)
            {
                return null;
            }
            
            for (var i = 0; i < equipmentCatalogue.owned.Count; i++)
            {
                if (equipmentCatalogue.owned[i].ID == equippedEquipment)
                {
                    return equipmentCatalogue.owned[i];
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned equipment {equipmentType} {equippedEquipment}");
        }

        public Definition.Equipment GetEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);
            for (var i = 0; i < equipmentCatalogue.owned.Count; i++)
            {
                if (equipmentCatalogue.owned[i].ID == equipmentID)
                {
                    return equipmentCatalogue.owned[i];
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned equipment {equipmentType} {equipmentID}");
        }
        
        public EquipmentCatalogue[] GetEquipmentCatalogues()
        {
            return _data.Equipments;
        }

        public EquipmentSlot[] GetEquipmentSlot()
        {
            return _data.EquipmentSlots;
        }

        public EquipmentSlot GetEquipmentSlot(EEquipmentType equipmentType)
        {
            EquipmentSlot[] equipmentSlots = GetEquipmentSlot();
            for (var i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].equipmentType == equipmentType)
                {
                    return equipmentSlots[i];
                }
            }
            
            throw new KeyNotFoundException($"Equipment type {equipmentType} not found");
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

        public bool EquipEquipment(EEquipmentType equipmentType, int equipmentID)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(equipmentType);
            if (!equipmentSlot.isUnlock)
            {
                return false;
            }

            EquipmentCatalogue equipmentCatalogue = GetEquipmentCatalogue(equipmentType);

            for (var i = 0; i < equipmentCatalogue.owned.Count; i++)
            {
                if (equipmentCatalogue.owned[i].ID != equipmentID)
                {
                    continue;
                }

                equipmentSlot.equippedEquipment = equipmentID;
                SaveData();
                return true;
            }
            
            return false;
        }

        public bool UnEquipEquipment(EEquipmentType equipmentType)
        {
            EquipmentSlot equipmentSlot = GetEquipmentSlot(equipmentType);
            if (!equipmentSlot.isUnlock)
            {
                return false;
            }

            if (equipmentSlot.equippedEquipment <= 0)
            {
                return false;
            }

            equipmentSlot.equippedEquipment = -1;
            SaveData();
            return true;
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

    }
}