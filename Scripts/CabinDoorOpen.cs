using UnityEngine;

public class CabinDoorOpen : MonoBehaviour
{
    public GameObject door;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door.SetActive(false);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf")
        {
            door.SetActive(true);
            //Debug.Log("hmmm");
        }
    }

}
