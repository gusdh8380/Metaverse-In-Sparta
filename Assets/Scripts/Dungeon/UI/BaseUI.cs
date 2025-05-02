using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager_Dungeon uiManager;

    public virtual void Init(UIManager_Dungeon uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}