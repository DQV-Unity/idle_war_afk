using System;
using _Scripts.Definition;
using qtLib.Helper;

namespace _Scripts.Board
{
    public partial class GameController
    {
        public void SetUpBoard()
        {
            _characterController.onCharacterDie += OnCharacterDie;
        }
        
        public void ClearBoard()
        {
            if (_levelController != null)
            {
                //Clear character
                _characterController.ClearScene();
                //Clear enemy
                _levelController.ClearScene();
                
                _levelController.onSpawnedEnemy -= OnSpawnedEnemy;
                _levelController.onEnemyAttack -= OnEnemyAttack;

                if (_levelController is CampaignMode campaignMode)
                {
                    campaignMode.onWaveComplete -= OnWaveComplete;
                    campaignMode.onSubStageComplete -= OnSubStageComplete;
                    campaignMode.onStageComplete -= OnStageComplete;
                    campaignMode.onMapComplete -= OnMapComplete;
                }
            }
        }

        //Character
        public void SetUpEquipment(EquipmentCatalogue[] inventoryData, EquipmentSlot[] equipmentSlots, bool needUpdate = false)
        {
            _equipmentController.SetUp(inventoryData, equipmentSlots, needUpdate);
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
        public void SetUpStat(Character equippedCharacter, StatLevel statLevel)
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
        
        //Mode
        public void SwitchToCampaignMode()
        {
            ClearBoard();
            onChangeGameMode?.Invoke(EGameMode.Campaign);
            _levelController = new CampaignMode(_enemySpawnPosition, _enemyInBattlePosition);
            _levelController.onSpawnedEnemy += OnSpawnedEnemy;
            _levelController.onEnemyAttack += OnEnemyAttack;

            CampaignMode campaignMode = _levelController as CampaignMode;
            campaignMode.onWaveComplete += OnWaveComplete;
            campaignMode.onSubStageComplete += OnSubStageComplete;
            campaignMode.onStageComplete += OnStageComplete;
            campaignMode.onMapComplete += OnMapComplete;
        }
        
        public void SwitchToIdleMode()
        {
            ClearBoard();
            onChangeGameMode?.Invoke(EGameMode.Idle);
            _levelController = new IdleMode(_enemySpawnPosition, _enemyInBattlePosition);
            _levelController.onSpawnedEnemy += OnSpawnedEnemy;
            _levelController.onEnemyAttack += OnEnemyAttack;
        }
    }
}