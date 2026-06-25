using System;
using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Board
{
    public class EquipmentController : MonoBehaviour, IInventoryProvider
    {
        #region ----- Variables -----

        private EquipmentCatalogue[] _inventoryData;
        private EquipmentSlot[] _equipmentSlots;

        #endregion

        #region ----- Events -----

        public event Action onEquipmentHasChanged;

        #endregion

        #region ----- Properties -----

        public EquipmentCatalogue[] EquipmentCatalogues => _inventoryData;
        public EquipmentSlot[] EquipmentSlots => _equipmentSlots;

        #endregion

        public void SetUp(EquipmentCatalogue[] inventoryData,  EquipmentSlot[] equipmentSlots, bool needUpdate = false)
        {
            _inventoryData = inventoryData;
            _equipmentSlots = equipmentSlots;
            
            if (needUpdate)
            {
                onEquipmentHasChanged?.Invoke();
            }
        }

        // public void EquipEquipment(EEquipmentType equipmentType, int equipmentID)
        // {
        //     for (var i = 0; i < _inventoryData.Length; i++)
        //     {
        //         if (InventoryData[i].equipmentType != equipmentType)
        //         {
        //             continue;
        //         }
        //         _inventoryData[i].equipped = equipmentID;
        //         break;
        //     }
        //     
        //     onEquipmentHasChanged?.Invoke();
        // }
        //
        // public void UnequipEquipment(EEquipmentType equipmentType)
        // {
        //     for (var i = 0; i < _inventoryData.Length; i++)
        //     {
        //         if (InventoryData[i].equipmentType != equipmentType)
        //         {
        //             continue;
        //         }
        //
        //         _inventoryData[i].equipped = -1;
        //         break;
        //     }
        //     
        //     onEquipmentHasChanged?.Invoke();
        // }
    }
}