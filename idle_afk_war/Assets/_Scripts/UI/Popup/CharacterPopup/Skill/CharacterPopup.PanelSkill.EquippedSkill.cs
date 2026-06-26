using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class EquippedSkill : MonoBehaviour
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

        #region ----- Variables -----

        private int _skillID;
        private Action<int> _onSelectSkill;

        #endregion

        #region ----- Unity Event -----

        private void Start()
        {
            _btnSelect.onClick.AddListener(OnSelectSkill);
        }

        #endregion
        
        #region ----- Public Functions -----

        public void ShowSkillSlot(Definition.Skill skill, Action<int> selectSkill)
        {
            _btnSelect.enabled = true;
            _goSkill.SetActive(true);
            _goEmpty.SetActive(false);
            _goLock.SetActive(false);
            
            _onSelectSkill = selectSkill;
            
            SkillConfig skillConfig = GameConfig.Instance.GetSkillConfig(skill.ID);
            SkillAsset skillAsset = GameAsset.Instance.GetSkillAsset(skill.ID);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(skillConfig.Rarity);
            
            _imgRarity.sprite = rarityAsset.SprItemBackground;
            _imgSkillIcon.sprite = skillAsset.SprIcon;
            _txtSkillLevel.SetText($"Lv{skill.level}");
        }

        public void ShowEmpty(Action<int> selectSkill)
        {
            _btnSelect.enabled = true;
            _goSkill.SetActive(false);
            _goEmpty.SetActive(true);
            _goLock.SetActive(false);
            
            _onSelectSkill = selectSkill;
        }

        public void Lock()
        {
            _btnSelect.enabled = false;
            _goSkill.SetActive(false);
            _goEmpty.SetActive(false);
            _goLock.SetActive(true);
        }

        #endregion

        #region ----- Private Functions -----

        private void OnSelectSkill()
        {
            _onSelectSkill?.Invoke(_skillID);
        }

        #endregion
    }
}