using UnityEngine;

public class MadScientist : MonoBehaviour
{
    public Animator scientist;
    public GameObject fish;
    public GameObject sci;
    private bool gotFish = false;
    public ElfMovement elfMovement;
    public Animator animator;
    
    void Start()
    {
        fish.SetActive(false);
        sci.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!gotFish && elfMovement.holdingFishSkeleton)
        {
            gotFish = true;
            scientist.SetBool("Spell", true);
            Invoke("done", .75f);
            elfMovement.holdingFishSkeleton = false;
            animator.SetBool("Fish Skeleton", false);
        }

    }

    void done()
    {
        scientist.SetBool("Spell", false);
        fish.SetActive(true);
    }
}
