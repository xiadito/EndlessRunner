using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float currentMoveSpeed;

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
        //check if can jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround(OnGroundCheck.position, jumpRadius, onGround))
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
        /* Makes the player go foward. */

        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, maxMoveSpeed, acceleration * Time.fixedDeltaTime);

        Vector2 _velocity = rb.velocity;
        _velocity.x = currentMoveSpeed;
        rb.velocity = _velocity;

        print(rb.velocity);
    }   

    void Jump()
    {
        /* Make the player jump. */

            canJump = false;

            Vector2 _velocity = rb.velocity;
            _velocity.y = 0f;
            rb.velocity = _velocity;

            rb.AddForce(Vector2.up * jumpForce);
    }

    bool OnGround(Vector2 point, float radius, LayerMask layerMask)
    {

        return Physics2D.OverlapCircle(point, radius, layerMask);
    }

}
