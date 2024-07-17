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
       // Debug.Log("face direction in shoot start: " + playerController.faceDirection);
        Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);
        Vector3 RedVelocity = new Vector3(0, 0, 0);
        Vector3 BlueVelocity = new Vector3(0, 0, 0);

        bullet.transform.position = firePoint.transform.position;


        if(playerController.RedfaceDirection == -1 || playerController.BluefaceDirection == -1)
        {
            RedVelocity = new Vector3(-1, 0, 0);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb?.AddForce(RedVelocity * bulletForce, ForceMode2D.Impulse);
            bullet.transform.localScale = new Vector3(playerController.RedfaceDirection, 1, 1);
        }
        if (playerController.BluefaceDirection == -1)
        {
            BlueVelocity = new Vector3(-1, 0, 0);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb?.AddForce(BlueVelocity * bulletForce, ForceMode2D.Impulse);
        }





        //velocity = new Vector3(1, 0, 0);
        //Debug.Log("get velocity" + velocity);

        //if (playerController.faceDirection == -1 )//player face to left
        //{
        //this is for when the player flips the bullet should flip to0

        // Debug.Log("shootDirection should be left,current:" + playerController.faceDirection);
        //velocity = new Vector3(playerController.faceDirection, 0, 0);
        //Debueeg.Log("get velocity" + velocity);
        //}

        //we create a new copy of a bullet and then we get its rigid body
        //rb.velocity = additionalVelocity;

        //rb?.AddForce(velocity * bulletForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }


    
}
