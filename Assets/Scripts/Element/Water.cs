using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public enum WaterType { RedWater, BlueWater }
    [SerializeField] private WaterType[] waterType;
    private PlayerController playerController;
    private Rigidbody2D rb;
    public float jumpForce = 10f;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController != null )
        {
            rb = playerController.GetComponent<Rigidbody2D>();
        }
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("RedPlayer"))
        {
            foreach (WaterType waterType in waterType)
            {
                if(waterType == WaterType.BlueWater)
                {
                    Debug.Log(" red water die player ");
                }
            }

               

        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("BluePlayer"))
        {


            foreach (WaterType waterType in waterType)
            {
                if (waterType == WaterType.RedWater)
                {
                    Debug.Log(" blue water die player ");
                }
            }

        }

    }

    private void Die(PlayerController playerController)
    {
        Debug.Log("Player Died in " + waterType);
        // reload scene or play die animation
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
