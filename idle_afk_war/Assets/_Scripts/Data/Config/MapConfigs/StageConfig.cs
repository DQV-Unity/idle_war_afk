using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "StageConfig", menuName = "Config/Map/Stage/StageConfig")]
    public class StageConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private List<SubStageConfig> _subStageConfigs;
        
        public int ID => _id;
        public List<SubStageConfig> SubStageConfigs => _subStageConfigs;
                
        public SubStageConfig GetSubStageConfig(int subStageID)
        {
            for (var i = 0; i < _subStageConfigs.Count; i++)
            {
                if (_subStageConfigs[i].ID == subStageID)
                {
                    return _subStageConfigs[i];
                }
            }
            
            throw new KeyNotFoundException($"Sub stage ID {subStageID} not found");
        }
    }
}