using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI countCollectableTextBlue;

    private void Start()
    {
        countCollectableTextBlue = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBlueCollectableText(PlayerInventory playerInventory)
    {
        countCollectableTextBlue.text = playerInventory.NumberOfCollectables.ToString();
    }
}
