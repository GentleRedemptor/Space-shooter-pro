using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text score_txt;
    [SerializeField]
    private Image livesUI;
    [SerializeField]
    private Sprite[] livessprites;
    [SerializeField]
    private Text GameoverUI;
    [SerializeField]
    private Text RestartTXTUI;
    private Game_Manager game_manager;

    // Start is called before the first frame update
    void Start()
    {
        GameoverUI.gameObject.SetActive(false);
        RestartTXTUI.gameObject.SetActive(false);
        score_txt.text = "Score:" +  0;
        game_manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        if (game_manager == null)
        {
            Debug.LogError("Game_Manager is NULL");
        }
    }

    public void UpdateScore (int playerscore)
    {
        score_txt.text = "Score:" + playerscore;
    }

    public void UpdateLives(int currentlives)
    {
        livesUI.sprite = livessprites[currentlives];
        if (currentlives < 1)
        {
            GameoverUI.gameObject.SetActive(true);
            RestartTXTUI.gameObject.SetActive(true);
            game_manager.playerisdead = true;
            StartCoroutine(gameoverflicker());
        }
    } 
    IEnumerator gameoverflicker()
    {
        while (true)
        {
            GameoverUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            GameoverUI.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
