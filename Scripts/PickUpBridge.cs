using UnityEngine;

public class PickUpBridge : MonoBehaviour
{
    public bool bridgeReady = false;
  void OnTriggerEnter2D(Collider2D other)
    {
        bridgeReady = true;   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        bridgeReady = false;   
    }
}
