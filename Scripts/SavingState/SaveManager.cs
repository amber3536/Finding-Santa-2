using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemDatabase itemDatabase;

    private void Start()
    {
        LoadGame();
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
    }
}