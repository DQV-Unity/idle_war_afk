using System;
using _Scripts.Definition;
using _Scripts.Extension;
using UnityEngine;

namespace _Scripts.Unit.Module.Attack
{
    public interface IAttack: IUpdatableObject
    {
        public event Action<AttackSnapshot, IUnit> onAttack;
        public void SetUp(IUnitStatProvider unitStatProvider, Func<Vector3, IUnit> getEnemy);
        public void Attack(IUnit target);
    }
}