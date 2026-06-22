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
    }
}