using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = CheckGrounded();
    }
    private bool CheckGrounded()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        float extraHeight = .05f;
         RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeight,  LayerMask.GetMask("Ground"));
         Color rayColor;
         if(raycastHit.collider)
         {
         	rayColor = Color.red;
         }
         else
         	rayColor = Color.green;

         Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
         return raycastHit.collider != null;
         //Debug.Log("get checkGround result" + CheckGrounded());



        // return false;
    }


}
