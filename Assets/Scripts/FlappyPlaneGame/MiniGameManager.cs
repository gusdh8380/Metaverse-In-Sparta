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

    private int BsetScore;
    public bool gameStarted = MasterGameManager.Instance.gameStart;
    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    public void Awake()
    {
        m_gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void Start()
    {
        uiManager.ShowStartUi();
        Time.timeScale = 0f;
        int bestScore = MasterGameManager.Instance.SetBestScore("FlappyPlane");
        BsetScore = bestScore;

        uiManager.UpdateScore(0, BsetScore);
    }
    void Update()
    {
        if (!gameStarted)
        {
            // 클릭 또는 스페이스바로 시작
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                BeginGame();
            return;
        }

       
    }
    public void BeginGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;
        uiManager.HideStartUi();
       
    }

    public void GameOver()
    {
        gameStarted = false;
        Debug.Log("Game Over");
        uiManager.setRestart();
        uiManager.setExit();
    }

    public void RestartGame()
    {
        MasterGameManager.Instance.MasterRestartGame("Flappy Plane Scene"); 
    }

    public void Exit()
    {
        MasterGameManager.Instance.Resume();
        SceneManager.UnloadSceneAsync("Flappy Plane Scene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score : " + currentScore);

        if (currentScore > BsetScore)
        {
            BsetScore = currentScore;
            //마스터게임 매니저에게 점수 데이터 전달
            MasterGameManager.Instance.ReceiveMiniGameScore("FlappyPlane", BsetScore);
        }
        uiManager.UpdateScore(currentScore, BsetScore);
    }
}
