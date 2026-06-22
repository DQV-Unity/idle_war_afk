using System;
using _Scripts.Data.Config;
using _Scripts.Definition;
using qtLib.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Scene.GameScene
{
    public class GameScene : qtScene
    {
        #region ----- Component Config -----
        
        [SerializeField] private GameObject _goIdleMode;
        [SerializeField] private Button _btnSwitchToCampaignMode;

        [SerializeField] private GameObject _goCampaignMode;
        [SerializeField] private TextMeshProUGUI _txtStageDetail;
        [SerializeField] private Slider _sldWaveProgress;
        
        [SerializeField] private PanelStat _pnlStats;
        [SerializeField] private PanelSkill _pnlSkills;
        
        #endregion

        #region ----- Properties -----

        public Button BtnSwitchToCampaignMode => _btnSwitchToCampaignMode;
        public Button BtnAutoSkill => _pnlSkills.btnAuto;

        #endregion

        #region ----- Public Functions -----

        public void ShowSubStage(CampaignData campaignData)
        {
            _txtStageDetail.SetText($"m{campaignData.mapID} - s{campaignData.stageID} - sub{campaignData.subStageID}");
            SubStageConfig subStageConfig = GameConfig.Instance.GetSubStageConfig(campaignData.mapID, campaignData.stageID, campaignData.subStageID);
            _sldWaveProgress.maxValue = subStageConfig.WaveConfigs.Count;
            _sldWaveProgress.value = 0;
        }
        
        public void ShowDamage(int damage)
        {
            _pnlStats.txtDamage.SetText(damage.ToString());
        }

        public void ShowStats(EUnitStatType statType, ((int level, int value) stat, int cost) data, Action<EUnitStatType> levelUp)
        {
            (statType switch
            {
                EUnitStatType.Damage => _pnlStats.pnlDamage,
                EUnitStatType.MaxHitPoints => _pnlStats.pnlMaxHitPoints,
                EUnitStatType.AttackSpeed => _pnlStats.pnlAttackSpeed,
                EUnitStatType.CritRate => _pnlStats.pnlCritRate,
                EUnitStatType.CritDamage => _pnlStats.pnlCritDamage,
                _ => throw new ArgumentOutOfRangeException(nameof(statType), statType, null)
            }).ShowStat(data, levelUp);
        }
        
        public void ShowSkills(int[] skills, Action<int> active)
        {
            for (var i = 0; i < skills.Length; i++)
            {
                if (skills[i] <= 0)
                {
                    _pnlSkills.skills[i].Lock();
                    continue;
                }
                
                _pnlSkills.skills[i].ShowSkill(skills[i], active);
            }
        }

        public void AutoSkill(bool isAuto)
        {
            _pnlSkills.txtAutoSkill.SetText($"Auto\n{(isAuto ? "auto" : "manual")}");
        }

        public void OnChangeGameMode(EGameMode gameMode)
        {
            switch (gameMode)
            {
                case EGameMode.Campaign:
                {
                    _goCampaignMode.SetActive(true);
                    _goIdleMode.SetActive(false);
                    break;
                }
                case EGameMode.Idle:
                {
                    _goIdleMode.SetActive(true);
                    _goCampaignMode.SetActive(false);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null);
                }
            }
        }

        public void OnWaveComplete(int subStageCompleted)
        {
            _sldWaveProgress.value = subStageCompleted;
        }

        public void OnSkillReload(int skillID, float percent)
        {
            for (var i = 0; i < _pnlSkills.skills.Length; i++)
            {
                if (_pnlSkills.skills[i].ID != skillID)
                {
                    continue;
                }
                
                _pnlSkills.skills[i].Reload(percent);
            }
        }

        public void OnSkillActive(int skillID)
        {
            for (var i = 0; i < _pnlSkills.skills.Length; i++)
            {
                if (_pnlSkills.skills[i].ID != skillID)
                {
                    continue;
                }
                
                _pnlSkills.skills[i].Active();
            }
        }
        
        #endregion
        
        [Serializable]
        private class PanelStat
        {
            public TextMeshProUGUI txtDamage;
            public Stat pnlDamage;
            public Stat pnlMaxHitPoints;
            public Stat pnlAttackSpeed;
            public Stat pnlCritRate;
            public Stat pnlCritDamage;
        }

        [Serializable]
        private class PanelSkill
        {
            public Button btnAuto;
            public TextMeshProUGUI txtAutoSkill;
            public Skill[] skills;
        }
    }
}