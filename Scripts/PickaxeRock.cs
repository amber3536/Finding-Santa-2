using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeRock : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject rock;
    public Animator animator;
    public bool gemReady = false;
    public GameObject scientist;
    //private int count = 0;

    void Start()
    {
        PlayerPrefs.SetInt("gems", 0);
    }

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
        int curr = PlayerPrefs.GetInt("gems");

        if (curr == 6)
        {
            scientist.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("gems", curr++);
        }
        
    }
}
