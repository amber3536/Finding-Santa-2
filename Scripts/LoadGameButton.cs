using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    public GameObject startMenu;
    static bool gameStarted = false;
    public ElfMovement elf;

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
        //SaveManager.Instance.gameStarted = true;
        //PlayerPrefs.SetInt("gameStarted", 1);
        SaveManager.Instance.LoadGame();
    }
}
