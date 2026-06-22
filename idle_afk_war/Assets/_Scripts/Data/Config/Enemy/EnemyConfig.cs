using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/Enemy/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxHitPoints;
        [SerializeField] private int _attackSpeed;
        [SerializeField] private float _attackRange;
        
        public int ID => _id;
        public int Damage => _damage;
        public int MaxHitPoints => _maxHitPoints;
        public float AttackSpeed => _attackSpeed;
        public float AttackRange => _attackRange;

        public UnitStat ToStat()
        {
            return new UnitStat()
            {
                ID = ID,
                Damage = Damage,
                MaxHitPoints = MaxHitPoints,
                AttackSpeed = AttackSpeed,
                AttackRange = AttackRange
            };
        }
    }
}