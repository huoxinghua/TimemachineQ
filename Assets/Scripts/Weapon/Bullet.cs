
using UnityEngine;

public class Bullet : PoolObject
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            DeSpawn();
        }

        else
        {
            DeSpawn();
        }
        
        
    }

    
}