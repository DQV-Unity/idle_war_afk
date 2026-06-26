using System;
using System.Collections.Generic;
using _Scripts.Data.Config;
using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class PanelSkill : MonoBehaviour
    {
        #region ----- Commponent Config -----

        [SerializeField] private EquippedSkills _equippedSkills;
        [SerializeField] private SkillScrollView _skillScrollView;
        
        [Space]
        [SerializeField] private TextMeshProUGUI _txtTotalEffect;
        
        [Space]
        [SerializeField] private Button _btnSummon;
        [SerializeField] private Button _btnFuseAll;

        #endregion

        #region ----- Properties -----

        public Button BtnSummon => _btnSummon;
        public Button BtnFuseAll => _btnFuseAll;

        #endregion

        #region ----- Public Functions -----

        public void ShowSkillSlots(SkillSlot[] skillSlots, Func<int, Definition.Skill> getSkill, Action<int> selectSkill, Func<EItemType, int, ItemData> getItemData, Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            _equippedSkills.ShowSkillSlots(skillSlots, getSkill, selectSkill);
        }

        public void ShowSkillCollection(List<Definition.Skill> skills, Func<int, bool> isEquip, Action<int> selectSkill, Func<EItemType, int, ItemData> getItemData, Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            _skillScrollView.ShowCollection(skills, isEquip, selectSkill, getItemData, getLevelConfig);
        }

        public void ShowOwnedAttackEffect(int value)
        {
            _txtTotalEffect.SetText($"Owned Effect: <color=yellow>ATK +{value}%</color>");   
        }

        #endregion
    }
}