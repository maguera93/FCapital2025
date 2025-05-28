using UnityEngine;

namespace Player
{
    public class DoubleWeapon : Weapon
    {
        public override void ShootWeapon()
        {
            if (!m_canShoot)
                return;

            audioManager.PlayAudio(0, 1f, Random.Range(0.8f, 1.1f));
            Vector3 position = m_transform.position;
            position.x -= 0.2f;

            for (int i = 0; i < 2; i++)
            {
                GlobalVariables.instance.Salary--;

                Instantiate(BulletGO, position, Quaternion.identity);
                m_canShoot = false;

                position.x += 0.4f;
            }
        }
    }
}