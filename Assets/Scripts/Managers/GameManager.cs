using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
     private GameObject gameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerDied()
    {
        //show Cursor
        Debug.Log("Player Died show pause menu");
        //Time.timeScale = 0;
        gameOverMenu.SetActive(true);
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
}
