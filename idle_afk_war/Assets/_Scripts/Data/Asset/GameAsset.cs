using _Scripts.Definition;
using qtLib.Helper;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    public class GameAsset : qtSingleton<GameAsset>
    {
        #region ----- Component Config -----

        [SerializeField] private EnemyAssets _enemyAssets;
        [SerializeField] private CharacterAssets _characterAssets;
        [SerializeField] private SkillAssets _skillAssets;
        [SerializeField] private RarityAssets _rarityAssets;
        [SerializeField] private ClassAssets _classAssets;
        [SerializeField] private EquipmentAssets _equipmentAssets;

        #endregion

        public EnemyAsset GetEnemyAsset(int enemyID)
        {
            return _enemyAssets.GetEnemyAsset(enemyID);
        }

        public CharacterAsset GetCharacterAsset(int characterID)
        {
            return _characterAssets.GetCharacterAsset(characterID);
        }

        public SkillAsset GetSkillAsset(int skillID)
        {
            return _skillAssets.GetSkillAsset(skillID);
        }

        public RarityAsset GetRarityAsset(ERarity rarity)
        {
            return _rarityAssets.GetRarityAsset(rarity);
        }

        public ClassAsset GetClassAsset(EClass @class)
        {
            return _classAssets.GetClassAsset(@class);
        }

        public EquipmentAsset GetEquipmentAsset(EEquipmentType equipmentType, int equipmentID)
        {
            return GetEquipmentCatalogueAsset(equipmentType).GetEquipmentAsset(equipmentID); 
        }
        
        public EquipmentCatalogueAsset GetEquipmentCatalogueAsset(EEquipmentType equipmentType)
        {
            return _equipmentAssets.GetEquipmentCatalogueAsset(equipmentType); 
        }
    }
}