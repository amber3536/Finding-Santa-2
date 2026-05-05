using UnityEngine;
using System.Collections;

public class PenguinCatchingNothing : MonoBehaviour
{   
    public Animator animator;
    public float animationTime = 8f;
    public string triggerName = "Checking";
    private bool catching = false;

    void Start()
    {
        StartCoroutine(CheckingLine());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!catching)
        {
            animator.SetBool("Catch", true);
            catching = true;
            Invoke("catchFalse", 1f);
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        catching = false;
    }

    void catchFalse()
    {
        animator.SetBool("Catch", false);
    }

    IEnumerator CheckingLine()
    {
        while (true)
        {
            animator.SetTrigger(triggerName);

            yield return new WaitForSeconds(animationTime);
        }
    }
 }
