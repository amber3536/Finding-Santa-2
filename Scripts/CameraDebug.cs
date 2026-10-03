using UnityEngine;

public class CameraDebug : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        Debug.Log("===== CAMERA DEBUG =====");
        Debug.Log("Screen: " + Screen.width + " x " + Screen.height);
        Debug.Log("Screen aspect: " + ((float)Screen.width / Screen.height));
        Debug.Log("Camera aspect: " + cam.aspect);
        Debug.Log("Camera rect: " + cam.rect);
        Debug.Log("Camera position: " + cam.transform.position);
        Debug.Log("Ortho size: " + cam.orthographicSize);

        float cameraWidth = cam.orthographicSize * 2f * cam.aspect;
        float cameraHeight = cam.orthographicSize * 2f;

        Debug.Log("Camera world width: " + cameraWidth);
        Debug.Log("Camera world height: " + cameraHeight);
    }
}
