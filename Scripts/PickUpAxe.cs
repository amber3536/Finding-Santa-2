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
}
