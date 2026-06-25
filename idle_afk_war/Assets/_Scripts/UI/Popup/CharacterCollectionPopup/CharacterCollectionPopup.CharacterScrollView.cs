using System;
using System.Collections.Generic;
using _Scripts.Definition;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
    public class CharacterScrollView : MonoBehaviour, IEnhancedScrollerDelegate
    {
        #region ----- Component Config -----

        [SerializeField] private EnhancedScroller _scroller;
        [SerializeField] private CharacterRow _characterRowPrefab;
        
        #endregion

        #region ----- Variables -----

        private List<Character> _characters;
        private Action<int> _onSelectCharacter;
        private int _selectedCharacter;
        
        #endregion
        
        private void Awake()
        {
            _scroller.Delegate = this;
        }

        public void ShowCollection(List<Character> characters, Action<int> onSelectCharacter, int selectedCharacter, bool firstTime)
        {
            _characters = characters;
            _onSelectCharacter = onSelectCharacter;
            _selectedCharacter = selectedCharacter;
            
            float currentPosition = 0;
            if (!firstTime)
            {
                currentPosition = _scroller.NormalizedScrollPosition;
            }
            _scroller.ReloadData(currentPosition);
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
            characterRow.ShowCharacter(ref _characters, dataIndex, _selectedCharacter, _onSelectCharacter);
            return characterRow;
        }
    }
}