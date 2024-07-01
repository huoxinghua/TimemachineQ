using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : PoolObject
{   
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Destroy(gameObject);
    }
}
