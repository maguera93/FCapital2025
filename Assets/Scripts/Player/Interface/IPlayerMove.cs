using UnityEngine;

namespace Player
{
    public interface IPlayerMove
    {
        public float Speed { get; set; }

        public IWeapon[] Weapons { get; set; }
        public int CurrentWeapon {  get; set; }
        public void Move();
    }
}