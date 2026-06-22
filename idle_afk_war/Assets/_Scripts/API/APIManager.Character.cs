using _Scripts.Definition;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public Character GetEquippedCharacter()
        {
            return _characterService.GetEquippedCharacter();
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return _characterService.GetCharacterCollection();
        }
    }
}