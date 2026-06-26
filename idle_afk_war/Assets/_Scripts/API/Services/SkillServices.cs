using System;
using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.API.Services
{
    public class SkillServices : APIService<SkillData>, IAPIService
    {
        protected override string DataPath => "Skill";

        public SkillCollection GetSkillCollection()
        {
            return _data.SkillCollection.Clone();
        }
        
        public int[] GetEquippedSkills()
        {
            return _data.EquippedSkills;
        }

        public Definition.Skill GetSkill(int skillID)
        {
            List<Definition.Skill> skills = GetSkillCollection().skills;
            for (var i = 0; i < skills.Count; i++)
            {
                if (skills[i].ID == skillID)
                {
                    return skills[i].Clone();            
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned skill {skillID}");
        }

        public bool EquipSkill(int slotPosition, int skillID)
        {
            List<Definition.Skill> skills = GetSkillCollection().skills;
            for (var i = 0; i < skills.Count; i++)
            {
                if (skills[i].ID == skillID)
                {
                    _data.EquippedSkills[slotPosition] = skillID;
                    SaveData();
                    return true;            
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned skill {skillID}");
        }

        public bool UnEquipSkill(int skillID)
        {
            for (var i = 0; i < _data.EquippedSkills.Length; i++)
            {
                if (_data.EquippedSkills[i] == skillID)
                {
                    _data.EquippedSkills[i] = -1;
                    return true;
                }
            }
            
            throw new KeyNotFoundException($"Not equip {skillID} yet");
        }
    }
}