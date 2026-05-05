using UnityEngine;

public class SnowyTreeBlowing : MonoBehaviour
{
    public Animator animator;
    public Animator animator1;
    public AudioSource wind;
    private bool hasPlayed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("Wind", true);
        animator1.SetBool("Wind", true);
        
        if (!hasPlayed)
        {
            wind.Play();
            hasPlayed = true;
        }
        
    }
}
