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
