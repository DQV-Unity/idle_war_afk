using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class Skill : MonoBehaviour
    {
        #region ----- Component Config -----
        
        [SerializeField] private Button _btnSelect;

        [SerializeField] private GameObject _goSkill;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private Image _imgSkillIcon;
        [SerializeField] private TextMeshProUGUI _txtSkillLevel;

        [Space] 
        [SerializeField] private GameObject _goLock;
        [SerializeField] private GameObject _goEmpty;

        #endregion
    }
}