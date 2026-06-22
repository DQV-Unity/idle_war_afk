using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    [Serializable]
    public class UniqueSkill
    {
        [SerializeField] private Image _imgRarity;
        [SerializeField] private Image _imgSkillIcon;
        [SerializeField] private TextMeshProUGUI _txtSkillName;
        [SerializeField] private TextMeshProUGUI _txtSkillDescription;
    }
}