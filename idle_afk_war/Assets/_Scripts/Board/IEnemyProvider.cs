using System.Collections.Generic;
using _Scripts.Enemy;
using _Scripts.Unit;
using UnityEngine;

namespace _Scripts.Board
{
    public interface IEnemyProvider
    {
        public bool HasAliveEnemy();
        public IReadOnlyList<IEnemy> AliveEnemies();
        public IUnit GetEnemy(Vector3 position);
    }
}