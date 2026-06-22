using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Unit.Module
{
    public class StatModule : MonoBehaviour
    {
        #region ----- Event -----

        public event Action<long> onDie;

        #endregion
        
        #region ----- Variables -----

        private int _id;
        private long _uniqueID;
        private int _maxHitPoints;
        private int _hitPoints;
        private int _damage;
        private float _attackRange;
        private float _attackSpeed;
        private int _critRate;
        private int _critDamage;

        [SerializeField] private EventModule _event;

        #endregion

        #region ----- Properties -----

        public int ID => _id;
        public long UniqueID => _uniqueID;
        public int MaxHitPoints => _maxHitPoints;
        public int HitPoints => _hitPoints;
        public int Damage => _damage;
        public float AttackSpeed => _attackSpeed;
        public float AttackRange => _attackRange;
        public int CritRate => _critRate;
        public int CritDamage => _critDamage;

        #endregion

        #region ----- Public Funtions -----

        public void InitStat(int id, int damage, int maxHitPoints, float attackSpeed, float attackRange, int critRate, int critDamage)
        {
            _id = id;
            _damage = damage;
            _hitPoints = _maxHitPoints = maxHitPoints;
            _attackSpeed = attackSpeed;
            _attackRange = attackRange;
            _critRate = critRate;
            _critDamage = critDamage;
        }

        public void InitStat(UnitStat stat, long uniqueID)
        {
            _uniqueID = uniqueID;
            _id = stat.ID;
            _damage = stat.Damage;
            _hitPoints = _maxHitPoints = stat.MaxHitPoints;
            _attackSpeed = stat.AttackSpeed;
            _attackRange = stat.AttackRange;
            _critRate = stat.CritRate;
            _critDamage = stat.CritDamage;
        }

        public void Hit(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                onDie?.Invoke(UniqueID);
                _event.Die();
            }
        }

        #endregion
    }
}