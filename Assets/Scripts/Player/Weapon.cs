using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private GameObject m_bulletGO;
    [SerializeField]
    private float m_cadency = 0.3f;

    private float m_currentTime;
    private bool m_canShoot = true;
    private Transform m_transform;

    public GameObject BulletGO 
    {
        get {return m_bulletGO;}
        set {m_bulletGO = value;}
    }
    public float Cadency
    {
        get { return m_cadency; }
        set {m_cadency = value;}
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
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
    }

    public void ShootWeapon()
    {
        if (!m_canShoot)
            return;

        GlobalVariables.instance.Salary--;

        Instantiate(BulletGO, m_transform.position, Quaternion.identity);
        m_canShoot = false;
    }
}
