using System;
using System.Collections.Generic;
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
        public void ShowCharacterDetails(Character equippedCharacter)
        {
            _pnlCharacter.ShowCharacterDetail(equippedCharacter);
        }

        public void ShowEquipment(EquipmentSlot[] equipmentSlots, Action<EEquipmentType> selectEquipmentSlot, Func<EEquipmentType, int, Definition.Equipment> getEquipmentData)
        {
            _pnlCharacter.ShowEquipment(equipmentSlots, selectEquipmentSlot, getEquipmentData);
        }
        
        //Skill
        public void ShowEquippedSkills(int[] equippedSkills, Func<int, Definition.Skill> getSkill, Action<int> selectSkill)
        {
            _pnlSkill.ShowEquippedSkills(equippedSkills, getSkill, selectSkill);
        }

        public void ShowSkillCollection(List<Definition.Skill> skills, Func<int, bool> isEquip, Action<int> selectSkill)
        {
            _pnlSkill.ShowSkillCollection(skills, isEquip, selectSkill);
        }

        #endregion
    }
}