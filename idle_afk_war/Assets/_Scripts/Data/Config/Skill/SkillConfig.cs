using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "SkillConfig", menuName = "Config/Skill/SkillConfig")]
    public class SkillConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private ERarity _rarity;
        [SerializeField] private float _reloadTime;
        [SerializeField] private BonusStat _ownedBonus;
        
        public int ID => _id;
        public ERarity Rarity => _rarity;
        public float ReloadTime => _reloadTime;
        public BonusStat OwnedBonus => _ownedBonus;
        
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