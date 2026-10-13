using UnityEngine;

public class WebGLResolutionFix : MonoBehaviour
{
    private const float TARGET_ASPECT = 16f / 9f;

    void Start()
    {
        #if UNITY_WEBGL
            FixResolution();
        #endif
    }

    void Update()
    {
        #if UNITY_WEBGL
            // Check if aspect ratio has drifted
            float currentAspect = (float)Screen.width / Screen.height;
            if (Mathf.Abs(currentAspect - TARGET_ASPECT) > 0.01f)
            {
                FixResolution();
            }
        #endif
    }

    private void FixResolution()
    {
        // Keep the current height, calculate correct 16:9 width
        int height = Screen.height;
        int width = Mathf.RoundToInt(height * TARGET_ASPECT);

        Debug.Log($"Fixing resolution to {width}x{height}");
        Screen.SetResolution(width, height, false);
    }
}

