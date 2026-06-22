using System;
using System.Collections.Generic;
using _Scripts.Data.Asset;
using _Scripts.Definition;
using _Scripts.Enemy;
using _Scripts.Unit;
using _Scripts.Unit.Character;
using UnityEngine;
using Character = _Scripts.Definition.Character;

namespace _Scripts.Board
{
    public class CharacterController : MonoBehaviour, IEnemyProvider
    {
        #region ----- Component Config -----

        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _inBattlePosition;

        #endregion
        
        #region ----- Variables -----
        
        private IStatProvider _statController;
        private IEnemyProvider _enemyProvider;
        private ICharacter _character;

        #endregion

        #region ----- Event -----

        public event Action<long> onCharacterDie;

        #endregion
        
        #region ----- Properties -----

        public int CharacterID() => _character.ID;
        
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

        public void SetUp(Definition.Character equippedCharacter, IEnemyProvider enemyProvider, IStatProvider statProvider)
        {
            _statController = statProvider;
            _enemyProvider = enemyProvider;
            
            CharacterAsset characterAsset = GameAsset.Instance.GetCharacterAsset(equippedCharacter.ID);
            _character = Instantiate(characterAsset.Prefab, _spawnPosition.position, Quaternion.identity).GetComponent<ICharacter>();
            _character.onDie += OnCharacterDie;
            
            _character.InitStat(equippedCharacter.ID, _statController.Damage, _statController.MaxHitPoints, _statController.AttackSpeed, _statController.AttackRange, _statController.CritRate, _statController.CritDamage);
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
            Destroy(_character.GameObject);
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