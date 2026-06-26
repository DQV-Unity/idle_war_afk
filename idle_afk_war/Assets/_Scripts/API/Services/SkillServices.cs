using System;
using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API.Services
{
    public class SkillServices : APIService<SkillData>, IAPIService
    {
        protected override string DataPath => "Skill";

        public SkillCollection GetSkillCollection()
        {
            return _data.SkillCollection;
        }
        
        public SkillSlot[] GetSkillSlots()
        {
            return _data.SkillSlots;
        }

        public Definition.Skill GetSkill(int skillID)
        {
            List<Definition.Skill> skills = _data.SkillCollection.owned;
            for (var i = 0; i < skills.Count; i++)
            {
                if (skills[i].ID == skillID)
                {
                    return skills[i];            
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned skill {skillID}");
        }

        public bool EquipSkill(int slotPosition, int skillID)
        {
            List<Definition.Skill> skills = _data.SkillCollection.owned;
            SkillSlot[] skillSlots = _data.SkillSlots;
            if (!skillSlots[slotPosition].isUnlock)
            {
                return false;
            }
            for (var i = 0; i < skills.Count; i++)
            {
                if (skills[i].ID == skillID)
                {
                    _data.SkillSlots[slotPosition].equippedSkill = skillID;
                    SaveData();
                    return true;            
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned skill {skillID}");
        }

        public bool UnEquipSkill(int skillID)
        {
            SkillSlot[] skillSlots = _data.SkillSlots;
            for (var i = 0; i < skillSlots.Length; i++)
            {
                if (skillSlots[i].equippedSkill == skillID)
                {
                    skillSlots[i].equippedSkill = -1;
                    SaveData();
                    return true;
                }
            }
            
            throw new KeyNotFoundException($"Not equip {skillID} yet");
        }
    }
}