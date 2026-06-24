using System;
using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.API.Services
{
    public class CharacterService : APIService<CharacterData>
    {
        protected override string DataPath()
        {
            return "Character";
        }

        public Character GetEquippedCharacter()
        {
            return GetCharacter(_data.EquippedCharacter);
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return _data.CharacterCollection;
        }

        public Character GetCharacter(int characterID)
        {
            List<Character> characters = GetCharacterCollection().characters;
            for (var i = 0; i < characters.Count; i++)
            {
                if (characters[i].ID == characterID)
                {
                    return characters[i];
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned character {characterID}");
        }

        public StatLevel GetStatLevel()
        {
            return _data.StatLevel;
        }

        public bool EquippedCharacter(int characterID)
        {
            List<Character> characters = GetCharacterCollection().characters;
            for (var i = 0; i < characters.Count; i++)
            {
                if (characters[i].ID == characterID)
                {
                    _data.EquippedCharacter = characters[i].ID;
                    SaveData();
                    return true;
                }
            }
            
            return false;
        }
    }
}