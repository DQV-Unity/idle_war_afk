using System;
using System.Collections.Generic;

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

    public enum EUnitSide
    {
        Alliance,
        Opponent,
    }

    public enum EEquipmentType
    {
        
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
        
    }

    public enum EClass
    {
        
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
    
    [Serializable]
    public struct EquipmentCatalogue
    {
        public EEquipmentType equipmentType;
        public bool isUnlock;
        public List<Equipment> owned;
    }

    [Serializable]
    public struct Equipment
    {
        public EEquipmentType equipmentType;
        public int ID;
        public int level;
    }

    [Serializable]
    public struct CharacterCollection
    {
        public List<Character> characters;
    }
    
    [Serializable]
    public struct Character
    {
        public int ID;
        public int level;
    }

    [Serializable]
    public struct StatLevel
    {
        public int damageLevel;
        public int maxHitPointsLevel;
        public int attackSpeedLevel;
        public int critRateLevel;
        public int critDamageLevel;

        public StatLevel(int damageLevel, int maxHitPointsLevel, int attackSpeedLevel, int critRateLevel, int critDamageLevel)
        {
            this.damageLevel = damageLevel;
            this.maxHitPointsLevel = maxHitPointsLevel;
            this.attackSpeedLevel = attackSpeedLevel;
            this.critRateLevel = critRateLevel;
            this.critDamageLevel = critDamageLevel;
        }
    }

    [Serializable]
    public struct SkillCollection
    {
        public List<Skill> skills;
        public int[] equippedSkills;
    }

    [Serializable]
    public struct Skill
    {
        public int ID;
        public int level;
    }
    
    public struct AttackSnapshot
    {
        public int Damage;
        public int CritRate;
        public int CritDamage;
    }
}