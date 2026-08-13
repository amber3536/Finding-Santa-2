using UnityEngine;

public class EnterCandyHouse4 : MonoBehaviour
{
    public CameraMovement myCamera;
    public bool relocate = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 10f, -10));
    }
}
