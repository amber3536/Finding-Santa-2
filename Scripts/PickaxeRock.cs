using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeRock : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject rock;
    public Animator animator;
    public bool gemReady = false;
    //private int count = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        gemReady = true;
        // if (Keyboard.current.spaceKey.isPressed)
        // {

        // }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        gemReady = false;
    }
    

    public void revealStone()
    {
        animator.SetBool("Axing", true);
        Invoke("bigReveal", 3f);
    }

    void bigReveal()
    {
        sr.sortingOrder = 1;
        rock.SetActive(false);
        animator.SetBool("Axing", false);
    }
}
