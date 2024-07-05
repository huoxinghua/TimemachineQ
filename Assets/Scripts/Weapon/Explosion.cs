using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PoolObject
{
    private void OnEnable()
    {
        Invoke(nameof(DeSpawn), time: 2f);
    }
}
