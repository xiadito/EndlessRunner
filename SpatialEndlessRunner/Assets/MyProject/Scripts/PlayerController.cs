using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float currentMoveSpeed;

    [SerializeField] float jumpForce;

    [SerializeField] Transform OnGroundCheck;
    [SerializeField] float jumpRadius;
    [SerializeField] LayerMask onGround;

    public bool isDead;
    bool canJump;
    bool canForceDown;

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.Instance.runGame) return;

        if (isDead) return;

        if (OnGround(OnGroundCheck.position, jumpRadius, onGround))
        {
            animator.SetBool("OnGround", true);
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("OnGround", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && !OnGround(OnGroundCheck.position, jumpRadius, onGround))
        {
            canForceDown = true;
        }

        //check if can jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && OnGround(OnGroundCheck.position, jumpRadius, onGround))
        {
            canJump = true;
        }
    }   
    private void FixedUpdate()
    {   
        if (!GameManager.Instance.runGame) return;

        if (isDead) return;

        Move();

        if (canJump) Jump();

        if (canForceDown) ForceDown();
    }

    /*
    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.CompareTag("Cacti"))
        {
            isDead = true;
            animator.SetBool("Death", true);
        }
    }
    */
    
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

            animator.SetBool("OnGround", false);
            animator.SetBool("Jump", true);

    }

    void ForceDown()
    {
        canForceDown = false;

        Vector2 _vel = rb.velocity;
        _vel.y = 0f;
        rb.velocity = _vel;

        rb.AddForce(Vector2.down * jumpForce);

    }

    public void Death()
    {
        animator.SetBool("Death", true);
       
        Invoke("ToggleScreenDead", 1f);
    }

    void ToggleScreenDead()
    {
        GameManager.Instance.ToggleScreen(GameManager.Screen.Dead);
    }

    bool OnGround(Vector2 point, float radius, LayerMask layerMask)
    {

        return Physics2D.OverlapCircle(point, radius, layerMask);
    }

}
