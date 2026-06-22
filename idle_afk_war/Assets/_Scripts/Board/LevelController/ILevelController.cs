using System;
using _Scripts.Definition;
using _Scripts.Unit;

namespace _Scripts.Board
{
    public interface ILevelController : IEnemyProvider
    {
        public event Action onSpawnedEnemy;
        public event Action onCompleteWave;
        public event Action<AttackSnapshot, IUnit> onEnemyAttack; 
        public event Action onLevelComplete;

        public EGameMode GameMode { get; }
        public bool isFinalWave { get; }
        
        public void SetUpLevel(int mapID, int stageID, int subStageID, IEnemyProvider enemyProvider);
        public void ClearScene();
    }
}