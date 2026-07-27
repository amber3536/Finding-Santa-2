using UnityEngine;

public class EnterCandyHouse3 : MonoBehaviour
{
    public CameraMovement myCamera;
    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.mode = CameraMode.LockedPosition;
        myCamera.LockToPosition(new Vector3(-20, 0, -10));
    }
}
