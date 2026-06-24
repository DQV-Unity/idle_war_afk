using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "EquipmentAssets", menuName = "Asset/Equipment/EquipmentAssets")]
    public class EquipmentAssets : ScriptableObject
    {
        [SerializeField] private List<EquipmentCatalogueAsset> _equipmentCatalogues;
        
        public EquipmentCatalogueAsset GetEquipmentCatalogueAsset(EEquipmentType equipmentType)
        {
            for (var i = 0; i < _equipmentCatalogues.Count; i++)
            {
                if (_equipmentCatalogues[i].EquipmentType == equipmentType)
                {
                    return _equipmentCatalogues[i];
                }
            }
            
            throw new KeyNotFoundException($"Equipment {equipmentType} not found");
        }
    }
}