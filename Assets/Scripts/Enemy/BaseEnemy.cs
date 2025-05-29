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
        private float m_speed = 1;
        [SerializeField]
        protected float stopDistance = 4f;
        [SerializeField]
        private GameObject m_hitParticles;
        [SerializeField]
        private GameObject m_deadParticles;

        private SpriteRenderer m_spriteRenderer;
        [Space, SerializeField]
        private GameObject m_powerUpPrefab;
        [SerializeField]
        private GameObject m_heartPrefab;
        [SerializeField]
        private float m_spawnStuff = 0.3f;
        [Space, SerializeField]
        protected AudioManager m_audioManager;

        protected Transform m_playerTransform;
        protected Transform m_transform;

        private bool m_canAttack = true;
        protected float m_currentTime;
        private float m_attackTime = 1f;

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
        public float Speed
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
            else
                Attack();
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
            Destroy(hitFX, 3f);

            m_spriteRenderer.DOColor(Color.red, 0.1f);
            m_spriteRenderer.DOColor(Color.white, 0.1f).SetDelay(0.2f);

            m_audioManager.PlayAudio(0, 0.3f, Random.Range(0.8f, 1.1f));

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

            float rand = Random.Range(0f, 1f);

            if (rand <= m_spawnStuff)
            {
                rand = Random.Range(0f, 1f);

                if (rand <= 0.5f)
                {
                    Instantiate(m_heartPrefab, m_transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(m_powerUpPrefab, m_transform.position, Quaternion.identity);
                }
            }

            m_audioManager.PlayAudio(1, 2f, Random.Range(0.8f, 1.1f));

            Destroy(dead, 4f);
            Destroy(gameObject);
        }

        public void Move()
        {
            m_transform.position = Vector2.MoveTowards(m_transform.position, m_playerTransform.position, Speed * Time.deltaTime);
            m_transform.LookAt(m_playerTransform);

            m_transform.rotation = Quaternion.Euler(0, 0, m_transform.rotation.eulerAngles.z);
        }

        protected virtual void Attack()
        {
            if (m_canAttack)
            {
                //Attack
                GlobalVariables.instance.PlayerHitTriggered();
                m_canAttack = false;
            }
            else
            {
                m_currentTime += Time.deltaTime;

                if (m_currentTime >= m_attackTime)
                {
                    m_currentTime = 0;
                    m_canAttack = true;
                }
            }
        }
    }
}