using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Config/Map/MapConfig")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private List<StageConfig> _stageConfigs;
        
        public int ID => _id;
        public List<StageConfig> StageConfigs => _stageConfigs;
    }
}