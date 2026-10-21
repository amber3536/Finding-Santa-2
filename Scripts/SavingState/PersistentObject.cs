using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField] private string uniqueId;
    [SerializeField] private string prefabKey;

    public string UniqueId => uniqueId;
    public string PrefabKey => prefabKey;

    public void SetUniqueId(string id)
    {
        uniqueId = id;
    }

    public void SetPrefabKey(string key)
    {
        prefabKey = key;
    }
}