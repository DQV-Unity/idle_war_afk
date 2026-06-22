using System;
using _Scripts.Board;
using _Scripts.Board.Bullet;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Skill
{
    public class Skill_02_Tsunami : Skill, ISkill
    {
        [SerializeField] private TsunamiBulletConfig bulletConfig;
        
        public override bool Active()
        {
            base.Active();
            ChangeState(ESkillState.Playing);
            IBullet bullet = GameController.BulletFactory(bulletConfig.bulletPrefab.Value);
            bullet.onCompleteMove += OnBulletCompleteMove;
            bullet.InitStat(new AttackSnapshot()
            {
                Damage = _statProvider.Damage,
                CritRate = _statProvider.CritRate,
                CritDamage = _statProvider.CritDamage,
            });
            bullet.Move(bulletConfig.startPosition, bulletConfig.endPosition);
            return true;
        }

        private void OnBulletCompleteMove(IBullet bullet)
        {
            bullet.onCompleteMove -= OnBulletCompleteMove;
            ChangeState(ESkillState.Battling);
        }

        [Serializable]
        private class TsunamiBulletConfig : SkillBulletConfig
        {
        }
    }
}