using System;
using _Scripts.Definition;
using _Scripts.Unit;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Board.Bullet
{
    public class OneTimeBullet : Bullet, IBullet
    {
        #region ----- Event -----

        public override event Action<AttackSnapshot, IUnit> onHit;

        #endregion

        #region ----- Variables -----

        private bool _isExploded;
        
        #endregion

        #region ----- Public Functions -----

        public override void InitStat(AttackSnapshot dataSnapshot)
        {
            base.InitStat(dataSnapshot);
            _isExploded = false;
        }
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (_isExploded)
            {
                return;
            }
            transform.DOKill();
            if (other.TryGetComponent(out IUnit target))
            {
                _isExploded = true;
                onHit?.Invoke(DataSnapshot, target);
            }
        }

        #endregion
    }
}