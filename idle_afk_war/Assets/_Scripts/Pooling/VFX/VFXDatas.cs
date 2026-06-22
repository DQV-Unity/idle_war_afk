using System;
using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Pooling
{
    [CreateAssetMenu(fileName = "VFXData", menuName = "Pooling/VFXData")]
    public class VFXDatas : ScriptableObject
    {
        [SerializeField] private List<VFXData> _data = new();
        public VFX this[EVfxType vfxType]
        {
            get
            {
                for (var i = 0; i < _data.Count; i++)
                {
                    if (_data[i].VFXType == vfxType)
                    {
                        return _data[i].prefab;
                    }
                }
                
                throw new KeyNotFoundException(vfxType.ToString());
            }
        }

        [Serializable]
        private class VFXData
        {
            [SerializeField] private EVfxType _vfxType;
            [SerializeField] private VFX _prefab;
            
            public EVfxType VFXType => _vfxType;
            public VFX prefab => _prefab;
        }
    }
}