using UnityEngine;

namespace Player
{
    public interface IPlayerMove
    {
        public float Speed { get; set; }
        public void Move();
    }
}