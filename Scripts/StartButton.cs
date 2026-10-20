using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject startMenu;
    public SquirrelMovement squirrel;
    static bool gameStarted = false;
    public CameraMovementCave cameraMovementCave;

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

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Cave World")
        {
            cameraMovementCave.updateOnLoad();
        }
        //SaveManager.Instance.gameBegun = true;
        //SaveManager.Instance.SaveGame();
        //PlayerPrefs.SetInt("gameStarted", 1);
        //SaveManager.Instance.gameStarted = true;
        //SaveManager.Instance.SaveGame();
        if (squirrel != null)
            squirrel.beginSquirrel();
    }

}
