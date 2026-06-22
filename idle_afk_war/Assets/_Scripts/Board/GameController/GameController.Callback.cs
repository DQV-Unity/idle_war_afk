using _Scripts.Definition;
using _Scripts.Unit;

namespace _Scripts.Board
{
    public partial class GameController
    {
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
                        
            _levelController.SetUpLevel(_campaignData, _characterController);
            SetUpCharacter(_equippedCharacter);
            
            StartGame();
        }
        
        private void OnEnemyDie(int enemyID){}

        private void OnSpawnedEnemy()
        {
            _characterController.OnSpawnedEnemy();
            _skillController.OnSpawnedEnemy();
        }

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

        private void OnEnemyAttack(AttackSnapshot dataSnapShot, IUnit target)
        {
            _battleController.HitCalculate(dataSnapShot, target);
        }
    }
}