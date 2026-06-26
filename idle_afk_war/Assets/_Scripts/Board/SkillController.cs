using System;
using System.Collections.Generic;
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

        private IStatProvider _statProvider;
        private SkillSlot[] _skillSlots;
        private ISkill[] _skills = new ISkill[6];

        private bool _isAuto = false;

        #endregion

        #region ----- Properties -----
        
        public bool IsAutoSkill => _isAuto;
        
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

        #endregion
        
        #region ----- Event -----

        public event Action<int, float> onReload; 
        public event Action<int> onActive;
        public event Action OnSkillHasChanged;
        
        #endregion

        #region ----- Public Functions -----

        public void LoadData(SkillSlot[] skillSlots, IStatProvider statProvider)
        {
            _skillSlots = skillSlots;
            _statProvider = statProvider;
        }
        
        public void MapData()
        {
            for (var i = 0; i < _skillSlots.Length; i++)
            {
                if (!_skillSlots[i].isUnlock)
                {
                    continue;
                }
                if (_skillSlots[i].equippedSkill <= 0)
                {
                    continue;
                }

                _skills[i] = CreateSkill(_skillSlots[i].equippedSkill);
            }
        }

        public void UpdateData(SkillSlot[] skillSlots)
        {
            _skillSlots = skillSlots;
            
            Dictionary<int, ISkill> currentSkills = new Dictionary<int, ISkill>();
            for (var i = 0; i < _skills.Length; i++)
            {
                if (_skills[i] == null)
                {
                    continue;
                }
                
                currentSkills.Add(_skills[i].ID, _skills[i]);
                _skills[i] = null;
            }
            
            for (var i = 0; i < _skillSlots.Length; i++)
            {
                if (!_skillSlots[i].isUnlock)
                {
                    continue;
                }
                if (_skillSlots[i].equippedSkill <= 0)
                {
                    continue;
                }

                if (currentSkills.TryGetValue(_skillSlots[i].equippedSkill, out ISkill skill))
                {
                    _skills[i] = skill;
                    currentSkills.Remove(_skillSlots[i].equippedSkill);
                    continue;
                }
                
                _skills[i] = CreateSkill(_skillSlots[i].equippedSkill);
            }
            
            foreach (ISkill currentSkillsValue in currentSkills.Values)
            {
                RemoveSkill(currentSkillsValue);
            }
        }
        
        public void OnSpawnEnemy()
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
        
        private ISkill CreateSkill(int skillId)
        {
            SkillConfig skillConfig =
                GameConfig.Instance.GetSkillConfig(skillId);

            ISkill newSkill = Instantiate(
                    GameAsset.Instance.GetSkillAsset(skillId).Prefab)
                .GetComponent<ISkill>();

            newSkill.SetUp(skillConfig.ToStat(), _statProvider);
            newSkill.onReload += OnSkillReload;
            newSkill.onActive += OnSkillActive;

            return newSkill;
        }

        private void RemoveSkill(ISkill skill)
        {
            skill.onReload -= OnSkillReload;
            skill.onActive -= OnSkillActive;
            
            DestroyImmediate(skill.GameObject);
        }
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