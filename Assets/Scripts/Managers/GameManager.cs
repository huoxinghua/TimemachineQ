using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject pauseOverMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        pauseOverMenu.SetActive(false);
    }
    public void LoadScene()
    {

    }

    public void PlayerDied()
    {
        //show Cursor
        pauseOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        Debug.Log("restart");
        Time.timeScale = 1;
        //LoadScene();
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowRestartMenu()
    {
        gameObject.SetActive(true);

    }

    public void ShowPauseMenu()
    {
        Debug.Log("show pause menu");
        pauseMenu.SetActive(true);

    }
}
