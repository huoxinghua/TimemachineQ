using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushBox : MonoBehaviour
{
    public float pushForce = 2.0f; // the force to push the box

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pushable")
        {
            Rigidbody2D boxRigidbody = collision.collider.GetComponent<Rigidbody2D>();

            if (boxRigidbody != null)
            {
                //push the box
                Vector2 pushDirection = collision.contacts[0].normal * -1;
                boxRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
