using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitgame();
        }
    }
    public void startgame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
