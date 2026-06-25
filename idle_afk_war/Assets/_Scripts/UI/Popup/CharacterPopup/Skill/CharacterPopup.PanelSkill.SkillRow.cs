using System;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class SkillRow : EnhancedScrollerCellView
    {
        public const int CellPerRow = 6;
        
        #region ----- Component Config -----

        [SerializeField] private SkillCell[] _skillCells;

        #endregion

        #region ----- Public Functions -----

        public void ShowSkills(ref List<Definition.Skill> skills, int dataIndex, Func<int, bool> isEquip, Action<int> selectSkill)
        {
            for (var i = 0; i < _skillCells.Length; i++)
            {
                if (i + dataIndex * CellPerRow >= skills.Count)
                {
                    _skillCells[i].ShowEmpty();
                    continue;
                }

                _skillCells[i].ShowSkill(skills[i + dataIndex * CellPerRow], isEquip, selectSkill);
            }
        }

        #endregion
    }
}