using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class SkillData : DataModel
    {
        [SerializeField] private SkillCollection _skillCollection;
        [SerializeField] private int[] _equippedSkills;
        
        public SkillCollection SkillCollection => _skillCollection;
        public int[] EquippedSkills => _equippedSkills;
        
        public SkillCollection GetSkills()
        {
            return _skillCollection;
        }
        
        public int[] GetEquippedSkills()
        {
            return _equippedSkills;
        }

        public SkillData()
        {
            _skillCollection = new SkillCollection()
            {
                skills = new()
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
            _equippedSkills = new int[]
            {
                -1,
                -1,
                -1,
                -1,
                -1,
                -1
            };
        }
    }
}