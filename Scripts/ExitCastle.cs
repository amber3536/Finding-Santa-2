using UnityEngine;

public class ExitCastle : MonoBehaviour
{
    public CameraMovementCastle myCamera;
    public GameObject elf;

   void OnTriggerEnter2D(Collider2D other)
    {
        elf.transform.position = new Vector3(20f, 3, 0);
        myCamera.ResumeFollow();       
    }
}
