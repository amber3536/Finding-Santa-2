using UnityEngine;
using UnityEngine.InputSystem;

public class PickBerries : MonoBehaviour
{
    public GameObject berry_bush;
    public SpriteRenderer sr;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            berry_bush.SetActive(false);
            int num = PlayerPrefs.GetInt("berries") + 1;
            PlayerPrefs.SetInt("berries", num);
            Debug.Log("berries " + num);
            sr.sortingOrder = 2;
        }
    }
}
