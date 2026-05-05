using UnityEngine;
using System.Collections;

public class SealLooking : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject seal;
    private bool finished = false;
    public string triggerName = "PlayAnim";
    public float interval = 5f;      // total cycle time
    public float animationTime = 1.3f; // how long animation plays
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //seal.SetActive(false);
        StartCoroutine(SealPeeking());
    }

    IEnumerator SealPeeking()
    {   
        while (!finished)
        {   
            spriteRenderer.enabled = true;
            animator.SetTrigger(triggerName);

            yield return new WaitForSeconds(animationTime);

            // Hide sprite
            spriteRenderer.enabled = false;
            float valX = Random.Range(13f, 17f); 

            // float pathLocation = PlayerPrefs.GetFloat("pathLocation");
            
            // while (val < pathLocation + 2 && val > pathLocation - 2)
            //     val = Random.Range(-5f, 55f);

            float valY = Random.Range(30f, 33f);
            seal.transform.position = new Vector3(valX, valY, 0f);

            yield return new WaitForSeconds(interval - animationTime);
        }
    }

    
}
