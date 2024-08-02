using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject RequiredPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //You are in finish line
        if ( collision.GetComponent<PlayerController>() && collision.gameObject == RequiredPlayer)
        {
            var cat = RequiredPlayer.GetComponent<PlayerController>();
            cat.enabled = false;
            GameManager.Instance.ShowWinMenu();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //You are in finish line
        if (collision.GetComponent<PlayerController>() && collision.gameObject == RequiredPlayer)
        {
            GameManager.Instance.Winners--;
        }
    }

}
