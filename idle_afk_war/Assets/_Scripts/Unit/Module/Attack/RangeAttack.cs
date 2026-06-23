using System;
using _Scripts.Board;
using _Scripts.Board.Bullet;
using _Scripts.Data.Asset;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Unit.Module.Attack
{
    public class RangeAttack : AttackModule, IAttack
    {
        #region ----- Variables -----

        protected IBullet _bulletPrefab;

        #endregion
        
        #region ----- Event -----

        public event Action<AttackSnapshot, IUnit> onAttack;

        #endregion
        
        #region ----- Public Functions -----

        public override void SetUp(IUnitStatProvider unitStatProvider,
            Func<Vector3, IUnit> getEnemy)
        {
            base.SetUp(unitStatProvider, getEnemy);
            _bulletPrefab = GameAsset.Instance.GetCharacterAsset(unitStatProvider.ID).Bullet;
        }
        
        #endregion

        #region ----- Private Functions -----

        protected override void OnTriggerAttack()
        {
            //todo: trigger ngay sau khi all enemy chết...
            if (_target == null)
            {
                return;
            }
            IBullet bullet = GameController.BulletFactory(_bulletPrefab);
            bullet.InitStat(new AttackSnapshot()
            {
                Damage = _unitStatProvider.Damage,
                CritRate =  _unitStatProvider.CritRate,
                CritDamage =  _unitStatProvider.CritDamage
            });
            bullet.Move(transform.position, _target.Transform.position);
        }

        #endregion
    }
}