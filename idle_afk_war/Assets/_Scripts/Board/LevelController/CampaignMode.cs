using _Scripts.Data.Config;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Board
{
    public class CampaignMode : LevelController, ILevelController
    {
        #region ----- Component Config -----

        private MapConfig _currentMapConfig;
        private StageConfig _currentStageConfig;
        private SubStageConfig _currentSubStageConfig;
        
        #endregion

        #region ----- Properties -----

        public EGameMode GameMode => EGameMode.Campaign;
        public bool isFinalWave => _currentSubStageConfig.WaveConfigs.IndexOf(_currentWaveConfig) == _currentSubStageConfig.WaveConfigs.Count - 1;

        #endregion

        #region ----- Constructor -----

        public CampaignMode(Transform spawnPosition, Transform inBattlePosition) : base(spawnPosition, inBattlePosition)
        {
            
        }

        #endregion

        #region ----- Public Functions -----

        public override void SetUpLevel(int mapID, int stageID, int subStageID, IEnemyProvider enemyProvider)
        {
            base.SetUpLevel(mapID, stageID, subStageID, enemyProvider);
            
            _currentMapConfig = GameConfig.Instance.GetMapConfig(mapID);
            for (var i = 0; i < _currentMapConfig.StageConfigs.Count; i++)
            {
                if (_currentMapConfig.StageConfigs[i].ID == stageID)
                {
                    _currentStageConfig = _currentMapConfig.StageConfigs[i];
                    break;
                }
            }

            for (int i = 0; i < _currentStageConfig.SubStageConfigs.Count; i++)
            {
                if (_currentStageConfig.SubStageConfigs[i].ID == subStageID)
                {
                    _currentSubStageConfig = _currentStageConfig.SubStageConfigs[i];
                    break;
                }
            }
            
            _currentWaveConfig = _currentSubStageConfig.WaveConfigs[0];

            SpawnEnemyWave();
        }

        #endregion

        #region ----- Private Functions -----

        protected override void CompleteWave()
        {
            int nextWave = _currentSubStageConfig.WaveConfigs.IndexOf(_currentWaveConfig) + 1;
            if (nextWave >= _currentSubStageConfig.WaveConfigs.Count)
            {
                CompleteSubStage();
                return;
            }
            
            _currentWaveConfig = _currentSubStageConfig.WaveConfigs[nextWave];
            SpawnEnemyWave();
        }

        private void CompleteSubStage()
        {
            int nextSubStage = _currentSubStageConfig.ID + 1;
            
            for (var i = 0; i < _currentStageConfig.SubStageConfigs.Count; i++)
            {
                if (_currentStageConfig.SubStageConfigs[i].ID == nextSubStage)
                {
                    _currentSubStageConfig = _currentStageConfig.SubStageConfigs[i];
                    _currentWaveConfig = _currentSubStageConfig.WaveConfigs[0];
                    SpawnEnemyWave();
                    return;
                }
            }
            
            CompleteStage();
        }

        private void CompleteStage()
        {
            int stageIndex = _currentMapConfig.StageConfigs.IndexOf(_currentStageConfig);
            stageIndex += 1;
            if (stageIndex >= _currentStageConfig.SubStageConfigs.Count)
            {
                CompleteMap();
                return;
            }
            
            _currentStageConfig = _currentMapConfig.StageConfigs[stageIndex];
            _currentSubStageConfig = _currentStageConfig.SubStageConfigs[0];
            _currentWaveConfig = _currentSubStageConfig.WaveConfigs[0];
            SpawnEnemyWave();
        }

        private void CompleteMap()
        {
            
        }


        #endregion
    }
}