using System;
using System.Collections.Generic;
using _Scripts.Board.Bullet;
using qtLib.Helper;

namespace _Scripts.Pooling
{
    public class BulletPooling : qtSingleton<BulletPooling>
    {
        #region ----- Component Config ------

        private Dictionary<object, BulletPool> _bulletPools = new();

        #endregion
        
        #region ----- Public Function -----
        
        public IBullet Get(IBullet bullet)
        {
            if (_bulletPools.TryGetValue(bullet.ObjectPoolID, out BulletPool bulletPool))
            {
                return bulletPool.Get();
            }
            bulletPool = new BulletPool(bullet);
            _bulletPools.Add(bullet.ObjectPoolID, bulletPool);
            return bulletPool.Get();
        }

        public void Release(IBullet bullet)
        {
            if (_bulletPools.TryGetValue(bullet.ObjectPoolID, out BulletPool bulletPool))
            {
                bulletPool.Release(bullet as Bullet);
                return;
            }

            throw new Exception($"Pool {bullet.ObjectPoolID} not found");
        }

        public void ReleaseAll()
        {
            
        }

        #endregion
    }
}