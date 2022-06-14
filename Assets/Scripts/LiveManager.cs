using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveManager : MonoBehaviour
{
    public bool gameEnded = false;

    public int waveCounter;
    public Text WaveCount;
    public GameObject GameOver;

    public static LiveManager instance;
    WaveSpawner ws;

    private void Awake()
    {
        instance = this;
        ws = WaveSpawner.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded == true)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        //WaveCount.text = ws.waveCount.ToString();
        WaveCount.text = waveCounter.ToString();

        GameOver.SetActive(true);
        gameEnded = true;
    }
}
