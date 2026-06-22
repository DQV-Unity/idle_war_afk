using System;
using _Scripts.Board;
using _Scripts.Board.Bullet;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.Extension;
using UnityEngine;

namespace _Scripts.Skill
{
    public class Skill_01_MakeItRain : ChargingSkill, IChargingSkill
    {
        [SerializeField] private MakeItRainBulletConfig bulletConfig;
       
        
        protected override void InternalOnCompleteStartPhase()
        {
            
        }

        protected override void InternalDoSkill()
        {
            //create bullet
            //fall
            Vector3 direction = bulletConfig.endPosition - bulletConfig.startPosition;
            AttackSnapshot data = new AttackSnapshot()
            {
                Damage = _statProvider.Damage,
                CritRate = _statProvider.CritRate,
                CritDamage = _statProvider.CritDamage,
            };
            
            for (int i = 0; i < bulletConfig.amount; i++)
            {
                IBullet bullet = GameController.BulletFactory(bulletConfig.bulletPrefab.Value);
                bullet.InitStat(data);
                bullet.GameObject.SetActive(false);
                MoveBullet(bullet, bulletConfig.startPosition, direction);
            }
            
            ChangeState(ESkillState.Battling);
        }

        private async void MoveBullet(IBullet bullet, Vector3 from, Vector3 direction)
        {
            bullet.Transform.position = from;
            await UniTask.Delay(UnityEngine.Random.Range(100, 200));
            Vector3 fromPosition = qtGameExtension.RandomPointInCircleXY(bulletConfig.startPosition, 1);
            bullet.Move(fromPosition, fromPosition + direction);
            bullet.GameObject.SetActive(true);
        }
        
        [Serializable]
        private class MakeItRainBulletConfig : SkillBulletConfig
        {
            public int amount;
        }
    }
}