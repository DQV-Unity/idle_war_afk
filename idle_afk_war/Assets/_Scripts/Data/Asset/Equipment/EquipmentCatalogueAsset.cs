using System.Collections.Generic;
using _Scripts.Definition;
using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "EquipmentCatalogue", menuName = "Asset/Equipment/EquipmentCatalogue")]
    public class EquipmentCatalogueAsset : ScriptableObject
    {
        [SerializeField] private EEquipmentType _equipmentType;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprIcon;
        [SerializeField] private List<EquipmentAsset> _equipmentAssets;
        
        public EEquipmentType EquipmentType => _equipmentType;
        public Sprite SprIcon => _sprIcon;
        public EquipmentAsset GetEquipmentAsset(int equipmentID)
        {
            for (var i = 0; i < _equipmentAssets.Count; i++)
            {
                if (_equipmentAssets[i].ID == equipmentID)
                {
                    return _equipmentAssets[i];
                }
            }
            throw new KeyNotFoundException($"Equipment {equipmentID} not found");
        }
    }
}