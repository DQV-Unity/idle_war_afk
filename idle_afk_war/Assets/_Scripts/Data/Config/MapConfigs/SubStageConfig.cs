using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "SubStageConfig", menuName = "Config/Map/Stage/SubStageConfig")]
    public class SubStageConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private List<WaveConfig> _waveConfigs;
        [SerializeField] private int _bossID;

        public int ID => _id;
        public List<WaveConfig> WaveConfigs => _waveConfigs;
        public int BossID => _bossID;
    }

    [Serializable]
    public class WaveConfig
    {
        [SerializeField] private int _enemyID;
        [SerializeField] private int _enemyAmount;

        public WaveConfig(int ID, int amount)
        {
            _enemyID = ID;
            _enemyAmount = amount;
        }

        public int EnemyID => _enemyID;

        public int EnemyAmount => _enemyAmount;
    }
}