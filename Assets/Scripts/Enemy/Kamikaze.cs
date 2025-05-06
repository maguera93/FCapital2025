using Enemy;
using UnityEngine;

namespace Enemy {
    public class Kamikaze : BaseEnemy
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                print("BOOM");
            }
        }
    }
}
