using System;
using System.Collections.Generic;
using _Scripts.Definition;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
    public class CharacterRow : EnhancedScrollerCellView
    {
        public const int CellPerRow = 4;

        #region ----- Component Config -----

        [SerializeField] private CharacterCell[] _characterCells;

        #endregion
        
        #region ----- Public Functions -----

        public void ShowCharacter(ref List<Character> characters, int dataIndex, int selectedCharacter, Action<int> selectCharacter)
        {
            for (var i = 0; i < _characterCells.Length; i++)
            {
                if (i + dataIndex * CellPerRow >= characters.Count)
                {
                    _characterCells[i].ShowEmpty();
                    continue;
                }

                _characterCells[i].ShowCharacter(characters[i + dataIndex * CellPerRow], selectedCharacter, selectCharacter);
            }
        }

        #endregion

    }
}