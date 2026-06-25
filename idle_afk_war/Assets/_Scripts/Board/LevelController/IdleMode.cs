using _Scripts.Data.Config;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Board
{
    public class IdleMode : LevelController, ILevelController
    {
        public IdleMode(Transform spawnPosition, Transform inBattlePosition) : base(spawnPosition, inBattlePosition)
        {
            
        }

        #region ----- Properties -----

        public EGameMode GameMode => EGameMode.Idle;
        public bool isFinalWave => false;

        #endregion

        public override void LoadData(CampaignData campaignData, IEnemyProvider enemyProvider)
        {
            base.LoadData(campaignData, enemyProvider);
            MapConfig currentMapConfig = GameConfig.Instance.GetMapConfig(campaignData.mapID);
            StageConfig currentStageConfig = currentMapConfig.GetStageConfig(campaignData.stageID);
            SubStageConfig currentSubStageConfig = currentStageConfig.GetSubStageConfig(campaignData.subStageID);
            
            _currentWaveConfig = currentSubStageConfig.WaveConfigs[0];
        }

        protected override async void CompleteWave()
        {
            await UniTask.Delay(2000);
            SpawnEnemyWave();
        }
    }
}