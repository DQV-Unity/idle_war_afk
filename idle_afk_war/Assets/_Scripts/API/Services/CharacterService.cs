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
            return _data.EquippedCharacter;
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return _data.CharacterCollection;
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
                    _data.EquippedCharacter = characters[i];
                    SaveData();
                    return true;
                }
            }
            
            return false;
        }
    }
}