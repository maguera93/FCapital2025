using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour, IBullet
    {
        private const int SCREEN_HEIGHT_BOUNDARIE = 80;

        [SerializeField]
        private int m_speed = 50;
        [SerializeField]
        private int m_damage = 7;

        private float m_yRotation = 0;
        private Transform m_transform;
        private Camera m_mainCamera;

        public int Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }
        public float YRotation
        {
            get { return m_yRotation; }
            set { m_yRotation = value; }
        }
        public int Damage
        {
            get { return m_damage; }
            set { m_damage = value; }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_transform = transform;
            m_mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public void Move()
        {
            m_transform.Translate(Vector3.up * m_speed * Time.deltaTime);

            if (m_mainCamera.WorldToScreenPoint(m_transform.position).y > Screen.height + SCREEN_HEIGHT_BOUNDARIE)
                Destroy(gameObject);
        }
    }
}