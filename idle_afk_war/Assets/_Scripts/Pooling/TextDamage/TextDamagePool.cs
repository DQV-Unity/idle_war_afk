using qtLib.Game.Controller;
using Object = UnityEngine.Object;

namespace _Scripts.Pooling
{
    public class TextDamagePool : SystemPool<TextDamage>
    {
        #region ----- Component Config -----

        private TextDamage _prefab;
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

        public TextDamagePool(TextDamage prefab) : base()
        {
            _prefab = prefab;
        }

        #endregion
        
        protected override TextDamage CreatePooledItem()
        {
            TextDamage go = Object.Instantiate(_prefab);
            return go;
        }
    }
}