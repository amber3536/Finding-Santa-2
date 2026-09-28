using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer topLeft;
    public SpriteRenderer topRight;
    public SpriteRenderer bottomLeft;
    public SpriteRenderer bottomRight;

    public Camera targetCamera;

    void Start()
    {
        SetupGrid();
    }

    void SetupGrid()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        // Camera viewport size in world units
        float tileHeight = targetCamera.orthographicSize * 2f;
        float tileWidth = tileHeight * targetCamera.aspect;

        // Scale each background to EXACTLY the camera viewport
        FitToSize(topLeft, tileWidth, tileHeight);
        FitToSize(topRight, tileWidth, tileHeight);
        FitToSize(bottomLeft, tileWidth, tileHeight);
        FitToSize(bottomRight, tileWidth, tileHeight);

        // Use top-left as the anchor
        Vector3 anchor = topLeft.transform.position;

        // 2x2 grid
        topRight.transform.position = new Vector3(
            anchor.x + tileWidth,
            anchor.y,
            topRight.transform.position.z
        );

        bottomLeft.transform.position = new Vector3(
            anchor.x,
            anchor.y - tileHeight,
            bottomLeft.transform.position.z
        );

        bottomRight.transform.position = new Vector3(
            anchor.x + tileWidth,
            anchor.y - tileHeight,
            bottomRight.transform.position.z
        );
    }

    void FitToSize(
        SpriteRenderer sprite,
        float targetWidth,
        float targetHeight)
    {
        if (sprite == null || sprite.sprite == null)
            return;

        float spriteWidth = sprite.sprite.bounds.size.x;
        float spriteHeight = sprite.sprite.bounds.size.y;

        // IMPORTANT:
        // Use uniform scaling so the image isn't distorted.
        float scaleX = targetWidth / spriteWidth;
        float scaleY = targetHeight / spriteHeight;

        // If aspect ratios already match, these will be almost identical.
        // Use scaleX because we want the tile width to be exact.
        float scale = scaleX;

        sprite.transform.localScale = new Vector3(
            scale,
            scale,
            1f
        );
    }
}