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

        //Map data
        public void LoadData(EquipmentCatalogue[] inventoryData, EquipmentSlot[] equipmentSlots)
        {
            _equipmentController.LoadData(inventoryData, equipmentSlots);
        }
        
        public void LoadData(Character equippedCharacter)
        {
            _equippedCharacter = equippedCharacter;
            _characterController.LoadData(equippedCharacter, _levelController, _statController);
        }
        
        public void LoadData(EGameMode gameMode, CampaignData campaignData)
        {
            _campaignData = campaignData;
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
            
            _levelController.LoadData(campaignData, _characterController);
        }

        public void LoadData(int[] equippedIDs)
        {
            _skillController.LoadData(equippedIDs, _statController);
        }
        
        public void LoadData(StatLevel statLevel)
        {
            _statController.LoadData(_characterController.CharacterData, _equipmentController, statLevel);
        }

        public void MapData()
        {
            _statController.MapData();
            _characterController.MapData();
            _skillController.MapData();
        }

        //Level
        public void UpdateData(CampaignData campaignData)
        {
            if (_levelController is CampaignMode campaignMode)
            {
                campaignMode.UpdateLevel(campaignData);
            }
        }
        
        public void LevelUpStat(EUnitStatType unitStatType)
        {
            _statController.LevelUpStat(unitStatType);
        }
        
        //Equipment
        public void UpdateData(EquipmentCatalogue[] inventoryData, EquipmentSlot[] equipmentSlots)
        {
            _equipmentController.UpdateData(inventoryData, equipmentSlots);
        }

        public void UpdateData(int[] equippedIDs)
        {
            
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
        
        public void StartGame()
                {
                    _characterController.StartGame();
                    _levelController.StartGame();
                }
    }
}