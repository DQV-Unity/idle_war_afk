using System;
using _Scripts.Definition;
using _Scripts.Extension;
using _Scripts.Pooling;
using UnityEngine;

namespace _Scripts.Unit.Module
{
    public class AnimationModule : Module, IModule
    {
        private static readonly int Key_Appear = Animator.StringToHash("Appear");
        private static readonly int Key_Attack = Animator.StringToHash("Attack");
        private static readonly int Key_Move = Animator.StringToHash("Move");
        private static readonly int Key_Die = Animator.StringToHash("Die");
        private static readonly int Key_Hit = Animator.StringToHash("Hit");
        private static readonly int Key_Idle = Animator.StringToHash("Idle");

        #region ----- Componenet Config -----

        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationEventCatcher _eventCatcher;

        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _eventCatcher.onTriggerAttack += OnTriggerAttack;
           
            _event.onStartMove += OnStartMove;
            _event.onStopMove += OnStopMove;

            _event.onStartAttack += OnStartAttack;

            _event.onDie += OnDie;
        }

        #endregion
        
        #region ----- Public Functions -----

        public void OnAppear()
        {
            _animator.SetTrigger(Key_Appear);
        }
        
        public void Hit()
        {
            _animator.SetTrigger(Key_Hit);
        }
        
        #endregion
        
        #region -----  Private Functions -----

        private void OnStartMove()
        {
            _animator.SetTrigger(Key_Move);
        }
        
        private void OnStopMove()
        {
            _animator.SetTrigger(Key_Idle);
        }
        
        private void OnStartAttack()
        {
            _animator.SetTrigger(Key_Attack);
        }

        private void OnTriggerAttack()
        {
            _event.TriggerAttack();
        }

        private void OnDie()
        {
            VFX vfx = VFXPooling.Instance.Get(EVfxType.EnemyDeath);
            vfx.transform.position = transform.position;
            _animator.SetTrigger(Key_Die);
        }

        #endregion
    }
}