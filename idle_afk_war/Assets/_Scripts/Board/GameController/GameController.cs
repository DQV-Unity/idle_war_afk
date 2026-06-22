using _Scripts.Definition;
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
        private CampaignData _campaignData;
        private Definition.Character _equippedCharacter;
        
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
            onChangeGameMode?.Invoke(EGameMode.Campaign);
            _levelController = new CampaignMode(_enemySpawnPosition, _enemyInBattlePosition);
            _levelController.onSpawnedEnemy += OnSpawnedEnemy;
            _levelController.onEnemyAttack += OnEnemyAttack;

            CampaignMode campaignMode = _levelController as CampaignMode;
            campaignMode.onWaveComplete += OnWaveComplete;
            campaignMode.onSubStageComplete += OnSubStageComplete;
            campaignMode.onStageComplete += OnStageComplete;
            campaignMode.onMapComplete += OnMapComplete;
        }
        
        private void SwitchToIdleMode()
        {
            ClearScene();
            onChangeGameMode?.Invoke(EGameMode.Idle);
            _levelController = new IdleMode(_enemySpawnPosition, _enemyInBattlePosition);
            _levelController.onSpawnedEnemy += OnSpawnedEnemy;
            _levelController.onEnemyAttack += OnEnemyAttack;
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
                _levelController.onEnemyAttack -= OnEnemyAttack;

                if (_levelController is CampaignMode campaignMode)
                {
                    campaignMode.onWaveComplete -= OnWaveComplete;
                    campaignMode.onSubStageComplete -= OnSubStageComplete;
                    campaignMode.onStageComplete -= OnStageComplete;
                    campaignMode.onMapComplete -= OnMapComplete;
                }
            }
            //Todo: Clear fx
        }

        #endregion
    }
}