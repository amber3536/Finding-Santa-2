using UnityEngine;
using System.Collections.Generic;
public class ItemDatabase : MonoBehaviour
{
    public List<ItemData> items;

    private Dictionary<string, ItemData> lookup;

    private void Awake()
    {
        lookup = new Dictionary<string, ItemData>();

        foreach (ItemData item in items)
        {
            lookup[item.itemName] = item;
        }
    }

    public ItemData GetItem(string id)
    {
        return lookup[id];
    }
}