using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "EquipmentAsset", menuName = "Asset/Equipment/EquipmentAsset")]
    public class EquipmentAsset : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprIcon;
        
        public int ID => _id;
        public string Name => _name;
        public Sprite SprIcon => _sprIcon;
    }
}