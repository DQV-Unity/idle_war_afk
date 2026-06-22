using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Unit.Character
{
    public class Character : Unit, ICharacter
    {
        #region ----- Event -----

        public event Action onStopMove
        {
            add => _event.onStopMove += value;
            remove => _event.onStopMove -= value;
        }

        #endregion

        #region ----- Properties -----

        public override EUnitSide Side => EUnitSide.Alliance;

        #endregion

        #region ----- Public Functions -----

        public override void SetUp(Func<Vector3, IUnit> getEnemy)
        {
            base.SetUp(getEnemy);
            _event.onStopMove += OnStopMove;
        }
        
        #endregion

        #region ----- Private Functions -----

        private void OnStopMove()
        {
            ChangeState(EUnitState.Battling);
        }

        #endregion
    }
}