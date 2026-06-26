using System;
using System.Collections.Generic;
using _Scripts.Data.Config;
using _Scripts.Definition;
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

        public void ShowSkills(
            ref List<Definition.Skill> skills, 
            int dataIndex, 
            Func<int, bool> isEquip, 
            Action<int> selectSkill, 
            Func<EItemType, int, ItemData> getItemData, 
            Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            for (var i = 0; i < _skillCells.Length; i++)
            {
                if (i + dataIndex * CellPerRow >= skills.Count)
                {
                    _skillCells[i].ShowEmpty();
                    continue;
                }

                _skillCells[i].ShowSkill(skills[i + dataIndex * CellPerRow], isEquip, selectSkill, getItemData, getLevelConfig);
            }
        }

        #endregion
    }
}