using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedPlayerInventory : MonoBehaviour
{
    public int NumberOfRedCollectables { get; private set; }

    public UnityEvent<RedPlayerInventory> OnRedCollectablesCollected;

    public void redCollectableCollected()
    {
        NumberOfRedCollectables++;
        OnRedCollectablesCollected.Invoke(this);
    }
}
