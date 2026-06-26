using _Scripts.Data.Config;
using _Scripts.Definition;

namespace _Scripts.API.Services
{
    public class BattleService : APIService<BattleData>, IAPIService
    {
        protected override string DataPath => "Battle";

        public CampaignData GetCampaignData()
        {
            return _data.CampaignData;
        }

        public EGameMode GetCurrentGameMode()
        {
            return _data.CurrentGameMode;
        }
        
        public CampaignData CompleteSubStage()
        {
            CampaignData campaignData = _data.CampaignData;
            StageConfig stageConfig = GameConfig.Instance.GetStageConfig(campaignData.mapID, campaignData.stageID);
            SubStageConfig subStageConfig = stageConfig.GetSubStageConfig(campaignData.subStageID);
            int index = stageConfig.SubStageConfigs.IndexOf(subStageConfig);
            if (index == stageConfig.SubStageConfigs.Count - 1)
            {
                //Complete stage
                return CompleteStage();
            }
            else
            {
                SubStageConfig nextSubStageConfig = stageConfig.SubStageConfigs[index + 1];
                campaignData.subStageID = nextSubStageConfig.ID;
                SaveData();
            }
            return campaignData;
        }

        private CampaignData CompleteStage()
        {
            CampaignData campaignData = _data.CampaignData;
            MapConfig mapConfig = GameConfig.Instance.GetMapConfig(campaignData.mapID);
            StageConfig stageConfig = mapConfig.GetStageConfig(campaignData.stageID);
            int index = mapConfig.StageConfigs.IndexOf(stageConfig);
            if (index == mapConfig.StageConfigs.Count - 1)
            {
                //Complete map
                return CompleteMapData();
            }
            else
            {
                StageConfig nextStageConfig = mapConfig.StageConfigs[index + 1];
                campaignData.stageID = nextStageConfig.ID;
                campaignData.subStageID = nextStageConfig.SubStageConfigs[0].ID;
                SaveData();
            }
            
            return campaignData;
        }

        private CampaignData CompleteMapData()
        {
            CampaignData campaignData = _data.CampaignData;
            campaignData.mapID = 1;
            campaignData.stageID = 1;
            campaignData.subStageID = 1;
            SaveData();
            return campaignData;
        }
    }
}