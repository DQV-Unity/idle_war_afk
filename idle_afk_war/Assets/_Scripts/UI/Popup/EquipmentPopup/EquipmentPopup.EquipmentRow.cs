using System;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.EquipmentPopup
{
    public class EquipmentRow : EnhancedScrollerCellView
    {
        public const int CellPerRow = 4;

        #region ----- Component Config -----

        [SerializeField] private EquipmentCell[] _equipmentCells;

        #endregion
        
        #region ----- Public Functions -----

        public void ShowEquipments(ref List<Definition.Equipment> equipments, int dataIndex, int selectedEquipment, int equippedEquipment, Action<int> selectEquipment)
        {
            for (var i = 0; i < _equipmentCells.Length; i++)
            {
                if (i + dataIndex * CellPerRow >= equipments.Count)
                {
                    _equipmentCells[i].ShowEmpty();
                    continue;
                }

                _equipmentCells[i].ShowEquipment(equipments[i + dataIndex * CellPerRow], selectedEquipment, equippedEquipment, selectEquipment);
            }
        }

        #endregion

    }
}