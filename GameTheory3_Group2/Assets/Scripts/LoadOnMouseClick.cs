using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnMouseClick : MonoBehaviour
{
    public int sceneIndex;

    private void Update()
    {
        LoadSceneOnClick();
    }

    public void LoadSceneOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
