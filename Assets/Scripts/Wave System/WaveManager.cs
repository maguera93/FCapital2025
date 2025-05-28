using JetBrains.Annotations;
using System;
using UnityEngine;
using DG.Tweening;
using Enemy;

[Serializable]
public struct WaveEnemy
{
    public GameObject enemyPrefab;
    public Vector2 position;
}

[Serializable]
public struct Wave
{
    public WaveEnemy[] enemies;
    private int deffeatedEnemies;

    public int DeffeatedEnemies { get => deffeatedEnemies; set => deffeatedEnemies = value; }
}

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;

    private int currentWave = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitWave();
        GlobalVariables.instance.OnEnemyDeffeated += OnEnemyDefeated;
    }

    private void OnDestroy()
    {
        GlobalVariables.instance.OnEnemyDeffeated -= OnEnemyDefeated;
    }

    private void InitWave()
    {
        Wave refWav = waves[currentWave];

        for (int i = 0; i < refWav.enemies.Length; i++)
        {
            GameObject enemy = Instantiate(refWav.enemies[i].enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.DOMove(refWav.enemies[i].position, 1f).SetEase(Ease.OutQuad);
        }
    }

    public void OnEnemyDefeated()
    {
        waves[currentWave].DeffeatedEnemies++;

        if (waves[currentWave].DeffeatedEnemies == waves[currentWave].enemies.Length)
        {
            currentWave++;

            if (currentWave == waves.Length)
            {
                // Level Completed
                GlobalVariables.instance.WinTriggered();
            }
            else
            {
                Invoke("InitWave", 1f);
            }
        }
    }
}
