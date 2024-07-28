using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Rigidbody2D rb;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
    }
    public void LoadScene()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Puzzles");
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

    public void ResetGame()
    {
        Debug.Log("restart");
        Time.timeScale = 1;
        //LoadScene();
        SceneManager.LoadScene(0);
    }


    public void ShowRestartMenu()
    {
        gameObject.SetActive(true);

    }

    public void ShowPauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }
    public void ShowWinMenu()
    {
        winMenu.SetActive(true);
    }
}
