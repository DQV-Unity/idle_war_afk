using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using qtLib.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using EquipmentCatalogue = _Scripts.Definition.EquipmentCatalogue;

namespace _Scripts.UI.Popup.EquipmentPopup
{
    public class EquipmentPopup : qtPopup
    {
        #region ----- Component Config -----

        [SerializeField] private Image _imgRarity;
        [SerializeField] private Image _imgEquipment;
        
        [SerializeField] private TextMeshProUGUI _txtEquipmentName;
        [SerializeField] private Image _imgEquipmentType;
        [SerializeField] private TextMeshProUGUI _txtRarity;
        
        [SerializeField] private Slider _sldEquipmentLevel;
        [SerializeField] private TextMeshProUGUI _txtEquipmentLevel;
        [SerializeField] private TextMeshProUGUI _txtEquipmentLevelProgress;
        
        [SerializeField] private TextMeshProUGUI _txtOwnedEffect;
        [SerializeField] private TextMeshProUGUI _txtEquippedEffect;
        
        [Space]
        [SerializeField] private Button _btnEquip;
        [SerializeField] private Button _btnUnEquip;
        [SerializeField] private Button _btnFuse;
        
        [Space]
        [SerializeField] private EquipmentScrollView equipmentScrollView;

        [Space]
        [SerializeField] private TextMeshProUGUI _txtTotalEffect;
        
        [Space] 
        [SerializeField] private Button _btnSummonEquipment;
        [SerializeField] private Button _btnFuseAll;
        [SerializeField] private Button _btnClose;
        
        #endregion

        #region ----- Properties -----

        public Button BtnEquip => _btnEquip;
        public Button BtnUnEquip => _btnUnEquip;
        public Button BtnFuse => _btnFuse;
        public Button BtnClose => _btnClose;

        #endregion

        #region ----- Public Functions -----

        public void ShowCollection(EquipmentCatalogue equipmentCatalogue, int selectedEquipment, int equippedEquipment,
            Action<int> onSelectEquipment, bool firstTime = false)
        {
            equipmentScrollView.ShowCollection(equipmentCatalogue.owned, onSelectEquipment, selectedEquipment, equippedEquipment, firstTime);
        }

        public void ShowEquipment(Definition.Equipment equipment, bool isEquipped)
        {
            _btnEquip.gameObject.SetActive(!isEquipped);
            _btnUnEquip.gameObject.SetActive(isEquipped);
            
            EquipmentConfig equipmentConfig = GameConfig.Instance.GetEquipmentConfig(equipment.equipmentType, equipment.ID);
            EquipmentAsset equipmentAsset = GameAsset.Instance.GetEquipmentAsset(equipmentConfig.EquipmentType, equipment.ID);
            EquipmentCatalogueAsset equipmentCatalogueAsset = GameAsset.Instance.GetEquipmentCatalogueAsset(equipmentConfig.EquipmentType);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(equipmentConfig.Rarity);
            _imgEquipment.sprite = equipmentAsset.SprIcon;
            _txtEquipmentName.SetText(equipmentAsset.Name);
            _imgEquipmentType.sprite = equipmentCatalogueAsset.SprIcon;
            _imgRarity.sprite = rarityAsset.SprItemBackground;
            _txtRarity.SetText(equipmentConfig.Rarity.ToString());
            _txtEquipmentLevel.SetText($"Level {equipment.level}");
            _txtOwnedEffect.SetText($"{equipmentConfig.OwnedBonus.bonusStat} {equipmentConfig.OwnedBonus.value}%");
            _txtEquippedEffect.SetText($"{equipmentConfig.EquippedBonus.bonusStat} {equipmentConfig.EquippedBonus.value}%");
            // _txtCharacterLevelProgress
                // _sldCharacterLevel.
        }

        #endregion
    }
}