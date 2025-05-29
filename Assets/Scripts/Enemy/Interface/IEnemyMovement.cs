using UnityEngine;

namespace Enemy
{
    public interface IEnemyMovement
    {
        public float Speed { get; set; }
        public void Move();
    }
}
