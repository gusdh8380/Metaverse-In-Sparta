using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    public GameObject panel;
    public Button buttonPrefab;
    public Transform buttonContainer;
    public Button exitButton;

    public List<CharacterData> characters;    

    public SpriteRenderer playerSprite;   
    public Animator playerAnimator; 

    void Awake()
    {
        panel.SetActive(false);
        exitButton.onClick.AddListener(Close);
    }

    void Start()
    {
        PopulateButtons();
    }

    void PopulateButtons()
    {
        foreach (Transform t in buttonContainer) Destroy(t.gameObject);

        for (int i = 0; i < characters.Count; i++)
        {
            int idx = i;
            var data = characters[i];
            Button btn = Instantiate(buttonPrefab, buttonContainer);
            btn.image.sprite = data.thumbnail;
            btn.onClick.AddListener(() => OnCharacterSelected(data));
        }
    }

    void OnCharacterSelected(CharacterData data)
    { 
        playerSprite.sprite = data.defaultSprite;
  
        playerAnimator.runtimeAnimatorController = data.animatorController;
        Close();
    }

    public void Open() => panel.SetActive(true);
    public void Close() => panel.SetActive(false);
}