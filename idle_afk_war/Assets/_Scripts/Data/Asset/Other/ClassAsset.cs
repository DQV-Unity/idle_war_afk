using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "ClassAsset", menuName = "Asset/Other/ClassAsset")]
    public class ClassAsset : ScriptableObject
    {
        [SerializeField] private EClass _class;
        [SerializeField] private Sprite _sprIcon;
        
        public EClass Class => _class;
        public Sprite SprIcon => _sprIcon;
    }
}