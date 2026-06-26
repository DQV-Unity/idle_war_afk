using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public ItemData GetItemData(EItemType itemType, int itemID)
        {
            return qtGameExtension.Clone(_inventoryService.GetItemData(itemType, itemID));
        }
        
        public ItemInventory GetItemInventory(EItemType itemType)
        {
            return qtGameExtension.Clone(_inventoryService.GetItemInventory(itemType));
        }

        public void ClaimItem(EItemType itemType, int itemID, int amount)
        {
            _inventoryService.ClaimItem(itemType, itemID, amount);
        }

        public bool ConsumeItem(EItemType itemType, int itemID, int amount)
        {
            return _inventoryService.ConsumeItem(itemType, itemID, amount);
        }
    }
}