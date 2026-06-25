using System;
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

        public void ShowCharacterDetail(Character equippedCharacter)
        {
            _characterDetail.ShowCharacterDetail(equippedCharacter);
        }

        public void ShowEquipment(EquipmentSlot[] equipmentSlots, Action<EEquipmentType> selectEquipmentSlot, Func<EEquipmentType, int, Definition.Equipment> getEquipmentData)
        {
            for (var i = 0; i < _equipments.Length; i++)
            {
                _equipments[i].Lock();
                
                for (var j = 0; j < equipmentSlots.Length; j++)
                {
                    if (equipmentSlots[j].equipmentType != _equipments[i].EquipmentType)
                    {
                        continue;
                    }

                    if (!equipmentSlots[j].isUnlock)
                    {
                        break;
                    }

                    if (equipmentSlots[j].equippedEquipment <= 0)
                    {
                        _equipments[i].ShowEmpty(selectEquipmentSlot);
                        break;
                    }
                   
                    _equipments[i].ShowEquipmentSlot(getEquipmentData.Invoke(equipmentSlots[j].equipmentType, equipmentSlots[i].equippedEquipment), selectEquipmentSlot);
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