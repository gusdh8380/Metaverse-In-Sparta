using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    //�÷��̾��� ��ȣ�ۿ� ���� ����
    //fŰ�� ���� ��ȣ�ۿ�

    private Collider2D currentTarget;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteraction interactable))
        {
            currentTarget = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (currentTarget == other)
        {
            currentTarget = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) )
        {      
            if (currentTarget != null)
            {
                animator.SetTrigger("Isinteract");
                Debug.Log("��ȣ�ۿ�");

           
                var interaction = currentTarget.GetComponent<IInteraction>();
                if (interaction != null)
                {
                    interaction.Interact();
                }
                else
                {
                    Debug.LogWarning("��ȣ�ۿ� ��� IInteraction ������Ʈ�� �����ϴ�.");
                }
            }
            else
            {          
                Debug.Log("��ȣ�ۿ� ��� ����");
            }
        }
    }
}
