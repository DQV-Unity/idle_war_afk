using qtLib.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.OverlayScene
{
    public class FooterScene : qtOverlayScene
    {
        #region ----- Component Config -----

        [SerializeField] private Button _btnCharacter;
        [SerializeField] private Button _btnCompanion;
        [SerializeField] private Button _btnFarm;
        [SerializeField] private Button _btnInstitute;
        [SerializeField] private Button _btnArmory;
        [SerializeField] private Button _btnShop;

        #endregion

        #region ----- Properties -----

        public Button BtnCharacter => _btnCharacter;
        public Button BtnCompanion => _btnCompanion;
        public Button BtnFarm => _btnFarm;
        public Button BtnInstitute => _btnInstitute;
        public Button BtnArmory => _btnArmory;
        public Button BtnShop => _btnShop;

        #endregion
    }
}