using System;
using System.Collections.Generic;
using _Scripts.Data.Asset;
using _Scripts.Definition;
using _Scripts.Enemy;
using _Scripts.Unit;
using _Scripts.Unit.Character;
using UnityEngine;

namespace _Scripts.Board
{
    public class CharacterController : MonoBehaviour, IEnemyProvider
    {
        #region ----- Component Config -----

        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _inBattlePosition;

        #endregion
        
        #region ----- Variables -----

        private Definition.Character _characterData;
        private IStatProvider _statController;
        private IEnemyProvider _enemyProvider;
        private ICharacter _character;

        #endregion

        #region ----- Event -----

        public event Action<long> onCharacterDie;

        #endregion
        
        #region ----- Properties -----

        public Definition.Character CharacterData => _characterData;
        
        public bool HasAliveEnemy()
        {
            return _character.IsAlive;
        }

        public IReadOnlyList<IEnemy> AliveEnemies()
        {
            throw new NotImplementedException();
        }

        public IUnit GetEnemy(Vector3 position)
        {
            return _character;
        }

        #endregion
        
        #region ----- Public Functions -----

        public void LoadData(Definition.Character equippedCharacter, IEnemyProvider enemyProvider, IStatProvider statProvider)
        {
            _statController = statProvider;
            _enemyProvider = enemyProvider;
            
            _characterData = equippedCharacter;
        }

        public void MapData()
        {
            CharacterAsset characterAsset = GameAsset.Instance.GetCharacterAsset(_characterData.ID);
            _character = Instantiate(characterAsset.Prefab, _spawnPosition.position, Quaternion.identity).GetComponent<ICharacter>();
            _character.onDie += OnCharacterDie;
            
            _character.InitStat(_characterData.ID, _statController.Damage, _statController.MaxHitPoints, _statController.AttackSpeed, _statController.AttackRange, _statController.CritRate, _statController.CritDamage);
            _character.SetUp(_enemyProvider.GetEnemy);
            _character.GameObject.SetActive(false);
        }

        public void StartGame()
        {
            _character.GameObject.SetActive(true);
            _character.Appear(_inBattlePosition.position - _spawnPosition.position);
        }

        public void OnStatHasChanged()
        {
            _character.InitStat(_statController.ID, _statController.Damage, _statController.MaxHitPoints, _statController.AttackSpeed, _statController.AttackRange, _statController.CritRate, _statController.CritDamage);
        }

        public void ClearScene()
        {
            _character.onDie -= OnCharacterDie;
            DestroyImmediate(_character.GameObject);
        }

        public void OnSpawnedEnemy()
        {
            if (_character.State is EUnitState.Idle)
            {
                _character.ChangeState(EUnitState.Battling);
            }
        }
        
        public void OnCompleteWave()
        {
            _character.ChangeState(EUnitState.Idle);
        }

        #endregion

        #region ----- Private Functions -----


        private void OnCharacterDie(long characterID)
        {
            onCharacterDie?.Invoke(characterID);
        }

        #endregion
    }
}