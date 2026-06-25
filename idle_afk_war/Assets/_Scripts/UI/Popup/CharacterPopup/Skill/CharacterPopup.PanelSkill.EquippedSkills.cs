using System;
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

        public void ShowEquippedSkills(int[] equippedSkills, Func<int, Definition.Skill> getSkill, Action<int> selectSkill)
        {
            for (var i = 0; i < equippedSkills.Length; i++)
            {
                if (equippedSkills[i] == -1)
                {
                    _equippedSkills[i].Lock();
                    continue;
                }

                if (equippedSkills[i] == 0)
                {
                    _equippedSkills[i].ShowEmpty(selectSkill);
                    continue;
                }

                _equippedSkills[i].ShowSkill(getSkill.Invoke(equippedSkills[i]), selectSkill);
            }
        }

        #endregion
    }
}