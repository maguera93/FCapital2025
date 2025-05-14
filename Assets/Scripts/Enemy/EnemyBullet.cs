using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private int m_speed = 50;
    [SerializeField]
    private int m_damage = 7;

    private float m_yRotation = 0;
    private Transform m_transform;
    private GameObject targetPlayer;
    private Rigidbody2D rb;
    public float force;

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
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player");

        Vector3 directionToPlayer = targetPlayer.transform.position - m_transform.position;
        rb.linearVelocity = new Vector2(directionToPlayer.x, directionToPlayer.y).normalized * m_speed;

        //Para cambiar la rotación de la bala
        //float rot = Mathf.Atan2(-directionToPlayer.y, -directionToPlayer.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
