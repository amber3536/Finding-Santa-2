using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpRock : MonoBehaviour
{
    public bool rockReady = false;


   void OnTriggerEnter2D(Collider2D other)
    {
        rockReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        rockReady = false;
    }

    public void destroyRock()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = true
            };
    }

    public void restoreRock()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = false
            };
    }
}
