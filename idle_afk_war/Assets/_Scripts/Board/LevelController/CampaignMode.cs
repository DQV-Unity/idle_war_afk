using System;
using _Scripts.Data.Config;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Board
{
    public class CampaignMode : LevelController, ILevelController
    {
        #region ----- Component Config -----

        private MapConfig _currentMapConfig;
        private StageConfig _currentStageConfig;
        private SubStageConfig _currentSubStageConfig;
        
        private bool _isFinalWave;
        
        #endregion

        #region ----- Events -----

        public event Action<int> onWaveComplete;
        public event Action onSubStageComplete;
        public event Action onStageComplete;
        public event Action onMapComplete;

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

        public override void LoadData(CampaignData campaignData, IEnemyProvider enemyProvider)
        {
            base.LoadData(campaignData, enemyProvider);
            UpdateLevel(campaignData);
        }

        public void UpdateLevel(CampaignData campaignData)
        {
            _currentMapConfig = GameConfig.Instance.GetMapConfig(campaignData.mapID);
            _currentStageConfig = _currentMapConfig.GetStageConfig(campaignData.stageID);
            _currentSubStageConfig = _currentStageConfig.GetSubStageConfig(campaignData.subStageID);
            _currentWaveConfig = _currentSubStageConfig.WaveConfigs[0];
        }

        #endregion

        #region ----- Private Functions -----

        protected override async void CompleteWave()
        {
            onWaveComplete?.Invoke(_currentSubStageConfig.WaveConfigs.IndexOf(_currentWaveConfig) + 1);
            int nextWave = _currentSubStageConfig.WaveConfigs.IndexOf(_currentWaveConfig) + 1;
            if (nextWave >= _currentSubStageConfig.WaveConfigs.Count)
            {
                CompleteSubStage();
            }
            else
            {
                _currentWaveConfig = _currentSubStageConfig.WaveConfigs[nextWave];
            }
            
            await UniTask.Delay(2000);
            SpawnEnemyWave();
            
            // if (_isFinalWave)
            // {
            //     CompleteSubStage();
            //     _isFinalWave = false;
            // }
            // else
            // {
            //     int nextWave = _currentSubStageConfig.WaveConfigs.IndexOf(_currentWaveConfig) + 1;
            //     if (nextWave >= _currentSubStageConfig.WaveConfigs.Count)
            //     {
            //         _isFinalWave = true;
            //         _currentWaveConfig = new WaveConfig(_currentSubStageConfig.BossID, 1);
            //     }
            //     else
            //     {
            //         _currentWaveConfig = _currentSubStageConfig.WaveConfigs[nextWave];
            //     }
            // }
            //
            // await UniTask.Delay(2000);
            // SpawnEnemyWave();
        }

        private void CompleteSubStage()
        {
            onSubStageComplete?.Invoke();
        }


        #endregion
    }
}