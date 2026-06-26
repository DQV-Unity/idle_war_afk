using _Scripts.Definition;
using qtLib.Helper;
using UnityEngine;

namespace _Scripts.Data.Config
{
    public class GameConfig : qtSingleton<GameConfig>
    {
        #region ----- Component Config -----

        [SerializeField] private MapConfigs _mapConfigs;
        [SerializeField] private CharacterConfigs _characterConfigs;
        [SerializeField] private EnemyConfigs _enemyConfigs;
        [SerializeField] private SkillConfigs _skillConfigs;
        [SerializeField] private EquipmentConfigs _equipmentConfigs;
        [SerializeField] private BossConfigs _bossConfigs;
        
        #endregion
        
        public CharacterConfig GetCharacterConfig(int characterID)
        {
            return _characterConfigs.GetCharacterConfig(characterID);
        }

        public LevelConfig GetCharacterLevelConfig(int level)
        {
            return _characterConfigs.GetLevelConfig(level);
        }

        public EnemyConfig GetEnemyConfig(int enemyID)
        {
            return _enemyConfigs.GetEnemyConfig(enemyID);
        }

        public MapConfig GetMapConfig(int mapID)
        {
            return _mapConfigs.GetMapConfig(mapID);
        }

        public StageConfig GetStageConfig(int mapID, int stageID)
        {
            return _mapConfigs.GetMapConfig(mapID).GetStageConfig(stageID);
        }

        public SubStageConfig GetSubStageConfig(int mapID, int stageID, int subStageID)
        {
            return GetStageConfig(mapID, stageID).GetSubStageConfig(subStageID);
        }
        
        public SkillConfig GetSkillConfig(int skillID)
        {
            return _skillConfigs.GetSkillConfig(skillID);
        }

        public LevelConfig GetSkillLevelConfig(int level)
        {
            return _skillConfigs.GetLevelConfig(level);
        }

        public EquipmentConfig GetEquipmentConfig(EEquipmentType equipmentType, int equipmentID)
        {
            return _equipmentConfigs.GetEquipmentConfig(equipmentType, equipmentID);
        }
       
        public LevelConfig GetEquipmentLevelConfig(int level)
        {
            return _equipmentConfigs.GetLevelConfig(level);
        }

        public BossConfig GetBossConfig(int bossID)
        {
            return _bossConfigs.GetBossConfig(bossID);
        }
    }
}