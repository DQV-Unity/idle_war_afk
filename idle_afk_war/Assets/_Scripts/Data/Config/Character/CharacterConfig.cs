using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Config/Character/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private ERarity _rarity;
        [SerializeField] private EClass _class;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxHitPoints;
        [SerializeField] private int _attackSpeed;
        [SerializeField] private float _attackRange;
        
        public int ID => _id;
        public ERarity Rarity => _rarity;
        public EClass Class => _class;
        public int Damage => _damage;
        public int MaxHitPoints => _maxHitPoints;
        public float AttackSpeed => _attackSpeed;
        public float AttackRange => _attackRange;

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