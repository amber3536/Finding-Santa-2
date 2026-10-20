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
}
