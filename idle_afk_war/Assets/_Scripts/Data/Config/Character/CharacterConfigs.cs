using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "CharacterConfigs", menuName = "Config/Character/CharacterConfigs")]
    public class CharacterConfigs : ScriptableObject
    {
        [SerializeField] private List<CharacterConfig> _characterConfigs;
        
        public CharacterConfig GetCharacterConfig(int characterID)
        {
            for (var i = 0; i < _characterConfigs.Count; i++)
            {
                if (_characterConfigs[i].ID == characterID)
                {
                    return _characterConfigs[i];
                }
            }
            
            throw new KeyNotFoundException($"Character ID {characterID} not found");
        }
    }
}