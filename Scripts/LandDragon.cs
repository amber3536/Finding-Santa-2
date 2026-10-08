using UnityEngine;

public class LandDragon : MonoBehaviour
{
    //public Animator animator;
    public Dragon dragon;
    private bool hasStarted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasStarted && other.gameObject.name == "Elf")
        {
            hasStarted = true;
            dragon.startDragon();
        }
        else if (other.gameObject.name == "Dragon")
        {
            dragon.stopDragon();
        }
    }
}
