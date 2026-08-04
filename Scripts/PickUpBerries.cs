using UnityEngine;

public class PickUpBerries : MonoBehaviour
{
    public bool berryReady = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        berryReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        berryReady = false;
    }
}
