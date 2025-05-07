using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    

    public override void Init(UIManager_Dungeon uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        MiniGameManager1.instance.RestartGame(); 
    }

    public void OnClickExitButton()
    {
        MiniGameManager1.instance.Exit();
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}