using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager_Main : MonoBehaviour
{
    public GameObject panel;

    public TextMeshProUGUI BestScoreList;
    public TextMeshProUGUI FlappyScore;
    public TextMeshProUGUI FlappyText;

    private int flappy_BestScore;

    void Start()
    {
        if (BestScoreList == null)
            Debug.LogError("BestScoreLis is null");

        if (FlappyScore == null)
            Debug.LogError("FlappyScore is  null");
        if (FlappyText == null)
            Debug.LogError("FlappyText is null");

       panel.gameObject.SetActive(true);

        if (!MasterGameManager.Instance.miniGameScores.ContainsKey("FlappyPlane"))
        {
            FlappyScore.text = "-";
        }
    }

    private void Update()
    {
        if (MasterGameManager.Instance.miniGameScores.ContainsKey("FlappyPlane"))
        {
            int flappy_BestScore = MasterGameManager.Instance.miniGameScores["FlappyPlane"];

            FlappyScore.text = flappy_BestScore.ToString();
        }
        
    }
}
