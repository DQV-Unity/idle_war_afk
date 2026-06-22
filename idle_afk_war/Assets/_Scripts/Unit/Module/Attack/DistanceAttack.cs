using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Unit.Module.Attack
{
    public class DistanceAttack : AttackModule, IAttack
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _attackPoint;

        #endregion
        
        #region ----- Event -----

        public event Action<AttackSnapshot, IUnit> onAttack;

        #endregion
        
        #region ----- Private Functions -----

        protected override void OnTriggerAttack()
        {
            onAttack?.Invoke(new AttackSnapshot()
            {
                Damage =  _unitStatProvider.Damage,
                CritRate = _unitStatProvider.CritRate,
                CritDamage =  _unitStatProvider.CritDamage,
            }, _target);
        }

        #endregion
    }
}