using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject startMenu;
    public SquirrelMovement squirrel;
    static bool gameStarted = false;

    void Start()
    {
        if (gameStarted)
        {
            startMenu.SetActive(false);
        }
    }
    public void OnButtonClick()
    {
        //Debug.Log("Button was clicked via the Inspector method!");
        startMenu.SetActive(false);
        gameStarted = true;
        //SaveManager.Instance.gameBegun = true;
        //SaveManager.Instance.SaveGame();
        //PlayerPrefs.SetInt("gameStarted", 1);
        //SaveManager.Instance.gameStarted = true;
        //SaveManager.Instance.SaveGame();
        squirrel.beginSquirrel();
    }

}
