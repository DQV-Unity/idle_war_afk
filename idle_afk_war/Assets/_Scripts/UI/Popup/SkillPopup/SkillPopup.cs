using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using _Scripts.Definition;
using qtLib.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.SkillPopup
{
    public class SkillPopup : qtPopup
    {
        #region ----- Component Config -----

        [SerializeField] private Image _imgRarity;
        [SerializeField] private Image _imgSkillIcon;
        [SerializeField] private Image _imgClass;
        [SerializeField] private TextMeshProUGUI _txtName;
        [SerializeField] private TextMeshProUGUI _txtRarity;
        [SerializeField] private TextMeshProUGUI _txtLevel;
        [SerializeField] private TextMeshProUGUI _txtLevelProgress;
        [SerializeField] private Slider _sldLevelProgress;
        [SerializeField] private TextMeshProUGUI _txtDescription;
        [SerializeField] private TextMeshProUGUI _txtCoolDown;
        [SerializeField] private TextMeshProUGUI _txtOwnedEffect;
        
        [SerializeField] private Button _btnEquip;
        [SerializeField] private Button _btnUnEquip;
        [SerializeField] private Button _btnFuse;
        [SerializeField] private Button _btnClose;

        #endregion

        #region ----- Properties -----

        public Button BtnEquip => _btnEquip;
        public Button BtnUnEquip => _btnUnEquip;
        public Button BtnFuse => _btnFuse;
        public Button BtnClose => _btnClose;

        #endregion

        #region ----- Public Functions -----

        public void ShowSkill(
            Definition.Skill skill, 
            bool isEquipped, 
            Func<int, ItemData> getItemData,
            Func<int, LevelConfig> getLevelConfig)
        {
            SkillConfig skillConfig = GameConfig.Instance.GetSkillConfig(skill.ID);
            SkillAsset skillAsset = GameAsset.Instance.GetSkillAsset(skill.ID);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(skillConfig.Rarity);
            ItemData itemData = getItemData(skill.ID);
            LevelConfig levelConfig = getLevelConfig(skill.level);
            
            _imgRarity.sprite = rarityAsset.SprItemBackground;
            _imgSkillIcon.sprite = skillAsset.SprIcon;
            _txtName.SetText(skillAsset.Name);
            _txtRarity.SetText(skillConfig.Rarity.ToString());
            _txtDescription.SetText(skillAsset.Description);
            _txtCoolDown.SetText($"{skillConfig.ReloadTime}s");
            _txtLevel.SetText($"Lv{skill.level}");
            _txtLevelProgress.SetText($"{itemData.amount}/{levelConfig.CardRequire}");
            _sldLevelProgress.maxValue = levelConfig.CardRequire;
            _sldLevelProgress.value = itemData.amount;
            
            _txtOwnedEffect.SetText($"{skillConfig.OwnedBonus.bonusStat} {skillConfig.OwnedBonus.value}%");
            
            _btnEquip.gameObject.SetActive(!isEquipped);
            _btnUnEquip.gameObject.SetActive(isEquipped);
        }

        #endregion
    }
}