using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Bullet : PoolObject
{
    [SerializeField] private PoolManager poolmanager;

    private void Start()
    {
        poolmanager = GetComponent<PoolManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        poolmanager.DeSpawn(this);
    }
}
