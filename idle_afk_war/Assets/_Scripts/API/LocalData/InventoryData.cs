using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class InventoryData : DataModel
    {
        [SerializeField] private ItemInventory _characterInventory;
        [SerializeField] private ItemInventory _equipmentInventory;
        [SerializeField] private ItemInventory _skillInventory;
        
        public ItemInventory CharacterInventory => _characterInventory;
        public ItemInventory EquipmentInventory => _equipmentInventory;
        public ItemInventory SkillInventory => _skillInventory;

        public InventoryData()
        {
            _characterInventory = new ItemInventory()
            {
                itemType = EItemType.Character,
                owned = new()
            };
            
            _equipmentInventory = new ItemInventory()
            {
                itemType = EItemType.Equipment,
                owned = new()
            };
            
            _skillInventory = new ItemInventory()
            {
                itemType = EItemType.Skill,
                owned = new()
            };
        }
    }
}