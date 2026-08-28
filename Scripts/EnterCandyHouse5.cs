using UnityEngine;
using UnityEngine.InputSystem;

public class EnterCandyHouse5 : MonoBehaviour
{
    public CameraMovement myCamera;
    private bool relocate = false;
    public GameObject elf;
    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-40, 0, -10));
        relocate = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        relocate = false;
    }

    void Update()
    {
        if (relocate && Keyboard.current.spaceKey.isPressed)
        {   
            elf.transform.position = new Vector3(15f, -2f, 0);;
            myCamera.ResumeFollow();
            relocate = false;
        }
    }
}
