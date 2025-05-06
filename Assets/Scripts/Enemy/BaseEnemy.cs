using UnityEngine;

namespace Enemy
{
    public class BaseEnemy : MonoBehaviour, IEnemyHealth, IEnemyMovement
    {
        public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Speed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public void GetDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}