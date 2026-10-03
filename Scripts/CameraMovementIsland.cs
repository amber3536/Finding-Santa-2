using UnityEngine;

public enum CameraModeIsland
{
    GridFollow,
    Free,
    LockedPosition
}

public class CameraMovementIsland : MonoBehaviour
{
    public Transform player;
    public Camera cam;

    [Header("Fixed 2x2 Camera Grid")]
    public float bottomLeftX = 8.8889f;   // Center X of the bottom-left tile
    public float bottomLeftY = 5.0f;      // Center Y of the bottom-left tile

    public float cameraStepX = 17.7778f;  // Exact tile width in Unity units
    public float cameraStepY = 10.0f;     // Exact tile height in Unity units

    private Vector3 lockedPosition;

    public CameraModeIsland mode = CameraModeIsland.GridFollow;

    private int lastScreenWidth;
    private int lastScreenHeight;

    void Start()
    {
        SetFixedAspectRatio();

        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;
    }

    void Update()
    {
        if (Screen.width != lastScreenWidth ||
            Screen.height != lastScreenHeight)
        {
            SetFixedAspectRatio();

            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
        }
    }

    void LateUpdate()
    {
        if (mode == CameraModeIsland.GridFollow)
        {
            // Determine which of the four background tiles
            // the player is currently in.

            float leftEdge = bottomLeftX - cameraStepX / 2f;
            float bottomEdge = bottomLeftY - cameraStepY / 2f;

            int gridX = Mathf.FloorToInt(
                (player.position.x - leftEdge) / cameraStepX
            );

            int gridY = Mathf.FloorToInt(
                (player.position.y - bottomEdge) / cameraStepY
            );

            // Clamp to the 2x2 grid
            gridX = Mathf.Clamp(gridX, 0, 1);
            gridY = Mathf.Clamp(gridY, 0, 1);

            // Calculate the exact camera center.
            float cameraX = bottomLeftX + gridX * cameraStepX;
            float cameraY = bottomLeftY + gridY * cameraStepY;

            transform.position = new Vector3(
                cameraX,
                cameraY,
                transform.position.z
            );
        }
        else if (mode == CameraModeIsland.LockedPosition)
        {
            transform.position = lockedPosition;
        }
    }

    public void LockToPosition(Vector3 pos)
    {
        lockedPosition = pos;
        mode = CameraModeIsland.LockedPosition;
    }

    public void ResumeFollow()
    {
        mode = CameraModeIsland.GridFollow;
    }

    private void SetFixedAspectRatio()
    {
        float targetAspect = 16f / 9f;

        // Force the camera's projection to remain 16:9.
        cam.aspect = targetAspect;

        // Use the entire Unity canvas.
        cam.rect = new Rect(0f, 0f, 1f, 1f);
    }
}