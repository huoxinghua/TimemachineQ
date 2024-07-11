using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    protected void DeSpawn()
    {
        PoolManager.Instance.DeSpawn(this);
    }
}