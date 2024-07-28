using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject pauseMenu;
   

    public  GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("GameManager have inti");
            DontDestroyOnLoad(gameObject);//make the instance singleton
        }
        else
        {
            Debug.LogWarning("find another");
            Destroy(gameObject);
        }
    }


    
    void Start()
    {
      
    }

    //this will been called in the puzzles scene
    public void SetUIElements(GameObject gameOver, GameObject win, GameObject pause)
    {
        gameOverMenu = gameOver;
        gameOverMenu.SetActive(false);
        winMenu = win;
        winMenu.SetActive(false);
        pauseMenu = pause;
        pauseMenu.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void ShowWinMenu()
    {
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
        Debug.Log("restart");
     

    }
    
    //pause menu resume button
    public void ResumeGame()
    {
        Debug.Log("back to play");
        Time.timeScale = 1;
        MenuInitializer.instance.HidePauseMenu();
    }


    public void ShowRestartMenu()
    {
        gameObject.SetActive(true);

    }

  
}
