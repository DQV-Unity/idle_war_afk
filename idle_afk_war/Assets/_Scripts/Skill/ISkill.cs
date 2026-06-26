using System;
using _Scripts.Definition;
using _Scripts.Extension;
using _Scripts.Unit;
using UnityEngine;

namespace _Scripts.Skill
{
    public interface ISkill : IUpdatableObject
    {
        public event Action<int, float> onReload; 
        public event Action<int> onActive;

        public bool IsReady { get; }
        public int ID { get; }
        public GameObject GameObject { get; }
        public ESkillState State { get; }
        public void SetUp(SkillStat stat, IStatProvider statProvider);
        public bool Active();
        public void ChangeState(ESkillState state);
    }
}