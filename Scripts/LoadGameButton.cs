using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    public GameObject startMenu;
    public void OnButtonClick()
    {
        //Debug.Log("Button was clicked via the Inspector method!");
        startMenu.SetActive(false);
        //SaveManager.Instance.gameStarted = true;
        PlayerPrefs.SetInt("gameStarted", 1);
        SaveManager.Instance.LoadGame();
    }
}
