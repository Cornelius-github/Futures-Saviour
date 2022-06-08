using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveManager : MonoBehaviour
{
    public bool gameEnded = false;

    public Text WaveCount;
    public GameObject GameOver;

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
        GameOver.SetActive(true);
        gameEnded = true;
    }
}
