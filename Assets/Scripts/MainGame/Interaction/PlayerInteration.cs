using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteration : MonoBehaviour
{
    //플레이어의 상호작용 로직 구현
    //f키를 통해 상호작용

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
                Debug.Log("상호작용");

           
                var interaction = currentTarget.GetComponent<IInteraction>();
                if (interaction != null)
                {
                    interaction.Interact();
                }
                else
                {
                    Debug.LogWarning("상호작용 대상에 IInteraction 컴포넌트가 없습니다.");
                }
            }
            else
            {          
                Debug.Log("상호작용 대상 없음");
            }
        }
    }
}
