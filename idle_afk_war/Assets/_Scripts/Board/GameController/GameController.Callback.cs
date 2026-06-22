using _Scripts.Definition;
using _Scripts.Unit;
using UnityEngine;

namespace _Scripts.Board
{
    public partial class GameController
    {
        private void OnCharacterDie(long characterID)
        {
            onGameOver?.Invoke(_levelController.GameMode, _levelController.isFinalWave);
            SwitchToIdleMode();
        }
        
        private void OnEnemyDie(int enemyID){}

        private void OnSpawnedEnemy()
        {
            _characterController.OnSpawnedEnemy();
            _skillController.OnSpawnedEnemy();
        }

        private void OnCompleteWave()
        {
            _characterController.OnCompleteWave();
            _skillController.OnCompleteWave();
        }

        private void OnEnemyAttack(AttackSnapshot dataSnapShot, IUnit target)
        {
            _battleController.HitCalculate(dataSnapShot, target);
        }
    }
}