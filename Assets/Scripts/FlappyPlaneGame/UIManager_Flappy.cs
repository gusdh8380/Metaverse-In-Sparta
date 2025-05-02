using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Flappy : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button restart;
    public Button exitbtn;

    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestscore;

    public GameObject startUI;

    // Start is called before the first frame update
    void Start()
    {
        if (restart == null)
            Debug.LogError("restart text is null");

        if (scoreText == null)
            Debug.LogError("score text is  null");
        if (exitbtn == null)
            Debug.LogError("exit btn is null");

        restart.gameObject.SetActive(false);
        exitbtn.gameObject.SetActive(false);
       
    }
    public void ShowStartUi()
    {
        startUI.gameObject.SetActive(true);
    }

    public void HideStartUi()
    {
        startUI.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
    }
    public void setRestart()
    {
        restart.gameObject.SetActive(true);
    }
    public  void UpdateScore(int score, int best)
    {
        scoreText.text = score.ToString();
        bestscore.text = best.ToString();

    }
    public void setExit()
    {
        exitbtn.gameObject.SetActive(true); 
    }
}
