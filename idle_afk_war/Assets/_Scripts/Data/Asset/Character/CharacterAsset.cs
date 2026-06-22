using _Scripts.Board.Bullet;
using AYellowpaper;
using UnityEngine;

namespace _Scripts.Data.Asset
{
    [CreateAssetMenu(fileName = "CharacterAsset", menuName = "Asset/Character/CharacterAsset")]
    public class CharacterAsset : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private Sprite _sprAvatar;
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private InterfaceReference<IBullet, MonoBehaviour> _bullet;
        
        public int ID => _id;
        public Sprite SprAvatar => _sprAvatar;
        public string Name => _name;
        public GameObject Prefab => _prefab;
        public IBullet Bullet => _bullet.Value;
    }
}