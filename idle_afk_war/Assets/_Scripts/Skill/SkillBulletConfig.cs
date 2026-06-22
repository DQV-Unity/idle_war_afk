using _Scripts.Board.Bullet;
using AYellowpaper;
using UnityEngine;

namespace _Scripts.Skill
{
    public class SkillBulletConfig
    {
        public string bulletID;
        public InterfaceReference<IBullet, MonoBehaviour> bulletPrefab;
        public float moveSpeed;
        public Vector3 startPosition;
        public Vector3 endPosition;
    }
}