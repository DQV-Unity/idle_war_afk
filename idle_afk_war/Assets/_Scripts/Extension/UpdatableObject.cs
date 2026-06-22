using _Scripts.GameSystem;
using UnityEngine;

namespace _Scripts.Extension
{
    public abstract class UpdatableObject : MonoBehaviour, IUpdatableObject
    {
        protected virtual void OnEnable()
        {
            TimeController.RegisterUpdatable(this);
        }

        public abstract void OnUpdate();

        protected virtual void OnDisable()
        {
            TimeController.UnregisterUpdatable(this);
        }
    }
}