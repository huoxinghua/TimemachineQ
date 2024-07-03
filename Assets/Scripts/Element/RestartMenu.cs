using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ShowRestartMenu()
    {
        Debug.Log("show pause menu");
        this.gameObject.SetActive(true);
       
    }
}
