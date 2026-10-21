using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpAxe : MonoBehaviour
{
    public bool axeReady = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        axeReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        axeReady = false;
    }
    public void dropAxe()
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
