using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotParent;
    public List<GameObject> slotObjects = new List<GameObject>();


    public void RefreshUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (InventorySlot slot in inventory.slots)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            slotObjects.Add(newSlot);
            
            InventoryUISlot uiSlot =
                newSlot.GetComponent<InventoryUISlot>();

            uiSlot.Set(slot);
            // Set icon and amount here
        }
    }
}