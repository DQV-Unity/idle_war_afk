using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using _Scripts.Definition;
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
        [SerializeField] private TextMeshProUGUI _txtCharacterLevel;
        [SerializeField] private Slider _sldCharacterLevelProgress;
        [SerializeField] private TextMeshProUGUI _txtCharacterLevelProgress;
        [SerializeField] private Image _imgCharacterClass;
        [SerializeField] private Image _imgCharacterRarity;

        #endregion

        #region ----- Public Functions -----

        public void ShowCharacterDetail(
            Definition.Character equippedCharacter, 
            Func<EItemType, int, Definition.ItemData> getItemData, 
            Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            CharacterAsset characterAsset = GameAsset.Instance.GetCharacterAsset(equippedCharacter.ID);
            _imgCharacterAvatar.sprite = characterAsset.SprAvatar;
            _txtCharacterLevel.SetText($"Level {equippedCharacter.level}");
            
            CharacterConfig characterConfig = GameConfig.Instance.GetCharacterConfig(equippedCharacter.ID);
            _imgCharacterRarity.sprite = GameAsset.Instance.GetRarityAsset(characterConfig.Rarity).SprIcon;
            _imgCharacterClass.sprite = GameAsset.Instance.GetClassAsset(characterConfig.Class).SprIcon;
            
            Definition.ItemData itemData = getItemData(EItemType.Character, equippedCharacter.ID);
            LevelConfig levelConfig = getLevelConfig(EItemType.Character, equippedCharacter.level);
            
            _txtCharacterLevel.SetText($"Level {equippedCharacter.level}");
            _sldCharacterLevelProgress.maxValue = levelConfig.CardRequire;
            _sldCharacterLevelProgress.value = itemData.amount;
            _txtCharacterLevelProgress.SetText($"{itemData.amount}/{levelConfig.CardRequire}");
        }

        #endregion
    }
}