using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
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
        [SerializeField] private Button _btnSelect;
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

        #region ----- Variables -----

        private Action<EEquipmentType> _onSelect;

        #endregion

        #region ----- Properties -----

        public EEquipmentType EquipmentType => _equipmentType;

        #endregion

        #region ----- Unity Event -----

        private void Start()
        {
            _btnSelect.onClick.AddListener(OnSelectEquipmentSlot);
        }

        #endregion
        
        #region ----- Public Functioons -----

        public void ShowEquipmentSlot(Definition.Equipment equippedEquipment, Action<EEquipmentType> selectEquipmentSlot)
        { 
            _onSelect = selectEquipmentSlot;
            
            _goEquipment.SetActive(true);
            _goEmpty.SetActive(false);
            _goLock.SetActive(false);
            _btnSelect.enabled = true;

            EquipmentConfig equipmentConfig = GameConfig.Instance.GetEquipmentConfig(equippedEquipment.equipmentType, equippedEquipment.ID);
            EquipmentAsset equipmentAsset = GameAsset.Instance.GetEquipmentAsset(equippedEquipment.equipmentType, equippedEquipment.ID);
            _imgEquipmentIcon.sprite = equipmentAsset.SprIcon;
            _txtEquipmentLevel.SetText($"Level {equippedEquipment.level}");

            _imgEquipmentClass.sprite = GameAsset.Instance.GetClassAsset(equipmentConfig.Class).SprIcon;
            _imgEquipmentRarity.sprite = GameAsset.Instance.GetRarityAsset(equipmentConfig.Rarity).SprItemBackground;
        }

        public void ShowEmpty(Action<EEquipmentType> selectEquipmentSlot)
        {
            _onSelect = selectEquipmentSlot;
           
            _goEmpty.SetActive(true);
            _goLock.SetActive(false);
            _goEquipment.SetActive(false);

            _btnSelect.enabled = true;
        }
        
        public void Lock()
        {
            _goLock.SetActive(true);
            _goEmpty.SetActive(false);
            _goEquipment.SetActive(false);
            
            _btnSelect.enabled = false;
        }
        #endregion

        #region ----- Private Functioons -----

        private void OnSelectEquipmentSlot()
        {
            _onSelect?.Invoke(_equipmentType);
        }

        #endregion
    }
}