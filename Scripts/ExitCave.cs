using UnityEngine;

public class ExitCave : MonoBehaviour
{
    public CameraMovementCave myCamera;
    public GameObject elf;

   void OnTriggerEnter2D(Collider2D other)
    {
        elf.transform.position = new Vector3(25f, 30, 0);
        myCamera.ResumeFollow();       
    }
}
