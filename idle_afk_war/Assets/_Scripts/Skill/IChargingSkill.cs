using System;

namespace _Scripts.Skill
{
    public interface IChargingSkill : ISkill
    {
        public void OnCompleteStartPhase();
    }
}