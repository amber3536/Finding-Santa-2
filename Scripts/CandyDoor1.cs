using UnityEngine;

public class CandyDoor1 : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Open", true);
    }
}
