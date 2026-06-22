using System;
using UnityEngine;

namespace _Scripts.Unit.Module
{
    public class EventModule : MonoBehaviour
    {
        public event Action onStartMove;
        public event Action onStopMove;

        public event Action onStartAttack;
        public event Action onTriggerAttack;

        public event Action onDie;

        public void StartAttack()
        {
            onStartAttack?.Invoke();
        }

        public void TriggerAttack()
        {
            onTriggerAttack?.Invoke();
        }

        public void StartMove()
        {
            onStartMove?.Invoke();
        }

        public void StopMove()
        {
            onStopMove?.Invoke();
        }

        public void Die()
        {
            onDie?.Invoke();
        }
    }
}
