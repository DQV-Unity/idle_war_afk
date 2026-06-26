using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "xx_LevelConfig", menuName = "Config/Level/LevelConfigs")]
    public class LevelConfigs : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levelConfigs;

        public LevelConfig GetLevelConfig(int level)
        {
            for (var i = 0; i < _levelConfigs.Count; i++)
            {
                if (_levelConfigs[i].Level == level)
                {
                    return _levelConfigs[i];
                }
            }

            return _levelConfigs[^1];
        }
    }
}