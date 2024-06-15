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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Move(float movement)
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
}
