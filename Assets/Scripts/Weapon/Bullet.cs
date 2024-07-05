using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Bullet : PoolObject
{
    public float speed;
    private Rigidbody2D rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    //if the bullet hit something destroy himself
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            PoolManager.Instance.DeSpawn(this);
        }  
    }
}
