using System;
using _Scripts.Data.Config;
using _Scripts.Definition;

namespace _Scripts.Board
{
    public partial class GameController
    {
        public event Action<int, float> onSkillReload
        {
            add => _skillController.onReload += value;
            remove => _skillController.onReload -= value;
        } 
        public event Action<int> onSkillActive
        {
            add => _skillController.onActive += value;
            remove => _skillController.onActive -= value;
        }
        public event Action<EGameMode> onChangeGameMode;
        public event Action<EGameMode, bool> onGameOver;
        public event Action<int> onWaveComplete; 
        public event Action onSubStageComplete;
        public event Action onStageComplete;
        public event Action onMapComplete;
        

        public int GetDamage()
        {
            return _statController.Damage;
        }
        
        public (int level, int value) GetStat(EUnitStatType statType)
        {
            return _statController.GetStat(statType);
        }

        public int[] GetSkillIDs()
        {
            return _skillController.GetSkillIDs();
        }

        public bool IsAutoSkill()
        {
            return _skillController.IsAutoSkill();
        }
    }
}