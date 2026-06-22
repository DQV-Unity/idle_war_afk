using System;
using System.Collections.Generic;
using _Scripts.Enemy;
using qtLib.Helper;

namespace _Scripts.Pooling
{
    public class EnemyPooling : qtSingleton<EnemyPooling>
    {
        #region ----- Component Config ------

        private Dictionary<object, EnemyPool> _enemyPools = new();

        #endregion
        
        #region ----- Public Function -----
        
        public IEnemy Get(int enemyID)
        {
            if (_enemyPools.TryGetValue(enemyID, out EnemyPool enemyPool))
            {
                return enemyPool.Get();
            }
            enemyPool = new EnemyPool(enemyID);
            _enemyPools.Add(enemyID, enemyPool);
            return enemyPool.Get();
        }

        public void Release(IEnemy enemy)
        {
            if (_enemyPools.TryGetValue(enemy.ObjectPoolID, out EnemyPool enemyPool))
            {
                enemyPool.Release(enemy as Unit.Enemy.Enemy);
                return;
            }

            throw new Exception($"Pool {enemy.ObjectPoolID} not found");
        }

        public void ReleaseAll()
        {
            
        }
        
        #endregion
    }
}