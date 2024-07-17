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

    public virtual void GunShoot(Vector2 velocity)
    {
        Debug.Log("Shoot.GunShoot:"+ velocity);
        Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);
        bullet.transform.position = firePoint.transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb?.AddForce(velocity * bulletForce, ForceMode2D.Impulse);
        bullet.transform.localScale = new Vector3(playerController.faceDirection, 1, 1);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    } 
}
