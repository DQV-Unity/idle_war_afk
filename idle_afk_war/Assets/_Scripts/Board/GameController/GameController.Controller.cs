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
                
                _levelController.onSpawnEnemy -= OnSpawnEnemy;
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

        public void LoadData(SkillSlot[] skillSlots)
        {
            _skillController.LoadData(skillSlots, _statController);
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

        
        //Skill
        public void ChangeAutoSkill()
        {
            _skillController.ChangeAutoSkill();
        }

        public void ActiveSkill(int skillID)
        {
            _skillController.ActiveSkill(skillID);
        }
        
        public void UpdateData(SkillSlot[] skillSlots)
        {
            _skillController.UpdateData(skillSlots);
        }

        //Mode
        public void SwitchToCampaignMode()
        {
            ClearBoard();
            onChangeGameMode?.Invoke(EGameMode.Campaign);
            CampaignMode campaignMode = new CampaignMode(_enemySpawnPosition, _enemyInBattlePosition);
            campaignMode.onSpawnEnemy += OnSpawnEnemy;
            campaignMode.onSpawnedEnemy += OnSpawnedEnemy;
            campaignMode.onEnemyAttack += OnEnemyAttack;

            campaignMode.onWaveComplete += OnWaveComplete;
            campaignMode.onSubStageComplete += OnSubStageComplete;
            campaignMode.onStageComplete += OnStageComplete;
            campaignMode.onMapComplete += OnMapComplete;

            _levelController = campaignMode;
        }
        
        public void SwitchToIdleMode()
        {
            ClearBoard();
            onChangeGameMode?.Invoke(EGameMode.Idle);
            IdleMode idleMode = new IdleMode(_enemySpawnPosition, _enemyInBattlePosition);
            idleMode.onSpawnEnemy += OnSpawnEnemy;
            idleMode.onSpawnedEnemy += OnSpawnedEnemy;
            idleMode.onEnemyAttack += OnEnemyAttack;
            
            _levelController = idleMode;
        }
        
        public void StartGame()
                {
                    _characterController.StartGame();
                    _levelController.StartGame();
                }
    }
}