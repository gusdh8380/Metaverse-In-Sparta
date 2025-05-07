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

    MiniGameManager1 m;

    public override void Init(UIManager_Dungeon uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        m.RestartGame(); 
    }

    public void OnClickExitButton()
    {
        m.Exit();
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}