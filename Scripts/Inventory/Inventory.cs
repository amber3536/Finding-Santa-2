using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public List<InventorySlot> slots = new List<InventorySlot>();

    public void AddItem(ItemData item)
    {
        // Stack if possible
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item && item.stackable)
            {
                slot.amount++;
                return;
            }
        }

        // Otherwise create new slot
        InventorySlot newSlot = new InventorySlot();
        newSlot.item = item;
        newSlot.amount = 1;

        slots.Add(newSlot);
    }
}