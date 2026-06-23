using System;
using System.Collections.Generic;
using _Scripts.Definition;

namespace _Scripts.Board
{
    public partial class GameController
    {
        public void SetUpBoard()
        {
            _characterController.onCharacterDie += OnCharacterDie;
        }

        //Character
        public void SetUpEquipment(EquipmentCatalogue[] inventoryData, EquipmentSlot[] equipmentSlots)
        {
            _equipmentController.SetUp(inventoryData, equipmentSlots);
        }
        
        public void SetUpCharacter(Character equippedCharacter)
        {
            _equippedCharacter = equippedCharacter;
            _characterController.SetUp(_equippedCharacter, _levelController, _statController);
        }
        
        public void SetUpSkill(int[] skillIDs)
        {
            _skillController.Setup(skillIDs, _statController);
        }
        
        //Level
        public void SetUpLevel(CampaignData campaignData)
        {
            _campaignData = campaignData;
               
            _levelController.SetUpLevel(_campaignData, _characterController);
        }

        public void SetUpLevel(EGameMode gameMode)
        {
            switch (gameMode)
            {
                case EGameMode.Campaign:
                {
                    SwitchToCampaignMode();
                    break;
                }
                case EGameMode.Idle:
                {
                    SwitchToIdleMode();
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null);
                }
            }
        }

        public void UpdateLevel(CampaignData campaignData)
        {
            _campaignData = campaignData;
            if (_levelController is CampaignMode campaignMode)
            {
                campaignMode.UpdateLevel(_campaignData);
            }
        }

        public void StartGame()
        {
            _characterController.StartGame();
            _levelController.StartGame();
        }
        
        //Stat
        public void CalculateStat(Character equippedCharacter, StatLevel statLevel)
        {
            _statController.SetUp(equippedCharacter, _equipmentController, statLevel);
        }

        public void LevelUpStat(EUnitStatType unitStatType)
        {
            _statController.LevelUpStat(unitStatType);
        }

        
        //Skill
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