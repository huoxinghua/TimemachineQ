using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderHelper : MonoBehaviour
{
    [SerializeField] private string sceneToLoadOnAwake;

    public void LoadScene(string sceneName)
    {
      //  SceneLoader.Instance.LoadScene(sceneName);
    }

    private void Start()
    {
        if (sceneToLoadOnAwake != null) { LoadScene(sceneToLoadOnAwake); }
    }
}
