using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public CircleCollider2D foot;
    public LayerMask ground;
    public float velocity = 10.0f;
    public float jumpForce = 10.0f;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        jump();
	}

    private void jump()
    {
        if (Input.GetButtonDown("Jump") && foot.IsTouchingLayers(ground)) {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
        animator.SetBool("isGround", foot.IsTouchingLayers(ground));
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * velocity, rigidbody2D.velocity.y);
        animator.SetFloat("xSpeed", Mathf.Abs(rigidbody2D.velocity.x));

        if (rigidbody2D.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rigidbody2D.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }else {
            //nothing
        }
    }
}
