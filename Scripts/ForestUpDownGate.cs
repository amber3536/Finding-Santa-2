using UnityEngine;

public class ForestUpDownGate : MonoBehaviour
{
    public Camera myCamera;

    void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        Vector2 exitVelocity = rb.linearVelocity;

        float height = myCamera.orthographicSize * 2;
        float width = height * myCamera.aspect;

        Vector3 stepUp = new Vector3(0, height, 0);

        if (exitVelocity.y > 0)
        {
            myCamera.transform.position += stepUp;
        }    
        else if (exitVelocity.y < 0)
        {
            myCamera.transform.position -= stepUp;
        }
    }
   
}
