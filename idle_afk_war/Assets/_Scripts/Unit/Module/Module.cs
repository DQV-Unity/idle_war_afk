using UnityEngine;

namespace _Scripts.Unit.Module
{
    public abstract class Module : MonoBehaviour
    {
        #region ----- Variables -----
        
        protected IUnitStatProvider _unitStatProvider;
        [SerializeField] protected EventModule _event;

        #endregion

        public virtual void SetUp(IUnitStatProvider unitStatProvider)
        {
            _unitStatProvider = unitStatProvider;
        }
    }
}