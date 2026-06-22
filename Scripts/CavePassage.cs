using UnityEngine;
using UnityEngine.SceneManagement;

public class CavePassage : MonoBehaviour
{

    public ElfMovement elfMovement;
    void OnTriggerEnter2D(Collider2D other)
    {
        // if (elfMovement.holdingRock)
        // {
        //     PlayerPrefs.SetInt("rock", 1);
        // }
        SceneManager.LoadScene("Cave World");
    }
}
