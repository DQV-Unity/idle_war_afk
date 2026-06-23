using System;
using _Scripts.Definition;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Unit.Enemy
{
    public class Enemy : Unit, IEnemy, IEnemyStatProvider
    {
        public override EUnitSide Side => EUnitSide.Opponent;

        public override void SetUp(Func<Vector3, IUnit> getEnemy)
        {
            base.SetUp(getEnemy);
            _event.onStopMove += OnStopMove;
        }
        
        public void Attack(IUnit target)
        {
            ChangeState(EUnitState.Moving);
            _attack.Value.Attack(target);
            _ = Move(target.Transform.position);
        }

        private void OnStopMove()
        {
            ChangeState(EUnitState.Battling);
        }
    }
}