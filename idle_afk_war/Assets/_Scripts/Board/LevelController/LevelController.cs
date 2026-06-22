using System;
using System.Collections.Generic;
using _Scripts.Data.Config;
using _Scripts.Definition;
using _Scripts.Enemy;
using _Scripts.Pooling;
using _Scripts.Unit;
using Cysharp.Threading.Tasks;
using qtLib.Extension;
using UnityEngine;

namespace _Scripts.Board
{
    public abstract class LevelController
    {
        #region ----- Component Config -----

        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _inBattlePosition;

        #endregion
        
        #region ----- Variables -----

        private List<IEnemy> _enemies = new();
        private IEnemyProvider _enemyProvider;

        protected WaveConfig _currentWaveConfig;
        
        #endregion

        #region ----- Events -----

        public event Action onSpawnedEnemy;
        public event Action<AttackSnapshot, IUnit> onEnemyAttack; 

        #endregion

        #region ----- Constructor -----

        public LevelController(Transform spawnPosition, Transform inBattlePosition)
        {
            _spawnPosition = spawnPosition;
            _inBattlePosition = inBattlePosition;
        }

        #endregion

        #region ----- Properties -----

        public bool HasAliveEnemy() => _enemies.Count > 0;
        public IReadOnlyList<IEnemy> AliveEnemies() => _enemies;

        public IUnit GetEnemy(Vector3 position)
        {
            if (_enemies.Count == 0)
            {
                return null;
            }
            return _enemies.TakeRandom(enemy => enemy.IsAlive);
        }
        
        #endregion
        
        #region ----- Public Functions -----

        public virtual void SetUpLevel(CampaignData campaignData, IEnemyProvider enemyProvider)
        {
            _enemyProvider = enemyProvider;
        }
        
        public virtual void StartGame()
        {
            SpawnEnemyWave();
        }

        public void ClearScene()
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].onDie -= OnEnemyDeath;
                _enemies[i].onAttack -= OnEnemyAttack;
                EnemyPooling.Instance.Release(_enemies[i]);
            }
            
            _enemies.Clear();
        }

        #endregion

        #region ----- Private Functions -----

        private void OnEnemyAttack(AttackSnapshot data, IUnit target)
        {
            onEnemyAttack?.Invoke(data, target);
        }
        
        private async void OnEnemyDeath(long enemyUniqueID)
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].UniqueID == enemyUniqueID)
                {
                    _enemies[i].onDie -= OnEnemyDeath;
                    _enemies[i].onAttack -= OnEnemyAttack;
                    EnemyPooling.Instance.Release(_enemies[i]);
                    _enemies.RemoveAt(i);
                    break;
                }
            }

            if (_enemies.Count == 0)
            {
                CompleteWave();
            }
        }
        
        protected abstract void CompleteWave();
        
        protected async void SpawnEnemyWave()
        {
            List<UniTask> moveTask = new();
            
            for (int i = 0; i < _currentWaveConfig.EnemyAmount; i++)
            {
                Vector3 spawnPosition = qtGameExtension.RandomPointInCircleXY(_spawnPosition.position, 0.5f);
                IEnemy enemy = GameController.EnemyFactory(_currentWaveConfig.EnemyID);
                enemy.Transform.position = spawnPosition;
                EnemyConfig enemyConfig = GameConfig.Instance.GetEnemyConfig(_currentWaveConfig.EnemyID);
                enemy.InitStat(enemyConfig.ToStat());
                enemy.SetUp(_enemyProvider.GetEnemy);
                enemy.onDie += OnEnemyDeath;
                enemy.onAttack += OnEnemyAttack;
                
                _enemies.Add(enemy);
                moveTask.Add(enemy.Appear(_inBattlePosition.position - _spawnPosition.position));
            }
            await UniTask.WhenAll(moveTask);
            
            onSpawnedEnemy?.Invoke();
            
            for (var i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Attack(_enemyProvider.GetEnemy(_enemies[i].Transform.position));
            }
        }
        
        #endregion
    }
}