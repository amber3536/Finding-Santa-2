using UnityEngine;

public class PickUpFishSkeleton : MonoBehaviour
{
    public bool fishSkeletonReady = false;


   void OnTriggerEnter2D(Collider2D other)
    {
        fishSkeletonReady = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fishSkeletonReady = false;
    }
}
