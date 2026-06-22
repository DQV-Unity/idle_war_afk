using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "SkillAssets", menuName = "Asset/Skill/Skill Assets")]
    public class SkillAssets : ScriptableObject
    {
        [SerializeField] private List<SkillAsset> _skillAssets;
        
        public SkillAsset GetSkillAsset(int skillID)
        {
            for (var i = 0; i < _skillAssets.Count; i++)
            {
                if (_skillAssets[i].ID == skillID)
                {
                    return _skillAssets[i];
                }
            }
            
            throw new KeyNotFoundException($"Skill ID {skillID} not found");
        }
    }
}