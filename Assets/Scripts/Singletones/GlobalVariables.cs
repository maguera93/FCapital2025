using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalVariables", menuName = "Scriptable Objects/GlobalVariables")]
public class GlobalVariables : ScriptableSingleton<GlobalVariables>
{
    [SerializeField]
    private int m_salary = 1100;
    [SerializeField]
    private int m_lifes = 6;
    [SerializeField]
    private int m_points = 0;

    public delegate void EnemyDeffeated();
    public EnemyDeffeated OnEnemyDeffeated;

    public delegate void EnemyHit();
    public EnemyHit OnEnemyHit;

    public int Salary { get => m_salary; set => m_salary = value; }
    public int Lifes { get => m_lifes; set => m_lifes = value; }
    public int Points { get => m_points; set => m_points = value; }

    public void EnemyDeffeatedTriggered()
    {
        if (OnEnemyDeffeated != null)
            OnEnemyDeffeated.Invoke();
    }

    public void EnemyHitTriggered()
    {
        if (OnEnemyHit != null)
            OnEnemyHit.Invoke();
    }
}
