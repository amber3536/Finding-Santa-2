using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpAxe : MonoBehaviour
{
    //public GameObject axe;
    //public Animator animator;
    public bool axeReady = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        axeReady = true;
        // if (Keyboard.current.spaceKey.isPressed)
        // {
        //     axe.SetActive(false);
        //     animator.SetBool("Pickaxe", true);

        // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        axeReady = false;
    }
}
