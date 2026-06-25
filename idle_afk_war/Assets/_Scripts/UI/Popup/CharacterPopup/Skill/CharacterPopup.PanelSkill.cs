using System;
using System.Collections.Generic;
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

        public void ShowEquippedSkills(int[] equippedSkills, Func<int, Definition.Skill> getSkill, Action<int> selectSkill)
        {
            _equippedSkills.ShowEquippedSkills(equippedSkills, getSkill, selectSkill);
        }

        public void ShowSkillCollection(List<Definition.Skill> skills, Func<int, bool> isEquip, Action<int> selectSkill)
        {
            _skillScrollView.ShowCollection(skills, isEquip, selectSkill);
        }

        #endregion
    }
}