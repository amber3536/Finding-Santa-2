using UnityEngine;
using UnityEngine.InputSystem;

public class EnterCandyHouse2 : MonoBehaviour
{
    public CameraMovement myCamera;
    private bool relocate = false;
    public GameObject elf;
    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 20, -10));
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
            elf.transform.position = new Vector3(0f, 7f, 0);
            myCamera.ResumeFollow();
            relocate = false;
        }
    }
}
