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

    [Header("Jump")]
    [SerializeField] float jumpVelocity = 5f;
    protected GroundCheck groundCheck;
    protected bool isJumping = false;
    protected bool isGrounded = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }
        void Start()
    {
        
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
        Debug.Log("Jump");
        if( rb != null )
        {
            if (!isJumping && (groundCheck.IsGrounded))

            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                isJumping = true;
                
            }
            Debug.Log("get rb" + rb.name);
        }
     
        
    }
    public void JumpReleased()
    {
        isJumping = false;
    }
}
