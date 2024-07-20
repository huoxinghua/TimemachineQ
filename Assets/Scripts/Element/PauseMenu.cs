using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOverMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;  
    }

    public void QuitGame()
    {
        Application.Quit();
       
    }
   
}
