using DG.Tweening;
using Player;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour, IPlayerMove
    {
        private const float SCREEN_BOUNDARIES_X = 7.5f;
        private const float SCREEN_BOUNDARIES_Y = 4f;

        [SerializeField]
        private float m_speed = 10;

        [SerializeField]
        private GameObject[] m_weaponsGO;
        private IWeapon[] m_weapons;

        [SerializeField]
        private Animator animator;
        [SerializeField]
        private SpriteRenderer playerSprite;
        [SerializeField]
        private ParticleSystem hitParticles;

        private int m_currentWeapon = 0;
        private Vector2 m_movement = new Vector2(0f, 0f);
        private Transform m_transform;

        private float m_currentTime = 0f;
        private float m_powerUpTime = 5f;
        private bool m_onPowerUp = false;

        public float Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        public IWeapon[] Weapons
        {
            get 
            {
                return m_weapons; 
            }
            set 
            {
                m_weapons = value; 
            }
        }

        public int CurrentWeapon
        {
            get { return m_currentWeapon; }
            set { m_currentWeapon = value; }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_transform = transform;

            Weapons = new IWeapon[m_weaponsGO.Length];

            for (int i = 0; i < m_weaponsGO.Length; i++)
            {
                Weapons[i] = m_weaponsGO[i].GetComponent<IWeapon>();
            }

            GlobalVariables.instance.OnPlayerHit += PlayerHurt;
        }

        private void OnDestroy()
        {
            GlobalVariables.instance.OnPlayerHit -= PlayerHurt;
        }

        // Update is called once per frame
        void Update()
        {
            Move();

            if (m_onPowerUp)
            {
                OnPowerUp();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyBullet"))
            {
                GlobalVariables.instance.PlayerHitTriggered();
                Destroy(collision.gameObject);
            }

            if (collision.CompareTag("PowerUp"))
            {
                CurrentWeapon = 1;
                m_onPowerUp = true;
                m_currentTime = 0;
                Destroy(collision.gameObject);
            }


            if (collision.CompareTag("Heart"))
            {
                GlobalVariables.instance.LifeUpTriggered();
                Destroy(collision.gameObject);
            }
        }

        public void Move()
        {
            m_movement.x = Input.GetAxis("Horizontal");
            m_movement.y = Input.GetAxis("Vertical");

            if (m_movement.x != 0 || m_movement.y != 0)
                animator.SetBool("IsMoving", true);
            else
                animator.SetBool("IsMoving", false);

            if (m_movement.x < 0 && m_transform.position.x <= -SCREEN_BOUNDARIES_X)
                m_movement.x = 0;
            else if (m_movement.x > 0 && m_transform.position.x >= SCREEN_BOUNDARIES_X)
                m_movement.x = 0;

            if (m_movement.y < 0 && m_transform.position.y <= -SCREEN_BOUNDARIES_Y)
                m_movement.y = 0;
            else if (m_movement.y > 0 && m_transform.position.y >= SCREEN_BOUNDARIES_Y)
                m_movement.y = 0;

            m_transform.Translate(m_movement * Speed *  Time.deltaTime);

            if (Input.GetButton("Jump"))
            {
                
                Weapons[CurrentWeapon].ShootWeapon();
            }
        }

        private void PlayerHurt()
        {
            playerSprite.DOColor(Color.red, 0.1f);
            playerSprite.DOColor(Color.white, 0.1f).SetDelay(0.2f);
            hitParticles.Emit(10);
        }

        private void OnPowerUp()
        {
            m_currentTime += Time.deltaTime;

            if (m_currentTime >= m_powerUpTime)
            {
                m_currentTime = 0;
                CurrentWeapon = 0;
                m_onPowerUp = false;
            }
        }
    }
}