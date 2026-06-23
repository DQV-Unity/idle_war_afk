using System;
using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.EquipmentPopup
{
    public class EquipmentCell : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _goContent;
        [SerializeField] private GameObject _goSelected;
        [SerializeField] private Button _btnSelect;
        [SerializeField] private Image _imgCharacter;
        [SerializeField] private Image _imgClass;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private TextMeshProUGUI _txtLevel;

        #endregion

        #region ----- Variables -----

        private int _equipmentID;
        private Action<int> _omSelectEquipment;
        
        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _btnSelect.onClick.AddListener(OnSelectEquipment);
        }

        #endregion

        #region ----- Public Functions -----
        
        public void ShowEquipment(Definition.Equipment equipment, int selectedEquipment, Action<int> selectEquipment)
        {
            _equipmentID = equipment.ID;
            _omSelectEquipment = selectEquipment;
            _goSelected.SetActive(selectedEquipment == equipment.ID);
            _goContent.SetActive(true);
        }

        public void ShowEmpty()
        {
            _goContent.SetActive(false);
        }

        #endregion

        #region ----- Private Functions -----

        private void OnSelectEquipment()
        {
            _omSelectEquipment?.Invoke(_equipmentID);
        }

        #endregion
    }
}