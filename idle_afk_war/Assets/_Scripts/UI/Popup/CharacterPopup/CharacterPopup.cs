using System;
using System.Collections.Generic;
using _Scripts.Data.Config;
using _Scripts.Definition;
using qtLib.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class CharacterPopup : qtPopup
    {
        #region ----- Component Config -----

        [SerializeField] private PanelButton _pnlButton;
        [SerializeField] private PanelCharacter _pnlCharacter;
        [SerializeField] private PanelSkill _pnlSkill;

        #endregion

        #region ----- Variable -----

        private GameObject _currentTab;

        #endregion
        
        #region ----- Properties -----

        public Button BtnCharacterTab => _pnlButton.BtnCharacter;
        public Button BtnSkillTab => _pnlButton.BtnSkill;
        
        public Button BtnChangeCharacter => _pnlCharacter.BtnChangeCharacter;
        
        public Button BtnSummonSkill => _pnlSkill.BtnSummon;
        public Button BtnFuseAllSkill => _pnlSkill.BtnFuseAll;

        #endregion

        #region ----- Button Tab -----

        public void OpenTab(CharacterPopupLogic.ETab tab)
        {
            if (_currentTab != null)
            {
                _currentTab.SetActive(false);
            }
            _currentTab = (tab switch
            {
                CharacterPopupLogic.ETab.Character => _pnlCharacter.gameObject,
                CharacterPopupLogic.ETab.Skill => _pnlSkill.gameObject,
                _ => throw new ArgumentOutOfRangeException(nameof(tab), tab, null)
            });
            _currentTab.SetActive(true);
        }

        #endregion
        
        #region ----- Public Functions -----

        //Character
        public void ShowCharacterDetails(Character equippedCharacter, 
            Func<EItemType, int, ItemData> getItemData, 
            Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            _pnlCharacter.ShowCharacterDetail(equippedCharacter, getItemData, getLevelConfig);
        }

        public void ShowEquipment(EquipmentSlot[] equipmentSlots, Action<EEquipmentType> selectEquipmentSlot, Func<EEquipmentType, int, Definition.Equipment> getEquipmentData)
        {
            _pnlCharacter.ShowEquipment(equipmentSlots, selectEquipmentSlot, getEquipmentData);
        }
        
        //Skill
        public void ShowSkillSlots(SkillSlot[] skillSlots, Func<int, Definition.Skill> getSkill, Action<int> selectSkill, Func<EItemType, int, ItemData> getItemData, Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            _pnlSkill.ShowSkillSlots(skillSlots, getSkill, selectSkill, getItemData, getLevelConfig);
        }

        public void ShowSkillCollection(List<Definition.Skill> skills, Func<int, bool> isEquip, Action<int> selectSkill, Func<EItemType, int, ItemData> getItemData, Func<EItemType, int, LevelConfig> getLevelConfig)
        {
            _pnlSkill.ShowSkillCollection(skills, isEquip, selectSkill, getItemData, getLevelConfig);
        }

        public void ShowOwnedAttackEffect(int value)
        {
            _pnlSkill.ShowOwnedAttackEffect(value);   
        }

        #endregion
    }
}