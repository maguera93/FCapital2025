using Bullet;
using DG.Tweening;
using Enemy;
using System.Collections;
using UnityEngine;

public class Boss : BaseEnemy
{
    [Space, SerializeField]
    private GameObject m_bulletGO;
    [SerializeField]
    private float m_cadency = 2f;
    [SerializeField]
    private Transform m_bulletParent;
    [SerializeField]
    private int m_bulletsPerShoot = 6;

    private bool m_canShoot = false;

    public float Cadency { get => m_cadency; set => m_cadency = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        Sequence sequence = DOTween.Sequence();

        sequence.Append(m_transform.DOMoveX(4f, 5f).SetEase(Ease.Linear));
        sequence.Append(m_transform.DOMoveX(-4f, 5f).SetEase(Ease.Linear));
        sequence.Append(m_transform.DOMoveX(0, 5f).SetEase(Ease.Linear));

        sequence.SetLoops(-1);

        sequence.Restart();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
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
            Attack();
    }

    protected override void Attack()
    {
        if (!m_canShoot)
            return;

        StartCoroutine(SpawnBullets());

        m_canShoot = false;
    }

    IEnumerator SpawnBullets()
    {
        float initAngle = 180;
        float angle = (initAngle)/m_bulletsPerShoot;

        for (int i = 0; i <= m_bulletsPerShoot; i++)
        {
            GameObject b = Instantiate(m_bulletGO, m_bulletParent.position, Quaternion.identity);

            EnemyBullet enemyBullet = b.GetComponent<EnemyBullet>();
            
            enemyBullet.Setup(initAngle);
            initAngle += angle;

            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
