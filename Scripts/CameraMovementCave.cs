using UnityEngine;

public enum CameraModeCave
{
    GridFollow,     // your normal map behavior
    Free,           // free movement / cutscene
    LockedPosition  // fixed location (like inside cabin)
}
public class CameraMovementCave : MonoBehaviour
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
    public float mapMinY = -5;
    public float mapMaxY = 50; 
    private Vector3 origin; 
    public CameraModeCave mode = CameraModeCave.LockedPosition;
    private Vector3 lockedPosition;
 

    void Start()
    {

        origin = new Vector3(mapMinX, mapMinY, 0);

        height = cam.orthographicSize * 2f;
        width = height * cam.aspect;

        minX = Mathf.FloorToInt((mapMinX + width / 2f - origin.x) / width);
        maxX = Mathf.FloorToInt((mapMaxX - width / 2f - origin.x) / width);

        minY = Mathf.FloorToInt((mapMinY + height / 2f - origin.y) / height);
        maxY = Mathf.FloorToInt((mapMaxY - height / 2f - origin.y) / height);

        LockToPosition(new Vector3(-20, 0, -10));
    }

    void LateUpdate()
    {
        int gridX = Mathf.FloorToInt((player.position.x - origin.x) / width);
        int gridY = Mathf.FloorToInt((player.position.y - origin.y) / height);

        gridX = Mathf.Clamp(gridX, minX, maxX);
        gridY = Mathf.Clamp(gridY, minY, maxY);

        Vector3 targetPosition = new Vector3(
            origin.x + gridX * width + width / 2f,
            origin.y + gridY * height + height / 2f,
            transform.position.z
            );

        if (mode == CameraModeCave.GridFollow)
        {
            transform.position = targetPosition;
        }
        else if (mode == CameraModeCave.LockedPosition)
        {
            transform.position = lockedPosition;
        }
        //if (!snowyHill.relocate && !goInsideCabin.relocate)
        //transform.position = targetPosition;
    }

    public void LockToPosition(Vector3 pos)
    {
        lockedPosition = pos;
        mode = CameraModeCave.LockedPosition;
    }

    public void ResumeFollow()
    {
        mode = CameraModeCave.GridFollow;
    }
}
