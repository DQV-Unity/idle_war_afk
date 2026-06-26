using System;
using _Scripts.Definition;
using _Scripts.Unit;
using UnityEngine;

namespace _Scripts.Skill
{
    public abstract class Skill : MonoBehaviour
    {
        #region ----- Variables -----

        private int _id;
        
        protected float _reloadTime;
        protected float _reloadTimer;
        private ESkillState _state;
        
        protected IStatProvider _statProvider;

        #endregion

        #region ----- Events -----

        public event Action<int, float> onReload;
        public event Action<int> onActive;

        #endregion

        #region ----- Properties -----

        public bool IsReady => _reloadTimer <= 0;
        public int ID => _id;
        public GameObject GameObject => gameObject;
        public ESkillState State => _state;

        #endregion

        #region ----- Public Functions -----

        public void SetUp(SkillStat stat, IStatProvider statProvider)
        {
            _statProvider = statProvider;
            _id = stat.ID;
            _reloadTime = stat.ReloadTime;
            _state = ESkillState.Idle;
        }

        public void ChangeState(ESkillState state)
        {
            _state = state;
        }
        
        public virtual bool Active()
        {
            if (_state is not ESkillState.Battling)
            {
                return false;
            }
            
            _reloadTimer = _reloadTime;
            onActive?.Invoke(_id);
            return true;
        }

        public virtual void OnUpdate()
        {
            if (_state is ESkillState.Playing)
            {
                return;
            }

            if (_reloadTimer <= 0)
            {
                return;
            }

            _reloadTimer -= Time.deltaTime;
            onReload?.Invoke(_id, _reloadTimer / _reloadTime);
        }

        #endregion
    }
}