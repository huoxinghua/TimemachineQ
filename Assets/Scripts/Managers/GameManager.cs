using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject pauseOverMenu;
    [SerializeField] GameObject winMenu;

    void Start()
    {
        Debug.Log("GameManager start");
       // pauseOverMenu.SetActive(true);

    }

    void Update()
    {
        
    }
    public void PlayerDied()
    {
        //show Cursor
        Debug.Log("you died");
        pauseOverMenu.SetActive(true);
        //winMenu.SetActive(true);
        //Time.timeScale = 0;
        // ShowRestartMenu();

        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }
    public void ResetGame()
    {
        Debug.Log("restart");
        Time.timeScale = 1;
        //LoadScene();
        SceneManager.LoadScene(0);

        
    }
    void QuitGame()
    {
       Application.Quit();
    }
    public void ShowRestartMenu()
    {
        Debug.Log("show pause menu");
        gameObject.SetActive(true);

    }
}
