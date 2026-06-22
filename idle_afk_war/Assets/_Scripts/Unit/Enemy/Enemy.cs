using System;
using _Scripts.Definition;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Unit.Enemy
{
    public class Enemy : Unit, IEnemy, IEnemyStatProvider
    {
        private long _uniqueID;

        public override EUnitSide Side => EUnitSide.Opponent;
        public long UniqueID => _uniqueID;

        public override void SetUp(Func<Vector3, IUnit> getEnemy)
        {
            base.SetUp(getEnemy);
            _event.onStopMove += OnStopMove;
        }

        public void InitStat(UnitStat stat)
        {
            _uniqueID = DateTime.Now.Ticks;
            base.InitStat(stat, UniqueID);
        }

        public void Attack(IUnit target)
        {
            ChangeState(EUnitState.Moving);
            _attack.Value.Attack(target);
            Move(target.Transform.position);
        }

        private void OnStopMove()
        {
            ChangeState(EUnitState.Battling);
        }
    }
}