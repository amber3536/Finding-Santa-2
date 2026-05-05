using UnityEngine;

public class FootprintFade : MonoBehaviour
{
    //public GameObject objectToDisable;
    void Start()
    {
        //Destroy(gameObject, 5f);
        //Invoke("HideFootprint", 3f);
    }

    void HideFootprint()
    {
        gameObject.SetActive(false);
        //GetComponent<SpriteRenderer>().enabled = false;
    }
}
