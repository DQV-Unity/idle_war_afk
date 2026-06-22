using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class SkillData : DataModel
    {
        [SerializeField] private SkillCollection _skillCollection;
        [SerializeField] private Definition.Skill[] _equippedSkills;
        
        public SkillCollection GetSkills()
        {
            return _skillCollection;
        }
        
        public Definition.Skill[] GetEquippedSkills()
        {
            return _equippedSkills;
        }
    }
}