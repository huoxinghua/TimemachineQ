using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory PlayeraInventory = other.GetComponent<PlayerInventory>();

        if (PlayeraInventory != null )
        {
            PlayeraInventory.collectableCollected();
            gameObject.SetActive(false);
        }
    }
}
