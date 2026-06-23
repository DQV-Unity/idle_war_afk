using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class CharacterPopup : qtPopup
    {
        [SerializeField] private PanelCharacter _pnlCharacter;

        #region ----- Properties -----

        public Button BtnChangeCharacter => _pnlCharacter.BtnChangeCharacter;

        #endregion

        #region ----- Public Functions -----

        public void ShowCharacterDetails(Definition.Character equippedCharacter)
        {
            _pnlCharacter.ShowCharacterDetail(equippedCharacter);
        }

        public void ShowEquipment(EquipmentSlot[] equipmentSlots)
        {
            _pnlCharacter.ShowEquipment(equipmentSlots);
        }

        #endregion
    }
}