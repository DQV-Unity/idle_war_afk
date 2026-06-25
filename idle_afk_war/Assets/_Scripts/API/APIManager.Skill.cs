using System;
using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public SkillCollection GetSkillCollection()
        {
            return _skillServices.GetSkillCollection();
        }
        
        public int[] GetEquippedSkills()
        {
            return _skillServices.GetEquippedSkills();
        }

        public Definition.Skill GetSkill(int skillID)
        {
            return _skillServices.GetSkill(skillID);
        }

        public bool EquipSkill(int slotPosition, int skillID)
        {
            return _skillServices.EquipSkill(slotPosition, skillID);
        }

        public bool UnEquipSkill(int skillID)
        {
            return _skillServices.UnEquipSkill(skillID);
        }
    }
}