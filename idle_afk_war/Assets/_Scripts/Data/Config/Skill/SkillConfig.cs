using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "SkillConfig", menuName = "Config/Skill/SkillConfig")]
    public class SkillConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private float _reloadTime;
        
        public int ID => _id;
        public float ReloadTime => _reloadTime;

        public SkillStat ToStat()
        {
            return new SkillStat()
            {
                ID = _id,
                ReloadTime = _reloadTime
            };
        }
    }
}