using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public enum WaterType { RedWater, BlueWater }
    [SerializeField] private WaterType[] waterType;
    private PlayerController playerController;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    private GameManager gameManager;

    #region  UI when die player
    [SerializeField] private GameObject pauseMenu;
    #endregion

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            rb = playerController.GetComponent<Rigidbody2D>();
        }
        rb = GetComponent<Rigidbody2D>();
     
    }

    private WaterType[] GetWaterType()
    {
        return waterType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("BluePlayer"))
        {
             foreach (WaterType var in waterType)
             {
                 if((var == WaterType.RedWater))
                 {
                    GameManager.Instance.PlayerDied();
                    Debug.Log("kill Blue player");
                 }
             }
         }
         else if (collision.gameObject.CompareTag("RedPlayer"))
         {
             foreach (WaterType var in waterType)
             {
                 if (var == WaterType.BlueWater)
                 {
                    GameManager.Instance.PlayerDied();
                }
             }

         }
    }
    } 
