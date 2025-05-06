using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Enemy
{
    public class BaseEnemy : MonoBehaviour, IEnemyHealth, IEnemyMovement
    {
        [SerializeField]
        private int m_health = 10;
        [SerializeField]
        private int m_speed = 1;

        private Transform playerTransform;

        public int Health
        { 
            get 
            {
                return m_health;
            } 
            set 
            {
                value = m_health;
            }
        }
        public int Speed
        {
            get
            {
                return m_health;
            }
            set
            {
                value = m_health;
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public void GetDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
            {
                // Death
                Death();
            }
        }

        public void Death()
        {

        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}