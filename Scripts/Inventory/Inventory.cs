using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public List<InventorySlot> slots = new List<InventorySlot>();
    //public List<GameObject> slotObjects = new List<GameObject>();

    public void AddItem(ItemData item)
    {
        // Stack if possible
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item && item.stackable)
            {
                slot.amount++;
                //refresh UI?
                return;
            }
        }

        // Otherwise create new slot
        InventorySlot newSlot = new InventorySlot();
        newSlot.item = item;
        newSlot.amount = 1;

        slots.Add(newSlot);

        inventoryUI.RefreshUI();
    }

    public void RemoveItem(int index, int amount)
    {
        var slot = slots[index];
        if (slot == null) return;

        slot.amount -= amount;

        if (slot.amount <= 0)
        {
            slot.item = null;
            slot.amount = 0;
        }

        inventoryUI.RefreshUI();
    }
}