using UnityEngine;

public class ForestRightLeftGate : MonoBehaviour
{
    public Camera myCamera;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Elf")
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 exitVelocity = rb.linearVelocity;
            
            float height = myCamera.orthographicSize * 2;
            float width = height * myCamera.aspect;

            Vector3 stepRight = new Vector3(width, 0, 0);
            Vector3 stepUp = new Vector3(0, height, 0);
                

            if (exitVelocity.x > 0)
            {
                myCamera.transform.position += stepRight;
            }    
            else if (exitVelocity.x < 0)
            {
                myCamera.transform.position -= stepRight;
            }  
        }

    }
}
