using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "BossConfig", menuName = "Config/Config/BossConfig")]
    public class BossConfig :  ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxHitPoints;
        [SerializeField] private int _attackSpeed;
        [SerializeField] private float _attackRange;
        [SerializeField] private Definition.Equipment[] _equipments;
        [SerializeField] private Definition.Skill[] _skills;

        public int ID => _id;
        public int Damage => _damage;
        public int MaxHitPoints => _maxHitPoints;
        public float AttackSpeed => _attackSpeed;
        public float AttackRange => _attackRange;
        
        public Definition.Equipment[] Equipments => _equipments;
        public Definition.Skill[] Skills => _skills;
        
        public UnitStat ToStat()
        {
            return new UnitStat()
            {
                ID = ID,
                MaxHitPoints = MaxHitPoints,
                Damage = Damage,
                AttackSpeed = AttackSpeed,
                AttackRange = AttackRange
            };
        }
    }
}