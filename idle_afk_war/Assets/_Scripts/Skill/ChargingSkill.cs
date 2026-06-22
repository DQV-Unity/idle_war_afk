using System;
using _Scripts.Definition;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace _Scripts.Skill
{
    [RequireComponent(typeof(PlayableDirector))]
    [RequireComponent(typeof(SignalReceiver))]
    [RequireComponent(typeof(Animator))]
    public abstract class ChargingSkill : Skill
    {
        #region ----- Component Config -----

        [SerializeField] protected PlayableDirector _startState;

        #endregion
        
        #region ----- Event -----

        public event Action<int> onEndCharging; 

        #endregion

        #region ----- Public Functions -----
        
        public void OnCompleteStartPhase()
        {
            InternalOnCompleteStartPhase();
            InternalDoSkill();
        }

        public override bool Active()
        {
            if (!base.Active())
            {
                return false;
            }
            ChangeState(ESkillState.Playing);
            _startState.Stop();
            _startState.Play();
            return true;
        }

        #endregion
        
        #region ----- Private Functions -----

        protected abstract void InternalOnCompleteStartPhase();
        protected abstract void InternalDoSkill();

        #endregion

    }
}