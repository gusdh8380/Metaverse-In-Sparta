using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGameManager 
{
    void AddScore(int amount);
    void GameOver();
    void RestartGame();
    void Exit();
}
