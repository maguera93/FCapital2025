using Bullet;
using Enemy;
using UnityEngine;

namespace Enemy{

    public class ShooterEnemy : BaseEnemy
    {
        [Space, SerializeField]
        private GameObject m_bulletGO;
        [SerializeField]
        private float m_cadency = 2f;
        [SerializeField]
        private Transform m_bulletParent;

        private bool m_canShoot = false;

        public GameObject BulletGO
        {
            get { return m_bulletGO; }
            set { m_bulletGO = value; }
        }
        public float Cadency
        {
            get { return m_cadency; }
            set { m_cadency = value; }
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();

            if (!m_canShoot)
            {
                m_currentTime += Time.deltaTime;

                if (m_currentTime >= Cadency)
                {
                    m_currentTime = 0;
                    m_canShoot = true;
                }
            }
            else
                ShootWeapon();
        }

        public void ShootWeapon()
        {
            if (!m_canShoot)
                return;

            GameObject b = Instantiate(BulletGO, m_bulletParent.position, Quaternion.identity);

            EnemyBullet enemyBullet = b.GetComponent<EnemyBullet>();
            Vector3 lookAt = (m_playerTransform.position - m_bulletParent.position);

            float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
            enemyBullet.Setup(angle);

            m_canShoot = false;
        }

        protected override void Attack()
        {
            
        }
    }
}
