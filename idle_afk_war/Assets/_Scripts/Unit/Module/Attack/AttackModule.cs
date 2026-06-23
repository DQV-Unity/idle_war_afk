using System;
using System.Threading;
using _Scripts.Definition;
using _Scripts.Extension;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Unit.Module.Attack
{
    public abstract class AttackModule : Module, IModule, IUpdatableObject
    {
        #region ----- Variables -----

        protected Func<Vector3, IUnit> _getEnemy;
        protected IUnit _target;
        
        private float _attackInterval;
        private float _attackTimer;
        
        protected CancellationTokenSource _destroyToken;

        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _event.onTriggerAttack += OnTriggerAttack;
        }

        #endregion
        
        #region ----- Public Functions -----

        public virtual void SetUp(IUnitStatProvider unitStatProvider,
            Func<Vector3, IUnit> getEnemy)
        {
            base.SetUp(unitStatProvider);
            _getEnemy = getEnemy;
            
            _attackInterval = 1 / unitStatProvider.AttackSpeed;
            _event.onDie += OnDie;
            _destroyToken = new CancellationTokenSource();
        }

        public void Attack(IUnit target)
        {
            _target = target;
            _target.onDie += OnTargetDie;
        }
        
        public virtual void OnUpdate()
        {
            if (_attackTimer > 0)
            {
                _attackTimer -= Time.deltaTime;
                return;
            }

            if (_target == null)
            {
                _target = _getEnemy.Invoke(transform.position);
                if (_target == null)
                {
                    return;
                }
                else
                {
                    _target.onDie += OnTargetDie;
                }
            }
            
            if (_unitStatProvider.State is EUnitState.Moving)
            {
                if (Vector3.Distance(transform.position, _target.Transform.position) < _unitStatProvider.AttackRange)
                {
                    transform.DOKill();
                }
                return;
            }
            
            if (_unitStatProvider.State is not EUnitState.Battling)
            {
                return;
            }

            StartAttack();
            _attackTimer = _attackInterval;
        }
        
        public void StartAttack()
        {
            _event.StartAttack();
        }

        #endregion

        #region ----- Private Functions -----

        protected abstract void OnTriggerAttack();

        private void OnTargetDie(long uniqueID)
        {
            if (_target == null)
            {
                return;
            }
            _target.onDie -= OnTargetDie;
            _target = null;
        }

        private void OnDie()
        {
            _event.onDie -= OnDie;
            if (_target != null)
            {
                _target.onDie -= OnTargetDie;
                _target = null;
            }
        }

        private void OnDestroy()
        {
            _destroyToken?.Dispose();
        }

        #endregion
    }
}