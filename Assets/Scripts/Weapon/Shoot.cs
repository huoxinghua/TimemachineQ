using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    string bulletPoolName;

    [SerializeField]
    float bulletForce = 15f;

    // Update is called once per frame
    public virtual void GunShoot(Vector2 additionalVelocity = new Vector2())
    {
        Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);

        bullet.transform.position = firePoint.transform.position;
        bullet.transform.rotation = firePoint.transform.rotation;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //we create a new copy of a bullet and then we get its rigid body
        rb.velocity = additionalVelocity;
        rb?.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
