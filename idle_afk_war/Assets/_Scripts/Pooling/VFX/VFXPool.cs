using qtLib.Game.Controller;
using Object = UnityEngine.Object;

namespace _Scripts.Pooling
{
    public class VFXPool : SystemPool<VFX>
    {
        #region ----- Component Config -----

        private VFX _prefab;
        protected override int DefaultPoolSize()
        {
            return 100;
        }

        protected override int MaxPoolSize()
        {
            return 200;
        }

        #endregion
        
        #region ----- Constructor -----

        public VFXPool(VFX prefab) : base()
        {
            _prefab = prefab;
        }

        #endregion
        
        protected override VFX CreatePooledItem()
        {
            VFX go = Object.Instantiate(_prefab);
            return go;
        }
    }
}