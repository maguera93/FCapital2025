using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GlobalVariables.instance.OnPlayerHit += OnPlayerHit;
    }

    private void OnDestroy()
    {
        ResumeTime();
        GlobalVariables.instance.OnPlayerHit -= OnPlayerHit;
    }

    // Update is called once per frame
    private void OnPlayerHit()
    {
        Time.timeScale = 0.2f;
        Invoke("ResumeTime", 0.2f);
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
