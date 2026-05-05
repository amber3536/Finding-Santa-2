using UnityEngine;

public class ThreeLogs : MonoBehaviour
{
    public bool logsReady = false;
    public GameObject threeLogs;
   void OnTriggerEnter2D(Collider2D other)
    {
        logsReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        logsReady = false;
    }
}
