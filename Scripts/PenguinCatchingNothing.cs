using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PenguinCatchingNothing : MonoBehaviour
{   
    public Animator animator;
    public float animationTime = 8f;
    public string triggerName = "Checking";
    private bool catching = false;
    public ElfMovement elf;
    public Rigidbody2D rb_train;
    public Animator animator_train;
    private bool trainFinished = false;
    public GameObject magic;
    public Animator animator_elf;

    void Start()
    {
        magic.SetActive(false);
        StartCoroutine(CheckingLine());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (elf.holdingFish && !trainFinished)
        {
            trainFinished = true;
            Invoke("magicHappens", 1f);
            Invoke("startTrain", 2f);
            Invoke("stopTrain", 8f);
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

    void magicHappens()
    {
        magic.transform.position = new Vector3(elf.transform.position.x, elf.transform.position.y + 1f, 0f);
        magic.SetActive(true);
        Invoke("endMagic", 1f);
    }

    void endMagic()
    {
        magic.SetActive(false);
        animator_elf.SetBool("Fish", false);
    }

    void startTrain()
    {
        rb_train.linearVelocity = new Vector2(-3f, 0);
    }

    void catchFalse()
    {
        animator.SetBool("Catch", false);
    }

    void stopTrain()
    {
        rb_train.linearVelocity = new Vector3(0f, 0f, 0f);
        animator_train.SetBool("Idle", true);
        Invoke("changeScene", 3f);
    }

    void changeScene()
    {
        SceneManager.LoadScene("Castle World");
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
