using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    //level select
    public void Level1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }
}
