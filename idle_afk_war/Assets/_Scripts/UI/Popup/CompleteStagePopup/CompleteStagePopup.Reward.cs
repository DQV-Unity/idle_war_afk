using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CompleteStagePopup
{
    public class Reward : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private Button _btnSelect;
        [SerializeField] private Image _imgBackgroundRarity;
        [SerializeField] private Image _imgItemRarity;
        [SerializeField] private Image _imgItem;
        [SerializeField] private TextMeshProUGUI _txtItemName;
        [SerializeField] private TextMeshProUGUI _txtItemRarity;
        [SerializeField] private TextMeshProUGUI _txtItemDescription;

        #endregion
    }
}