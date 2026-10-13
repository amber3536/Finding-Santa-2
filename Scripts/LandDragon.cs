using UnityEngine;

public class LandDragon : MonoBehaviour
{
    //public Animator animator;
    public Dragon dragon;
    private bool hasStarted = false;
    private bool hasStopped = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasStarted && other.gameObject.name == "Elf")
        {
            hasStarted = true;
            dragon.startDragon();
        }
        else if (!hasStopped && other.gameObject.name == "Dragon")
        {
            hasStopped = true;
            dragon.stopDragon();
        }
    }
}
