using System;
using _Scripts.GameSystem;
using AYellowpaper;
using UnityEngine;

namespace _Scripts.Extension
{
    public class UpdatableRegister : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private InterfaceReference<IUpdatableObject> _updatableObject;

        #endregion

        private void OnEnable()
        {
            TimeController.RegisterUpdatable(_updatableObject.Value);
        }

        private void OnDisable()
        {
            TimeController.UnregisterUpdatable(_updatableObject.Value);
        }

        private void OnDestroy()
        {
            TimeController.UnregisterUpdatable(_updatableObject.Value);
        }
    }
}