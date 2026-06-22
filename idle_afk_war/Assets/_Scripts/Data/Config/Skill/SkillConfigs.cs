using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "SkillConfigs", menuName = "Config/Skill/Skill Configs")]
    public class SkillConfigs : ScriptableObject
    {
        [SerializeField] private List<SkillConfig> _skillConfigs;
        
        public SkillConfig GetSkillConfig(int skillID)
        {
            for (var i = 0; i < _skillConfigs.Count; i++)
            {
                if (_skillConfigs[i].ID == skillID)
                {
                    return _skillConfigs[i];
                }
            }
            
            throw new KeyNotFoundException($"Skill ID {skillID} not found");
        }
    }
}