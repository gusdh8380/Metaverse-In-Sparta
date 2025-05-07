using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager1 : MonoBehaviour, IMiniGameManager
{
    public static MiniGameManager1 instance;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    private EnemyManager enemyManager;
    private UIManager_Dungeon uiManager;
   
    private int BsetScore;
    public bool gameStarted = MasterGameManager.Instance.gameStart;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<UIManager_Dungeon>();

        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }

    private void Start()
    {
        uiManager.SetStartGame();
        Time.timeScale = 0f;
    }
    private void Update()
    {
        AddScore(currentWaveIndex);
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;
        uiManager.SetPlayGame();
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        uiManager.ChangeWave(currentWaveIndex);
        enemyManager.StartWave(1 + currentWaveIndex / 5);
    }

    public void EndOfWave()
    {
        StartNextWave();
       
    }

    public void GameOver()
    {
        gameStarted =false;
        enemyManager.StopWave();
        uiManager.SetGameOver();
    }

    public void AddScore(int score)
    {
        if (score > BsetScore)
        {
            BsetScore = score;
            //마스터게임 매니저에게 점수 데이터 전달
            MasterGameManager.Instance.ReceiveMiniGameScore("Dungeon", BsetScore);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        MasterGameManager.Instance.Resume();
        SceneManager.UnloadSceneAsync("Dungeon Scene");
        
    }

    public void RestartGame()
    {
        MasterGameManager.Instance.MasterRestartGame("Dungeon Scene");
    }

  
}
