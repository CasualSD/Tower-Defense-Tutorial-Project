using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform WaveSpawnPoint;

    public float TimeNextWave = 5f;
    public float WaveStartCountDown = 2f;
    private int WaveIndex = 0;

    public Text WaveCountDownTimer;

    void Update()
    {
        if (WaveStartCountDown <= 0)
        {
            StartCoroutine(SpawnWave());
            WaveStartCountDown = TimeNextWave;
        }

        WaveStartCountDown -= Time.deltaTime;

        WaveCountDownTimer.text = Mathf.Round(WaveStartCountDown).ToString();
    }
    IEnumerator SpawnWave()
    {
        WaveIndex++;

        for (int i = 0; i < WaveIndex; i++)//peew
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }

    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, WaveSpawnPoint.position, WaveSpawnPoint.rotation);
    }
}
