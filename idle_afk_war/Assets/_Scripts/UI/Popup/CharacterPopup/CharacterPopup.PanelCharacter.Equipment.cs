using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class Equipment : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private EEquipmentType _equipmentType;
        [SerializeField] private Image _imgEquipmentRarity;
        [SerializeField] private Image _imgEquipmentIcon;
        [SerializeField] private Image _imgEquipmentClass;
        [SerializeField] private TextMeshProUGUI _txtEquipmentName;
        [SerializeField] private TextMeshProUGUI _txtEquipmentLevel;

        #endregion

        #region ----- Properties -----

        public EEquipmentType EquipmentType => _equipmentType;

        #endregion
        
        #region ----- Public Functioons -----

        public void ShowEquipment(Definition.Equipment  equippedEquipment)
        {
            
        }
        
        public void Lock()
        {
            
        }
        
        #endregion
    }
}