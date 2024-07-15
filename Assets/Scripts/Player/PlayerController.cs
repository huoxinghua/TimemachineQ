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
    private bool isLadder = false;
    private bool isClimbing;

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

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);

        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, movementVector.y);
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
        }
        else
        {
            HandleJumpModifier();
        }

        HandleVisualFlip();
    }

    public void Move(float movement)
    {
        Debug.Log("W for jump");
        isJumping = true;
        this.movementVector.x = movement;
        if (rb != null)
        {
            // Calculate velocity and Apply velocity to the Rigidbody2D
            Vector2 velocity = new Vector2(this.movementVector.x * speed, rb.velocity.y);

            rb.velocity = velocity;
        }
    }

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
        if (!isLadder || movementUp < 0)
        {
            isJumping = false;
            return;
        }

        isJumping = true;
        Debug.Log("Move up");
        this.movementVector.y = movementUp;
        Vector2 velocity = new Vector2(rb.velocity.x,this.movementVector.y * speed);

        // Apply the new velocity to the Rigidbody2D component
        rb.velocity = velocity;
        rb.gravityScale = 0.6f;

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
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            Debug.Log("You are done climbing");
            isLadder = false;
            isClimbing = false;
        }
    }
}

