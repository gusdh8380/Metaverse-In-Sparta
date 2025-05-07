using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager_Dungeon uiManager)
    {
        base.Init(uiManager);
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        MiniGameManager1.instance.StartGame();
    }

    public void OnClickExitButton()
    {
        MiniGameManager1.instance.Exit();
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}