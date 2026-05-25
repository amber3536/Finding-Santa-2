using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCaveToForest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Forest Intro");
    }
}
