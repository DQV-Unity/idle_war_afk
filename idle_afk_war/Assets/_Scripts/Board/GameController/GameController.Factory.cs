using _Scripts.Board.Bullet;
using _Scripts.Enemy;
using _Scripts.Pooling;
using UnityEngine;

namespace _Scripts.Board
{
    public partial class GameController
    {
        private static GameController _instance;
        
        [Space] 
        private Transform _bulletParent;

        private void Awake()
        {
            _instance = this;
        }

        public static IBullet BulletFactory(IBullet bullet)
        {
            IBullet newBullet = BulletPooling.Instance.Get(bullet);
            newBullet.onHit -= _instance._battleController.HitCalculate;
            newBullet.onHit += _instance._battleController.HitCalculate;
            newBullet.Transform.SetParent(_instance._bulletParent);
            return newBullet;
        }

        public static IEnemy EnemyFactory(int enemyID)
        {
            IEnemy newEnemy = EnemyPooling.Instance.Get(enemyID);
            return newEnemy;
        }
    }
}