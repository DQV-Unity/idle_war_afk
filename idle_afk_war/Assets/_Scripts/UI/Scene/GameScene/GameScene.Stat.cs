using System;
using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Scene.GameScene
{
    public class Stat : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private EUnitStatType _unitStatType;
        [SerializeField] private TextMeshProUGUI _txtLevel;
        [SerializeField] private TextMeshProUGUI _txtStat;
        [SerializeField] private TextMeshProUGUI _txtCost;
        [SerializeField] private Button _btnLevelUp;
        [SerializeField] private GameObject _goMax;

        #endregion

        #region ----- Variables -----

        private event Action<EUnitStatType> _levelUp; 

        #endregion

        #region ----- Properties -----

        public Button BtnLevelUp => _btnLevelUp;

        #endregion

        #region ----- Uinty Events -----

        private void Start()
        {
            _btnLevelUp.onClick.AddListener(OnClickLevelUpButton);
        }

        #endregion

        #region ----- Public Function -----

        public void ShowStat(((int level, int value) stat, int cost) data, Action<EUnitStatType> levelUp)
        {
            _levelUp = levelUp;
            _txtLevel.SetText($"Level {data.stat.level}");
            _txtStat.SetText(data.stat.value.ToString());
            _txtCost.SetText(data.cost.ToString());
        }

        #endregion

        #region ----- Private Function -----

        private void OnClickLevelUpButton()
        {
            _levelUp?.Invoke(_unitStatType);
        }

        #endregion
    }
}