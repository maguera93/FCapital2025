using UnityEngine;

public class SalaryMenu : MonoBehaviour
{
    [SerializeField]
    private SalaryEntry[] entries;
    private int currentEntrie;

    [SerializeField]
    private SceneLoader loader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateEntries();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            MoveLeft();
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            MoveRight();

        if (Input.GetKeyDown(KeyCode.Space) ||  Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
            loader.LoadScene(1);
        }
    }

    private void UpdateEntries()
    {
        for (int i = 0; i < entries.Length; i++)
        {
            entries[i].Selected = false;
        }

        entries[currentEntrie].Selected = true;
    }

    private void MoveLeft()
    {
        currentEntrie++;

        if (currentEntrie >= entries.Length)
            currentEntrie = 0;

        UpdateEntries();
    }

    private void MoveRight()
    {
        currentEntrie--;

        if (currentEntrie < 0)
            currentEntrie = entries.Length - 1;

        UpdateEntries();
    }

    private void StartGame()
    {
        int salary = 0;

        for (int i = 0;i < entries.Length;i++)
        {
            salary += entries[i].Value * (int)Mathf.Pow(10f, i);
        }

        GlobalVariables.instance.InitSalary = salary;
    }
}
