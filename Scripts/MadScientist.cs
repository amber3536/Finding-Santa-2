using UnityEngine;

public class MadScientist : MonoBehaviour
{
    public Animator scientist;
    public GameObject fish;
    
    void Start()
    {
        fish.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        scientist.SetBool("Spell", true);
        Invoke("done", .75f);
    }

    void done()
    {
        scientist.SetBool("Spell", false);
        fish.SetActive(true);
    }
}
