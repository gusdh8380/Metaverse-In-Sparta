using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MasterGameManager : MonoBehaviour
{
    public static MasterGameManager Instance;
    public Dictionary<string, int> miniGameScores = new Dictionary<string, int>();
    private GameObject[] pauseRoots;

 
    public string[] MiniGameSceneName ;

    public bool gameStart = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        MiniGameSceneName[0] =  "Flappy Plane Scene";
        MiniGameSceneName[1] =  "Dungeon Scene";

        Debug.Log(MiniGameSceneName[0]);
        Debug.Log(MiniGameSceneName[1]);
    }
    public void Pause()
    {
        pauseRoots = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var obj in pauseRoots)
        {
            if (obj.name == "DontDestroyOnLoad")
                continue;
            obj.SetActive(false);
        }
    }


    public void ReceiveMiniGameScore(string gameId, int score)
    {
        miniGameScores[gameId] = score;
        Debug.Log($"[{gameId}] ���� ����: {score}");
        
    }

    public int GetMiniGameScore(string gameId)
    {
        return miniGameScores.TryGetValue(gameId, out int score) ? score : 0;
    }
    public int SetBestScore(string gameId)
    {
        return miniGameScores.TryGetValue(gameId, out var score)
               ? score
               : 0;
    }
    public void Resume()
    {
        foreach (var obj in pauseRoots)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }

    public void LoadMiniGame(string scnenName)
    {
        var op = SceneManager.LoadSceneAsync(scnenName, LoadSceneMode.Additive);
        op.completed += _ =>
        {
            // �� �ε尡 ���� �� Active Scene���� ����
            var mini = SceneManager.GetSceneByName(scnenName);
            if (mini.IsValid())
                SceneManager.SetActiveScene(mini);
        };
    }

    public void MasterRestartGame(string sceneName)
    {
        MasterGameManager.Instance.StartCoroutine(ReloadMiniGame(sceneName));
    }

    private IEnumerator ReloadMiniGame(string s)
    {
        // 1) ��ε�
        var unload = SceneManager.UnloadSceneAsync(s);
        yield return unload;

        // 2) ��ε�
        var load = SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
        yield return load;

        // 3) Ȱ�� �� ��ȯ
        var miniScene = SceneManager.GetSceneByName(s);
        SceneManager.SetActiveScene(miniScene);
    } 
}
