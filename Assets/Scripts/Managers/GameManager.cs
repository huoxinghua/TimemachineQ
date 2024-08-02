using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionMenu;
    
    public  GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //GameManager have inti
            DontDestroyOnLoad(gameObject);//make the instance singleton
        }
        else
        {
            Debug.LogWarning("find another");
            Destroy(gameObject);
        }
    }


    //this will been called in the puzzles scene
    public void SetUIElements(GameObject gameOver, GameObject win, GameObject pause,GameObject option)
    {
        gameOverMenu = gameOver;
        gameOverMenu.SetActive(false);
        winMenu = win;
        winMenu.SetActive(false);
        pauseMenu = pause;
        pauseMenu.SetActive(false);
        optionMenu = option;
        optionMenu.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
        }
    }

    public int Winners = 0;
    public void ShowWinMenu()
    {
        Winners++;

        if(Winners != 2) { return;  }
        if (winMenu != null)
        {
            winMenu.SetActive(true);
        }
    }

    public void ShowPauseMenu()
    {
       
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void HidePauseMenu()
    {
        if (pauseMenu != null)
        { pauseMenu.SetActive(true); }
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowOptionMenu()
    {
       
        if (winMenu != null)
        {
            optionMenu.SetActive(true);
        }
    }
    public void LoadScene()
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Puzzles1");
    }


    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
    
    public void PlayerDied()
    {
        //show Cursor
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }


    //when the game restart need initial the state
    public void ResetGame()
    {
        if (optionMenu != null)
        { optionMenu.SetActive(false); }
        if (gameOverMenu != null)
        { gameOverMenu.SetActive(false); }
        if (pauseMenu != null)
        { pauseMenu.SetActive(false); }
        Time.timeScale = 1;
    }

    //pause menu resume button
  


 

  
}
