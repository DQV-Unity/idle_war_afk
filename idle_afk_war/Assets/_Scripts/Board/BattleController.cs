using System;
using _Scripts.Definition;
using _Scripts.Enemy;
using _Scripts.Extension;
using _Scripts.Pooling;
using _Scripts.Unit;
using _Scripts.Unit.Character;
using UnityEngine;

namespace _Scripts.Board
{
    public class BattleController : MonoBehaviour
    {
        #region ----- Variables  -----

        private IEnemyProvider _enemyProvider;

        #endregion
        
        #region ----- Public Functions -----

        public void SetUp(IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
        }

        public void HitCalculate(AttackSnapshot dataSnapShot, IUnit target)
        {
            switch (target.Side)
            {
                case EUnitSide.Alliance:
                {
                    HitCharacter(dataSnapShot, target as ICharacter);
                    break;
                }
                case EUnitSide.Opponent:
                {
                    HitEnemy(dataSnapShot, target as IEnemy);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(target.Side), target.Side, null);
                }
            }
        }

        #endregion

        #region ----- Private Functions -----

        private void HitEnemy(AttackSnapshot dataSnapShot, IEnemy target)
        {
            TextDamage textDamage = null;
            if (dataSnapShot.DamageCalculate(out int damage))
            {
                textDamage = TextDamagePooling.Instance.Get(ETextDamageType.Critical);
            }
            else
            {
                textDamage = TextDamagePooling.Instance.Get(ETextDamageType.Normal);
            }

            target.Hit(damage);
            textDamage.ShowDamage(damage);
            textDamage.transform.position = target.Transform.position;
        }


        private void HitCharacter(AttackSnapshot dataSnapShot, ICharacter target)
        {
            TextDamage textDamage = null;
            if (dataSnapShot.DamageCalculate(out int damage))
            {
                textDamage = TextDamagePooling.Instance.Get(ETextDamageType.Critical);
            }
            else
            {
                textDamage = TextDamagePooling.Instance.Get(ETextDamageType.Normal);
            }
            target.Hit(damage);
            textDamage.ShowDamage(damage);
            textDamage.transform.position = target.Transform.position;
        }
        
        #endregion
    }
}