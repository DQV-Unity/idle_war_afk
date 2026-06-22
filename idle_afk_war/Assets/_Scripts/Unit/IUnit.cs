using System;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.Game.Object;
using UnityEngine;

namespace _Scripts.Unit
{
    public interface IUnit: IPoolingObject
    {
        public EUnitSide Side { get; }
        public bool IsAlive { get; }
        public GameObject GameObject { get; }
        public Transform Transform { get; }
        public EUnitState State { get; }
        public int ID { get; }

        public event Action<AttackSnapshot, IUnit> onAttack;
        public event Action<long> onDie;
        
        public void SetUp(Func<Vector3, IUnit> getEnemy);
        public void ChangeState(EUnitState newState);
        public UniTask Appear(Vector3 direction);
        public UniTask Move(Vector3 toPosition);
        public void Hit(int damage);
    }
}