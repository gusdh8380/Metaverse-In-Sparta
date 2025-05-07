using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Cutomization : MonoBehaviour, IInteraction
{
    public CharacterSelectionUI selectionUI;

    public void Interact()
    {
        selectionUI.Open();
    }
}
