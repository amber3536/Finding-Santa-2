using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Transform player;
    public ElfMovement elf;
    public Dictionary<string, WorldObjectSaveData> worldObjects = new Dictionary<string, WorldObjectSaveData>();
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemDatabase itemDatabase;
    public string carriedWorldObjectUniqueId;

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
        //PersistentObject[] objects = FindObjectsByType<PersistentObject>(FindObjectsSortMode.None);

        PersistentObject[] objects =
            FindObjectsByType<PersistentObject>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);

        foreach (PersistentObject obj in objects)
        {
            //Debug.Log($"Found object: {obj.name}  ID: {obj.UniqueId}");
            if (worldObjects.TryGetValue(
                    obj.UniqueId,
                    out WorldObjectSaveData d))
            {
                if (d.isDestroyed)
                {
                    obj.gameObject.SetActive(false);
                }
                else
                {
                    //Debug.Log(obj.UniqueId);
                    obj.gameObject.SetActive(true);
                }
            }
        }
        carriedWorldObjectUniqueId = data.carriedObjectId;
        elf.addCarryItem();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.inventoryItems = inventory.GetInventorySaveData();
        saveData.playerPosition = player.position;
        saveData.worldObjects = worldObjects.Values.ToList();
        saveData.carriedObjectId = carriedWorldObjectUniqueId;
    
        SaveSystem.Save(saveData);

    }
}