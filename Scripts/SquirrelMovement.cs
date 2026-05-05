using UnityEngine;
using System;

public class SquirrelMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Look", 3f);
    }

    void Look()
    {
        animator.SetBool("Look", true);
        Invoke("Run", 3f);
    }

    void Run()
    {
        animator.SetBool("Run", true);
        rb.linearVelocity = new Vector2(3f, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ahhh");
        Run();
    }
}
