using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float speed = 5.0f;
    #region Private Variables
    private Rigidbody2D rb;
    private Vector2 movementVector;
    #endregion

    [Header("visual part of player to Flip")]
    [SerializeField] private Transform visuals;

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
    public bool isOperate;
    [SerializeField] ElevatorSwitch elevatorSwitch;

    [Header("Stairs")]
    [SerializeField] private float climbSpeed = 8f;
    private bool isOnLadder = false;
    public bool isClimbing;

    private float fallMultiplier;
    private float lowJumpMultiplier;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
        if (gun && gunLocation) 
        {
            weapon = Instantiate(gun, gunLocation);
            weapon.player = this.gameObject;
        }
    }

    void Start()
    {
        GameObject switchObject = GameObject.FindGameObjectWithTag("Switch");
        if (switchObject != null)
        {
            elevatorSwitch = switchObject.GetComponent<ElevatorSwitch>();
        }

        if (elevatorSwitch == null)
        {
            Debug.LogWarning("SwitchButtonController not found or not assigned.");
        }
    }

    private void Update()
    {
        if (!isOnLadder)
        {
            rb.gravityScale = 1f;
        }
            
    }
    private void FixedUpdate()
    {
        /*
        if(isLadder)
        {
            isClimbing = true;
            MoveUp(1);
        }
        else if(!isLadder)
        {
            isClimbing = false;
            MoveUp(-1);
        }
       */
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);

        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, movementVector.y* climbSpeed);
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);//this is for nomal move
        }
        else
        {
            HandleJumpModifier();
        }

        HandleVisualFlip();
    }

    public void Move(float movement)
    {
        isJumping = true;
        this.movementVector.x = movement;
    }

    //the player move left and right should be different in visual
    private void HandleVisualFlip()
    {
        if(movementVector.x > 0)
        {
            visuals.localScale = new Vector3(1, 1, 1);
        }
        else if(movementVector.x < 0)
        {
            visuals.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
       
        if( rb != null )
        {
            if (!isJumping && (groundCheck.IsGrounded))

            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                isJumping = true;
                rb.gravityScale = 1f;
            }
        } 
    }

    private void HandleJumpModifier()
    {
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
        }
    }

    public void MoveUp(float movementUp)
    {
        Debug.Log("move up now");
        Debug.Log("movementUP");
        if (!isOnLadder || movementUp < 0)
        {
            isJumping = false;
            return;
        }
        this.movementVector.y = movementUp;
        rb.gravityScale = 0f;

    }
   

    public void JumpReleased()
    {
        isJumping = false;
    }

    public void AttachToParent(Transform newParent)
    {
        this.transform.parent = newParent;
    }

    public void PlayerShoot()
    {
        weapon?.GunShoot(rb.velocity);
    }
   
  
    public void Die()
    {
        //pause the game 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            Debug.Log("You are about to climb");
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            Debug.Log("You are done climbing");
            isOnLadder = false;
            isClimbing = false;
        }
    }
}

