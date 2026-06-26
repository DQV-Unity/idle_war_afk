using _Scripts.Definition;
using qtLib.Extension;

namespace _Scripts.API
{
    public partial class APIManager
    {
        public CampaignData GetCampaignData()
        {
            return qtGameExtension.Clone(_battleService.GetCampaignData());
        }

        public EGameMode GetCurrentGameMode()
        {
            return _battleService.GetCurrentGameMode();
        }

        public CampaignData CompleteSubStage()
        {
            return qtGameExtension.Clone(_battleService.CompleteSubStage());
        }
    }
}