using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject doorMovePart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You are in finish line");
        if ( collision.GetComponent<PlayerController>())
        {
            
            GameManager.Instance.ShowWinMenu();
            doorMovePart.SetActive(false);
        }
    }
    
}
