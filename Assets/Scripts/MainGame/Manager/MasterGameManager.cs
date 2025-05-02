using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterGameManager : MonoBehaviour
{
    public static MasterGameManager Instance;

    public Dictionary<string, int> miniGameScores = new Dictionary<string, int>();

    private UIManager_Main ui;

    private GameObject[] all;

  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void Pause()
    {
        all = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var obj in all)
        {
            if (obj.name == "Main Camera" || obj.name == "DontDestroyOnLoad")
                continue;
            obj.SetActive(false);
        }
    }


    public void ReceiveMiniGameScore(string gameId, int score)
    {
        miniGameScores[gameId] = score;
        Debug.Log($"[{gameId}] 점수 수신: {score}");
        Debug.Log(MasterGameManager.Instance.miniGameScores["FlappyPlane"]);
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
        foreach (var obj in all)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }

    public void LoadMiniGame()
    {
        SceneManager.LoadSceneAsync("Flappy Plane Scene", LoadSceneMode.Additive);
    }

    public void MasterRestartGame()
    {
        MasterGameManager.Instance.StartCoroutine(ReloadMiniGame());
    }

    private IEnumerator ReloadMiniGame()
    {
        // 1) 언로드
        var unload = SceneManager.UnloadSceneAsync("Flappy Plane Scene");
        yield return unload;

        // 2) 재로드
        var load = SceneManager.LoadSceneAsync("Flappy Plane Scene", LoadSceneMode.Additive);
        yield return load;

        // 3) 활성 씬 전환
        var miniScene = SceneManager.GetSceneByName("Flappy Plane Scene");
        SceneManager.SetActiveScene(miniScene);
    }

   
}
