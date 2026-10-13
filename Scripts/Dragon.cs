using UnityEngine;

public class Dragon : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject elf;

    private bool ready = false;
    //public bool dragonReady = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void startDragon()
    {
        rb.linearVelocity = new Vector2(-2, 0);
    }

    public void stopDragon()
    {
        Debug.Log("stop");
        animator.SetBool("Land", true);
        rb.linearVelocity = new Vector2(0, 0);
        ready = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf" && ready)
        {
            Debug.Log("Dragon trigger");
            animator.SetBool("Fly", true);
            rb.linearVelocity = new Vector2(-2, 0);
            elf.SetActive(false);
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     dragonReady = false;
    // }
}
