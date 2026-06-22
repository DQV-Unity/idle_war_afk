using System;
using _Scripts.Definition;
using _Scripts.Unit;
using UnityEngine;

namespace _Scripts.Board.Bullet
{
    public class PiercingBullet : Bullet
    {
        #region ----- Event -----

        public override event Action<AttackSnapshot, IUnit> onHit;

        #endregion
        #region ----- Public Functions -----
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IUnit target))
            {
                onHit?.Invoke(DataSnapshot, target);
            }
        }

        #endregion
   
    }
}