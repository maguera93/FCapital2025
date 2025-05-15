using Enemy;
using UnityEngine;

namespace Enemy {
    public class Kamikaze : BaseEnemy
    {
        protected override void Start()
        {
            base.Start();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("BOOM");
                Destroy(gameObject);
            }
        }
    }
}
