using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
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
        [SerializeField] private Image _imgEquipment;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private TextMeshProUGUI _txtLevel;
        [SerializeField] private Slider _sldLevelProgress;
        [SerializeField] private TextMeshProUGUI _txtLevelProgress;
        [SerializeField] private GameObject _goEquipped;

        #endregion

        #region ----- Variables -----

        private int _equipmentID;
        private Action<int> _onSelectEquipment;
        
        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _btnSelect.onClick.AddListener(OnSelectEquipment);
        }

        #endregion

        #region ----- Public Functions -----
        
        public void ShowEquipment(
            Definition.Equipment equipment, 
            int selectedEquipment,
            int equippedEquipment, 
            Action<int> selectEquipment,
            Func<int, ItemData> getItemData, 
            Func<int, LevelConfig> getLevelConfig)
        {
            _equipmentID = equipment.ID;
            _onSelectEquipment = selectEquipment;
            _goSelected.SetActive(selectedEquipment == _equipmentID);
            _goContent.SetActive(true);
            _goEquipped.SetActive(_equipmentID == equippedEquipment);
            
            EquipmentConfig equipmentConfig = GameConfig.Instance.GetEquipmentConfig(equipment.equipmentType, equipment.ID);
            EquipmentAsset equipmentAsset = GameAsset.Instance.GetEquipmentAsset(equipment.equipmentType, equipment.ID);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(equipmentConfig.Rarity);
            ItemData itemData = getItemData(equipment.ID);
            LevelConfig levelConfig = getLevelConfig(equipment.level);
            
            _imgEquipment.sprite = equipmentAsset.SprIcon;
            _imgRarity.sprite = rarityAsset.SprItemBackground;
            _txtLevel.SetText($"Lv {equipment.level.ToString()}");
            _txtLevelProgress.SetText($"{itemData.amount}/{levelConfig.CardRequire}");
            _sldLevelProgress.maxValue = levelConfig.CardRequire;
            _sldLevelProgress.value = itemData.amount;
        }

        public void ShowEmpty()
        {
            _goContent.SetActive(false);
        }

        #endregion

        #region ----- Private Functions -----

        private void OnSelectEquipment()
        {
            _onSelectEquipment?.Invoke(_equipmentID);
        }

        #endregion
    }
}