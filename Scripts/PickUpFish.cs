using UnityEngine;

public class PickUpFish : MonoBehaviour
{
    public bool fishReady = false;


   void OnTriggerEnter2D(Collider2D other)
    {
        fishReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fishReady = false;
    }
    public void dropFish()
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
