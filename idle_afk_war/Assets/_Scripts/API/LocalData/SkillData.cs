using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class SkillData : DataModel
    {
        [SerializeField] private SkillCollection _skillCollection;
        [SerializeField] private SkillSlot[] _skillSlots;
        
        public SkillCollection SkillCollection => _skillCollection;
        public SkillSlot[] SkillSlots => _skillSlots;
        
        public SkillCollection GetSkills()
        {
            return _skillCollection;
        }
        
        public SkillSlot[] GetEquippedSkills()
        {
            return _skillSlots;
        }

        public SkillData()
        {
            _skillCollection = new SkillCollection()
            {
                owned = new()
                {
                    new Definition.Skill()
                    {
                        ID = 1,
                        level = 1,
                    },
                    new Definition.Skill()
                    {
                        ID = 2,
                        level = 1,
                    }
                }
            };
            _skillSlots = new SkillSlot[]
            {
                new SkillSlot()
                {
                    isUnlock = true,
                    equippedSkill = -1,
                },
                new SkillSlot()
                {
                    isUnlock = true,
                    equippedSkill = -1,
                },
                new SkillSlot()
                {
                    isUnlock = false,
                    equippedSkill = -1,
                },
                new SkillSlot()
                {
                    isUnlock = false,
                    equippedSkill = -1,
                },
                new SkillSlot()
                {
                    isUnlock = false,
                    equippedSkill = -1,
                },
                new SkillSlot()
                {
                    isUnlock = false,
                    equippedSkill = -1,
                }
            };
        }
    }
}