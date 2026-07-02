using UnityEngine;
using UnityEngine.InputSystem;

public class RiverUnblock : MonoBehaviour
{
    //public Collider2D block;
    public GameObject path;  
    public GameObject magic;
    public GameObject block;

    
    public bool unblocked = false;

    void Start()
    {
        path.SetActive(false);
        magic.SetActive(false);
    }


    public void UnblockRiver()
    {
        magic.SetActive(true);
        Invoke("keepUnblockin", 1f);
        PersistentObject po_path = path.GetComponent<PersistentObject>();
        
        SaveManager.Instance.worldObjects[po_path.UniqueId] = new WorldObjectSaveData
            {
                id = po_path.UniqueId,
                isDestroyed = false
            };
    }

    void keepUnblockin()
    {
        magic.SetActive(false);
        //block.enabled = false;
        path.SetActive(true);

        PersistentObject po_block = block.GetComponent<PersistentObject>();
        
        SaveManager.Instance.worldObjects[po_block.UniqueId] = new WorldObjectSaveData
            {
                id = po_block.UniqueId,
                isDestroyed = true
            };
        block.SetActive(false);
        SaveManager.Instance.SaveGame();
    }
}
