using _Scripts.Definition;
using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "ClassAsset", menuName = "Asset/Other/ClassAsset")]
    public class ClassAsset : ScriptableObject
    {
        [SerializeField] private EClass _class;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprIcon;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprBackground;
        
        public EClass Class => _class;
        public Sprite SprIcon => _sprIcon;
        public Sprite SprBackground => _sprBackground;
    }
}