using System;
using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Pooling
{
    [CreateAssetMenu(fileName = "TextDamageData", menuName = "Pooling/TextDamageData")]
    public class TextDamageDatas : ScriptableObject
    {
        [SerializeField] private List<TextDamageData> _data = new();
        public TextDamage this[ETextDamageType damageType]
        {
            get
            {
                for (var i = 0; i < _data.Count; i++)
                {
                    if (_data[i].damageType == damageType)
                    {
                        return _data[i].prefab;
                    }
                }
                
                throw new KeyNotFoundException(damageType.ToString());
            }
        }

        [Serializable]
        private class TextDamageData
        {
            [SerializeField] private ETextDamageType _damageType;
            [SerializeField] private TextDamage _prefab;
            
            public ETextDamageType damageType => _damageType;
            public TextDamage prefab => _prefab;
        }
    }
}