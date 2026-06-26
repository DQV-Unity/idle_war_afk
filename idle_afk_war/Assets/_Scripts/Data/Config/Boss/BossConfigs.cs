using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "BossConfigs", menuName = "Config/Config/BossConfigs")]
    public class BossConfigs : ScriptableObject
    {
        [SerializeField] private List<BossConfig> _bossConfigs;

        public BossConfig GetBossConfig(int bossID)
        {
            for (var i = 0; i < _bossConfigs.Count; i++)
            {
                if (_bossConfigs[i].ID == bossID)
                {
                    return _bossConfigs[i];
                }
            }
            
            throw new KeyNotFoundException($"Boss ID {bossID} not found");
        }
    }
}