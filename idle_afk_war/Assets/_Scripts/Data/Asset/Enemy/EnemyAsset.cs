using NaughtyAttributes;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "EnemyAsset", menuName = "Asset/Enemy/EnemyAsset")]
    public class EnemyAsset : ScriptableObject
    {
        [SerializeField] private int _id;
        [ShowAssetPreview]
        [SerializeField] private GameObject _prefab;
        
        public int ID => _id;
        public GameObject Prefab => _prefab;
    }
}