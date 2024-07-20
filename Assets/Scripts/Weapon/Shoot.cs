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

    [SerializeField]
    public GameObject player;
    // Update is called once per frame
    public virtual void GunShoot(Vector2 additionalVelocity = new Vector2())
    {
        Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);
        var velocity = new Vector3(0, 0, 0);

        if(player.transform.localScale.x < 0)
        {
            velocity = new Vector3(-1, 0, 0);
        }
        else
        {
            velocity = new Vector3(1, 0, 0);
        }

        bullet.transform.position = firePoint.transform.position;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //we create a new copy of a bullet and then we get its rigid body
        rb.velocity = additionalVelocity;

        rb?.AddForce(velocity * bulletForce, ForceMode2D.Impulse);
    }


}
