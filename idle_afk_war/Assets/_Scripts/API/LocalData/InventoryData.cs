using System;
using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class InventoryData : DataModel
    {
        [SerializeField] private EquipmentCatalogue[] _equipments;
        [SerializeField] private EquipmentSlot[] _equipmentSlots;
        
        public EquipmentCatalogue[] Equipments => _equipments;
        public EquipmentSlot[] EquipmentSlots => _equipmentSlots;

        public InventoryData()
        {
            _equipments = new EquipmentCatalogue[]
            {
                new EquipmentCatalogue()
                {
                    equipmentType = EEquipmentType.Axe,
                    owned = new List<Definition.Equipment>()
                    {
                        new Definition.Equipment()
                        {
                            equipmentType = EEquipmentType.Axe,
                            ID = 1,
                            level = 1
                        }
                    }
                },
                new EquipmentCatalogue()
                {
                    equipmentType = EEquipmentType.Hammer,
                    owned = new List<Definition.Equipment>()
                    {
                        new Definition.Equipment()
                        {
                            equipmentType = EEquipmentType.Hammer,
                            ID = 1,
                            level = 1
                        }
                    }
                },
                new EquipmentCatalogue()
                {
                    equipmentType = EEquipmentType.Sword,
                    owned = new List<Definition.Equipment>()
                },
                new EquipmentCatalogue()
                {
                    equipmentType = EEquipmentType.Boom,
                    owned = new List<Definition.Equipment>()
                }
            };
            
            _equipmentSlots = new EquipmentSlot[]
            {
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Axe, 
                    isUnlock = true,
                    equippedEquipment = -1
                },
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Hammer,
                    isUnlock = true,
                    equippedEquipment = -1
                },
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Sword,
                    isUnlock = false,
                    equippedEquipment = -1
                },
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Boom,
                    isUnlock = false,
                    equippedEquipment = -1
                }
            };
        }
    }
}