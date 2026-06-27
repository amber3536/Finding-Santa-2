using UnityEngine;
using System.Collections;

public class PenguinCatchingNothing : MonoBehaviour
{   
    public Animator animator;
    public float animationTime = 8f;
    public string triggerName = "Checking";
    private bool catching = false;
    public ElfMovement elf;
    public Rigidbody2D rb_train;
    public Animator animator_train;

    void Start()
    {
        StartCoroutine(CheckingLine());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (elf.holdingFish)
        {
            //Debug.Log("fishy");
            rb_train.linearVelocity = new Vector2(-3f, 0);
            Invoke("stopTrain", 6f);
        }
        else if (!catching)
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

    void stopTrain()
    {
        rb_train.linearVelocity = new Vector3(0f, 0f, 0f);
        animator_train.SetBool("Idle", true);
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
