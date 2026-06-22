using System;

namespace _Scripts.Unit.Character
{
    public interface ICharacter : IUnit
    {
        public event Action onStopMove;
        
        public void InitStat(int id, int damage, int maxHitPoints, float attackSpeed, float attackRange, int critRate, int critDamage);
    }
}