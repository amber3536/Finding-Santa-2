using UnityEngine;

public class PickUpFishSkeleton : MonoBehaviour
{
    public bool fishSkeletonReady = false;


   void OnTriggerEnter2D(Collider2D other)
    {
        fishSkeletonReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fishSkeletonReady = false;
    }
    public void destroyFishSkeleton()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = true
            };
    }

    public void dropFishSkeleton()
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
