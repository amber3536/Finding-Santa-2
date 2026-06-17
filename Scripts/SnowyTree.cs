using UnityEngine;

public class SnowyTree : MonoBehaviour
{
    public GameObject tree;
    //public SpriteRenderer sr_stump;
    public GameObject log;
    public GameObject stump;

    void Start()
    {
        log.SetActive(false);
        stump.SetActive(false);
    }

    public void chopTree()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = true
            };

        tree.SetActive(false);
  
        PersistentObject po_log = log.GetComponent<PersistentObject>();
        //Debug.Log("log " + po_log.UniqueId);
        SaveManager.Instance.worldObjects[po_log.UniqueId] = new WorldObjectSaveData
            {
                id = po_log.UniqueId,
                isDestroyed = false
            };
        log.SetActive(true);

        PersistentObject po_stump = stump.GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po_stump.UniqueId] = new WorldObjectSaveData
            {
                id = po_stump.UniqueId,
                isDestroyed = false
            };
        stump.SetActive(true);
    }
}
