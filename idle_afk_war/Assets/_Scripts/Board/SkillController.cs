using System;
using System.Linq;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using _Scripts.Definition;
using _Scripts.Extension;
using _Scripts.Skill;
using _Scripts.Unit;
using UnityEngine;

namespace _Scripts.Board
{
    public class SkillController : UpdatableObject
    {
        #region ----- Variables -----

        private StatController _statController;
        private ISkill[] _skills = new ISkill[6];

        private bool _isAuto = false;

        #endregion

        #region ----- Event -----

        public event Action<int, float> onReload; 
        public event Action<int> onActive;

        #endregion

        #region ----- Public Functions -----

        public void Setup(int[] equippedSkills, IStatProvider statProvider)
        {
            for (var i = 0; i < equippedSkills.Length; i++)
            {
                if (equippedSkills[i] <= 0)
                {
                    continue;
                }

                SkillConfig skillConfig = GameConfig.Instance.GetSkillConfig(equippedSkills[i]);
                ISkill newSkill = Instantiate(GameAsset.Instance.GetSkillAsset(equippedSkills[i]).Prefab).GetComponent<ISkill>();
                newSkill.SetUp(skillConfig.ToStat(), statProvider);
                newSkill.onReload += OnSkillReload;
                newSkill.onActive += OnSkillActive;
                _skills[i] = newSkill;
            }
        }

        public int[] GetSkillIDs()
        {
            return _skills.Select(x =>
            {
                if (x == null)
                {
                    return -1;
                }
                return x.ID;
            }).ToArray();
        }
        
        public bool IsAutoSkill() => _isAuto;

        public void OnSpawnedEnemy()
        {
            for (var i = 0; i < _skills.Length; i++)
            {
                if (_skills[i] == null)
                {
                    continue;
                }
                
                _skills[i].ChangeState(ESkillState.Battling);
            }
        }

        public void OnCompleteWave()
        {
            for (var i = 0; i < _skills.Length; i++)
            {
                if (_skills[i] == null)
                {
                    continue;
                }
                
                _skills[i].ChangeState(ESkillState.Idle);
            }
        }

        public void ChangeAutoSkill()
        {
            _isAuto = !_isAuto;
        }

        public void ActiveSkill(int skillID)
        {
            for (int i = 0; i < _skills.Length; i++)
            {
                if (_skills[i].ID != skillID)
                {
                    continue;
                }

                if (!_skills[i].IsReady)
                {
                    return;
                }
                
                _skills[i].Active();
                return;
            }
            
            throw new ArgumentException($"Skill not found {skillID}");
        }
        
        public override void OnUpdate()
        {
            for (var i = 0; i < _skills.Length; i++)
            {
                if (_skills[i] == null)
                {
                    continue;
                }

                if (_isAuto && _skills[i].IsReady)
                {
                    _skills[i].Active();
                }
                _skills[i].OnUpdate();
            }
        }

        #endregion

        #region ----- Private Functions -----


        private void OnSkillReload(int skillID, float value)
        {
            onReload?.Invoke(skillID, value);
        }

        private void OnSkillActive(int skillID)
        {
            onActive?.Invoke(skillID);
        }

        #endregion
    }
}