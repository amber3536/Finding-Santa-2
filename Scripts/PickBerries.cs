using UnityEngine;
using UnityEngine.InputSystem;


public class PickBerries : MonoBehaviour
{
    public GameObject berry_bush;
    public SpriteRenderer sr;
    public bool pickReady = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        pickReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pickReady = false;
    }

    public void picking()
    {
        PersistentObject po = GetComponent<PersistentObject>();

        SaveManager.Instance.worldObjects[po.UniqueId] = new WorldObjectSaveData
            {
                id = po.UniqueId,
                isDestroyed = true
            };

        //berry_bush.SetActive(false);
        Destroy(berry_bush);
        int num = PlayerPrefs.GetInt("berries") + 1;
        PlayerPrefs.SetInt("berries", num);
        Debug.Log("berries " + num);
        sr.sortingOrder = 2;
    }
}
