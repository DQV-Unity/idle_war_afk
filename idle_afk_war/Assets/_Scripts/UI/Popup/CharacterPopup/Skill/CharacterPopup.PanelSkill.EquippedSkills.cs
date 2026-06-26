using System;
using _Scripts.Data.Config;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.UI.Popup.CharacterPopup
{
    [Serializable]
    public class EquippedSkills
    {
        #region ----- Component Config -----

        [SerializeField] private EquippedSkill[] _equippedSkills; 

        #endregion

        #region ----- Public Functions -----

        public void ShowSkillSlots(
            SkillSlot[] skillSlots, 
            Func<int, Definition.Skill> getSkill, 
            Action<int> selectSkill)
        {
            for (var i = 0; i < skillSlots.Length; i++)
            {
                if (!skillSlots[i].isUnlock)
                {
                    _equippedSkills[i].Lock();
                    continue;
                }

                if (skillSlots[i].equippedSkill <= 0)
                {
                    _equippedSkills[i].ShowEmpty(selectSkill);
                    continue;
                }

                _equippedSkills[i].ShowSkillSlot(getSkill.Invoke(skillSlots[i].equippedSkill), selectSkill);
            }
        }

        #endregion
    }
}