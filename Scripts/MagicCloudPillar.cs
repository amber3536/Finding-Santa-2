using UnityEngine;

public class MagicCloudPillar : MonoBehaviour
{
    public GameObject bridge;
    public bool magicCloudReady = false;
    //private bool done = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bridge.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        magicCloudReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        magicCloudReady = false;
    }
    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if (elf.holdingLogs && !done)
    //     {
    //         bridge.SetActive(true);
    //     }
    // }

    public void makeMagic()
    {
        bridge.SetActive(true);
    }

}
