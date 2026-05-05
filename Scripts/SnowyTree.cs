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
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.enabled = false;
        //Debug.Log("yyyyy");
        tree.SetActive(false);
        //tree.sortingOrder = -1;
        //sr_stump.sortingOrder = 2;
        log.SetActive(true);
        stump.SetActive(true);
    }
}
