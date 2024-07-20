using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;

    private Shoot weapon;

    [Header("Movement")]
    [SerializeField] protected float speed = 5.0f;
    #region Private Variables
    private Rigidbody2D rb;
    private Vector2 movementVector;
    #endregion

    [Header("Jump")]
    [SerializeField] float jumpVelocity = 5f;
    protected GroundCheck groundCheck;
    protected bool isJumping = false;
    protected bool isGrounded = false;

    [Header("Weapons")]
    [SerializeField]
    private Shoot gun;
    [SerializeField]
    private Transform gunLocation;

    [Header("Operate Elevator")]
    public bool isOperate;
    [SerializeField] SwitchButtonController switchButtonController;

    [Header("Stairs")]
    [SerializeField] private float climbSpeed = 8f;
        [SerializeField]
    private bool isLadder = false;
    private bool isClimbing;

    private float fallMultiplier;
    private float lowJumpMultiplier;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
        _rb = GetComponent<Rigidbody2D>();
        if (gun && gunLocation) 
        {
            weapon = Instantiate(gun, gunLocation);
            weapon.player = this.gameObject;
        }
    }
    void Start()
    {
        // isOperate = false;
        GameObject switchObject = GameObject.FindGameObjectWithTag("Switch");
        if (switchObject != null)
        {
            switchButtonController = switchObject.GetComponent<SwitchButtonController>();
        }

        if (switchButtonController == null)
        {
            Debug.LogWarning("SwitchButtonController not found or not assigned.");
        }
    }

    
    
    public void Move(float movement)
    {
        Debug.Log("W for jump");
        this.movementVector.x = movement;
        if (rb != null)
        {

            // Calculate velocity
            Vector2 velocity = new Vector2(this.movementVector.x * speed, rb.velocity.y);

            // Apply velocity to the Rigidbody2D
            rb.velocity = velocity;

            //flipping character
            if (velocity.x > 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);

            }

            if (velocity.x < 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }

  
         
            
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
       // rb.AddForce(new Vector2(0, this.movementVector.y * speed), ForceMode2D.Impulse);
        Vector2 velocity = new Vector2(rb.velocity.x,this.movementVector.y * speed);

        // Apply the new velocity to the Rigidbody2D component
        //rb.velocity = new Vector2(rb.velocity.x, speed);
        rb.velocity = velocity;
        rb.gravityScale = 0.6f;

    }
   

    public void JumpReleased()
    {
        isJumping = false;
    }
    private void FixedUpdate()
    {
        if(rb != null)
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



    public void AttachToParent(Transform newParent)
    {
        this.transform.parent = newParent;
    }

    public void PlayerShoot()
    {
        weapon?.GunShoot(_rb.velocity);
    }
   
    

    //this is for the player operate the elevator
    public void Operate()
    {
        Debug.Log("Get Y");
        switchButtonController.ToggleSwitch();
    }
    public void OperateReleased()
    {
        //isOperate = false;
        Debug.Log("Release Y");
        switchButtonController.ToggleSwitch();
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

