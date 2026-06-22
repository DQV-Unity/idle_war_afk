using _Scripts.Data.Asset;
using qtLib.Game.Controller;
using UnityEngine;

namespace _Scripts.Pooling
{
    public class EnemyPool : SystemPool<Unit.Enemy.Enemy>
    {
        #region ----- Component Config -----

        private GameObject _prefab;
        protected override int DefaultPoolSize()
        {
            return 100;
        }

        protected override int MaxPoolSize()
        {
            return 200;
        }

        #endregion
        
        #region ----- Constructor -----

        public EnemyPool(int enemyID) : base()
        {
            _prefab = GameAsset.Instance.GetEnemyAsset(enemyID).Prefab;
        }

        #endregion
        
        protected override Unit.Enemy.Enemy CreatePooledItem()
        {
            Unit.Enemy.Enemy go = Object.Instantiate(_prefab).GetComponent<Unit.Enemy.Enemy>();
            return go;
        }

    }
}