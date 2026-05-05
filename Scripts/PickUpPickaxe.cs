using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpPickaxe : MonoBehaviour
{
    // public GameObject axe;
    // public Animator animator;
    public bool pickAxeReady = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        pickAxeReady = true;
        // if (Keyboard.current.spaceKey.isPressed)
        // {
            // axe.SetActive(false);
            // animator.SetBool("Pickaxe", true);
        // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pickAxeReady = false;
    }
}
