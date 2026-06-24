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
        Common,
    }

    public enum EClass
    {
        Human
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
    public class EquipmentCatalogue
    {
        public EEquipmentType equipmentType;
        public List<Equipment> owned;
    }

    [Serializable]
    public class Equipment
    {
        public EEquipmentType equipmentType;
        public int ID;
        public int level;
    }

    [Serializable]
    public class EquipmentSlot
    {
        public EEquipmentType equipmentType;
        public bool isUnlock;
        public int equippedEquipment;
    }

    [Serializable]
    public class CharacterCollection
    {
        public List<Character> characters;
    }
    
    [Serializable]
    public class Character
    {
        public int ID;
        public int level;
    }

    [Serializable]
    public class StatLevel
    {
        public int damageLevel;
        public int maxHitPointsLevel;
        public int attackSpeedLevel;
        public int critRateLevel;
        public int critDamageLevel;

        public StatLevel(){}
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

    [Serializable]
    public class CampaignData
    {
        public int mapID;
        public int stageID;
        public int subStageID;
    }
    
    public struct AttackSnapshot
    {
        public int Damage;
        public int CritRate;
        public int CritDamage;
    }
}