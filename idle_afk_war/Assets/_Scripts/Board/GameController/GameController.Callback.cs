using _Scripts.Definition;
using _Scripts.Unit;

namespace _Scripts.Board
{
    public partial class GameController
    {
        //Character
        private void OnCharacterDie(long characterID)
        {
            onGameOver?.Invoke(_levelController.GameMode, _levelController.isFinalWave);
            if (_levelController.isFinalWave)
            {
                SwitchToIdleMode();
            }
            else
            {
                SwitchToCampaignMode();
            }
                        
            _levelController.LoadData(_campaignData, _characterController);
            LoadData((Character)_equippedCharacter);
            
            StartGame();
        }
        
        //Enemy
        private void OnSpawnEnemy()
        {
            _skillController.OnSpawnEnemy();
        } 
            
        private void OnSpawnedEnemy()
        {
            _characterController.OnSpawnedEnemy();
        }

        private void OnEnemyAttack(AttackSnapshot dataSnapShot, IUnit target)
        {
            _battleController.HitCalculate(dataSnapShot, target);
        }
        
        private void OnEnemyDie(int enemyID){}

        //Stage
        private void OnWaveComplete(int completedWaveCount)
        {
            _characterController.OnCompleteWave();
            _skillController.OnCompleteWave();
            onWaveComplete?.Invoke(completedWaveCount);
        }

        private void OnSubStageComplete()
        {
            onSubStageComplete?.Invoke();
        }

        private void OnStageComplete()
        {
            onStageComplete?.Invoke();
        }

        private void OnMapComplete()
        {
            onMapComplete?.Invoke();
        }
    }
}