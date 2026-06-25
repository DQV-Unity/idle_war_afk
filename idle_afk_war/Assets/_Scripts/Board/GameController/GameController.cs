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
    }
}