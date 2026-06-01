using UnityEngine;

public class ReturnToYeti : MonoBehaviour
{
    public GameObject elf;
    public CameraMovementCave myCamera;
   void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraModeCave.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 0, -10));
        //relocate = true;
        //myCamera.transform.position = new Vector3(-20, 0, -10);
        elf.transform.position = new Vector3(-12f, -4, 0);
    }

}
