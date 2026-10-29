using UnityEngine;

public class UnlockGateCandyWorld : MonoBehaviour
{

    public GameObject block;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf")
        {
            block.SetActive(false);
        }
    }
}
