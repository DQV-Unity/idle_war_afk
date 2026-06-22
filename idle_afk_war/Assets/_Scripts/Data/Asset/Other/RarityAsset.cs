using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "RarityAsset", menuName = "Asset/Other/Rarity Asset")]
    public class RarityAsset : ScriptableObject
    {
        [SerializeField] private ERarity _rarity;
        [SerializeField] private Sprite _sprIcon;
        
        public ERarity Rarity => _rarity;
        public Sprite SprIcon => _sprIcon;
    }
}