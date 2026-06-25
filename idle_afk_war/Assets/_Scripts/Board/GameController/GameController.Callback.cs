using _Scripts.Definition;
using _Scripts.Unit;
using qtLib.Helper;

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
                        
            _levelController.SetUpLevel(_campaignData, _characterController);
            SetUpCharacter(_equippedCharacter);
            
            StartGame();
        }
        
        //Enemy
        private void OnSpawnedEnemy()
        {
            _characterController.OnSpawnedEnemy();
            _skillController.OnSpawnedEnemy();
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

        //Event
        private void OnEquipmentChanged(MessageDispatcher.MessageObject message)
        {
            
        }
    }
}