using _Scripts.Definition;
using qtLib.Game.Object;
using UnityEngine;

namespace _Scripts.Pooling
{
    public class VFX : PoolingObject
    {
        #region ----- Component Config -----

        [SerializeField] private EVfxType _vfxType;
        [SerializeField] private ParticleSystem _fx;
        
        #endregion

        #region ----- Properties -----

        public override object ObjectPoolID => (int)_vfxType;
        public EVfxType VFXType => _vfxType;

        #endregion

        #region ----- Public Funtions ------
        
        public override void OnGet()
        {
            base.OnGet();
            gameObject.SetActive(true);
        }

        public override void OnRelease()
        {
        }

        #endregion

        #region ----- Private Funtions ------

        private void OnEnable()
        {
            _fx.Play();
        }

        private void OnDisable()
        {
            VFXPooling.Instance.Release(this);
        }

        #endregion
    }
}