using System.Collections.Generic;
using _Scripts.Definition;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
    public class CharacterScrollview : MonoBehaviour, IEnhancedScrollerDelegate
    {
        #region ----- Component Config -----

        [SerializeField] private EnhancedScroller _scroller;
        [SerializeField] private CharacterRow _characterRowPrefab;
        
        #endregion

        #region ----- Variables -----

        private List<Character> _characters;
        
        #endregion
        
        private void Awake()
        {
            _scroller.Delegate = this;
        }

        public void ShowCollection(List<Character> characters)
        {
            _characters = characters;

            _scroller.ReloadData();
        }

        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return Mathf.CeilToInt((float)_characters.Count/CharacterRow.CellPerRow);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 175;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            CharacterRow characterRow = _scroller.GetCellView(_characterRowPrefab) as CharacterRow;
            characterRow.ShowCharacter(ref _characters, dataIndex);
            return characterRow;
        }
    }
}