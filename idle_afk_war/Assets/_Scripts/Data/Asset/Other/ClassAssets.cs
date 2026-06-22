using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "ClassAssets", menuName = "Asset/Other/ClassAssets")]
    public class ClassAssets : ScriptableObject
    {
        [SerializeField] private List<ClassAsset>  _classAssets;
        
        public ClassAsset GetClassAsset(EClass @class)
        {
            for (var i = 0; i < _classAssets.Count; i++)
            {
                if (_classAssets[i].Class == @class)
                {
                    return _classAssets[i];
                }
            }
            
            throw new KeyNotFoundException($"Class {@class} not found");
        }
    }
}