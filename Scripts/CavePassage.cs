using UnityEngine;
using UnityEngine.SceneManagement;

public class CavePassage : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Cave World");
    }
}
