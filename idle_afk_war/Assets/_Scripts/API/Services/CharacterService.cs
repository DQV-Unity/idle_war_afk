using System;
using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.API.Services
{
    public class CharacterService : APIService<CharacterData>
    {
        protected override string DataPath => "Character";

        public Character GetEquippedCharacter()
        {
            return GetCharacter(_data.EquippedCharacter).Clone();
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return _data.CharacterCollection.Clone();
        }

        public Character GetCharacter(int characterID)
        {
            List<Character> characters = GetCharacterCollection().characters;
            for (var i = 0; i < characters.Count; i++)
            {
                if (characters[i].ID == characterID)
                {
                    return characters[i].Clone();
                }
            }
            
            throw new ArgumentOutOfRangeException($"Not owned character {characterID}");
        }

        public StatLevel GetStatLevel()
        {
            return _data.StatLevel.Clone();
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