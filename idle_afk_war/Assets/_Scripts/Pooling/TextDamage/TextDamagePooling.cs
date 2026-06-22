using System.Collections.Generic;
using _Scripts.Definition;
using qtLib.Helper;
using UnityEngine;

namespace _Scripts.Pooling
{
    public class TextDamagePooling : qtSingleton<TextDamagePooling>
    {
        #region ----- Component Config ------

        [SerializeField]
        private TextDamageDatas _prefabs;
        private Dictionary<ETextDamageType, TextDamagePool> _textDamagePools = new Dictionary<ETextDamageType, TextDamagePool>();

        #endregion

        #region ----- Variable -----

        private TextDamagePool _curPool;

        #endregion
        
        #region ----- Public Function -----
        
        public TextDamage Get(ETextDamageType damageType)
        {
            if (!_textDamagePools.TryGetValue(damageType, out _curPool))
            {
                _curPool = new TextDamagePool( _prefabs[damageType]);
                _textDamagePools.Add(damageType, _curPool);
            }
            
            TextDamage textDamage = _curPool.Get();
            return textDamage;
        }

        public void Release(TextDamage textDamage)
        {
            _textDamagePools[textDamage.DamageType].Release(textDamage);
        }

        public void ReleaseAll()
        {
            
        }

        #endregion
    }
}