using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCollectables { get; private set; }

    public UnityEvent<PlayerInventory> OnCollectablesCollected;

    public void collectableCollected()
    {
        NumberOfCollectables++;
        OnCollectablesCollected.Invoke(this);
    }
}
