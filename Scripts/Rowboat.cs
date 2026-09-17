using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (other.gameObject.name == "Elf")
        {
            elf.SetActive(false);
            animator.SetBool("Row", true);
            Invoke("Row", 2);
        }
    }

    void Row()
    {
        animator.SetBool("Row", false);
        rb.linearVelocity = new Vector2(2, 0);
        Invoke("changeScene", 4);
    }

    void changeScene()
    {
        SceneManager.LoadScene("Island World");
    }
}
