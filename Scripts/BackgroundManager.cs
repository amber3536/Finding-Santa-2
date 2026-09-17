using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer topLeft;
    public SpriteRenderer topRight;
    public SpriteRenderer bottomLeft;
    public SpriteRenderer bottomRight;

    public float targetHeight = 10f;

    void Start()
    {
        ArrangeGrid();
    }

    void ArrangeGrid()
    {
        // Scale all four images to the same height
        ScaleToHeight(topLeft);
        ScaleToHeight(topRight);
        ScaleToHeight(bottomLeft);
        ScaleToHeight(bottomRight);

        // -----------------------------------------
        // TOP RIGHT
        // Move it so its LEFT edge touches
        // the RIGHT edge of TOP LEFT.
        // -----------------------------------------

        float horizontalGap =
            topLeft.bounds.max.x - topRight.bounds.min.x;

        topRight.transform.position +=
            new Vector3(horizontalGap, 0f, 0f);


        // -----------------------------------------
        // BOTTOM LEFT
        // Move it so its TOP edge touches
        // the BOTTOM edge of TOP LEFT.
        // -----------------------------------------

        float verticalGap =
            topLeft.bounds.min.y - bottomLeft.bounds.max.y;

        bottomLeft.transform.position +=
            new Vector3(0f, verticalGap, 0f);


        // -----------------------------------------
        // BOTTOM RIGHT
        // First align it horizontally with
        // BOTTOM LEFT.
        // -----------------------------------------

        float bottomRightHorizontalGap =
            bottomLeft.bounds.max.x - bottomRight.bounds.min.x;

        bottomRight.transform.position +=
            new Vector3(bottomRightHorizontalGap, 0f, 0f);


        // -----------------------------------------
        // Then align BOTTOM RIGHT vertically
        // with TOP RIGHT.
        // -----------------------------------------

        float bottomRightVerticalGap =
            topRight.bounds.min.y - bottomRight.bounds.max.y;

        bottomRight.transform.position +=
            new Vector3(0f, bottomRightVerticalGap, 0f);
    }

    void ScaleToHeight(SpriteRenderer sprite)
    {
        if (sprite == null || sprite.sprite == null)
            return;

        float spriteHeight = sprite.sprite.bounds.size.y;

        float scale = targetHeight / spriteHeight;

        sprite.transform.localScale = new Vector3(
            scale,
            scale,
            1f
        );
    }
}