using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RedPlayerInventory RedPlayeraInventory = other.GetComponent<RedPlayerInventory>();

        if (RedPlayeraInventory != null)
        {
            RedPlayeraInventory.redCollectableCollected();
            gameObject.SetActive(false);
        }
    }
}
