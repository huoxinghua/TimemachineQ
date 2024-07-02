using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedInventoryUI : MonoBehaviour
{
    private TextMeshProUGUI countCollectableTextRed;

    private void Start()
    {
        countCollectableTextRed = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateRedCollectableText(RedPlayerInventory redPlayerInventory)
    {
        countCollectableTextRed.text = redPlayerInventory.NumberOfRedCollectables.ToString();
    }
}
