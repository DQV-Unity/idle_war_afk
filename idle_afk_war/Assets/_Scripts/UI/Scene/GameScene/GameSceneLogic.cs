using System;
using _Scripts.API;
using _Scripts.Board;
using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using qtLib.UI.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.UI.Scene.GameScene
{
public class GameSceneLogic : qtLogic
    {
        private GameController _gameController;
        private CampaignData _campaignData;
        
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
      
        public event Action<EGameMode> onChangeGameMode
        {
            add =>  _gameController.onChangeGameMode += value;
            remove => _gameController.onChangeGameMode -= value;
        } 

        public event Action<int> onWaveComplete
        {
            add => _gameController.onWaveComplete += value;
            remove => _gameController.onWaveComplete -= value;
        }

        public event Action onSubStageComplete;
        
        public event Action onStageComplete
        {
            add => _gameController.onStageComplete += value;
            remove => _gameController.onStageComplete -= value;
        } 
        
        public event Action onMapComplete
        {
            add => _gameController.onMapComplete += value;
            remove => _gameController.onMapComplete -= value;
        } 
        
        public CampaignData CampaignData => _campaignData;
        
        public override UniTask Initialize()
        {
            if (_gameController == null)
            {
                _gameController = Object.FindAnyObjectByType<GameController>(FindObjectsInactive.Include);

                _gameController.onSubStageComplete += OnSubStageComplete;
                
                _gameController.SetUpBoard();
            }

            _campaignData = APIManager.Instance.GetCampaignData();
            return base.Initialize();
        }
        
        public void LoadData()
        {
            _gameController.LoadData(APIManager.Instance.GetCurrentGameMode(), CampaignData);
            
            Character equippedCharacter = APIManager.Instance.GetEquippedCharacter();
            _gameController.LoadData(APIManager.Instance.GetEquipmentCatalogues(), APIManager.Instance.GetEquipmentSlot());
            _gameController.LoadData(equippedCharacter);
            _gameController.LoadData(APIManager.Instance.GetSkillSlots());
            _gameController.LoadData(APIManager.Instance.GetStatLevel());
        }
        
        public void MapData()
        {
            _gameController.MapData();
        }

        public void UpdateEquipment()
        {
            _gameController.UpdateData(APIManager.Instance.GetEquipmentCatalogues(), APIManager.Instance.GetEquipmentSlot());
        }

        public void UpdateSkill()
        {
            _gameController.UpdateData(APIManager.Instance.GetSkillSlots());
        }

        public void StartGame()
        {
            _gameController.StartGame();
        }
        
        public int GetDamage()
        {
            return _gameController.GetDamage();
        }

        public void ClearBoard()
        {
            _gameController.ClearBoard();   
        }
        
        //Skill
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

        public void ActiveSkill(int skillID)
        {
            _gameController.ActiveSkill(skillID);
        }

        //Stat
        public ((int level, int value) stat, int cost) GetStat(EUnitStatType statType)
                {
                    return (_gameController.GetStat(statType), 0);
                }
        
        public void LevelUpStat(EUnitStatType statType)
        {
            _gameController.LevelUpStat(statType);
        }

        //Mode
        public void SwitchToCampaignMode()
        {
            _gameController.SwitchToCampaignMode();
        }

        private void OnSubStageComplete()
        {
            //update campaignData
            _campaignData =  APIManager.Instance.CompleteSubStage();
            _gameController.UpdateData(_campaignData);
            
            onSubStageComplete?.Invoke();
        }
    }
}