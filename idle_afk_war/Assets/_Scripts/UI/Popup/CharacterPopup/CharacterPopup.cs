using System.Collections.Generic;
using qtLib.UI.Base;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class CharacterPopup : qtPopup
    {
        [SerializeField] private PanelCharacter _pnlCharacter;

        #region ----- Public Functions -----

        public void ShowCharacterDetails(int characterID, int characterLevel)
        {
            _pnlCharacter.ShowCharacterDetail(characterID, characterLevel);
        }

        public void ShowEquipment(List<Definition.Equipment> equippedEquipments)
        {
            _pnlCharacter.ShowEquipment(equippedEquipments);
        }

        #endregion
    }
}