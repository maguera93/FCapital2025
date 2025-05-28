using UnityEngine;

namespace Bullet
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField]
        private int m_speed = 50;
        [SerializeField]
        private int m_damage = 7;

        public int Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        public int Damage
        {
            get { return m_damage; }
            set { m_damage = value; }
        }

        public void Setup(float rotation)
        {
            transform.rotation = Quaternion.AngleAxis(rotation - 90, Vector3.forward);
        }

        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);

            if (transform.position.y < -10)
                Destroy(gameObject);
        }
    }
}