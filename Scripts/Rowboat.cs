using UnityEngine;

public class Rowboat : MonoBehaviour
{
    public GameObject elf;
    public Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        elf.SetActive(false);
        animator.SetBool("Row", true);
        Invoke("Row", 2);
    }

    void Row()
    {
        animator.SetBool("Row", false);
        rb.linearVelocity = new Vector2(2, 0);
    }
}
