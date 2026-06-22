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
            return _data.GetEquippedCharacter();
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return _data.GetCharacterCollection();
        }
    }
}