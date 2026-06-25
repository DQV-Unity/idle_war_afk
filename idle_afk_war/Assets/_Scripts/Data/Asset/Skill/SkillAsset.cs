using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "SkillAsset", menuName = "Asset/Skill/SkillAsset")]
    public class SkillAsset : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprIcon;
        [SerializeField] private GameObject _prefab;
         
        public int ID => _id;
        public string Name => _name;
        public string Description => _description;
        public Sprite SprIcon => _sprIcon;
        public GameObject Prefab => _prefab;
    }
}