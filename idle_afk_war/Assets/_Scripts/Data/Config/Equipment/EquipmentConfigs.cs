using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "EquipmentConfigs", menuName = "Config/Equipment/EquipmentConfigs")]
    public class EquipmentConfigs : ScriptableObject
    {
        [SerializeField] private List<EquipmentCatalogue> _equipmentCatalogues;

        public EquipmentConfig GetEquipmentConfig(EEquipmentType equipmentType, int equipmentID)
        {
            for (var i = 0; i < _equipmentCatalogues.Count; i++)
            {
                if (_equipmentCatalogues[i].EquipmentType != equipmentType)
                {
                    continue;
                }

                for (var j = 0; j < _equipmentCatalogues[i].EquipmentConfig.Count; j++)
                {
                    if (_equipmentCatalogues[i].EquipmentConfig[j].ID == equipmentID)
                    {
                        return _equipmentCatalogues[i].EquipmentConfig[j];
                    }
                }
            }
            throw new KeyNotFoundException($"Equipment Type {equipmentType} ID {equipmentID} not found");
        }
    }
}