using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoader loader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GlobalVariables.instance.Salary = GlobalVariables.instance.InitSalary;
        GlobalVariables.instance.Lifes = 3;
        GlobalVariables.instance.Points = 0;

        GlobalVariables.instance.OnPlayerHit += PlayerHit;
        GlobalVariables.instance.OnLifeUp += LifeUp;
        GlobalVariables.instance.OnWin += Win;
    }

    private void OnDestroy()
    {
        GlobalVariables.instance.OnPlayerHit -= PlayerHit;
        GlobalVariables.instance.OnLifeUp -= LifeUp;
        GlobalVariables.instance.OnWin -= Win;
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
