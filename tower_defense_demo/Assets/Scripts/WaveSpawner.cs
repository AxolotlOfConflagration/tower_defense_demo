using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemyPrefab;
        public int enemyAmount;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float countdownTime = 5f;
    public float countdown;
    public Transform spawnPoint;

    private bool spawning = false;

    public Text waveAnnouncerText;

    private void Start()
    {
        countdown = countdownTime;
    }

    private void Update()
    {
        if (countdown <= 0f && !spawning)
        {
            spawning = true;
            waveAnnouncerText.text = String.Format("Wave {0}", nextWave+1);
            StartCoroutine(SpawnWave(waves[nextWave]));
        }
        if (!spawning)
        {
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave tempWave)
    {
        for (int i = 0; i < tempWave.enemyAmount; i++)
        {
            SpawnEnemy(tempWave.enemyPrefab);
            yield return new WaitForSeconds(1f / tempWave.rate);
        }
        BeginNewRound();
        yield break;
    }

    void SpawnEnemy(Transform tempEnemy)
    {
        Instantiate(tempEnemy, spawnPoint.position, spawnPoint.rotation);
    }

    void BeginNewRound()
    {
        spawning = false;
        countdown = countdownTime;
        if (nextWave+1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }
}
