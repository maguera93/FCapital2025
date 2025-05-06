using UnityEngine;

namespace Enemy
{
    public interface IEnemyMovement
    {
        public int Speed { get; set; }
        public void Move();
    }
}
