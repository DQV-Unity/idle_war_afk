namespace _Scripts.Unit
{
    public interface IStatProvider
    {
        public int ID { get; }
        public int MaxHitPoints { get; }
        public int HitPoints { get; }
        public int Damage { get; }
        public float AttackSpeed { get; }
        public float AttackRange { get; }
        public int CritRate { get; }
        public int CritDamage { get; }
    }
}