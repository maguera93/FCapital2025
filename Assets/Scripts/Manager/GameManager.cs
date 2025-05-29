using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoader loader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (GlobalVariables.instance.InitSalary == 0)
            GlobalVariables.instance.InitSalary = 1100;

        GlobalVariables.instance.Salary = GlobalVariables.instance.InitSalary;
        GlobalVariables.instance.Lifes = 3;
        GlobalVariables.instance.Points = 0;

        GlobalVariables.instance.OnPlayerHit += PlayerHit;
        GlobalVariables.instance.OnLifeUp += LifeUp;
        GlobalVariables.instance.OnWin += Win;
        GlobalVariables.instance.OnPlayerShoot += OnPlayerShoot;
    }

    private void OnDestroy()
    {
        GlobalVariables.instance.OnPlayerHit -= PlayerHit;
        GlobalVariables.instance.OnLifeUp -= LifeUp;
        GlobalVariables.instance.OnWin -= Win;
        GlobalVariables.instance.OnPlayerShoot -= OnPlayerShoot;
    }

    private void PlayerHit()
    {
        GlobalVariables.instance.Lifes--;

        if (GlobalVariables.instance.Lifes == 0 )
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
        GlobalVariables.instance.Salary--;

        if (GlobalVariables.instance.Salary <= 0)
        {
            GameOver();
        }
    }

    private void LifeUp()
    {
        GlobalVariables.instance.Lifes++;

        if (GlobalVariables.instance .Lifes >= 3)
            GlobalVariables.instance.Lifes = 3;
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
