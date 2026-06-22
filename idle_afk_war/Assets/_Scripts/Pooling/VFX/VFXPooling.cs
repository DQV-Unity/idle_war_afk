using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.Helper;
using UnityEngine;

namespace _Scripts.Pooling
{
    public class VFXPooling : qtSingleton<VFXPooling>
    {
        #region ----- Component Config ------

        [SerializeField] private VFXDatas _prefabs;
        private Dictionary<EVfxType, VFXPool> _vfxPools = new ();

        #endregion

        #region ----- Variable -----

        private VFXPool _curPool;

        #endregion
        
        #region ----- Public Function -----
        
        public VFX Get(EVfxType vfxTyp)
        {
            if (!_vfxPools.TryGetValue(vfxTyp, out _curPool))
            {
                _curPool = new VFXPool( _prefabs[vfxTyp]);
                _vfxPools.Add(vfxTyp, _curPool);
            }
            
            VFX vfx = _curPool.Get();
            return vfx;
        }

        public void Release(VFX vfx)
        {
            _vfxPools[vfx.VFXType].Release(vfx);
        }

        public void ReleaseAll()
        {
            
        }

        #endregion
    }
}