using _Scripts.Definition;
using _Scripts.Unit;
using qtLib.Game.Object;

namespace _Scripts.Enemy
{
    public interface IEnemy : IUnit
    {
        public long UniqueID { get; }
        public void InitStat(UnitStat stat);
        public void Attack(IUnit target);
    }
}