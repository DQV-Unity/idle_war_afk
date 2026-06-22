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
        [SerializeField] private List<Definition.Equipment> _equippedEquipments;
        
        public EquipmentCatalogue[] Equipments => _equipments;
        public List<Definition.Equipment> EquippedEquipments => _equippedEquipments;

        public InventoryData()
        {
            _equipments = new EquipmentCatalogue[] { };
            _equippedEquipments = new List<Definition.Equipment>();
        }
    }
}