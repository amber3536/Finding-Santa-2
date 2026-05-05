using UnityEngine;

public class SnowyHill : MonoBehaviour
{
    public CameraMovement myCamera;
    public GameObject elf;
   // public bool relocate = false;
//    void Start()
//     {
//         CameraController cam = Camera.main.GetComponent<CameraController>();
//     }
   void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 0, -10));
        //relocate = true;
        //myCamera.transform.position = new Vector3(-20, 0, -10);
        elf.transform.position = new Vector3(-18f, -4, 0);
    }
}
