using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact_MiniGame2 : MonoBehaviour, IInteraction
{   
    public void Interact()
    {
        MasterGameManager.Instance.Pause();
        MasterGameManager.Instance.LoadMiniGame(MasterGameManager.Instance.MiniGameSceneName[1]);
    }

   
}
