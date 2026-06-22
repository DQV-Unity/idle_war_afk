using _Scripts.Definition;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Unit.Module
{
    public class MoveModule : Module, IModule
    {
        #region ----- Public Functions -----
        
        public async UniTask Move(Vector3 toPosition)
        {
            _event.StartMove();
            float time = Mathf.Abs(toPosition.x - transform.position.x) / (_unitStatProvider.Side == EUnitSide.Alliance
                ? Definition.Definition.Character_Move_Speed
                : Definition.Definition.Enemy_Move_speed);
            await transform.DOMoveX(toPosition.x, time).SetEase(Ease.Linear).ToUniTask();
            _event.StopMove();
        }
        
        #endregion
    }
}