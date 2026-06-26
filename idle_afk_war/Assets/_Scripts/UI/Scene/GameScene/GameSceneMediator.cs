using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;

namespace _Scripts.UI.Scene.GameScene
{
    public class GameSceneMediator : qtMediator<GameScene, GameSceneLogic>
    {
        public GameSceneMediator() : base()
        {
            _configUI = (ui, logic, mediator) =>
            {
                MessageDispatcher.Register(MessageDispatcher.EEvent.SwitchTab, OnSwitchTab);
               
                MessageDispatcher.Register(MessageDispatcher.EEvent.CharacterChanged, OnCharacterChanged);
                MessageDispatcher.Register(MessageDispatcher.EEvent.EquipmentChanged, OnEquipmentChanged);
                MessageDispatcher.Register(MessageDispatcher.EEvent.SkillChanged, OnSkillChanged);

                logic.onSkillReload += ui.OnSkillReload;
                logic.onSkillActive += ui.OnSkillActive;

                logic.onChangeGameMode += ui.OnChangeGameMode;
                
                logic.onWaveComplete += ui.OnWaveComplete;
                logic.onSubStageComplete += OnSubStageComplete;
                
                logic.onGameOver += OnGameOver;
                
                ui.BtnAutoSkill.onClick.AddListener(ChangeAutoSkill);
                ui.BtnSwitchToCampaignMode.onClick.AddListener(SwitchToCampaignMode);
                
                return UniTask.CompletedTask;
            };

            _beforeUIShow = (ui, logic, mediator) =>
            {
                logic.LoadData();
                
                logic.MapData();
                
                ui.ShowSubStage(logic.CampaignData);
                
                ShowStats();
                
                ui.ShowSkills(logic.GetSkillIDs(), ActiveSkill);
                ui.AutoSkill(logic.IsAutoSkill());
                
                return UniTask.CompletedTask;
            };

            _afterUIShow = (ui, logic, mediator) =>
            {
                logic.StartGame();
                return UniTask.CompletedTask;
            };
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            MessageDispatcher.UnRegister(MessageDispatcher.EEvent.SwitchTab, OnSwitchTab);
            MessageDispatcher.UnRegister(MessageDispatcher.EEvent.CharacterChanged, OnCharacterChanged);
            MessageDispatcher.UnRegister(MessageDispatcher.EEvent.EquipmentChanged, OnEquipmentChanged);
            MessageDispatcher.UnRegister(MessageDispatcher.EEvent.SkillChanged, OnSkillChanged);

            _logic.onSkillReload -= _ui.OnSkillReload;
            _logic.onSkillActive -= _ui.OnSkillActive;

            _logic.onWaveComplete -= _ui.OnWaveComplete;
            
            _logic.onGameOver -= OnGameOver;
                
            _ui.BtnAutoSkill.onClick.RemoveAllListeners();
            _ui.BtnSwitchToCampaignMode.onClick.RemoveAllListeners();
        }

        #region ----- Button Event -----

        private void LevelUpStat(EUnitStatType statType)
        {
            _logic.LevelUpStat(statType);
            ShowStats();
        }
        
        private void ActiveSkill(int skillID)
        {
            _logic.ActiveSkill(skillID);
        }

        private void ChangeAutoSkill()
        {
            _logic.ChangeAutoSkill();
            _ui.AutoSkill(_logic.IsAutoSkill());
        }

        private void SwitchToCampaignMode()
        {
            _logic.SwitchToCampaignMode();
        }
        
        #endregion

        #region ----- Private Functions -----

        private void ShowStats()
        {
            _ui.ShowDamage(_logic.GetDamage());
                
            _ui.ShowStats(EUnitStatType.Damage, _logic.GetStat(EUnitStatType.Damage), LevelUpStat);
            _ui.ShowStats(EUnitStatType.MaxHitPoints, _logic.GetStat(EUnitStatType.MaxHitPoints), LevelUpStat);
            _ui.ShowStats(EUnitStatType.AttackSpeed, _logic.GetStat(EUnitStatType.AttackSpeed), LevelUpStat);
            _ui.ShowStats(EUnitStatType.CritRate, _logic.GetStat(EUnitStatType.CritRate), LevelUpStat);
            _ui.ShowStats(EUnitStatType.CritDamage, _logic.GetStat(EUnitStatType.CritDamage), LevelUpStat);
        }

        private void OnSubStageComplete()
        {
            _ui.ShowSubStage(_logic.CampaignData);
        }  
        
        private void OnGameOver(EGameMode gameMode, bool isFinalStage)
        {
            if (gameMode == EGameMode.Campaign)
            {
                _ui.ShowSubStage(_logic.CampaignData);
            }
        }

        private void OnSwitchTab(MessageDispatcher.MessageObject message)
        {
            MessageDispatcher.SwitchFooterTabMessage data = (MessageDispatcher.SwitchFooterTabMessage)message;
            if (data == null)
            {
                return;
            }

            // switch (data.tab)
            // {
            //     case ETab.Character:
            //     {
            //         if (data.isShow)
            //         {
            //             qtUiFlow.Request<CharacterPopupMediator>().Move();
            //         }
            //         else
            //         {
            //             CharacterPopupMediator popup = qtUiFlow.GetNewest<CharacterPopupMediator>();
            //             popup.Close();
            //         }
            //         break;
            //     }
            //     case ETab.Companion:
            //     {
            //         break;
            //     }
            //     case ETab.Farm:
            //     {
            //         break;
            //     }
            //     case ETab.Institute:
            //     {
            //         break;
            //     }
            //     case ETab.Armory:
            //     {
            //         break;
            //     }
            //     case ETab.Shop:
            //     {
            //         break;
            //     }
            //     default:
            //     {
            //         throw new ArgumentOutOfRangeException(nameof(data.tab), data.tab, null);
            //     }
            // }
        }

        private void OnCharacterChanged(object message)
        {
            _logic.ClearBoard();
            _logic.LoadData();
            _logic.StartGame();
        }

        private void OnEquipmentChanged(object message)
        {
            _logic.UpdateEquipment();
            _ui.ShowDamage(_logic.GetDamage());
        }

        private void OnSkillChanged(object message)
        {
            _logic.UpdateSkill();
            _ui.ShowSkills(_logic.GetSkillIDs(), ActiveSkill);
            _ui.ShowDamage(_logic.GetDamage());
        }

        #endregion
    }
}