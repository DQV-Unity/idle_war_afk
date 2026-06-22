using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.API.Services
{
    [Serializable]
    public class BattleData : DataModel
    {
        [SerializeField] private CampaignData _campaignData;
        [SerializeField] private EGameMode _currentGameMode;
        
        public CampaignData CampaignData => _campaignData;
        public EGameMode CurrentGameMode => _currentGameMode;

        public BattleData()
        {
            _campaignData = new CampaignData()
            {
                mapID = 1,
                stageID = 1,
                subStageID = 1,
            };

            _currentGameMode = EGameMode.Campaign;
        }
    }
}