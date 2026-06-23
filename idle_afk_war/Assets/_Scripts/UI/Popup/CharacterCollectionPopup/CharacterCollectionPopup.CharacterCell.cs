using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
    public class CharacterCell : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _goContent;
        [SerializeField] private Button _btnSelect;
        [SerializeField] private Image _imgCharacter;
        [SerializeField] private Image _imgClass;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private TextMeshProUGUI _txtLevel;

        #endregion

        #region ----- Public Functions -----
        
        public void ShowCharacter(Character characters)
        {
            _goContent.SetActive(true);
        }

        public void ShowEmpty()
        {
            _goContent.SetActive(false);
        }

        #endregion
    }
}