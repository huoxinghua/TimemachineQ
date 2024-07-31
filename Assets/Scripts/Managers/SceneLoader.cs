using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    private string _currentScene = "";
    private GameManager _gameManager;

    private void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

         Instance = this;
    }
  

    
    public void PlayGame()

    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
            Time.timeScale = 1;
            SceneManager.LoadScene("Puzzles1");
        }
        else
        {
            Debug.LogError("GameManager instance is not initialized.");
        }
    }
    public void LoadController()

    {
        if (GameManager.Instance != null)
        {
            SceneManager.LoadScene("Controller");
        }
        else
        {
            Debug.LogError("GameManager instance is not initialized.");
        }
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
