using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int nextSceneIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene(1);
        }

       /* if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadNextScene(2);
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void LoadNextScene(int index)
    {
        /*if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }*/
        SceneManager.LoadScene(index);
    }
}
