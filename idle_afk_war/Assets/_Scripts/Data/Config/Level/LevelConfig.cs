using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "Level_xx", menuName = "Config/Level/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _level;
        [SerializeField] private int _cardRequire;
        
        public int Level => _level;
        public int CardRequire => _cardRequire;
    }
}