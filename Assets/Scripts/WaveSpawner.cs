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

    //for stopping waves after lost
    LiveManager lm;


    private void Start()
    {
        lm = LiveManager.instance;
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
                enemyPrefab.GetComponent<Enemy>().health = (1 + waveCount);
                enemyPrefab.GetComponent<Enemy>().speed = (5 + waveCount);
            }

            waveCount++;
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
        randomChance = Random.Range(1, 5);

        if (randomChance < 4 || bossSpawn == true)
        {
            Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
        }

        //first boss
        if (randomChance == 4 && bossSpawn == false)
        {
            boss1.GetComponent<Enemy>().health = (3 * waveCount);
            boss1.GetComponent<Enemy>().speed = (9 * waveCount);

            boss = (GameObject) Instantiate(boss1, spawnpoint.position, spawnpoint.rotation);
            bossSpawn = true;
        }
        
    }
}
