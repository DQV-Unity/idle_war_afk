using _Scripts.Definition;

namespace _Scripts.Board
{
    public partial class GameController
    {
        public void SetUpBoard()
        {
            SwitchToCampaignMode();
            _characterController.onCharacterDie += OnCharacterDie;
        }

        public void SetUpEquipment(EquipmentCatalogue[] inventoryData)
        {
            _equipmentController.SetUp(inventoryData);
        }
        
        public void SetUpCharacter(int characterID)
        {
            _characterController.SetUp(characterID, _levelController, _statController);
        }
        
        public void SetUpLevel(int mapID, int stageID, int subStageID)
        {
            _levelController.SetUpLevel(mapID, stageID, subStageID, _characterController);
        }
        
        public void SetUpSkill(int[] skillIDs)
        {
            _skillController.Setup(skillIDs, _statController);
        }
        
        public void CalculateStat(Character equippedCharacter)
        {
            _statController.SetUp(equippedCharacter, _equipmentController, new StatLevel(1,1,1,1, 1));
        }

        public void LevelUpStat(EUnitStatType unitStatType)
        {
            _statController.LevelUpStat(unitStatType);
        }

        public void ChangeAutoSkill()
        {
            _skillController.ChangeAutoSkill();
        }

        public void ActiveSkill(int skillID)
        {
            _skillController.ActiveSkill(skillID);
        }
    }
}