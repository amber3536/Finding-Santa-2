using UnityEngine;

public class Train : MonoBehaviour
{
    private Rigidbody2D rb_train;
    public Animator animator;
    public SpriteRenderer sr;
    public GameObject train;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb_train = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        rb_train.linearVelocity = new Vector2(3f, 0);
        Invoke("stopTrain", 5f);
    }

    void stopTrain()
    {
        rb_train.linearVelocity = new Vector2(0, 0);
        sr.sortingOrder = 2;
        animator.SetBool("Idle", true);
        Invoke("startTrain", 3f);
    }

    void startTrain()
    {
        rb_train.linearVelocity = new Vector2(3f, 0);
        animator.SetBool("Idle", false);
        Invoke("disappear", 4f);
    }

    void disappear()
    {
        train.SetActive(false);
    }
}
