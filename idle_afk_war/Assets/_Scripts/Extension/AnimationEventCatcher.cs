using System;
using UnityEngine;

namespace _Scripts.Extension
{
    public class AnimationEventCatcher : MonoBehaviour
    {
        #region ----- Event -----

        public event Action onTriggerAttack; 

        #endregion
        
        public void OnTriggerAttack()
        {
            onTriggerAttack?.Invoke();
        }
    }
}