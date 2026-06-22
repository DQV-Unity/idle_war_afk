using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "EnemyAsset", menuName = "Asset/Enemy/Enemy Assets")]
    public class EnemyAssets : ScriptableObject
    {
        [SerializeField] private List<EnemyAsset> _enemyAssets;
        
        public EnemyAsset GetEnemyAsset(int enemyID)
        {
            for (var i = 0; i < _enemyAssets.Count; i++)
            {
                if (_enemyAssets[i].ID == enemyID)
                {
                    return _enemyAssets[i];
                }
            }
            
            throw new KeyNotFoundException($"Enemy ID {enemyID} not found");
        }
    }
}