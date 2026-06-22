using System;

namespace _Scripts.Equipment
{
    public class Equipment : IEquipment
    {
        #region ----- Events -----

        public event Action<int> OnEquip;
        public event Action<int> OnUnEquip;

        #endregion

        #region ----- Public Functions -----

        public void Equip()
        {
            throw new NotImplementedException();
        }

        public void UnEquip()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}