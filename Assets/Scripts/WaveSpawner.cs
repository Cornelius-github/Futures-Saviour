using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public int waveCount = 0;

    //enemies
    public Transform enemyPrefab;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;

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

    //for stopping waves after lost
    LiveManager lm;

    public static WaveSpawner instance;


    private void Start()
    {
        lm = LiveManager.instance;
        instance = this;
    }
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
        if (lm.gameEnded == false) //spawns waves if the game has ended
        {
            //this was in update, which meant it was called every fucking frame, resulting in high speed that broke the game. i love code
            if (waveCount > 1)
            {
                bossSpawn = false;
                if (enemyPrefab.GetComponent<Enemy>().speed <= 500)
                {
                    enemyPrefab.GetComponent<Enemy>().health = (1);
                    enemyPrefab.GetComponent<Enemy>().speed = (5 + waveCount);
                }
            }

            waveCount++;
            lm.waveCounter = waveCount;
            for (int i = 0; i < waveCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.8f); //waits for .8 seconds then continues going through
            }
        }
        
    }

    //spawning enemies
    void SpawnEnemy()
    {
        randomChance = Random.Range(1, 25);

        if (randomChance < 15 || bossSpawn == true)
        {
            Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
        }

        //first boss
        if ((randomChance >= 16 && randomChance <=19) && bossSpawn == false)
        {
            if (boss1.GetComponent<Enemy>().speed <= 500)
            {
                boss1.GetComponent<Enemy>().health = (3 + waveCount);
                boss1.GetComponent<Enemy>().speed = (3 * waveCount);
            }

            if (waveCount <= 10)
            {
                boss1.GetComponent<Enemy>().health = (3);
            }

            boss = (GameObject) Instantiate(boss1, spawnpoint.position, spawnpoint.rotation);
            bossSpawn = true;
        }

        //second boss
        if ((randomChance >= 20 && randomChance <= 22) && bossSpawn == false)
        {
            if (boss2.GetComponent<Enemy>().speed <= 500)
            {
                boss2.GetComponent<Enemy>().health = (2 + waveCount);
                boss2.GetComponent<Enemy>().speed = (5 * waveCount);
            }

            if (waveCount <= 10)
            {
                boss2.GetComponent<Enemy>().health = (2);
            }

            boss = (GameObject)Instantiate(boss2, spawnpoint.position, spawnpoint.rotation);
            bossSpawn = true;
        }

        //second boss
        if ((randomChance > 22) && bossSpawn == false)
        {
            if (boss3.GetComponent<Enemy>().speed <= 500)
            {
                boss3.GetComponent<Enemy>().health = (5 + waveCount);
                boss3.GetComponent<Enemy>().speed = (1 * waveCount);
            }

            if (waveCount <= 10)
            {
                boss3.GetComponent<Enemy>().health = (5);
            }

            boss = (GameObject)Instantiate(boss3, spawnpoint.position, spawnpoint.rotation);
            bossSpawn = true;
        }

    }
}
