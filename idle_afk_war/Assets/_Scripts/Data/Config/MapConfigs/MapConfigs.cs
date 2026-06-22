using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "MapConfigs", menuName = "Config/Map/MapConfigs")]
    public class MapConfigs : ScriptableObject
    {
        [SerializeField] private List<MapConfig> _mapConfigs;
        
        public MapConfig GetMapConfig(int mapID)
        {
            for (var i = 0; i < _mapConfigs.Count; i++)
            {
                if (_mapConfigs[i].ID == mapID)
                {
                    return _mapConfigs[i];
                }
            }
            
            throw new KeyNotFoundException($"Map ID {mapID} not found");
        }
    }
}