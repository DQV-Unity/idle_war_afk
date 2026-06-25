using System;
using System.Collections.Generic;

namespace _Scripts.Definition
{
    [Serializable]
    public struct EquipmentCatalogue
    {
        public EEquipmentType equipmentType;
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
    public struct EquipmentSlot
    {
        public EEquipmentType equipmentType;
        public bool isUnlock;
        public int equippedEquipment;
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
    }

    [Serializable]
    public struct Skill
    {
        public int ID;
        public int level;
    }

    [Serializable]
    public struct CampaignData
    {
        public int mapID;
        public int stageID;
        public int subStageID;
    }
}