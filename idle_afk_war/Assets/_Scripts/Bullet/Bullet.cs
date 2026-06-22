using System;
using _Scripts.Definition;
using _Scripts.Pooling;
using _Scripts.Unit;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using qtLib.Game.Object;
using UnityEngine;

namespace _Scripts.Board.Bullet
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : PoolingObject, IBullet
    {
        #region ----- Component Config -----

        [SerializeField] private string _bulletID; 

        #endregion
        
        #region ----- Variables -----

        private AttackSnapshot _dataSnapshot;

        #endregion
        
        #region ----- Properties -----

        public GameObject GameObject => gameObject;
        public Transform Transform => transform;
        public AttackSnapshot DataSnapshot => _dataSnapshot;

        public override object ObjectPoolID => _bulletID;
        
        #endregion

        #region ----- Event -----

        public abstract event Action<AttackSnapshot, IUnit> onHit;
        public event Action<IBullet> onCompleteMove; 

        #endregion

        public virtual void InitStat(AttackSnapshot dataSnapshot)
        {
            _dataSnapshot = dataSnapshot;
        }

        public async void Move(Vector2 from, Vector2 to)
        {
            transform.position = from;
            await transform.DOMove(to, 1).SetEase(Ease.Linear).ToUniTask();
            onCompleteMove?.Invoke(this);
            SelfRelease();
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);

        private void SelfRelease()
        {
            BulletPooling.Instance.Release(this);
        }

        public override void OnRelease()
        {
            base.OnRelease();
            gameObject.SetActive(false);
        }
        
        public override void OnGet()
        {
            base.OnGet();
            gameObject.SetActive(true);
        }
    }
}