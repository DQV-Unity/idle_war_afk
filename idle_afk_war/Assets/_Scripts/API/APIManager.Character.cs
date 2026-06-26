using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public Character GetEquippedCharacter()
        {
            return qtGameExtension.Clone(_characterService.GetEquippedCharacter());
        }
        
        public CharacterCollection GetCharacterCollection()
        {
            return qtGameExtension.Clone(_characterService.GetCharacterCollection());
        }

        public Character GetCharacter(int characterID)
        {
            return qtGameExtension.Clone(_characterService.GetCharacter(characterID));
        }

        public StatLevel GetStatLevel()
        {
            return qtGameExtension.Clone(_characterService.GetStatLevel());
        }

        public bool EquippedCharacter(int characterID)
        {
            return _characterService.EquippedCharacter(characterID);
        }
    }
}