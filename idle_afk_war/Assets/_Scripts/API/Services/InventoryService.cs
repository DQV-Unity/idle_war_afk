using System;
using _Scripts.Definition;

namespace _Scripts.API.Services
{
    public class InventoryService : APIService<InventoryData>, IAPIService
    {
        protected override string DataPath => "Inventory";

        public ItemData GetItemData(EItemType itemType, int itemID)
        {
            ItemInventory itemInventory = itemType switch
            {
                EItemType.Character => _data.CharacterInventory,
                EItemType.Equipment => _data.EquipmentInventory,
                EItemType.Skill => _data.SkillInventory,
                _ => throw new ArgumentOutOfRangeException($"Not owned item {itemType} - {itemID}")
            };

            for (int i = 0; i < itemInventory.owned.Count; i++)
            {
                if (itemInventory.owned[i].ID == itemID)
                {
                    return itemInventory.owned[i];
                }
            }
            
            return new ItemData()
            {
                ID = itemID,
            };
        }
        
        public ItemInventory GetItemInventory(EItemType itemType)
        {
            return itemType switch
            {
                EItemType.Character => _data.CharacterInventory,
                EItemType.Equipment => _data.EquipmentInventory,
                EItemType.Skill => _data.SkillInventory,
                _ => throw new ArgumentOutOfRangeException($"Not owned item {itemType}")
            };
        }

        public void ClaimItem(EItemType itemType, int itemID, int amount)
        {
            ItemData itemData = GetItemData(itemType, itemID);
            if (itemData == null)
            {
                //Todo: unlock
                ItemInventory itemInventory = GetItemInventory(itemType);
                itemData = new ItemData()
                {
                    ID = 0
                };
                itemInventory.owned.Add(itemData);
            }
            
            itemData.amount += amount;
            SaveData();
        }

        public bool ConsumeItem(EItemType itemType, int itemID, int amount)
        {
            ItemData itemData = GetItemData(itemType, itemID);
            if (itemData == null)
            {
                return false;
            }
            
            if (itemData.amount < amount)
            {
                return false;
            }
            
            itemData.amount -= amount;
            SaveData();
            return true;
        }
    }
}