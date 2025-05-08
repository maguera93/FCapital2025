using Enemy;
using UnityEngine;

namespace Enemy{
    public class ShooterEnemy : BaseEnemy
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //m_speed = 0;
            }
        }

       // void StopMovement()
       // {
       //     SetMovement(new Vector2(0, 0));
       // }
    }
}
