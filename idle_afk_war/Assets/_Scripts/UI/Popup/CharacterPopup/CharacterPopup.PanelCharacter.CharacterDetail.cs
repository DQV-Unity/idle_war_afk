using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    [Serializable]
    public class CharacterDetail
    {
        #region ----- Component Config -----

        [SerializeField] private Image _imgCharacterAvatar;
        [SerializeField] private TextMeshProUGUI _txtCharacterName;
        [SerializeField] private TextMeshProUGUI _txtCharacterLevel;
        [SerializeField] private Image _imgCharacterClass;
        [SerializeField] private Image _imgCharacterRarity;

        #endregion

        #region ----- Public Functions -----

        public void ShowCharacterDetail(int characterID, int characterLevel)
        {
            CharacterAsset characterAsset = GameAsset.Instance.GetCharacterAsset(characterID);
            _imgCharacterAvatar.sprite = characterAsset.SprAvatar;
            _txtCharacterName.SetText(characterAsset.Name);
            _txtCharacterLevel.SetText($"Level {characterLevel}");
            
            CharacterConfig characterConfig = GameConfig.Instance.GetCharacterConfig(characterID);
            _imgCharacterRarity.sprite = GameAsset.Instance.GetRarityAsset(characterConfig.Rarity).SprIcon;
            _imgCharacterClass.sprite = GameAsset.Instance.GetClassAsset(characterConfig.Class).SprIcon;
        }

        #endregion
    }
}