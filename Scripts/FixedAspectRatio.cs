using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        UpdateViewport();
    }

    void Update()
    {
        UpdateViewport();
    }

    void UpdateViewport()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Window is taller/narrower than 16:9
            cam.rect = new Rect(
                0,
                (1.0f - scaleHeight) / 2.0f,
                1.0f,
                scaleHeight
            );
        }
        else
        {
            // Window is wider than 16:9
            float scaleWidth = 1.0f / scaleHeight;

            cam.rect = new Rect(
                (1.0f - scaleWidth) / 2.0f,
                0,
                scaleWidth,
                1.0f
            );
        }
    }
}