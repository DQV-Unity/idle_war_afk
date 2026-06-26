using _Scripts.Definition;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public Character GetEquippedCharacter()
        {
            return _characterService.GetEquippedCharacter().Clone();
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return _characterService.GetCharacterCollection().Clone();
        }

        public Character GetCharacter(int characterID)
        {
            return _characterService.GetCharacter(characterID).Clone();
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