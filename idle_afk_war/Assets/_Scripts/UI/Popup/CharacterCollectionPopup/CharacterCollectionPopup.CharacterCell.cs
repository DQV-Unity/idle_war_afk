using System;
using _Scripts.Data.Asset;
using _Scripts.Data.Config;
using _Scripts.Definition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterCollectionPopup
{
    public class CharacterCell : MonoBehaviour
    {
        #region ----- Component Config -----

        [SerializeField] private GameObject _goContent;
        [SerializeField] private GameObject _goSelected;
        [SerializeField] private Button _btnSelect;
        [SerializeField] private Image _imgBackground;
        [SerializeField] private Image _imgCharacter;
        [SerializeField] private Image _imgClass;
        [SerializeField] private Image _imgRarity;
        [SerializeField] private TextMeshProUGUI _txtLevel;

        #endregion

        #region ----- Variables -----

        private int _characterID;
        private Action<int> _onSelectCharacter;
        
        #endregion

        #region ----- Unity Events -----

        private void Start()
        {
            _btnSelect.onClick.AddListener(OnSelectCharacter);
        }

        #endregion

        #region ----- Public Functions -----
        
        public void ShowCharacter(Character character, int selectedCharacter, Action<int> selectCharacter)
        {
            _onSelectCharacter = selectCharacter;
            _characterID = character.ID;
            
            _goSelected.SetActive(selectedCharacter == character.ID);
            
            _goContent.SetActive(true);
            
            CharacterConfig characterConfig = GameConfig.Instance.GetCharacterConfig(character.ID);
            CharacterAsset characterAsset = GameAsset.Instance.GetCharacterAsset(character.ID);
            ClassAsset classAsset = GameAsset.Instance.GetClassAsset(characterConfig.Class);
            RarityAsset rarityAsset = GameAsset.Instance.GetRarityAsset(characterConfig.Rarity);
            _imgBackground.sprite = rarityAsset.SprItemBackground;
            _imgCharacter.sprite = characterAsset.SprAvatar;
            _imgClass.sprite = classAsset.SprIcon;
            _imgRarity.sprite = rarityAsset.SprIcon;
            _txtLevel.SetText($"Level {character.level}");
        }

        public void ShowEmpty()
        {
            _goContent.SetActive(false);
        }

        #endregion

        #region ----- Private Functions -----

        private void OnSelectCharacter()
        {
            _onSelectCharacter?.Invoke(_characterID);
        }

        #endregion
    }
}