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

    // 2x2 grid — each tile is exactly 16x9 Unity units
    private const float TILE_W = 16f;
    private const float TILE_H = 9f;

    // Pre-calculated exact snap positions for each grid cell
    // No runtime math = no floating point drift
    private readonly Vector2[,] snapPositions = new Vector2[2, 2]
    {
        { new Vector2(8f,  4.5f),  new Vector2(8f,  13.5f) },  // Left column
        { new Vector2(24f, 4.5f),  new Vector2(24f, 13.5f) }   // Right column
    };

    // Center of bottom-left tile — used for grid boundary detection
    private const float ORIGIN_X = 8f;
    private const float ORIGIN_Y = 4.5f;

    private Vector3 lockedPosition;
    public CameraModeIsland mode = CameraModeIsland.GridFollow;

    void Start()
    {
        cam.orthographicSize = 4.5f;
        cam.aspect = 16f / 9f;
        cam.rect = new Rect(0f, 0f, 1f, 1f);
    }

    void Update()
    {
        // Re-enforce every frame to prevent WebGL drift
        cam.orthographicSize = 4.5f;
        cam.aspect = 16f / 9f;
    }

    void LateUpdate()
    {
        if (mode == CameraModeIsland.GridFollow)
        {
            // Determine which tile the player is in
            int gridX = (player.position.x < ORIGIN_X + TILE_W / 2f) ? 0 : 1;
            int gridY = (player.position.y < ORIGIN_Y + TILE_H / 2f) ? 0 : 1;

            // Clamp to 2x2 grid
            gridX = Mathf.Clamp(gridX, 0, 1);
            gridY = Mathf.Clamp(gridY, 0, 1);

            // Snap to exact pre-calculated position
            Vector2 snap = snapPositions[gridX, gridY];

            transform.position = new Vector3(
                snap.x,
                snap.y,
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
}
