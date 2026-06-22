using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "RarityAssets", menuName = "Asset/Other/Rarity Assets")]
    public class RarityAssets : ScriptableObject
    {
        [SerializeField] private List<RarityAsset> _rarityAssets;

        public RarityAsset GetRarityAsset(ERarity rarity)
        {
            for (var i = 0; i < _rarityAssets.Count; i++)
            {
                if (_rarityAssets[i].Rarity == rarity)
                {
                    return _rarityAssets[i];
                }
            }
            
            throw new KeyNotFoundException($"Rarity {rarity} not found");
        }
    }
}