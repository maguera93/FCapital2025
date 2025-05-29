using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalVariables", menuName = "Scriptable Objects/GlobalVariables")]
public class GlobalVariables : ScriptableObject
{
    [SerializeField]
    private int m_salary;
    [SerializeField]
    private int m_lifes;
    [SerializeField]
    private int m_points;

    private int m_initSalary;

    public delegate void PlayerShoot();
    public PlayerShoot OnPlayerShoot;

    public delegate void PlayerHit();
    public PlayerHit OnPlayerHit;

    public delegate void LifeUp();
    public LifeUp OnLifeUp;

    public delegate void EnemyDeffeated();
    public EnemyDeffeated OnEnemyDeffeated;

    public delegate void EnemyHit();
    public EnemyHit OnEnemyHit;

    public delegate void Win();
    public Win OnWin;

    public int Salary { get => m_salary; set => m_salary = value; }
    public int Lifes { get => m_lifes; set => m_lifes = value; }
    public int Points { get => m_points; set => m_points = value; }
    public int InitSalary { get => m_initSalary; set => m_initSalary = value; }

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

    public void PlayerHitTriggered()
    {
        if (OnPlayerHit != null)
            OnPlayerHit.Invoke();
    }

    public void PlayerShootTriggered()
    {
        if (OnPlayerShoot != null)
            OnPlayerShoot.Invoke();
    }

    public void LifeUpTriggered()
    {
        if (OnLifeUp != null)
            OnLifeUp.Invoke();
    }

    public void WinTriggered()
    {
        if (OnWin != null)
            OnWin.Invoke();
    }
}