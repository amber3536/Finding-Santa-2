using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotParent;


    public void RefreshUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (InventorySlot slot in inventory.slots)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            
            InventoryUISlot uiSlot =
                newSlot.GetComponent<InventoryUISlot>();

            uiSlot.Set(slot);
            // Set icon and amount here
        }
    }
}