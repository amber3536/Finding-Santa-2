using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject startMenu;
    public SquirrelMovement squirrel;

    void Start()
    {
       // Debug.Log(SaveManagr.Instance.gameStarted);
        if (PlayerPrefs.GetInt("gameStarted") == 1)
        {
            startMenu.SetActive(false);
        }
    }
    public void OnButtonClick()
    {
        //Debug.Log("Button was clicked via the Inspector method!");
        startMenu.SetActive(false);
        PlayerPrefs.SetInt("gameStarted", 1);
        //SaveManager.Instance.gameStarted = true;
        //SaveManager.Instance.SaveGame();
        squirrel.beginSquirrel();
    }

}
