using _Scripts.Definition;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public CampaignData GetCampaignData()
        {
            return _battleService.GetCampaignData();
        }

        public EGameMode GetCurrentGameMode()
        {
            return _battleService.GetCurrentGameMode();
        }

        public CampaignData CompleteSubStage()
        {
            return _battleService.CompleteSubStage();
        }
    }
}