using System;
using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class CharacterData : DataModel
    {
        [SerializeField] private StatLevel _statLevel;
        [SerializeField] private CharacterCollection _characterCollection;
        [SerializeField] private Character _equippedCharacter;
        

        public CharacterData()
        {
            _statLevel = new StatLevel
            {
                damageLevel = 1,
                maxHitPointsLevel = 1,
                attackSpeedLevel = 1,
                critRateLevel = 1,
                critDamageLevel = 1
            };

            _characterCollection = new CharacterCollection()
            {
                characters = new List<Character>()
                {
                    new Character()
                    {
                        ID = 1,
                        level = 1
                    }
                }
            };
            
            _equippedCharacter = _characterCollection.characters[0];
        }

        public StatLevel GetStatLevel()
        {
            return _statLevel;
        }

        public CharacterCollection GetCharacterCollection()
        {
            return _characterCollection;
        }

        public Character GetEquippedCharacter()
        {
            return _equippedCharacter;
        }
    }
}