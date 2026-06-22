using System.Collections.Generic;
using _Scripts.Extension;
using UnityEngine;

namespace _Scripts.GameSystem
{
    public class TimeController : MonoBehaviour
    {
        #region ----- Variables -----

        private static List<IUpdatableObject> _updatableObjects = new();
        
        #endregion
        
        #region ----- Unity Event -----

        private void Update()
        {
            for (var i = 0; i < _updatableObjects.Count; i++)
            {
                _updatableObjects[i].OnUpdate();
            }
        }

        #endregion

        #region ----- Static Function -----

        public static void RegisterUpdatable(IUpdatableObject updatableObject)
        {
            if (_updatableObjects.Contains(updatableObject))
            {
                return;
            }
            
            _updatableObjects.Add(updatableObject);
        }

        public static void UnregisterUpdatable(IUpdatableObject updatableObject)
        {
            _updatableObjects.Remove(updatableObject);
        }

        #endregion
        
    }
}