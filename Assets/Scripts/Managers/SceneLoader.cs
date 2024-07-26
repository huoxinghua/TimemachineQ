using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public static SceneLoader Instance { get; private set; }
    private string _currentScene = "";

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
        SceneManager.LoadScene("Puzzles");
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
