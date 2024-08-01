using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float speed = 5.0f;
    #region Private Variables
    private Rigidbody2D rb;
    private Vector2 movementVector;
    #endregion

    [Header("visual part of player to Flip")]
    [SerializeField] public Transform visuals;
    public float faceDirection;
    public string currentMovePlayer;
    [SerializeField] PlayerInputController playerInputController;
    
    

    [Header("Jump")]
    [SerializeField] float jumpVelocity = 5f;
    protected GroundCheck groundCheck;
    protected bool isJumping = false;
    protected bool isGrounded = false;

    [Header("Weapons")]
    [SerializeField]
    private Shoot gun;
    private Shoot weapon;
    [SerializeField]
    private Transform gunLocation;

    [Header("Operate Elevator")]
    [SerializeField] ElevatorSwitch elevatorSwitch;

    [Header("Stairs")]
    [SerializeField] private float climbSpeed = 2f;
    public bool isOnLadder = false;
   
    private float fallMultiplier;
    private float lowJumpMultiplier;
    private PlayerInputController.PlayerType currentplayerType;


    [Header("Animations")]
    [SerializeField] private Animator animator;



    void Awake()
    {
        groundCheck = GetComponent<GroundCheck>();

        if (gun && gunLocation) 
        {
            weapon = Instantiate(gun, gunLocation);
           
        }
    }

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        faceDirection = 1;
       

        GameObject switchObject = GameObject.FindGameObjectWithTag("Switch");
        if (switchObject != null)
        {
            elevatorSwitch = switchObject.GetComponent<ElevatorSwitch>();
        }

        if (elevatorSwitch == null)
        {
            Debug.LogWarning("SwitchButtonController not found or not assigned.");
        }
        playerInputController = GetComponent<PlayerInputController>();


    }

    private void Update()
    {
        

        var velocity = rb.velocity;
        velocity.y = 0;

        if(rb.velocity.magnitude < 0.1f)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("isGround", groundCheck.IsGrounded);
        }

        if (rb.velocity.magnitude > 0.1f)
        {

            animator.SetBool("IsWalking", true);
        }

        return;
    }
    private void FixedUpdate()
    {

        //renew the rb when on Stair
        if (isOnLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, movementVector.y* climbSpeed);
            rb.gravityScale = 0f;
        }
        else
        {
            rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
            rb.gravityScale = 1f;
            HandleJumpModifier();
        }
    }

    public void Move(float movement)
    {
        this.movementVector.x = movement;
        if (rb != null)
        {
            rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
            rb.gravityScale = 1f;

        }

        //this is for flip the player when left and right
        if (visuals != null)
        {
            if (movementVector.x > 0)
            {
                visuals.localScale = new Vector3(1, 1, 1);
                faceDirection = movement;
            }
            else if (movementVector.x < 0)
            {
                visuals.localScale = new Vector3(-1, 1, 1);
                faceDirection = movement;
            }
        }
        else
        {
            Debug.LogWarning("Visuals reference is null.");
        }

    }

    public void PlayerShoot()
    {
        weapon?.GunShoot(faceDirection);

    }


    public void Jump()
    {
        if (!groundCheck.IsGrounded) return;

        if (animator != null)
        {
            animator.SetTrigger("jump");
        }
        else
        {
            Debug.LogWarning("Animator is null. Cannot trigger Jump animation.");
        }
       

        if ( rb != null )
        {
            if (groundCheck.IsGrounded && !isJumping)

            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                isJumping = true;
            }
            else if(!groundCheck.IsGrounded && !isJumping && !isOnLadder)
            {
                HandleJumpModifier();
            }
        }
        
    }

    private void HandleJumpModifier()
    {
        //Debug.Log(this.name + "add coyote time to better jump");
        if (rb != null)
        {
            //is falling
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * (Physics2D.gravity.y * Time.fixedDeltaTime * fallMultiplier);
            }
            //is up,but not holding the jump button
            else if (rb.velocity.y > 0 && !isJumping)
            {
                rb.velocity += Vector2.up * (Physics2D.gravity.y * Time.fixedDeltaTime * lowJumpMultiplier);
            }
            rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
            rb.gravityScale = 1f;
        }
    }

    

    public void StairMove(float movementUp)
    {
       // Stair Move begin
        this.movementVector.y = movementUp;
        climbSpeed = 2f;
    }


    public void JumpReleased()
    {
        isJumping = false;
    }

    public void StopInStair()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
      
        climbSpeed = 0f;
        
    }

    public void AttachToParent(Transform newParent)
    {
        
         this.transform.parent = newParent; 
       
       
    }

    public void Die()
    {
        //pause the game 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Stair"))
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("isGround", groundCheck.IsGrounded);

            isOnLadder = true;
            isJumping = false;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Stair"))
        {
            StartCoroutine(RestoreGravity());
        }
    }

    private IEnumerator RestoreGravity()
    {
        yield return new WaitForSeconds(0.2f); // Adjust the delay time as needed
        isOnLadder = false;
        isJumping = false;
        rb.gravityScale = 1f;
    }
}

