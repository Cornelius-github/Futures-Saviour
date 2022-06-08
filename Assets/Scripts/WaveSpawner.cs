using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public int waveCount = 0;

    //one enemy plan
    public Transform enemyPrefab;

    //spawning location
    public Transform spawnpoint;

    //time between waves
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    //references for UI purposes
    public Text wavetext;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        //floor cleans up the decimal places, not that useful for ints but useful for floats, etc.
        wavetext.text = Mathf.Floor(waveCount).ToString();

        enemyPrefab.GetComponent<Enemy>().health += 1;
        enemyPrefab.GetComponent<Enemy>().speed += 2;
    }

    //spawning each wave
    IEnumerator SpawnWave()
    {
        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //waits for .5 seconds then continues going through
        }
    }

    //spawning enemies
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}
