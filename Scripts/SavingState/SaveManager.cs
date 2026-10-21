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
    public string carriedWorldObjectUniqueId = null;
    static bool gameBegun = false;
    

    private void Awake()
    {
        Instance = this;
        //PlayerPrefs.SetInt("gameStarted", 0);
    }

    private void Start()
    {
        //LoadGame();
        //Debug.Log("save manager");
        if (gameBegun)
        {
            GetCarryObject();
        }
        gameBegun = true;
        
    }

    private void GetCarryObject()
    {
        SaveData data = SaveSystem.Load();

        if (data == null)
        {
            Debug.Log("No save file found");
            return;
        }

        carriedWorldObjectUniqueId = data.carriedObjectId;
        elf.addCarryItem();

        inventory.LoadInventory(
            data,
            itemDatabase);

        
        foreach (WorldObjectSaveData d in data.worldObjects)
            {
                worldObjects[d.id] = d;
            }
            
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

        HashSet<string> foundIds = new HashSet<string>();

        foreach (PersistentObject obj in objects)
        {
            //Debug.Log($"Found object: {obj.name}  ID: {obj.UniqueId}");
            if (worldObjects.TryGetValue(
                    obj.UniqueId,
                    out WorldObjectSaveData d))
            {
                foundIds.Add(d.id);
                if (d.isDestroyed)
                {
                    obj.gameObject.SetActive(false);
                }
                else
                {
                    obj.gameObject.SetActive(true);
                    obj.transform.position = d.objectPosition;
                    //TODO add object locations
                }
            }
        }

        // Recreate saved objects that don't exist in the scene
        foreach (WorldObjectSaveData d in worldObjects.Values)
        {
            if (foundIds.Contains(d.id) || d.isDestroyed)
                continue;

            ItemData item = itemDatabase.GetItem(d.prefabKey);

            if (item == null || item.worldPrefab == null)
            {
                Debug.LogError($"Cannot recreate world object: {d.prefabKey}");
                continue;
            }

            GameObject obj = Instantiate(
                item.worldPrefab,
                d.objectPosition,
                Quaternion.identity);

            PersistentObject po = obj.GetComponent<PersistentObject>();

            if (po == null)
            {
                Debug.LogError($"Prefab '{d.prefabKey}' has no PersistentObject!");
                Destroy(obj);
                continue;
            }

            po.SetUniqueId(d.id);
            po.SetPrefabKey(d.prefabKey);
        }

        carriedWorldObjectUniqueId = data.carriedObjectId;
        elf.addCarryItem();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.inventoryItems = inventory.GetInventorySaveData();
        saveData.playerPosition = player.position;

        foreach (var persistentObject in FindObjectsByType<PersistentObject>(
             FindObjectsSortMode.None))
        {
            string id = persistentObject.UniqueId;

            if (worldObjects.TryGetValue(id, out WorldObjectSaveData data))
            {
                data.objectPosition = persistentObject.transform.position;
            }
        }

        saveData.worldObjects = worldObjects.Values.ToList();
        saveData.carriedObjectId = carriedWorldObjectUniqueId;
    
        SaveSystem.Save(saveData);

    }
}