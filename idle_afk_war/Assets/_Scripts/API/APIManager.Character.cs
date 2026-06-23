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

        public StatLevel GetStatLevel()
        {
            return _characterService.GetStatLevel();
        }

        public bool EquippedCharacter(int characterID)
        {
            return _characterService.EquippedCharacter(characterID);
        }
    }
}