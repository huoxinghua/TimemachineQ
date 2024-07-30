using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInitializer : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject pauseMenu;


    public static MenuInitializer instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ensure the GameManager instance exists
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetUIElements(gameOverMenu, winMenu, pauseMenu);
        }
        else
        {
            Debug.LogError("GameManager instance is not available.");
        }
    }


    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }




}
