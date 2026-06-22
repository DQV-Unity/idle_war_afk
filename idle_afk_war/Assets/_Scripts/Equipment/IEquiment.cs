using System;

namespace _Scripts.Equipment
{
    public interface IEquipment
    {
        public event Action<int> OnEquip;
        public event Action<int> OnUnEquip;
        
        public void Equip();
        public void UnEquip();
    }
}