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
}
