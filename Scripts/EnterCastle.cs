using UnityEngine;

public class EnterCastle : MonoBehaviour
{
    public CameraMovementCastle myCamera;
    public GameObject elf;

   void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraModeCastle.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 10, -10));
        //relocate = true;
        //myCamera.transform.position = new Vector3(-20, 0, -10);
        elf.transform.position = new Vector3(-18f, 5, 0);
    }
}
