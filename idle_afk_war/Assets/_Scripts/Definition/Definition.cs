using System;

namespace _Scripts.Definition
{
    public class Definition
    {
        public const float Character_Move_Speed = 1.5f;
        public const float Enemy_Move_speed = 1;
    }

    public enum EGameMode
    {
        Campaign,
        Idle,
    }
    
    //Type
    public enum EUnitStatType
    {
        Damage,
        MaxHitPoints,
        AttackSpeed,
        CritRate,
        CritDamage,
    }

    public enum EEquipmentType
    {
        Axe,
        Hammer,
        Sword,
        Boom,
    }

    public enum ETextDamageType
    {
        Normal,
        Critical,
    }

    public enum EVfxType
    {
        EnemyDeath,
    }
    
    public enum ETab
    {
        None,
        Character,
        Companion,
        Farm,
        Institute,
        Armory,
        Shop,
    }

    public enum ERarity
    {
        Common,
    }

    public enum EClass
    {
        Human
    }

    public enum EItemType
    {
        Character,
        Equipment,
        Skill,
    }
    
    //Game
    public enum EUnitState
    {
        Idle,
        PreBattling,
        Moving,
        Battling,
        Dead,
    }

    public enum ESkillState
    {
        Idle,
        Battling,
        Playing,
    }
    
    public enum EUnitSide
    {
        Alliance,
        Opponent,
    }

    //Stat
    public struct UnitStat
    {
        public int ID;
        public int MaxHitPoints;
        public int Damage;
        public float AttackSpeed;
        public float AttackRange;
        public int CritRate;
        public int CritDamage;
    }

    public struct SkillStat
    {
        public int ID;
        public float ReloadTime;
    }
    
    public struct AttackSnapshot
    {
        public int Damage;
        public int CritRate;
        public int CritDamage;
    }
    
    [Serializable]
    public struct BonusStat
    {
        public EUnitStatType bonusStat;
        public int value;
    }
}