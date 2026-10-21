using UnityEngine;

public class PickUpBerries : MonoBehaviour
{
    public bool berryReady = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        berryReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        berryReady = false;
    }

    public void dropBerry()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = false,
                objectPosition = transform.position,
                prefabKey = po.PrefabKey
            };
    }
}
