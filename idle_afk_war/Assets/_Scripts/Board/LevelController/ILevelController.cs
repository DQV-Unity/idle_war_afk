using System;
using _Scripts.Definition;
using _Scripts.Unit;

namespace _Scripts.Board
{
    public interface ILevelController : IEnemyProvider
    {
        public event Action onSpawnedEnemy;
        public event Action<AttackSnapshot, IUnit> onEnemyAttack; 

        public EGameMode GameMode { get; }
        public bool isFinalWave { get; }
        
        public void SetUpLevel(CampaignData campaignData, IEnemyProvider enemyProvider);
        public void StartGame();
        public void ClearScene();
    }
}