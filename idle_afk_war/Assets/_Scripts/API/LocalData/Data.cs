using System;
using System.Collections.Generic;
using qtLib.Extension;
using qtLib.Helper;

namespace _Scripts.Definition
{
    [Serializable]
    public class EquipmentCatalogue : ICloneable<EquipmentCatalogue>
    {
        public EEquipmentType equipmentType;
        public List<Equipment> owned;
        
        public EquipmentCatalogue Clone()
        {
            return new EquipmentCatalogue()
            {
                equipmentType = equipmentType,
                owned = owned.Clone()
            };
        }
    }

    [Serializable]
    public class Equipment : ICloneable<Equipment>
    {
        public EEquipmentType equipmentType;
        public int ID;
        public int level;
        
        public Equipment Clone()
        {
            return new Equipment()
            {
                equipmentType = equipmentType,
                ID = ID,
                level = level
            };
        }
    }

    [Serializable]
    public class EquipmentSlot : ICloneable<EquipmentSlot>
    {
        public EEquipmentType equipmentType;
        public bool isUnlock;
        public int equippedEquipment;
        
        public EquipmentSlot Clone()
        {
            return new EquipmentSlot()
            {
                equipmentType = equipmentType,
                isUnlock = isUnlock,
                equippedEquipment = equippedEquipment
            };
        }
    }

    [Serializable]
    public class CharacterCollection : ICloneable<CharacterCollection>
    {
        public List<Character> owned;
        
        public CharacterCollection Clone()
        {
            return new CharacterCollection()
            {
                owned = owned.Clone()
            };
        }
    }
    
    [Serializable]
    public class Character : ICloneable<Character>
    {
        public int ID;
        public int level;
        
        public Character Clone()
        {
            return new Character()
            {
                ID = ID,
                level = level
            };
        }
    }

    [Serializable]
    public class StatLevel : ICloneable<StatLevel>
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

        public StatLevel Clone()
        {
            return new StatLevel()
            {
                damageLevel = damageLevel,
                maxHitPointsLevel = maxHitPointsLevel,
                attackSpeedLevel = attackSpeedLevel,
                critRateLevel = critRateLevel,
                critDamageLevel = critDamageLevel,
            };
        }
    }

    [Serializable]
    public class SkillCollection : ICloneable<SkillCollection>
    {
        public List<Skill> owned;
        
        public SkillCollection Clone()
        {
            return new SkillCollection()
            {
                owned = owned.Clone(),
            };
        }
    }
    
    [Serializable]
    public class SkillSlot : ICloneable<SkillSlot>
    {
        public bool isUnlock;
        public int equippedSkill;
        
        public SkillSlot Clone()
        {
            return new SkillSlot()
            {
                isUnlock = isUnlock,
                equippedSkill = equippedSkill
            };
        }
    }

    [Serializable]
    public class Skill : ICloneable<Skill>
    {
        public int ID;
        public int level;
        
        public Skill Clone()
        {
            return new Skill()
            {
                ID = ID,
                level = level
            };
        }
    }

    [Serializable]
    public class CampaignData : ICloneable<CampaignData>
    {
        public int mapID;
        public int stageID;
        public int subStageID;
        
        public CampaignData Clone()
        {
            return new CampaignData()
            {
                mapID = mapID,
                stageID = stageID,
                subStageID = subStageID
            };
        }
    }
}