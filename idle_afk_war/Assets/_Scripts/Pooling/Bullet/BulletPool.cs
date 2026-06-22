using _Scripts.Board.Bullet;
using qtLib.Game.Controller;
using UnityEngine;

namespace _Scripts.Pooling
{
    public class BulletPool : SystemPool<Bullet>
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

        public BulletPool(IBullet bullet) : base()
        {
            _prefab = bullet.GameObject;
        }

        #endregion
        
        protected override Bullet CreatePooledItem()
        {
            Bullet go = Object.Instantiate(_prefab).GetComponent<Bullet>();
            return go;
        }
    }
}