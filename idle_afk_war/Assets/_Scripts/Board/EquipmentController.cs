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
        private List<Definition.Equipment> _equippedEquipments;

        #endregion

        #region ----- Events -----

        public event Action onEquipmentHasChanged;

        #endregion

        #region ----- Properties -----

        public EquipmentCatalogue[] EquipmentCatalogues => _inventoryData;
        public List<Definition.Equipment> EquippedEquipments => _equippedEquipments;

        #endregion

        public void SetUp(EquipmentCatalogue[] inventoryData,  List<Definition.Equipment> equippedEquipments)
        {
            _inventoryData = inventoryData;
            _equippedEquipments = equippedEquipments;
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