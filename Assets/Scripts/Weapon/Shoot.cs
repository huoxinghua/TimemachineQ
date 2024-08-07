using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;


    [SerializeField]
    string bulletPoolName;

    [SerializeField]
    float bulletForce = 10f;

    

    public virtual void GunShoot(float faceDirection)
    {
        Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);


        if (firePoint != null)
        { bullet.transform.position = firePoint.transform.position; }
        else
        {
            Debug.LogWarning("firePoint is null.");
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 velocity = new Vector2(faceDirection, rb.velocity.y);
       

        if (faceDirection < 0)
        {
            //the bullet rotate to left with 90 
            bullet.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else {
            //the bullet rotate to right with 90 
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        rb?.AddForce(velocity * bulletForce, ForceMode2D.Impulse);

       
    }

   
}
