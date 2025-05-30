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
    [SerializeField] float maxJumpHeight;
    bool isJumpReleased;
    bool canJump;

    [SerializeField] Transform OnGroundCheck;
    [SerializeField] float footRadius;
    [SerializeField] LayerMask onGround;

    public bool isDead;
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

        if (OnGround(OnGroundCheck.position, footRadius, onGround))
        {
            animator.SetBool("OnGround", true);
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("OnGround", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !OnGround(OnGroundCheck.position, footRadius, onGround))
        {
            canForceDown = true;
        }

        //check if can jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) && OnGround(OnGroundCheck.position, footRadius, onGround))
        {
            canJump = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && canJump) isJumpReleased = true;

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

    #region Methods

    #region Movement

    void Move()
    {
       /** Makes the player go foward. **/
        
        
        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, maxMoveSpeed, acceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector2(currentMoveSpeed, rb.velocity.y);

    }   

    void Jump()
    {
        /** Add vertical positive value to the x vector. **/

        if (!isJumpReleased)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);

            AudioController.Instance.jumpSound.Play();
            animator.SetBool("OnGround", false);
            animator.SetBool("Jump", true);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            canJump = false;
            isJumpReleased = false;
        }



    }

    void ForceDown()
    {
        /** Add vertical negative value to the x vector. **/

        canForceDown = false;

        rb.velocity = new Vector2(rb.velocity.x, 0f);

        rb.AddForce(Vector2.down * jumpForce);

    }
    bool OnGround(Vector2 point, float radius, LayerMask layerMask)
    {
        /**
        /// Return true or false if the player is in the ground
        /// true: if the radius intercepts the layermask.
        /// false: if the radius doesn't intercept the layermask.
        /// <param>point: where creates the circle</param>
        /// <param>radius: size of the radius.</param>
        /// <param>layermask: layermask name that is verificated.</param>
        **/
        return Physics2D.OverlapCircle(point, radius, layerMask);
    }
    #endregion

    #region Death
    public void Death()
    {
        /** Toggle death bool on animator and changes the screen. **/

        GameManager.Instance.runGame = false;

        AudioController.Instance.deathSound.Play();

        animator.SetBool("Death", true);
       
        Invoke("ToggleScreenDead", 1f);
    }

    void ToggleScreenDead()
    {
        /** Changes the Screen value in GameManager **/

        GameManager.Instance.ToggleScreen(GameManager.Screen.Dead);
    }

    #endregion

    #endregion


}
