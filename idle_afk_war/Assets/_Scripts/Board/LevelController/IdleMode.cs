using _Scripts.Data.Config;
using _Scripts.Definition;
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

        public override void SetUpLevel(int mapID, int stageID, int subStageID, IEnemyProvider enemyProvider)
        {
            base.SetUpLevel(mapID, stageID, subStageID, enemyProvider);
            MapConfig currentMapConfig = GameConfig.Instance.GetMapConfig(mapID);
            StageConfig currentStageConfig = null;
            SubStageConfig currentSubStageConfig = null;
            for (var i = 0; i < currentMapConfig.StageConfigs.Count; i++)
            {
                if (currentMapConfig.StageConfigs[i].ID == stageID)
                {
                    currentStageConfig = currentMapConfig.StageConfigs[i];
                    break;
                }
            }

            for (int i = 0; i < currentStageConfig.SubStageConfigs.Count; i++)
            {
                if (currentStageConfig.SubStageConfigs[i].ID == subStageID)
                {
                    currentSubStageConfig = currentStageConfig.SubStageConfigs[i];
                    break;
                }
            }
            
            _currentWaveConfig = currentSubStageConfig.WaveConfigs[0];
            SpawnEnemyWave();
        }

        protected override void CompleteWave()
        {
            SpawnEnemyWave();
        }
    }
}