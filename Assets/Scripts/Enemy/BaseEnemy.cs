using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Enemy
{
    public class BaseEnemy : MonoBehaviour, IEnemyHealth, IEnemyMovement
    {
        [SerializeField]
        private int m_health = 10;
        [SerializeField]
        private int m_speed = 1;
        [SerializeField]
        private float stopDistance = 4f;

        private Transform m_playerTransform;
        private Transform m_transform;

        protected Transform m_playerTransform;
        protected Transform m_transform;


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
                return m_speed;
            }
            set
            {
                value = m_speed;
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Start()
        {
            m_playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            m_transform = transform;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (Vector2.Distance(m_playerTransform.position, m_transform.position) > stopDistance)
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
            m_transform.position = Vector2.MoveTowards(m_transform.position, m_playerTransform.position, Speed * Time.deltaTime);
            m_transform.LookAt(m_playerTransform);

            m_transform.rotation = Quaternion.Euler(0, 0, m_transform.rotation.eulerAngles.z);
        }
    }
}