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
                Debug.Log("hiya");
                inventoryUI.RefreshUI();
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

    public void RemoveItem(int index)
    {
        //Debug.Log(slots.Count);
        var slot = slots[index];
        if (slot == null) return;

        slot.amount -= 1;

        if (slot.amount <= 0)
        {
            slot.item = null;
            slot.amount = 0;
            slots.RemoveAt(index);
        }
        //Debug.Log(slots.Count);
        inventoryUI.RefreshUI();
    }

    public string IdentifyItem(int index)
    {
        var slot = slots[index];
        if (slot == null) return "";

        return slot.item.itemName;
    }

    public ItemData GetItem(int index)
    {
        var slot = slots[index];
        return slot.item;
    }
}