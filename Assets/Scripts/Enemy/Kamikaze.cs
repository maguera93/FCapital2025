using Enemy;
using UnityEngine;

namespace Enemy {
    public class Kamikaze : BaseEnemy
    {

        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("BOOM");
            }
        }
    }
}
