using System;
using System.Threading.Tasks;
using _Scripts.Board;
using _Scripts.Board.Bullet;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Unit.Module.Attack
{
    public class BurstAttack : RangeAttack
    {
        [SerializeField] private BurstAttackConfig _bulletConfig;

        protected override async void OnTriggerAttack()
        {
            if (_target == null)
            {
                return;
            }

            Vector3 position = _target.Transform.position;

            try
            {
                for (int i = 0; i < _bulletConfig.bulletAmount; i++)
                {
                    IBullet bullet = GameController.BulletFactory(_bulletPrefab);
                    bullet.InitStat(new AttackSnapshot()
                    {
                        Damage = _unitStatProvider.Damage,
                        CritRate = _unitStatProvider.CritRate,
                        CritDamage = _unitStatProvider.CritDamage
                    });
                    bullet.Move(transform.position, position);

                    await UniTask.Delay(_bulletConfig.spaceBetweenBullets, cancellationToken: _destroyToken.Token);
                }
            }
            catch (TaskCanceledException _)
            {
            }
        }

        [Serializable]
        private class BurstAttackConfig
        {
            public int bulletAmount;
            public int spaceBetweenBullets;
        }
    }
}