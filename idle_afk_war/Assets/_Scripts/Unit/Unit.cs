using System;
using _Scripts.Definition;
using _Scripts.Extension;
using _Scripts.Unit.Module;
using _Scripts.Unit.Module.Attack;
using AYellowpaper;
using Cysharp.Threading.Tasks;
using qtLib.Game.Object;
using UnityEngine;

namespace _Scripts.Unit
{
    [RequireComponent(typeof(StatModule))]
    public abstract class Unit : PoolingObject, IUnit, IUnitStatProvider, IUpdatableObject
    {
        #region ----- Component Config -----
        
        [SerializeField] protected StatModule _stat;
        [SerializeField] protected InterfaceReference<IAttack> _attack;
        [SerializeField] protected AnimationModule _animation;
        [SerializeField] protected MoveModule _move;
        
        [SerializeField] protected EventModule _event;

        #endregion

        #region ----- Variables -----

        protected EUnitState _state;
        protected int _uniqueID;

        #endregion
        
        #region ----- Events -----

        public event Action<long> onDie
        {
            add => _stat.onDie += value;
            remove => _stat.onDie -= value;
        }
        
        public event Action<AttackSnapshot, IUnit> onAttack
        {
            add => _attack.Value.onAttack += value;
            remove => _attack.Value.onAttack -= value;
        }
        
        #endregion
        
        #region ----- Properties -----

        public abstract EUnitSide Side { get; }
        public EUnitState State => _state;
        public int UniqueID => _uniqueID;
        public int ID => _stat.ID;
        public int MaxHitPoints => _stat.MaxHitPoints;
        public int HitPoints => _stat.HitPoints;
        public int Damage => _stat.Damage;
        public float AttackSpeed => _stat.AttackSpeed;
        public float AttackRange => _stat.AttackRange;
        public int CritRate => _stat.CritRate;
        public int CritDamage => _stat.CritDamage;
        public bool IsAlive => _stat.HitPoints > 0;
        public Transform Transform => transform;

        public override object ObjectPoolID => _stat.ID;
        
        #endregion

        #region ----- Unity Events ----

        private void Start()
        {
            _event.onDie += OnDie;
        }

        #endregion

        #region ----- Public Functions -----

        public virtual void SetUp(Func<Vector3, IUnit> getEnemy)
        {
            _animation.SetUp(this);
            _move.SetUp(this);
            _attack.Value.SetUp(this, getEnemy);
            
            ChangeState(EUnitState.Idle);
        }

        public void ChangeState(EUnitState newState)
        {
            _state = newState;
        }

        public void InitStat(int id, int damage, int maxHitPoints, float attackSpeed, float attackRange, int critRate, int critDamage)
        {
            _stat.InitStat(id,damage, maxHitPoints, attackSpeed, attackRange, critRate, critDamage);
        }
        
        public void InitStat(UnitStat stat, int uniqueID)
        {
            _uniqueID = uniqueID;
            _stat.InitStat(stat, uniqueID);
        }

        public async UniTask Appear(Vector3 direction)
        {
            gameObject.SetActive(true);
            _animation.OnAppear();
            ChangeState(EUnitState.PreBattling);
            await Move(transform.position + direction);
        }
        
        public async UniTask Move(Vector3 toPosition)
        {
            await _move.Move(toPosition);
            ChangeState(EUnitState.Battling);
        }
        
        public void Hit(int damage)
        {
            // _animation.Hit();
            _stat.Hit(damage);
        }

        public override void OnRelease()
        {
            base.OnRelease();
            gameObject.SetActive(false);
        }
        
        public override void OnGet()
        {
            base.OnGet();
            gameObject.SetActive(true);
        }

        public virtual void OnUpdate()
        {
            _attack.Value.OnUpdate();
        }

        #endregion

        #region ----- Private Functions -----

        protected virtual void OnDie()
        {
            ChangeState(EUnitState.Dead);
        }

        #endregion
    }
}