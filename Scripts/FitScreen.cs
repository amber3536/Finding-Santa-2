using UnityEngine;
using UnityEngine.UI;


//[RequireComponent(typeof(RectTransform))]
public class FitScreen : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    //private Camera cam;

    public float targetHeight = 10f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        FitHeight();
    }

    void FitHeight()
    {
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;

        float scale = targetHeight / spriteHeight;

        transform.localScale = new Vector3(scale, scale, 1f);
    }
    //void Start()
    //{
        
        // spriteRenderer = GetComponent<SpriteRenderer>();
        // cam = Camera.main;

        // FitToScreen();
    //}

    void FitToScreen()
    {

        // // Size of the sprite in world units
        // float imageWidth = spriteRenderer.sprite.bounds.size.x;
        // float imageHeight = spriteRenderer.sprite.bounds.size.y;

        // // Size of the camera view in world units
        // float screenHeight = cam.orthographicSize * 2f;
        // float screenWidth = screenHeight * cam.aspect;

        // // Scale enough to completely cover the screen
        // float scaleX = screenWidth / imageWidth;
        // float scaleY = screenHeight / imageHeight;

        // float scale = Mathf.Max(scaleX, scaleY);

        // transform.localScale = new Vector3(scale, scale, 1f);
    }
//     private float imageWidth = 400f;
//     private float imageHeight = 200f;
//     void Start()
//     {
//         float imageAspect = imageWidth / imageHeight;
//         float screenAspect = (float)Screen.width / Screen.height;

//         if (screenAspect > imageAspect)
//         {
//             // Screen is wider — fit to width
//             transform.localScale = Vector3.one * Screen.width / imageWidth;
//         }
//         else
//         {
//             // Screen is taller/narrower — fit to height
//             transform.localScale = Vector3.one * Screen.height / imageHeight;
//         }

//     }
 }


