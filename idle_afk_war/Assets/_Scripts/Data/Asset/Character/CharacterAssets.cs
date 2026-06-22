using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "CharacterAssets", menuName = "Asset/Character/Character Assets")]
    public class CharacterAssets : ScriptableObject
    {
        [SerializeField] private List<CharacterAsset> _characterAssets;

        public CharacterAsset GetCharacterAsset(int characterID)
        {
            for (var i = 0; i < _characterAssets.Count; i++)
            {
                if (_characterAssets[i].ID == characterID)
                {
                    return _characterAssets[i];
                }
            }
            
            throw new KeyNotFoundException($"Character ID {characterID} not found");
        }
    }
}