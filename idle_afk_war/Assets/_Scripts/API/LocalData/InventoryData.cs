using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class InventoryData : DataModel
    {
        [SerializeField] private EquipmentCatalogue[] _equipments;
        [SerializeField] private EquipmentSlot[] _equippedEquipments;
        
        public EquipmentCatalogue[] Equipments => _equipments;
        public EquipmentSlot[] EquippedEquipments => _equippedEquipments;

        public InventoryData()
        {
            _equipments = new EquipmentCatalogue[] { };
            _equippedEquipments = new EquipmentSlot[]
            {
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Axe, 
                    isUnlock = false,
                },
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Hammer,
                    isUnlock = false,
                },
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Sword,
                    isUnlock = false,
                },
                new EquipmentSlot()
                {
                    equipmentType = EEquipmentType.Boom,
                    isUnlock = false,
                }
            };
        }
    }
}