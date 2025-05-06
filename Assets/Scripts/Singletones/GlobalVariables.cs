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

    public int Salary { get => m_salary; set => m_salary = value; }
    public int Lifes { get => m_lifes; set => m_lifes = value; }
    public int Points { get => m_points; set => m_points = value; }
}
