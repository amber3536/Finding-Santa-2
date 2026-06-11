using UnityEngine;
using System.Collections;

public class GemTroll : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public string triggerName = "PlayAnim"; // set this trigger in your Animator

    void Start()
    {
        StartCoroutine(PlayLoop());
    }




    IEnumerator PlayLoop()
    {
        while (true)
        {
            animator.SetTrigger(triggerName);
            Invoke("startWalking", .25f);
            Invoke("stopWalking", .5f);
            Invoke("walkBack", 1f);
            Invoke("stopWalking", 1.25f);
            yield return new WaitForSeconds(7f);
        }
    }

    void startWalking()
    {
        rb.linearVelocity = new Vector2(1f, 0f);
    }

    void stopWalking()
    {
        rb.linearVelocity = new Vector2(0f, 0f);
    }

    void walkBack()
    {
        rb.linearVelocity = new Vector2(-1f, 0f);
    }
}
