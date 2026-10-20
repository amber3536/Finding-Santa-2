using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    public GameObject startMenu;
    static bool gameStarted = false;
    public ElfMovement elf;
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
        elf.justLoaded = true;

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Cave World")
        {
            cameraMovementCave.updateOnLoad();
        }
        SaveManager.Instance.LoadGame();
    }
}
