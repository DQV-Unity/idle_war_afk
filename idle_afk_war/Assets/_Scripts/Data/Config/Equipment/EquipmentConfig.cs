using System;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "EquipmentConfig", menuName = "Config/Equipment/EquipmentConfig")]
    public class EquipmentConfig : ScriptableObject
    {
        [SerializeField] private EEquipmentType _equipmentType;
        [SerializeField] private int _id;
        [SerializeField] private EquipmentBonusStat _ownedBonus;
        [SerializeField] private EquipmentBonusStat _equippedBonus;
        
        public EEquipmentType EquipmentType => _equipmentType;
        public int ID => _id;
        public EquipmentBonusStat OwnedBonus => _ownedBonus;
        public EquipmentBonusStat EquippedBonus => _equippedBonus;
        
        [Serializable]
        public struct EquipmentBonusStat
        {
            public EUnitStatType bonusStat;
            public int value;
        }
    }
}