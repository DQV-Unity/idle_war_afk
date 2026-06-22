using System;
using _Scripts.API;
using _Scripts.Board;
using _Scripts.Definition;
using _Scripts.UI.Popup.CharacterPopup;
using Cysharp.Threading.Tasks;
using qtLib.Helper;
using qtLib.UI.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.UI.Scene.GameScene
{
    public class GameSceneLogic : qtLogic
    {
        private GameController _gameController;
        
        public event Action<int, float> onSkillReload
        {
            add => _gameController.onSkillReload += value;
            remove => _gameController.onSkillReload -= value;
        }
        
        public event Action<int> onSkillActive
        {
            add => _gameController.onSkillActive += value;
            remove => _gameController.onSkillActive -= value;
        }
        
        public event Action<EGameMode, bool> onGameOver
        {
            add => _gameController.onGameOver += value;
            remove => _gameController.onGameOver -= value;
        } 
        
        public override UniTask Initialize()
        {
            if (_gameController == null)
            {
                _gameController = Object.FindAnyObjectByType<GameController>(FindObjectsInactive.Include);
                _gameController.SetUpBoard();
            }

            return base.Initialize();
        }

        public void SetUpBoard()
        {
            Character equippedCharacter = APIManager.Instance.GetEquippedCharacter();
            _gameController.SetUpEquipment(APIManager.Instance.GetEquipmentCatalogues());
            _gameController.CalculateStat(equippedCharacter);
            _gameController.SetUpCharacter(equippedCharacter.ID);
            _gameController.SetUpLevel(1, 1, 1);
            _gameController.SetUpSkill(new int[]{2});
        }

        public int GetDamage()
        {
            return _gameController.GetDamage();
        }
        
        public ((int level, int value) stat, int cost) GetStat(EUnitStatType statType)
        {
            return (_gameController.GetStat(statType), 0);
        }

        public int[] GetSkillIDs()
        {
            return _gameController.GetSkillIDs();
        }

        public bool IsAutoSkill()
        {
            return _gameController.IsAutoSkill();
        }

        public void ChangeAutoSkill()
        {
            _gameController.ChangeAutoSkill();
        }
        
        public void LevelUpStat(EUnitStatType statType)
        {
            _gameController.LevelUpStat(statType);
        }

        public void ActiveSkill(int skillID)
        {
            _gameController.ActiveSkill(skillID);
        }

        public void SwitchToCampaignMode()
        {
            _gameController.SwitchToCampaignMode();
        }
    }
    
    public class GameSceneMediator : qtMediator<GameScene, GameSceneLogic>
    {
        public GameSceneMediator() : base()
        {
            _configUI = (ui, logic, mediator) =>
            {
                MessageDispatcher.Register(MessageDispatcher.EEvent.SwitchTab, OnSwitchTab);
                
                logic.onSkillReload += ui.OnSkillReload;
                logic.onSkillActive += ui.OnSkillActive;
                
                logic.onGameOver += OnGameOver;
                
                ui.BtnAutoSkill.onClick.AddListener(ChangeAutoSkill);
                ui.BtnSwitchToCampaignMode.onClick.AddListener(SwitchToCampaignMode);
                
                ui.ShowButtonSwitchToCampaignMode(false);
                return UniTask.CompletedTask;
            };

            _beforeUIShow = (ui, logic, mediator) =>
            {
                logic.SetUpBoard();
                
                ShowStats();
                
                ui.ShowSkills(logic.GetSkillIDs(), ActiveSkill);
                ui.AutoSkill(logic.IsAutoSkill());
                
                return UniTask.CompletedTask;
            };
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            MessageDispatcher.UnRegister(MessageDispatcher.EEvent.SwitchTab, OnSwitchTab);
            
            _logic.onSkillReload -= _ui.OnSkillReload;
            _logic.onSkillActive -= _ui.OnSkillActive;
            
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

        private void OnGameOver(EGameMode gameMode, bool isFinalStage)
        {
            if (gameMode != EGameMode.Campaign || !isFinalStage)
            {
                return;
            }
            
            _ui.ShowButtonSwitchToCampaignMode(true);
        }

        private void OnSwitchTab(MessageDispatcher.MessageObject message)
        {
            MessageDispatcher.SwitchFooterTabMessage data = (MessageDispatcher.SwitchFooterTabMessage)message;
            if (data == null)
            {
                return;
            }

            switch (data.tab)
            {
                case ETab.Character:
                {
                    if (data.isShow)
                    {
                        qtUiFlow.Request<CharacterPopupMediator>().Move();
                    }
                    else
                    {
                        CharacterPopupMediator popup = qtUiFlow.GetNewest<CharacterPopupMediator>();
                        popup.ManualHideFromOutSide();
                    }
                    break;
                }
                case ETab.Companion:
                {
                    break;
                }
                case ETab.Farm:
                {
                    break;
                }
                case ETab.Institute:
                {
                    break;
                }
                case ETab.Armory:
                {
                    break;
                }
                case ETab.Shop:
                {
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(data.tab), data.tab, null);
                }
            }
        }

        #endregion
    }
}