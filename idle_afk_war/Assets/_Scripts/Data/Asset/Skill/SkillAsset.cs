using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "SkillAsset", menuName = "Asset/Skill/SkillAsset")]
    public class SkillAsset : ScriptableObject
    {
        [SerializeField] private int _id;
        [ShowAssetPreview]
        [SerializeField] private Sprite _sprIcon;
        [SerializeField] private GameObject _prefab;
         
        public int ID => _id;
        public Sprite SprIcon => _sprIcon;
        public GameObject Prefab => _prefab;
    }
}