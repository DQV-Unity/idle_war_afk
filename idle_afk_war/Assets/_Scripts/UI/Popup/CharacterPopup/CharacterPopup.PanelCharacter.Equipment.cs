using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class Equipment : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _goEquipment;
        [SerializeField] private EEquipmentType _equipmentType;
        [SerializeField] private Image _imgEquipmentRarity;
        [SerializeField] private Image _imgEquipmentIcon;
        [SerializeField] private Image _imgEquipmentClass;
        [SerializeField] private TextMeshProUGUI _txtEquipmentName;
        [SerializeField] private TextMeshProUGUI _txtEquipmentLevel;

        [Space]
        [SerializeField] private GameObject _goEmpty;
        [SerializeField] private GameObject _goLock;
        
        #endregion

        #region ----- Properties -----

        public EEquipmentType EquipmentType => _equipmentType;

        #endregion
        
        #region ----- Public Functioons -----

        public void ShowEquipment(Definition.Equipment  equippedEquipment)
        {
            _goEquipment.SetActive(true);
            _goEmpty.SetActive(false);
            _goLock.SetActive(false);
        }

        public void ShowEmpty()
        {
            _goEmpty.SetActive(true);
            _goLock.SetActive(false);
            _goEquipment.SetActive(false);
        }
        
        public void Lock()
        {
            _goLock.SetActive(true);
            _goEmpty.SetActive(false);
            _goEquipment.SetActive(false);
        }
        
        #endregion
    }
}