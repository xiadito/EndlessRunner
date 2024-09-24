using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject OnGroundCheck;
    [SerializeField] float jumpRadius;
    [SerializeField] LayerMask onGround;

    bool canJump;

    Vector2 point;


    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        point = OnGroundCheck.GetComponent<Rigidbody2D>().position;
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Jump") && OnGround)
        {
            
        }
        canJump = true;
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector2 _velocity = rb.velocity;
        _velocity.x = moveSpeed;
        rb.velocity = _velocity;

    }

    void Jump()
    {
        if (canJump)
        {

        }
    }

    bool OnGround()
    {
        return Physics2D.OverlapCircle(point, jumpRadius, onGround);
    }

}
