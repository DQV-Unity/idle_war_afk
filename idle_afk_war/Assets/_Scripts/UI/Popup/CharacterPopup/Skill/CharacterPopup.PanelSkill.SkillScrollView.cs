using System;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class SkillScrollView : MonoBehaviour, IEnhancedScrollerDelegate
    {
        #region ----- Component Config -----

        [SerializeField] private EnhancedScroller _scroller;
        [SerializeField] private SkillRow _skillRowPrefab; 

        #endregion

        #region ----- Variables -----

        private List<Definition.Skill> _skills;
        private Func<int, bool> _isEquip;
        private Action<int> _selectSkill;
        
        #endregion

        #region ----- Unity Events -----

        private void Awake()
        {
            _scroller.Delegate = this;
        }

        #endregion
        
        #region ----- Public Functions -----

        public void ShowCollection(List<Definition.Skill> skills, Func<int, bool> isEquip, Action<int> selectSkill, bool firstTime = false)
        {
            _skills = skills;
            _isEquip = isEquip;
            _selectSkill = selectSkill;
            
            float currentPosition = 0;
            if (!firstTime)
            {
                currentPosition = _scroller.NormalizedScrollPosition;
            }

            _scroller.ReloadData(currentPosition);
        }

        #endregion
        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return Mathf.CeilToInt((float)_skills.Count / SkillRow.CellPerRow);
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 125;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            SkillRow skillRow = _scroller.GetCellView(_skillRowPrefab) as SkillRow;
            skillRow.ShowSkills(ref _skills, dataIndex, _isEquip, _selectSkill);
            return skillRow;
        }
    }
}