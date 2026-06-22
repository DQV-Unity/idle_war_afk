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
        
        #endregion
        
        public CharacterConfig GetCharacterConfig(int characterID)
        {
            return _characterConfigs.GetCharacterConfig(characterID);
        }

        public EnemyConfig GetEnemyConfig(int enemyID)
        {
            return _enemyConfigs.GetEnemyConfig(enemyID);
        }

        public MapConfig GetMapConfig(int mapID)
        {
            return _mapConfigs.GetMapConfig(mapID);
        }
        
        public SkillConfig GetSkillConfig(int skillID)
        {
            return _skillConfigs.GetSkillConfig(skillID);
        }

        public EquipmentConfig GetEquipmentConfig(EEquipmentType equipmentType, int equipmentID)
        {
            return _equipmentConfigs.GetEquipmentConfig(equipmentType, equipmentID);
        }
    }
}