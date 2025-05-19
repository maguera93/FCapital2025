using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using DG.Tweening;

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
        [SerializeField]
        private GameObject m_hitParticles;
        [SerializeField]
        private GameObject m_deadParticles;

        [Space]
        private SpriteRenderer m_spriteRenderer;

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
                m_health = value;
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
                m_speed = value;
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Start()
        {
            m_playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            m_transform = transform;

            m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (Vector2.Distance(m_playerTransform.position, m_transform.position) > stopDistance)
                Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                
                IBullet bullet = collision.GetComponent<IBullet>();
                GetDamage(bullet.Damage);
                Destroy(collision.gameObject);
            }
        }

        public void GetDamage(int damage)
        {
            if (Health <= 0)
                return;

            Health -= damage;

            GlobalVariables.instance.EnemyHitTriggered();

            GameObject hitFX = Instantiate(m_hitParticles, m_transform.position, Quaternion.identity);
            Destroy(hitFX, 0.5f);

            m_spriteRenderer.DOColor(Color.red, 0.1f);
            m_spriteRenderer.DOColor(Color.white, 0.1f).SetDelay(0.2f);

            if (Health <= 0)
            {
                // Death
                Death();
            }
        }

        public void Death()
        {
            GlobalVariables.instance.EnemyDeffeatedTriggered();
            GameObject dead = Instantiate(m_deadParticles, m_transform.position, Quaternion.identity);
            Destroy(dead, 0.5f);
            Destroy(gameObject);
        }

        public void Move()
        {
            m_transform.position = Vector2.MoveTowards(m_transform.position, m_playerTransform.position, Speed * Time.deltaTime);
            m_transform.LookAt(m_playerTransform);

            m_transform.rotation = Quaternion.Euler(0, 0, m_transform.rotation.eulerAngles.z);
        }
    }
}