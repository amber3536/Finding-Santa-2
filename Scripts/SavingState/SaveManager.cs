using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Transform player;
    public Dictionary<string, WorldObjectSaveData> worldObjects = new Dictionary<string, WorldObjectSaveData>();
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemDatabase itemDatabase;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //LoadGame();
    }

    public void LoadGame()
    {
        SaveData data = SaveSystem.Load();

        if (data == null)
        {
            Debug.Log("No save file found");
            return;
        }

        inventory.LoadInventory(
            data,
            itemDatabase);

        player.position = data.playerPosition;
        

        foreach (WorldObjectSaveData d in data.worldObjects)
            {
                worldObjects[d.id] = d;
            }
        PersistentObject[] objects = FindObjectsByType<PersistentObject>(FindObjectsSortMode.None);

        foreach (PersistentObject obj in objects)
        {
            if (worldObjects.TryGetValue(
                    obj.UniqueId,
                    out WorldObjectSaveData d))
            {
                if (d.isDestroyed)
                {
                    obj.gameObject.SetActive(false);
                }
            }
        }
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.inventoryItems = inventory.GetInventorySaveData();
        saveData.playerPosition = player.position;
        saveData.worldObjects = worldObjects.Values.ToList();
    
        SaveSystem.Save(saveData);

        //data.inventoryItems = inventory.GetInventorySaveData();

        //data.playerPosition = player.position;

        //SaveSystem.Save(data);
    }
}