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
        public Button _btnChangeCharacter;

        #endregion

        #region ----- Properties -----

        public Button BtnChangeCharacter => _btnChangeCharacter;

        #endregion

        #region ----- Public Functions -----

        public void ShowCharacterDetail(int characterID, int characterLevel)
        {
            _characterDetail.ShowCharacterDetail(characterID, characterLevel);
        }

        public void ShowEquipment(List<Definition.Equipment> equippedEquipments)
        {
            for (var i = 0; i < _equipments.Length; i++)
            {
                _equipments[i].Lock();

                for (var j = 0; j < equippedEquipments.Count; j++)
                {
                    if (equippedEquipments[i].equipmentType == _equipments[i].EquipmentType)
                    {
                        _equipments[i].ShowEquipment(equippedEquipments[i]);
                        break;
                    }
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