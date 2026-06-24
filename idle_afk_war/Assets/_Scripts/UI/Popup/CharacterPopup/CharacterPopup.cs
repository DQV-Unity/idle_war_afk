using System;
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

        public void ShowCharacterDetails(Character equippedCharacter)
        {
            _pnlCharacter.ShowCharacterDetail(equippedCharacter);
        }

        public void ShowEquipment(EquipmentSlot[] equipmentSlots, Action<EEquipmentType> selectEquipmentSlot, Func<EEquipmentType, int, Definition.Equipment> getEquipmentData)
        {
            _pnlCharacter.ShowEquipment(equipmentSlots, selectEquipmentSlot, getEquipmentData);
        }

        #endregion
    }
}