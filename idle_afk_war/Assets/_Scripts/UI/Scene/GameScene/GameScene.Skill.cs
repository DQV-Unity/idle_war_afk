using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Scene.GameScene
{
    public class Skill : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _goLock;
        [SerializeField] private GameObject _goReady;
        [SerializeField] private Button _btnActive;
        [SerializeField] private TextMeshProUGUI _txtSkillName;
        [SerializeField] private Image _imgPlaying;
        [SerializeField] private Image _imgSkillIcon;
        [SerializeField] private Image _imgDuration;
        [SerializeField] private Image _imgReload;

        [SerializeField] private Material _matReload;

        #endregion

        #region ----- Variables -----

        private int _skillID;
        private Action<int> _active;
        
        #endregion
        
        #region ----- Properties -----

        public int ID => _skillID;
        public Button BtnActive => _btnActive;

        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _btnActive.onClick.AddListener(OnClickActiveButton);
        }

        #endregion

        #region ----- Public Functions -----

        public void ShowSkill(int skillID, Action<int> active)
        {
            _btnActive.enabled = true;
            _goLock.gameObject.SetActive(false);

            _imgSkillIcon.material = null;
            
            _skillID = skillID;
            _active = active;

            _imgDuration.fillAmount = 0;
            _imgReload.fillAmount = 0;
            
            _txtSkillName.SetText(skillID.ToString());
        }

        public void Lock()
        {
            _btnActive.enabled = true;
            _goLock.gameObject.SetActive(true);
        }

        public void Active()
        {
            _imgDuration.fillAmount = 1;
            _imgPlaying.transform.DORotate(360 * Vector3.forward, 1, RotateMode.FastBeyond360).SetLoops(-1);
        }

        public void Play(float value)
        {
            _imgDuration.fillAmount = value;
        }

        public void Reload(float value)
        {
            _imgPlaying.transform.DOKill();
            _imgPlaying.transform.eulerAngles = Vector3.zero;
            _imgDuration.fillAmount = 0;
            
            _imgSkillIcon.material = _matReload;
            _imgReload.fillAmount = value;

            if (value <= 0)
            {
                _imgSkillIcon.material = null;
            }
        }

        #endregion

        #region ----- Private Functions -----

        private void OnClickActiveButton()
        {
            _active?.Invoke(_skillID);
        }

        #endregion
    }
}