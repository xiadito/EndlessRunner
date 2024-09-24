using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform OnGroundCheck;
    [SerializeField] float jumpRadius;
    [SerializeField] LayerMask onGround;

    bool canJump;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        print(OnGround());

        if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround())
        {
            canJump = true;
        }
    }   
    private void FixedUpdate()
    {
        Move();
        if (canJump) Jump();
    }

    void Move()
    {
        Vector2 _velocity = rb.velocity;
        _velocity.x = moveSpeed;
        rb.velocity = _velocity;

    }

    void Jump()
    {
            canJump = false;

            Vector2 _velocity = rb.velocity;
            _velocity.y = 0f;
            rb.velocity = _velocity;

            rb.AddForce(Vector2.up * jumpForce);
    }

    bool OnGround()
    {
        return Physics2D.OverlapCircle(OnGroundCheck.position, jumpRadius, onGround);
    }

}
