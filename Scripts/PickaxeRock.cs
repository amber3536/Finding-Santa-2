using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeRock : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject rock;
    public Animator animator;
    //private int count = 0;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            animator.SetBool("Axing", true);
            // count++;
            // Debug.Log(count);
            // if (count == 5)
            // {
            //     revealStone();
            // }
            Invoke("revealStone", 3f);
        }
        // else
        // {
        //     animator.SetBool("Axing", false);
        //     count = 0;
        // }
    }

    void revealStone()
    {
        sr.sortingOrder = 1;
        rock.SetActive(false);
        animator.SetBool("Axing", false);
    }
}
