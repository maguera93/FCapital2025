using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoader loader;
    [Space, SerializeField]
    protected GlobalVariables m_globalVariables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (m_globalVariables.InitSalary == 0)
            m_globalVariables.InitSalary = 1100;

        m_globalVariables.Salary = m_globalVariables.InitSalary;
        m_globalVariables.Lifes = 3;
        m_globalVariables.Points = 0;

        m_globalVariables.OnPlayerHit += PlayerHit;
        m_globalVariables.OnLifeUp += LifeUp;
        m_globalVariables.OnWin += Win;
        m_globalVariables.OnPlayerShoot += OnPlayerShoot;
    }

    private void OnDestroy()
    {
        m_globalVariables.OnPlayerHit -= PlayerHit;
        m_globalVariables.OnLifeUp -= LifeUp;
        m_globalVariables.OnWin -= Win;
        m_globalVariables.OnPlayerShoot -= OnPlayerShoot;
    }

    private void PlayerHit()
    {
        m_globalVariables.Lifes--;

        if (m_globalVariables.Lifes == 0 )
        {
            // Game Over
            PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
            playerMove.enabled = false;

            Invoke("LoadGameOverScene", 2f);
        }
    }

    private void GameOver()
    {
        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        playerMove.enabled = false;

        Invoke("LoadGameOverScene", 2f);
    }

    private void OnPlayerShoot()
    {
        m_globalVariables.Salary--;

        if (m_globalVariables.Salary <= 0)
        {
            GameOver();
        }
    }

    private void LifeUp()
    {
        m_globalVariables.Lifes++;

        if (m_globalVariables .Lifes >= 3)
            m_globalVariables.Lifes = 3;
    }

    private void LoadGameOverScene()
    {
        loader.LoadScene(3);
    }

    private void Win()
    {
        Invoke("LoadWinScene", 2f);
    }

    private void LoadWinScene()
    {
        loader.LoadScene(2);
    }
}
