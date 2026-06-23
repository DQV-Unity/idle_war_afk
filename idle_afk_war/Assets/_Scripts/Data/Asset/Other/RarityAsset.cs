using _Scripts.Definition;
using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "RarityAsset", menuName = "Asset/Other/Rarity Asset")]
    public class RarityAsset : ScriptableObject
    {
        [SerializeField] private ERarity _rarity;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprIcon;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprBackground;
        
        public ERarity Rarity => _rarity;
        public Sprite SprIcon => _sprIcon;
        public Sprite SprBackground => _sprBackground;
    }
}