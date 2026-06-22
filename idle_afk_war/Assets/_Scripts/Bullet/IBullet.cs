using System;
using _Scripts.Definition;
using _Scripts.Unit;
using qtLib.Game.Object;
using UnityEngine;

namespace _Scripts.Board.Bullet
{
    public interface IBullet : IPoolingObject
    {
        public GameObject GameObject { get; }
        public Transform Transform { get; }

        public event Action<AttackSnapshot, IUnit> onHit; 
        public event Action<IBullet> onCompleteMove; 

        public void InitStat(AttackSnapshot dataSnapshot);
        public void Move(Vector2 from, Vector2 to);
    }
}