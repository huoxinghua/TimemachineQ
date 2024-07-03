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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(float movement)
    {
        this.movementVector.x = movement;
        if (rb != null)
        {

            // Calculate velocity
            Vector2 velocity = new Vector2(this.movementVector.x * speed, rb.velocity.y);

            // Apply velocity to the Rigidbody2D
            rb.velocity = velocity;
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
                
            }
            
        }
     
        
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



    public  void AttachToParent(Transform newParent)
    {
        this.transform.parent = newParent;
    }

    public void PlayerShoot()
    {
        weapon?.GunShoot(_rb.velocity);
    }
    //this for the player to perate the elevator
    public void OnTriggerEnter2D(Collider2D other)
    {
        // chect if is player
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Operate();
        }


    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OperateReleased();
            Debug.Log("player has leave");
        }

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
}

