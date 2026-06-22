using _Scripts.Definition;

namespace _Scripts.Unit
{
    public interface IUnitStatProvider : IStatProvider
    {
        public EUnitSide Side { get; }
        public EUnitState State { get; }
        public float AttackRange { get; }
    }
}