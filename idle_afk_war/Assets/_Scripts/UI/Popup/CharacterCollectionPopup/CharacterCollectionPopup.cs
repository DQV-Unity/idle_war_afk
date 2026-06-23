using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using _Scripts.Definition;
using qtLib.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
    public class CharacterCollectionPopup : qtPopup
    {
        #region ----- Component Config -----

        [SerializeField] private Image _imgClassBackground;
        [SerializeField] private Image _imgCharacter;
        [SerializeField] private TextMeshProUGUI _txtCharacterName;
        [SerializeField] private Image _imgClass;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private TextMeshProUGUI _txtCharacterLevel;
        [SerializeField] private TextMeshProUGUI _txtCharacterLevelProgress;
        [SerializeField] private Slider _sldCharacterLevel;
        [SerializeField] private GameObject _goEquipped;
        
        [Space]
        [SerializeField] private CharacterScrollView characterScrollView;
        
        [Space]
        [SerializeField] private Button _btnEquip;
        [SerializeField] private Button _btnEnhance;

        [Space]
        [SerializeField] private Button _btnClose;
        
        #endregion

        #region ----- Properties -----

        public Button BtnEquip => _btnEquip;
        public Button BtnEnhance => _btnEnhance;
        public Button BtnClose => _btnClose;

        #endregion

        #region ----- Public Functions -----

        public void ShowCollection(CharacterCollection characterCollection, int selectedCharacter,
            Action<int> onSelectCharacter, bool firstTime = false)
        {
            characterScrollView.ShowCollection(characterCollection.characters, onSelectCharacter, selectedCharacter, firstTime);
        }

        public void ShowCharacter(Character character, bool isEquipped)
        {
            CharacterConfig characterConfig = GameConfig.Instance.GetCharacterConfig(character.ID);
            CharacterAsset characterAsset = GameAsset.Instance.GetCharacterAsset(character.ID);
            ClassAsset classAsset = GameAsset.Instance.GetClassAsset(characterConfig.Class);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(characterConfig.Rarity);
            _imgClassBackground.sprite = classAsset.SprBackground;
            _imgCharacter.sprite = characterAsset.SprAvatar;
            _txtCharacterName.SetText(characterAsset.Name);
            _imgClass.sprite = classAsset.SprIcon;
            _imgRarity.sprite = rarityAsset.SprIcon;
            _txtCharacterLevel.SetText($"Level {character.level}");
            // _txtCharacterLevelProgress
                // _sldCharacterLevel.
            _goEquipped.SetActive(isEquipped);
        }

        #endregion
    }
}