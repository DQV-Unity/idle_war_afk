using UnityEngine;

namespace _Scripts.Board
{
    public partial class GameController : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private SkillController _skillController;
        [SerializeField] private StatController _statController;
        [SerializeField] private BattleController _battleController;
        [SerializeField] private EquipmentController _equipmentController;

        [Space] 
        [SerializeField] private Transform _enemySpawnPosition;
        [SerializeField] private Transform _enemyInBattlePosition;
        
        private ILevelController _levelController;
        
        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _equipmentController.onEquipmentHasChanged += _statController.OnEquipmentHasChanged;
            _statController.onStatHasChanged += _characterController.OnStatHasChanged;
        }

        #endregion
        
        #region ----- Private Functions -----

        public void SwitchToCampaignMode()
        {
            ClearScene();
            _levelController = new CampaignMode(_enemySpawnPosition, _enemyInBattlePosition);
            _levelController.onSpawnedEnemy += OnSpawnedEnemy;
            _levelController.onCompleteWave += OnCompleteWave;
            _levelController.onEnemyAttack += OnEnemyAttack;
            
            _battleController.SetUp(_levelController);
        }
        
        private void SwitchToIdleMode()
        {
            ClearScene();
            _levelController = new IdleMode(_enemySpawnPosition, _enemyInBattlePosition);
            _levelController.onSpawnedEnemy += OnSpawnedEnemy;
            _levelController.onCompleteWave += OnCompleteWave;
            _levelController.onEnemyAttack += OnEnemyAttack;
            
            _levelController.SetUpLevel(1,1,1, _characterController);
            _battleController.SetUp(_levelController);
            SetUpCharacter(1);
        }

        private void ClearScene()
        {
            if (_levelController != null)
            {
                //Clear character
                _characterController.ClearScene();
                //Clear enemy
                _levelController.ClearScene();
                
                _levelController.onSpawnedEnemy -= OnSpawnedEnemy;
                _levelController.onCompleteWave -= OnCompleteWave;
                _levelController.onEnemyAttack -= OnEnemyAttack;
            }
            //Todo: Clear fx
        }

        #endregion
    }
}