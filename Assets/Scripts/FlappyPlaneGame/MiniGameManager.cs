using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour, IMiniGameManager
{
    static MiniGameManager m_gameManager;
    public static MiniGameManager Instance { get { return m_gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }


    public void Awake()
    {
        m_gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.setRestart();
        uiManager.setExit();
    }

    public void RestartGame()
    {
        MasterGameManager.Instance.MasterRestartGame(); 
    }

    




    public void Exit()
    {
        //마스터게임 매니저에게 점수 데이터 전달
        MasterGameManager.Instance.ReceiveMiniGameScore("FlappyPlane", currentScore);
        MasterGameManager.Instance.Resume();
        SceneManager.UnloadSceneAsync("Flappy Plane Scene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score : " + currentScore);
        uiManager.UpdateScore(currentScore);

    }


}
