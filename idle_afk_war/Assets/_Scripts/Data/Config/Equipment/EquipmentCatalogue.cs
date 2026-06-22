using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "EquipmentCatalog", menuName = "Config/Equipment/EquipmentCatalog")]
    public class EquipmentCatalogue : ScriptableObject
    {
        [SerializeField] private EEquipmentType _equipmentType;
        [SerializeField] private List<EquipmentConfig> _equipmentConfig;
        
        public EEquipmentType EquipmentType => _equipmentType;
        public List<EquipmentConfig> EquipmentConfig => _equipmentConfig;
    }
}