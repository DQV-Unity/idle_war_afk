using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "SkillAsset", menuName = "Asset/Skill/SkillAsset")]
    public class SkillAsset : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private GameObject _prefab;
         
        public int ID => _id;
        public GameObject Prefab => _prefab;
    }
}