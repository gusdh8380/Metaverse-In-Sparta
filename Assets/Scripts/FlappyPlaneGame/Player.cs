using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;


    public float flapForce = 6f;
    public float forwardSpeed =3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    MiniGameManager gamemanager;

   

    void Start()
    {
        gamemanager = MiniGameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not founded Animator");
        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");

    }


    void Update()
    {
        if (!MiniGameManager.Instance.gameStarted)
            return; // 게임 시작 전 입력 무시
        if (isDead)
        {
            if(deathCooldown <= 0f)
            {
                ////게임 재시작
                //if (Input.GetKeyDown(KeyCode.Space)) 
                //{ 
                //    gamemanager.RestartGame();
                //}
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!MiniGameManager.Instance.gameStarted)
            return; // 게임 시작 전 입력 무시

        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;

        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(godMode) {return; }

        if(isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gamemanager.GameOver();
    }
}
