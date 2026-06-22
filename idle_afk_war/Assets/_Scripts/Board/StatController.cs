using System;
using System.Collections.Generic;
using _Scripts.Data.Config;
using _Scripts.Definition;
using _Scripts.Unit;
using UnityEngine;
using EquipmentCatalogue = _Scripts.Definition.EquipmentCatalogue;

namespace _Scripts.Board
{
    public class StatController : MonoBehaviour, IStatProvider
    {
        #region ----- Variables -----

        private UnitStat _baseStat;
        
        private int _id;
        private int _damage;
        private int _hitPoints;
        private int _maxHitPoints;
        private float _attackSpeed;
        private float _attackRange;
        private int _critRate;
        private int _critDamage;

        private int _damageLevel = 1;
        private int _maxHitPointsLevel = 1;
        private int _attackSpeedLevel = 1;
        private int _critRateLevel = 1;
        private int _critDamageLevel = 1;
        
        private IInventoryProvider _inventoryProvider;
        
        #endregion

        #region ----- Unity Events -----

        public event Action onStatHasChanged;

        #endregion

        #region ----- Properties -----

        public int ID => _id;
        public int Damage => _damage;
        public int HitPoints => _hitPoints;
        public int MaxHitPoints => _maxHitPoints;
        public float AttackSpeed => _attackSpeed;
        public float AttackRange => _attackRange;
        public int CritRate => _critRate;
        public int CritDamage => _critDamage;
        
        public int DamageLevel => _damageLevel;
        public int MaxHitPointsLevel => _maxHitPointsLevel;
        public int AttackSpeedLevel => _attackSpeedLevel;
        public int CritRateLevel => _critRateLevel;
        public int CritDamageLevel => _critDamageLevel;

        #endregion
        
        #region ----- Public Functions -----
        
        public void SetUp(Character equippedCharacter, IInventoryProvider inventoryProvider, StatLevel statLevel)
        {
            _inventoryProvider = inventoryProvider;
            
            CharacterConfig characterConfig = GameConfig.Instance.GetCharacterConfig(equippedCharacter.ID);
            _baseStat = characterConfig.ToStat();
            
            //Todo: handle level
            _id = equippedCharacter.ID;
            _damage = characterConfig.Damage;
            _hitPoints = characterConfig.MaxHitPoints;
            _maxHitPoints = characterConfig.MaxHitPoints;
            _attackSpeed = characterConfig.AttackSpeed;
            _attackRange = characterConfig.AttackRange;
            
            _damageLevel = statLevel.damageLevel;
            _maxHitPointsLevel = statLevel.maxHitPointsLevel;
            _attackSpeedLevel = statLevel.attackSpeedLevel;
            _critRateLevel = statLevel.critRateLevel;
            _critDamageLevel = statLevel.critDamageLevel;

            //Todo: handle inventory
            CalculateStat();
        }

        public void LevelUpStat(EUnitStatType unitStatType)
        {
            switch (unitStatType)
            {
                case EUnitStatType.Damage:
                {
                    _damageLevel += 1;
                    break;
                }
                case EUnitStatType.MaxHitPoints:
                {
                    _maxHitPointsLevel += 1;
                    break;
                }
                case EUnitStatType.AttackSpeed:
                {
                    _attackSpeedLevel += 1;
                    break;
                }
                case EUnitStatType.CritRate:
                {
                    _critRateLevel += 1;
                    break;
                }
                case EUnitStatType.CritDamage:
                {
                    _critDamageLevel += 1;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(unitStatType), unitStatType, null);
                }
            }
            CalculateStat();
            onStatHasChanged?.Invoke();
        }

        public (int level, int value) GetStat(EUnitStatType statType)
        {
            switch (statType)
            {
                case EUnitStatType.Damage:
                {
                    return (DamageLevel, Damage);
                }
                case EUnitStatType.MaxHitPoints:
                {
                    return (MaxHitPointsLevel, MaxHitPoints);
                }
                case EUnitStatType.AttackSpeed:
                {
                    return (AttackSpeedLevel, AttackSpeedLevel);
                }
                case EUnitStatType.CritRate:
                {
                    return (CritRateLevel, CritRateLevel);
                }
                case EUnitStatType.CritDamage:
                {
                    return (CritDamageLevel, CritDamageLevel);
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(statType), statType, null);
                }
            }
        }

        public void OnEquipmentHasChanged()
        {
            CalculateStat();
            onStatHasChanged?.Invoke();
        }

        #endregion

        #region ----- Private Functions -----

        private void CalculateStat()
        {
            _damage = _baseStat.Damage * (1 + DamageLevel - 1);
            _maxHitPoints = _baseStat.MaxHitPoints *  (1 + MaxHitPointsLevel - 1);
            _attackSpeed = _baseStat.AttackSpeed * (1 + AttackSpeedLevel - 1);
            _critRate = _baseStat.CritRate *  (1 + CritRateLevel - 1);
            _critDamage = _baseStat.CritDamage *  (1 + CritDamageLevel - 1);
            
            //Todo: bonus from equipment

            _damage = (int)(_damage * (1 + GetBonusStatFromEquipment(EUnitStatType.Damage)));
            _maxHitPoints = (int)(_maxHitPoints * (1 + GetBonusStatFromEquipment(EUnitStatType.MaxHitPoints)));
            _attackSpeed = _attackSpeed * (1 + GetBonusStatFromEquipment(EUnitStatType.AttackSpeed));
            _critRate = (int)(_critRate * (1 + GetBonusStatFromEquipment(EUnitStatType.CritRate)));
            _critDamage = (int)(_critDamage * (1 + GetBonusStatFromEquipment(EUnitStatType.CritDamage)));
        }

        private float GetBonusStatFromEquipment(EUnitStatType statType)
        {
            int bonusStat = 0;
            Definition.EquipmentCatalogue[] equipmentCatalogue = _inventoryProvider.EquipmentCatalogues;
            EquipmentConfig equipmentConfig;
            for (var i = 0; i < equipmentCatalogue.Length; i++)
            {
                //owned
                for (int j = 0; j < equipmentCatalogue[i].owned.Count; j++)
                {
                    equipmentConfig = GameConfig.Instance.GetEquipmentConfig(equipmentCatalogue[i].equipmentType, equipmentCatalogue[i].owned[j].ID);
                    if (equipmentConfig.OwnedBonus.bonusStat != statType)
                    {
                        continue;
                    }

                    bonusStat += equipmentConfig.OwnedBonus.value;
                }
            }
            
            List<Definition.Equipment> equippedEquipment = _inventoryProvider.EquippedEquipments;
            for (var i = 0; i < equippedEquipment.Count; i++)
            {
                equipmentConfig = GameConfig.Instance.GetEquipmentConfig(equipmentCatalogue[i].equipmentType, equippedEquipment[i].ID);
                if (equipmentConfig.EquippedBonus.bonusStat != statType)
                {
                    continue;
                }

                bonusStat += equipmentConfig.EquippedBonus.value;
            }
            
            return bonusStat/100f;
        }
        
        #endregion
    }
}