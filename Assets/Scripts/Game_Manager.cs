using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public bool playerisdead = false;
    // Start is called before the first frame update
    void Start()
    {
        playerisdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerisdead == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
