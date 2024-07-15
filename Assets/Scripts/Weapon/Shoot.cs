using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    string bulletPoolName;

    [SerializeField]
    float bulletForce = 10f;

    [SerializeField]
    public GameObject player;
    // Update is called once per frame
    private void Start()
    {
       playerController = GameObject.FindObjectOfType<PlayerController>();
        

    }

    public virtual void GunShoot(Vector2 additionalVelocity = new Vector2())
    {
        Debug.Log("face direction in shoot start: " + playerController.faceDirection);
        Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);
        var velocity = new Vector3(1, 0, 0);



         if (playerController.faceDirection == -1 )// if flip ;player face to left
        {
            Debug.Log("shootDirection should be left,current:" + playerController.faceDirection);
            velocity = new Vector3(-8, 0, 0); // this is for right;
        }
     


        bullet.transform.position = firePoint.transform.position;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //we create a new copy of a bullet and then we get its rigid body
        rb.velocity = additionalVelocity;

        rb?.AddForce(velocity * bulletForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }


    
}
