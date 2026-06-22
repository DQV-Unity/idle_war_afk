using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "EnemyConfigs", menuName = "Config/Enemy/EnemyConfigs")]
    public class EnemyConfigs : ScriptableObject
    {
        [SerializeField] private List<EnemyConfig> _enemyConfigs;
        
        public EnemyConfig GetEnemyConfig(int enemyID)
        {
            for (var i = 0; i < _enemyConfigs.Count; i++)
            {
                if (_enemyConfigs[i].ID == enemyID)
                {
                    return _enemyConfigs[i];
                }
            }
            
            throw new KeyNotFoundException($"Enemy ID {enemyID} not found");
        }
    }
}