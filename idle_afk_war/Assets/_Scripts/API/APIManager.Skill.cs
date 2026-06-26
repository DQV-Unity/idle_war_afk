using System;
using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public SkillCollection GetSkillCollection()
        {
            return _skillServices.GetSkillCollection().Clone();
        }
        
        public SkillSlot[] GetSkillSlots()
        {
            return qtGameExtension.Clone(_skillServices.GetSkillSlots());
        }

        public Definition.Skill GetSkill(int skillID)
        {
            return _skillServices.GetSkill(skillID).Clone();
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