using System;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.EquipmentPopup
{
    public class EquipmentScrollView : MonoBehaviour, IEnhancedScrollerDelegate
    {
        #region ----- Component Config -----

        [SerializeField] private EnhancedScroller _scroller;
        [SerializeField] private EquipmentRow equipmentRowPrefab;
        
        #endregion

        #region ----- Variables -----

        private List<Definition.Equipment> _equipments;
        private Action<int> _onSelectEquipment;
        private int _selectedEquipment;
        private int _equippedEquipment;
        
        #endregion
        
        private void Awake()
        {
            _scroller.Delegate = this;
        }

        public void ShowCollection(List<Definition.Equipment> equipments, Action<int> onSelectEquipment, int selectedEquipment, int equippedEquipment, bool firstTime)
        {
            _equipments = equipments;
            _onSelectEquipment = onSelectEquipment;
            _selectedEquipment = selectedEquipment;
            _equippedEquipment = equippedEquipment;
            
            float currentPosition = 0;
            if (!firstTime)
            {
                currentPosition = _scroller.NormalizedScrollPosition;
            }
            _scroller.ReloadData(currentPosition);
        }

        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return Mathf.CeilToInt((float)_equipments.Count/EquipmentRow.CellPerRow);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 175;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            EquipmentRow equipmentRow = _scroller.GetCellView(equipmentRowPrefab) as EquipmentRow;
            equipmentRow.ShowEquipment(ref _equipments, dataIndex, _selectedEquipment, _equippedEquipment, _onSelectEquipment);
            return equipmentRow;
        }
    }
}