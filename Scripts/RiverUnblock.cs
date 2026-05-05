using UnityEngine;
using UnityEngine.InputSystem;

public class RiverUnblock : MonoBehaviour
{
    public Collider2D block;
    public GameObject path;  
    public GameObject magic;

    //public ElfMovement elfMovement;
    // public Animator animator;
    
    public bool unblocked = false;

    void Start()
    {
        path.SetActive(false);
        magic.SetActive(false);
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     unblocked = true;
    //     // if (Keyboard.current.spaceKey.isPressed && elfMovement.holdingRock)
    //     // {
    //     //     magic.SetActive(true);
    //     //     PlayerPrefs.SetFloat("pathLocation", path.transform.position.x);
    //     //     Invoke("UnblockRiver", 1f);
    //     // }

    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     unblocked = false;
    // }

    public void UnblockRiver()
    {
        magic.SetActive(true);
        Invoke("keepUnblockin", 1f);
        //animator.SetBool("Rock", false);
    }

    void keepUnblockin()
    {
        magic.SetActive(false);
        block.enabled = false;
        path.SetActive(true);
    }
}
