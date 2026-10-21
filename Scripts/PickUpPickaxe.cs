using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpPickaxe : MonoBehaviour
{
    public bool pickAxeReady = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        pickAxeReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pickAxeReady = false;
    }

    public void dropPickaxe()
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
