using UnityEngine;
using System.Collections.Generic;
[System.Serializable]

public class SaveData
{
    public int playerLevel;
    public Vector3 playerPosition;

    public List<InventorySlotSaveData> inventoryItems = new List<InventorySlotSaveData>();

    public List<WorldObjectSaveData> worldObjects = new List<WorldObjectSaveData>();
    public string carriedObjectId;

    //public bool started;
}