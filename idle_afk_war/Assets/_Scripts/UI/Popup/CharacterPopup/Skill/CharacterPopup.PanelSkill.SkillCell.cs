using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class SkillCell : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _goContent;
        [SerializeField] private Button _btnSelect;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private Image _imgSkillIcon;
        [SerializeField] private TextMeshProUGUI _txtLevel;
        [SerializeField] private TextMeshProUGUI _txtLevelProgress;
        [SerializeField] private Slider _sldLevelProgress;
        [SerializeField] private GameObject _goEquipped;

        #endregion

        #region ----- Variable -----

        private int _skillID;
        private Action<int> _onSelectSkill;

        #endregion

        #region ----- Unity Event -----

        private void Start()
        {
            _btnSelect.onClick.AddListener(OnClickSelectButton);
        }

        #endregion
        
        #region ----- Public Functions -----

        public void ShowSkill(Definition.Skill skill, Func<int, bool> isEquip, Action<int> selectSkill)
        {
            _goContent.SetActive(true);
            _skillID = skill.ID;
            _onSelectSkill = selectSkill;
            
            SkillConfig skillConfig = GameConfig.Instance.GetSkillConfig(skill.ID);
            SkillAsset skillAsset = GameAsset.Instance.GetSkillAsset(skill.ID);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(skillConfig.Rarity);
            
            _imgRarity.sprite = rarityAsset.SprItemBackground;
            _imgSkillIcon.sprite = skillAsset.SprIcon;
            _txtLevel.SetText($"Lv{skill.level}");

            _goEquipped.SetActive(isEquip.Invoke(skill.ID));
        }

        public void ShowEmpty()
        {
            _goContent.SetActive(false);
        }

        #endregion

        #region ----- Private Functions -----

        private void OnClickSelectButton()
        {
            _onSelectSkill?.Invoke(_skillID);
        }

        #endregion
    }
}