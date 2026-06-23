using System.Collections.Generic;
using _Scripts.Definition;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Popup.CharacterPopup
{
    public class PanelCharacter : MonoBehaviour
    {
        #region ----- Component Config -----

        //Character detail
        [SerializeField] private CharacterDetail _characterDetail;
        //Equipment 
        [SerializeField] private Equipment[] _equipments;
        //Owned effect
        [SerializeField] private OwnedEffect _ownedEffect;
        //Unique skill
        [SerializeField] private UniqueSkill _uniqueSkill;
        //Collection
        [SerializeField] private Button _btnChangeCharacter;

        #endregion

        #region ----- Properties -----

        public Button BtnChangeCharacter => _btnChangeCharacter;

        #endregion

        #region ----- Public Functions -----

        public void ShowCharacterDetail(Definition.Character equippedCharacter)
        {
            _characterDetail.ShowCharacterDetail(equippedCharacter);
        }

        public void ShowEquipment(EquipmentSlot[] equipmentSlots)
        {
            for (var i = 0; i < _equipments.Length; i++)
            {
                for (var j = 0; j < equipmentSlots.Length; j++)
                {
                    if (equipmentSlots[j].equipmentType != _equipments[i].EquipmentType)
                    {
                        continue;
                    }

                    if (!equipmentSlots[j].isUnlock)
                    {
                        _equipments[i].Lock();
                        break;
                    }

                    if (equipmentSlots[j].equippedEquipment.ID <= 0)
                    {
                        _equipments[i].ShowEmpty();
                        break;
                    }
                   
                    _equipments[i].ShowEquipment(equipmentSlots[i].equippedEquipment);
                    break;
                }
            }
        }

        public void ShowOwnedEffect()
        {
            
        }

        public void ShowUniqueSkill()
        {
            
        }

        #endregion
    }
}