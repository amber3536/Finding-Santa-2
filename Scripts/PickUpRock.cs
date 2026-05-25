using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpRock : MonoBehaviour
{
    public bool rockReady = false;


   void OnTriggerEnter2D(Collider2D other)
    {
        rockReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        rockReady = false;
    }
}
