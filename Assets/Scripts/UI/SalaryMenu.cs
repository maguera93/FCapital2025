using UnityEngine;

public class SalaryMenu : MonoBehaviour
{
    [SerializeField]
    private SalaryEntry[] entries;
    private int currentEntrie;

    [SerializeField]
    private SceneLoader loader;
    [SerializeField]
    private AudioManager m_audioManager;
    private bool start = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateEntries();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                MoveLeft();
            else if (Input.GetKeyUp(KeyCode.RightArrow))
                MoveRight();

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                Invoke("StartGame", 1f);

                //StartGame();
                for (int i = 0; i < entries.Length; i++)
                {
                    entries[i].enabled = false;
                }

                start = true;
                m_audioManager.PlayAudio(1, 1f, 1f);
            }
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

        m_audioManager.PlayAudio(0, 1f, Random.Range(0.8f, 1.1f));

        UpdateEntries();
    }

    private void MoveRight()
    {
        currentEntrie--;

        if (currentEntrie < 0)
            currentEntrie = entries.Length - 1;

        m_audioManager.PlayAudio(0, 1f, Random.Range(0.8f, 1.1f));

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

        loader.LoadScene(1);
    }
}
