using System;
using System.Collections.Generic;
using _Scripts.API.Services;
using qtLib.Helper;

namespace _Scripts.API
{
    public partial class APIManager : qtSingleton<APIManager>
    {
        public static int API_TimeBetween2TimeSaveData = 500;
        
        private InventoryService _inventoryService;
        private CharacterService _characterService;
        private BattleService _battleService;
        
        protected override void _Init()
        {
            base._Init();
            _inventoryService = new InventoryService();
            _characterService = new CharacterService();
            _battleService = new BattleService();
        }

        // private void _CollectReward(RewardModel reward)
        // {
        //     switch (reward.rewardType)
        //     {
        //         case EItemType.Coin:
        //         case EItemType.CogUnit:
        //         case EItemType.SolUnit:
        //         case EItemType.Aquamarine:
        //         case EItemType.DrawTicket:
        //         {
        //             CollectCurrency(reward.rewardType, reward.amount);
        //             break;
        //         }
        //         case EItemType.Exp:
        //         {
        //             CollectExp(reward.amount);
        //             break;
        //         }
        //         case EItemType.Seed:
        //         case EItemType.Pot:
        //         case EItemType.Fertilizer:
        //         case EItemType.Fruit:
        //         {
        //             CollectInventoryItem(reward.rewardType, reward.itemID, reward.amount);
        //             break;
        //         }
        //         case EItemType.Card:
        //         {
        //             CollectCard(reward.itemID, reward.amount);
        //             break;
        //         }
        //         case EItemType.CommonBox:
        //         case EItemType.RareBox:
        //         case EItemType.EpicBox:
        //         case EItemType.LegendBox:
        //         {
        //             CollectRewards(OpenBlindBox(reward.rewardType));
        //             break;
        //         }
        //         default:
        //         {
        //             throw new ArgumentOutOfRangeException(nameof(reward.rewardType), reward.rewardType, null);
        //         }
        //     }
        // }
        //
        // public void CollectRewards(List<RewardModel> rewards)
        // {
        //     for (var i = 0; i < rewards.Count; i++)
        //     {
        //         _CollectReward(rewards[i]);
        //     }
        //     UpdateUserResource(_user.GetTotalResource());
        // }
        //
        // public void CollectReward(RewardModel reward)
        // {
        //     _CollectReward(reward);
        //     UpdateUserResource(_user.GetTotalResource());
        // }
        //
        // public List<RewardModel> OpenBlindBox(EItemType itemType)
        // {
        //     return _user.OpenBlindBox(itemType);
        // }
    }
}