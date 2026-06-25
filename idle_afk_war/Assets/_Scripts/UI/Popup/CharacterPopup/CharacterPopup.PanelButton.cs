using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    [Serializable]
    public class PanelButton
    {
        #region ----- Component Config -----

        [SerializeField] private Button _btnCharacter;
        [SerializeField] private Button _btnSkill;

        #endregion

        #region ----- Properties -----

        public Button BtnCharacter => _btnCharacter;
        public Button BtnSkill => _btnSkill;

        #endregion
    }
}