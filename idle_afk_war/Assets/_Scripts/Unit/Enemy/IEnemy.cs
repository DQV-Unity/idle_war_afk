using _Scripts.Definition;
using _Scripts.Unit;
using qtLib.Game.Object;

namespace _Scripts.Enemy
{
    public interface IEnemy : IUnit
    {
        public int UniqueID { get; }
        public void InitStat(UnitStat stat, int uniqueID);
        public void Attack(IUnit target);
    }
}