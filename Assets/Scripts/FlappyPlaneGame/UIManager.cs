using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button restart;
    public Button exitbtn;

    // Start is called before the first frame update
    void Start()
    {
        if (restart == null)
            Debug.LogError("restart text id null");

        if (scoreText == null)
            Debug.LogError("score text is  null");
        if (exitbtn == null)
            Debug.LogError("exit btn is null");

        restart.gameObject.SetActive(false);
        exitbtn.gameObject.SetActive(false);
    }

    public void setRestart()
    {
        restart.gameObject.SetActive(true);
    }
    public  void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void setExit()
    {
        exitbtn.gameObject.SetActive(true); 
    }
}
