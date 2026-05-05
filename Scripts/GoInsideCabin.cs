using UnityEngine;
using UnityEngine.InputSystem;

public class GoInsideCabin : MonoBehaviour
{
    public CameraMovement myCamera;
    public bool relocate = false;
//
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (Keyboard.current.spaceKey.isPressed)
        //{
            Debug.Log("relocate true");
            relocate = true;
            //myCamera.transform.position = new Vector3(-20, 15, -10);
            myCamera.mode = CameraMode.LockedPosition;
            myCamera.LockToPosition(new Vector3(-20, 15, -10));
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        relocate = false;
        Debug.Log("relocate false");
    }

    public void free()
    {
        myCamera.ResumeFollow();
    }
}
