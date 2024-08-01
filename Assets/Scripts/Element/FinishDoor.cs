using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject doorMovePart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //You are in finish line
        if ( collision.GetComponent<PlayerController>())
        {
            
            GameManager.Instance.ShowWinMenu();
            doorMovePart.SetActive(false);
        }
    }
    
}
