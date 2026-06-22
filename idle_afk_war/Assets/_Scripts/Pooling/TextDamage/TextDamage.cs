using _Scripts.Definition;
using qtLib.Game.Object;
using TMPro;
using UnityEngine;

namespace _Scripts.Pooling
{
    public class TextDamage : PoolingObject
    {
        #region ----- Component Config -----

        [SerializeField] private ETextDamageType _damageType;
        [SerializeField] private TextMeshPro _textDamage;
        
        #endregion

        #region ----- Properties -----

        public override object ObjectPoolID => (int)_damageType;
        public ETextDamageType DamageType => _damageType;

        #endregion

        #region ----- Public Funtions ------

        public void ShowDamage(int damage)
        {
            _textDamage.SetText(damage.ToString());
        }

        public void CompleteShow()
        {
            TextDamagePooling.Instance.Release(this);
        }

        public override void OnGet()
        {
            base.OnGet();
            gameObject.SetActive(true);
        }

        public override void OnRelease()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}