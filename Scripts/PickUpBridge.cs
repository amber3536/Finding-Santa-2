using UnityEngine;

public class PickUpBridge : MonoBehaviour
{
    public bool bridgeReady = false;
  void OnTriggerEnter2D(Collider2D other)
    {
        bridgeReady = true;   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        bridgeReady = false;   
    }

    public void destroyBridge()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = true
            };
    }
    public void dropBridge()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = false,
                objectPosition = transform.position
            };
    }
}
