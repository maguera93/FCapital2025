using UnityEngine;

namespace Enemy
{
    public interface IEnemyHealth
    {
        public int Health { get; set; }
        public void GetDamage(int damage);
        public void Death();

    }
}
