using UnityEngine;

public enum CameraMode
{
    GridFollow,
    Free,
    LockedPosition
}

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Camera cam;

    private float width;
    private float height;

    private int minX;
    private int maxX;
    private int minY;
    private int maxY;

    public float mapMinX = -8.5f;
    public float mapMaxX = 60;
    public float mapMinY = -15;
    public float mapMaxY = 50;

    private Vector3 origin;

    public CameraMode mode = CameraMode.GridFollow;
    private Vector3 lockedPosition;

    private int lastScreenWidth;
    private int lastScreenHeight;

    void Start()
    {
        origin = new Vector3(mapMinX, mapMinY, 0);

        SetFixedAspectRatio();
        RecalculateCamera();

        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;
    }

    void Update()
    {
        // Detect browser/window resizing
        if (Screen.width != lastScreenWidth ||
            Screen.height != lastScreenHeight)
        {
            SetFixedAspectRatio();
            RecalculateCamera();

            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
        }
    }

    void RecalculateCamera()
    {
        height = cam.orthographicSize * 2f;

        // Because SetFixedAspectRatio() forces the camera viewport
        // to 16:9, this will always be 17.7778 when size = 5.
        width = height * cam.aspect;

        minX = Mathf.FloorToInt(
            (mapMinX + width / 2f - origin.x) / width
        );

        maxX = Mathf.FloorToInt(
            (mapMaxX - width / 2f - origin.x) / width
        );

        minY = Mathf.FloorToInt(
            (mapMinY + height / 2f - origin.y) / height
        );

        maxY = Mathf.FloorToInt(
            (mapMaxY - height / 2f - origin.y) / height
        );
    }

    void LateUpdate()
    {
        if (mode == CameraMode.GridFollow)
        {
            int gridX = Mathf.FloorToInt(
                (player.position.x - origin.x) / width
            );

            int gridY = Mathf.FloorToInt(
                (player.position.y - origin.y) / height
            );

            gridX = Mathf.Clamp(gridX, minX, maxX);
            gridY = Mathf.Clamp(gridY, minY, maxY);

            Vector3 targetPosition = new Vector3(
                origin.x + gridX * width + width / 2f,
                origin.y + gridY * height + height / 2f,
                transform.position.z
            );

            transform.position = targetPosition;
        }
        else if (mode == CameraMode.LockedPosition)
        {
            transform.position = lockedPosition;
        }
    }

    public void LockToPosition(Vector3 pos)
    {
        lockedPosition = pos;
        mode = CameraMode.LockedPosition;
    }

    public void ResumeFollow()
    {
        mode = CameraMode.GridFollow;
    }

    private void SetFixedAspectRatio()
    {
        float targetAspect = 16f / 9f;

        cam.aspect = targetAspect;
        cam.rect = new Rect(0f, 0f, 1f, 1f);
    }

    // private void SetFixedAspectRatio()
    // {
    //     float targetAspect = 16f / 9f;
    //     float windowAspect = (float)Screen.width / Screen.height;

    //     float scaleHeight = windowAspect / targetAspect;

    //     Rect rect = new Rect();

    //     if (scaleHeight < 1.0f)
    //     {
    //         // Window is narrower than 16:9
    //         rect.width = 1.0f;
    //         rect.height = scaleHeight;
    //         rect.x = 0;
    //         rect.y = (1.0f - scaleHeight) / 2.0f;
    //     }
    //     else
    //     {
    //         // Window is wider than 16:9
    //         float scaleWidth = 1.0f / scaleHeight;

    //         rect.width = scaleWidth;
    //         rect.height = 1.0f;
    //         rect.x = (1.0f - scaleWidth) / 2.0f;
    //         rect.y = 0;
    //     }

    //     cam.rect = rect;
    // }
}