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

    private float lastAspect;

    void Start()
    {
        origin = new Vector3(mapMinX, mapMinY, 0);

        RecalculateCamera();
        lastAspect = cam.aspect;
    }

    void Update()
    {
        // Detect window resizing
        if (!Mathf.Approximately(lastAspect, cam.aspect))
        {
            RecalculateCamera();
            lastAspect = cam.aspect;
        }
    }

    void RecalculateCamera()
    {
        height = cam.orthographicSize * 2f;

        // Width changes with the actual window
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
}