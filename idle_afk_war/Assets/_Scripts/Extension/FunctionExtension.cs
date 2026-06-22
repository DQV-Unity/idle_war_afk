using _Scripts.Definition;
using UnityEngine;

namespace _Scripts.Extension
{
    public static class FunctionExtension
    {
        public static bool DamageCalculate(this AttackSnapshot dataSnapShot, out int damage)
        {
            damage = dataSnapShot.Damage;
            int critRate = Mathf.RoundToInt(dataSnapShot.CritRate);
            if (qtLib.Extension.qtGameExtension.RandomPercent(critRate))
            {
                damage = dataSnapShot.Damage * dataSnapShot.CritDamage / 100;
                return true;
            }

            return false;
        }
    }
}