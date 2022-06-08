using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public int waveCount = 0;

    //one enemy plan
    public Transform enemyPrefab;
    public GameObject boss1;

    //boss chance
    private GameObject boss;
    private int randomChance;
    bool bossSpawn = true;

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
    }

    //spawning each wave
    IEnumerator SpawnWave()
    {
        //this was in update, which meant it was called every fucking frame, resulting in high speed that broke the game. i love code
        if (waveCount > 1)
        {
            bossSpawn = false;
            enemyPrefab.GetComponent<Enemy>().health += 1;
            enemyPrefab.GetComponent<Enemy>().speed += 2;
        }
        
        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f); //waits for .8 seconds then continues going through
        }
    }

    //spawning enemies
    void SpawnEnemy()
    {
        randomChance = Random.Range(1, 5);

        if (randomChance == 4 || bossSpawn == true)
        {
            Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
        }

        //first boss
        if (randomChance < 4 && bossSpawn == false)
        {
            boss = (GameObject) Instantiate(boss1, spawnpoint.position, spawnpoint.rotation);
            bossSpawn = true;
        }
        
    }
}
