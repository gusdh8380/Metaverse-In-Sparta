using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D rb;
    private Vector2 vector2;

    private SpriteRenderer rbSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        vector2.x = Input.GetAxisRaw("Horizontal");
        vector2.y = Input.GetAxisRaw("Vertical");
        vector2.Normalize();

        //방향 전환 처리
        if(vector2.x > 0)
            rbSprite.flipX = false;
        else if(vector2.x < 0)
            rbSprite.flipX = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition((Vector2)rb.position + vector2 * Speed * Time.fixedDeltaTime);
    }
}
