using UnityEngine;

public class ThreeLogs : MonoBehaviour
{
    public bool logsReady = false;
    public GameObject threeLogs;
   void OnTriggerEnter2D(Collider2D other)
    {
        logsReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        logsReady = false;
    }

    public void destroyLogs()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = true
            };
    }

    public void dropLogs()
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
