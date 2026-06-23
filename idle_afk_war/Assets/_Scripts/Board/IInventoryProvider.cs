using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.Board
{
    public interface IInventoryProvider
    {
        public EquipmentCatalogue[] EquipmentCatalogues { get; }
        public EquipmentSlot[] EquipmentSlots { get; }
    }
}